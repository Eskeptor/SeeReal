using SeeReal.Struct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Const = SeeReal.GlobalConstants;

namespace SeeReal.Util
{
    public class XmlMgr
    {
        public static string XML_FILE = "SerialList.xml"; // XML 파일명
        public static string XML_ROOT = "Serials";          // XML 파일의 최상단 루트
        public static string XML_SUB = "Serial";            // XML 파일의 서브 키
        public static string XML_SUB_TITLE = "Name";
        public static string XML_SUB_TILE = "TileNo";
        public static string XML_SUB_COM = "COM";           
        public static string XML_SUB_BAUD = "Baudrate";     
        public static string XML_SUB_DATABIT = "DataBit";
        public static string XML_SUB_PARITY = "Parity";
        public static string XML_SUB_STOPBIT = "StopBit";
        public static string XML_SUB_FLOW = "FlowControl";
        public static string XML_SUB_MACROENABLE = "MacroEnable";
        public static string XML_SUB_DELAY = "Delay";
        public static string XML_SUB_TILECOLOR = "TileColor";
        public static string XML_SUB_LOG_SAVE = "LogSave";
        public static string XML_SUB_LOG_SAVE_TYPE = "LogSaveType";
        public static string XML_SUB_LOG_SAVE_TOKEN = "LogSaveToken";
        public static string XML_SUB_LOG_SAVE_PATH = "LogSavePath";
        public static string XML_SUB_SUB = "MacroList";
        public static string XML_SUB_SUB_MACRO_NO = "Macro";
        public static string XML_SUB_SUB_MACRO_NAME = "MacroName";
        public static string XML_SUB_SUB_MACRO = "Macro";
        public static string XML_SUB_SUB_MACRO_ENABLE = "Enable";

        /// <summary>
        /// LoadAccount의 결과값으로 사용할 enum
        /// </summary>
        public enum LoadResult
        {
            Success,            // 성공
            NoData,             // 로드할 데이터 없음
            Fail_FileLoad       // 파일 로드 실패
        }


        /// <summary>
        /// 계정을 불러오는 메소드
        /// (각 배열의 짝수구간에는 ID, 홀수구간에는 PW가 들어있음)
        /// </summary>
        /// <param name="listSerial">불러온 계정을 저장할 리스트(ref)</param>
        /// <returns>로드 결과</returns>
        public static LoadResult LoadSerialData(ref ArrayList mTileList)
        {
            LoadResult eResult = LoadResult.NoData;
            string strPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Const.PATH_SERIAL_FOLDER + Path.DirectorySeparatorChar + XML_FILE;

            if (mTileList.Count > 0)
                mTileList.Clear();

            try
            {
                string strNodes = string.Format(@"/{0}/{1}", XML_ROOT, XML_SUB);
                string strParity = string.Empty;
                string strStopBit = string.Empty;
                string strFlowControl = string.Empty;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strPath);
                XmlNodeList nodeList = xDoc.SelectNodes(strNodes);

                foreach (XmlNode xmlNode in nodeList)
                {
                    int nTileNo = int.Parse(xmlNode.SelectSingleNode(XML_SUB_TILE).InnerText);
                    TileStruct tileStruct = new TileStruct(nTileNo, xmlNode.Attributes[XML_SUB_TITLE].Value);
                    tileStruct.SerialData.SerialName = xmlNode.Attributes[XML_SUB_TITLE].Value;
                    tileStruct.SerialData.PortNum = int.Parse(xmlNode.SelectSingleNode(XML_SUB_COM).InnerText);
                    tileStruct.SerialData.BaudRate = int.Parse(xmlNode.SelectSingleNode(XML_SUB_BAUD).InnerText);
                    tileStruct.SerialData.DataBit = int.Parse(xmlNode.SelectSingleNode(XML_SUB_DATABIT).InnerText);
                    tileStruct.SerialData.ParityCode = (Parity)int.Parse(xmlNode.SelectSingleNode(XML_SUB_PARITY).InnerText);
                    tileStruct.SerialData.StopBitCode = (StopBits)int.Parse(xmlNode.SelectSingleNode(XML_SUB_STOPBIT).InnerText);
                    tileStruct.SerialData.FlowControl = (SerialStruct.FlowC)int.Parse(xmlNode.SelectSingleNode(XML_SUB_FLOW).InnerText);
                    tileStruct.SerialData.MacroEnable = int.Parse(xmlNode.SelectSingleNode(XML_SUB_MACROENABLE).InnerText) == 1;
                    tileStruct.SerialData.RunDelay = int.Parse(xmlNode.SelectSingleNode(XML_SUB_DELAY).InnerText);
                    tileStruct.TileColor = (Const.StyleType)int.Parse(xmlNode.SelectSingleNode(XML_SUB_TILECOLOR).InnerText);
                    tileStruct.SerialName = tileStruct.SerialData.SerialName;
                    tileStruct.Text = tileStruct.SerialData.SerialName;
                    tileStruct.SerialData.LogSave = int.Parse(xmlNode.SelectSingleNode(XML_SUB_LOG_SAVE).InnerText) == 1;
                    tileStruct.SerialData.LogSaveType = (Const.LogSaveType)int.Parse(xmlNode.SelectSingleNode(XML_SUB_LOG_SAVE_TYPE).InnerText);
                    tileStruct.SerialData.LogToken = (Const.LogToken)int.Parse(xmlNode.SelectSingleNode(XML_SUB_LOG_SAVE_TOKEN).InnerText);
                    tileStruct.SerialData.LogSavePath = xmlNode.SelectSingleNode(XML_SUB_LOG_SAVE_PATH).InnerText;

                    XmlNodeList nodeMacroList = xmlNode.SelectSingleNode(XML_SUB_SUB).ChildNodes;
                    foreach (XmlNode xmlMacro in nodeMacroList)
                    {
                        MacroStruct macroStruct = new MacroStruct();
                        macroStruct.MacroName = xmlMacro.SelectSingleNode(XML_SUB_SUB_MACRO_NAME).InnerText;
                        macroStruct.Macro = xmlMacro.SelectSingleNode(XML_SUB_SUB_MACRO).InnerText;
                        macroStruct.Enable = int.Parse(xmlMacro.SelectSingleNode(XML_SUB_SUB_MACRO_ENABLE).InnerText) == 1 ? true : false;
                        tileStruct.SerialData.MacroList.Add(macroStruct);
                    }

                    mTileList.Add(tileStruct);
                }

                if (mTileList.Count > 0)
                    eResult = LoadResult.Success;
                else
                    eResult = LoadResult.NoData;
            }
            catch
            {
                eResult = LoadResult.Fail_FileLoad;
            }

            return eResult;
        }

        /// <summary>
        /// 계정 정보를 저장하는 메소드
        /// (각 배열의 짝수구간에는 ID, 홀수구간에는 PW가 들어있음)
        /// </summary>
        /// <param name="listSerial"></param>
        /// <returns></returns>
        public static bool SaveSerialData(ArrayList mTileList)
        {
            bool bResult = false;
            string strPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Const.PATH_SERIAL_FOLDER + Path.DirectorySeparatorChar + XML_FILE;

            try
            {
                XmlDocument xDoc = new XmlDocument();

                // 루트 노드
                XmlNode rootNode = xDoc.CreateElement(XML_ROOT);            // Serials
                xDoc.AppendChild(rootNode);

                int nSize = mTileList.Count;
                TileStruct tileStruct = null;

                // 하위 노드
                for (int i = 0; i < nSize; i++)
                {
                    tileStruct = mTileList[i] as TileStruct;

                    if (tileStruct != null)
                    {
                        XmlNode xmlSubNode = xDoc.CreateElement(XML_SUB);                   // Serial

                        XmlAttribute xmlAttribute = xDoc.CreateAttribute(XML_SUB_TITLE);    // Name
                        xmlAttribute.Value = tileStruct.SerialData.SerialName;
                        xmlSubNode.Attributes.Append(xmlAttribute);

                        XmlNode nodeTile = xDoc.CreateElement(XML_SUB_TILE);                // TileNo
                        nodeTile.InnerText = tileStruct.TileNo.ToString();
                        xmlSubNode.AppendChild(nodeTile);

                        XmlNode nodePort = xDoc.CreateElement(XML_SUB_COM);                 // COM
                        nodePort.InnerText = tileStruct.SerialData.PortNum.ToString();
                        xmlSubNode.AppendChild(nodePort);

                        XmlNode nodeBaud = xDoc.CreateElement(XML_SUB_BAUD);                // Baudrate
                        nodeBaud.InnerText = tileStruct.SerialData.BaudRate.ToString();
                        xmlSubNode.AppendChild(nodeBaud);

                        XmlNode nodeDataBit = xDoc.CreateElement(XML_SUB_DATABIT);          // DataBit
                        nodeDataBit.InnerText = tileStruct.SerialData.DataBit.ToString();
                        xmlSubNode.AppendChild(nodeDataBit);

                        XmlNode nodeParity = xDoc.CreateElement(XML_SUB_PARITY);            // Parity
                        nodeParity.InnerText = string.Format("{0}", (int)tileStruct.SerialData.ParityCode);
                        xmlSubNode.AppendChild(nodeParity);

                        XmlNode nodeStopBit = xDoc.CreateElement(XML_SUB_STOPBIT);          // StopBit
                        nodeStopBit.InnerText = string.Format("{0}", (int)tileStruct.SerialData.StopBitCode);
                        xmlSubNode.AppendChild(nodeStopBit);

                        XmlNode nodeFlow = xDoc.CreateElement(XML_SUB_FLOW);                // FlowControl
                        nodeFlow.InnerText = string.Format("{0}", (int)tileStruct.SerialData.FlowControl);
                        xmlSubNode.AppendChild(nodeFlow);

                        XmlNode nodeMacroEnable = xDoc.CreateElement(XML_SUB_MACROENABLE);  // MacroEnable
                        nodeMacroEnable.InnerText = string.Format("{0}", tileStruct.SerialData.MacroEnable ? 1 : 0);
                        xmlSubNode.AppendChild(nodeMacroEnable);

                        XmlNode nodeDelay = xDoc.CreateElement(XML_SUB_DELAY);              // Delay
                        nodeDelay.InnerText = string.Format("{0}", tileStruct.SerialData.RunDelay);
                        xmlSubNode.AppendChild(nodeDelay);

                        XmlNode nodeTileColor = xDoc.CreateElement(XML_SUB_TILECOLOR);      // Tile Color
                        nodeTileColor.InnerText = string.Format("{0}", (int)tileStruct.TileColor);
                        xmlSubNode.AppendChild(nodeTileColor);

                        XmlNode nodeLogSave = xDoc.CreateElement(XML_SUB_LOG_SAVE);         // Log Save
                        nodeLogSave.InnerText = string.Format("{0}", tileStruct.SerialData.LogSave ? 1 : 0);
                        xmlSubNode.AppendChild(nodeLogSave);

                        XmlNode nodeLogSaveType = xDoc.CreateElement(XML_SUB_LOG_SAVE_TYPE);// Log Save Type
                        nodeLogSaveType.InnerText = string.Format("{0}", (int)tileStruct.SerialData.LogSaveType);
                        xmlSubNode.AppendChild(nodeLogSaveType);

                        XmlNode nodeLogToken = xDoc.CreateElement(XML_SUB_LOG_SAVE_TOKEN);  // Log Save Token
                        nodeLogToken.InnerText = string.Format("{0}", (int)tileStruct.SerialData.LogToken);
                        xmlSubNode.AppendChild(nodeLogToken);

                        XmlNode nodeLogSavePath = xDoc.CreateElement(XML_SUB_LOG_SAVE_PATH);// Log Save Path
                        nodeLogSavePath.InnerText = string.Format("{0}", tileStruct.SerialData.LogSavePath);
                        xmlSubNode.AppendChild(nodeLogSavePath);

                        XmlNode nodeMacroList = xDoc.CreateElement(XML_SUB_SUB);            // MacroList
                        int nCount = 0;
                        string strNodeNo = string.Empty;
                        foreach (MacroStruct macro in tileStruct.SerialData.MacroList)
                        {
                            strNodeNo = string.Format("{0}{1}", XML_SUB_SUB_MACRO_NO, nCount++);
                            XmlNode nodeNo = xDoc.CreateElement(strNodeNo);

                            XmlNode nodeName = xDoc.CreateElement(XML_SUB_SUB_MACRO_NAME);
                            nodeName.InnerText = macro.MacroName;
                            nodeNo.AppendChild(nodeName);

                            XmlNode nodeMacro = xDoc.CreateElement(XML_SUB_SUB_MACRO);
                            nodeMacro.InnerText = macro.Macro;
                            nodeNo.AppendChild(nodeMacro);

                            XmlNode nodeEnable = xDoc.CreateElement(XML_SUB_SUB_MACRO_ENABLE);
                            nodeEnable.InnerText = string.Format("{0}", macro.Enable ? 1 : 0);
                            nodeNo.AppendChild(nodeEnable);

                            nodeMacroList.AppendChild(nodeNo);
                        }
                        xmlSubNode.AppendChild(nodeMacroList);

                        rootNode.AppendChild(xmlSubNode);
                    }
                }

                xDoc.Save(strPath);
                bResult = true;
            }
            catch
            {
                bResult = false;
            }

            return bResult;
        }
    }
}
