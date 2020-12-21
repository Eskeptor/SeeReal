using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Const = SeeReal.GlobalConstants;
using SeeReal.Util;
using System.Threading;
using SeeReal.Language;
using System.IO;

namespace SeeReal.Struct
{
    public class SerialStruct : IDisposable
    {
        /// <summary>
        /// 데이터 비트
        /// </summary>
        public enum DataB
        {
            IdxData5 = 0,
            IdxData6,
            IdxData7,
            IdxData8,

            Data5 = 5,
            Data6,
            Data7,
            Data8
        }

        /// <summary>
        /// 흐름 제어
        /// </summary>
        public enum FlowC
        {
            None = 0,
            xONxOFF,
            RTSCTS,
        }

        /// <summary>
        /// 보드레이트
        /// </summary>
        public enum BaudR
        {
            Idx2400 = 0,
            Idx4800,
            Idx9600,
            Idx14400,
            Idx19200,
            Idx38400,
            Idx57600,
            Idx115200,
            Idx230400,
            Idx460800,
            Idx921600,
            BaudRateIdxMax,

            BR2400 = 2400,
            BR4800 = 4800,
            BR9600 = 9600,
            BR14400 = 14400,
            BR19200 = 19200,
            BR38400 = 38400,
            BR57600 = 57600,
            BR115200 = 115200,
            BR230400 = 230400,
            BR460800 = 460800,
            BR921600 = 921600
        }

        /// <summary>
        /// 시리얼명
        /// </summary>
        public string SerialName { get; set; }

        /// <summary>
        /// 포트
        /// </summary>
        public int PortNum { get; set; }

        /// <summary>
        /// 보드 레이트
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 데이터 비트
        /// </summary>
        public int DataBit { get; set; }

        /// <summary>
        /// 패리티 코드
        /// </summary>
        public Parity ParityCode { get; set; }

        /// <summary>
        /// 정지 비트
        /// </summary>
        public StopBits StopBitCode { get; set; }

        /// <summary>
        /// 흐름 제어
        /// </summary>
        public FlowC FlowControl { get; set; }

        /// <summary>
        /// 매크로 활성화
        /// </summary>
        public bool MacroEnable { get; set; }

        /// <summary>
        /// 반복 딜레이(ms)
        /// </summary>
        public int RunDelay { get; set; }

        /// <summary>
        /// 로그 저장
        /// </summary>
        public bool LogSave { get; set; }

        /// <summary>
        /// 로그 저장 타입
        /// </summary>
        public Const.LogSaveType LogSaveType { get; set; }

        /// <summary>
        /// 구분자
        /// </summary>
        public Const.LogToken LogToken { get; set; }

        /// <summary>
        /// 로그 저장 경로
        /// </summary>
        public string LogSavePath { get; set; }

        /// <summary>
        /// 로그를 기록하는 이벤트
        /// </summary>
        public event Const.WriteLogDelegate WriteLogEvent = null;

        /// <summary>
        /// 매크로 목록
        /// </summary>
        public ArrayList MacroList { get { return mMacroList; } }
        private ArrayList mMacroList = new ArrayList();

        /// <summary>
        /// Serial Port 객체
        /// </summary>
        private SerialPort mSerialPort = new SerialPort();
        /// <summary>
        /// 딜레이 시간마다 자동으로 데이터를 Send하는 스레드
        /// </summary>
        private Thread mThreadSend = null;
        /// <summary>
        /// 자동으로 포트를 오픈시키는 스레드
        /// </summary>
        private Thread mThreadOpen = null;
        /// <summary>
        /// 모든 스레드의 while문을 제어하는 필드
        /// </summary>
        private bool mThreadRun = true;
        /// <summary>
        /// Serial 통신으로 받아온 데이터를 저장하는 버퍼
        /// </summary>
        private ArrayList mDataBuffer = new ArrayList();

        public SerialStruct()
        {
            #region 데이터 초기화
            Clear();
            #endregion

            #region 자동 포트 오픈

            if (mThreadOpen == null)
            {
                mThreadOpen = new Thread(new ThreadStart(AutoPortOpen));
                if (mThreadOpen != null)
                {
                    mThreadOpen.Start();
                }
            }

            #endregion

            #region 딜레이 Send 스레드 초기화

            if (mThreadSend == null)
            {
                mThreadSend = new Thread(new ThreadStart(DelaySend));
                if (mThreadSend != null)
                {
                    mThreadSend.Start();
                }
            }

            #endregion

        }


        public void Clear()
        {
            SerialName = string.Empty;
            PortNum = -1;
            BaudRate = (int)BaudR.BR9600;
            DataBit = (int)DataB.Data8;
            ParityCode = Parity.None;
            StopBitCode = StopBits.One;
            FlowControl = FlowC.None;
            mMacroList.Clear();
        }

        /// <summary>
        /// 얕은 복사
        /// </summary>
        /// <returns></returns>
        public SerialStruct Copy()
        {
            return (SerialStruct)MemberwiseClone();
        }

        /// <summary>
        /// 시리얼 포트 열기
        /// </summary>
        /// <returns>시리얼 포트가 열렸는지 유무</returns>
        public bool Open()
        {
            bool bOpened = false;

            if (MacroEnable)
            {
                if (!mSerialPort.IsOpen)
                {
                    try
                    {
                        mSerialPort.PortName = string.Format("COM{0}", PortNum);
                        mSerialPort.BaudRate = BaudRate;
                        mSerialPort.DataBits = DataBit;
                        mSerialPort.Parity = ParityCode;
                        mSerialPort.StopBits = StopBitCode;
                        mSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

                        mSerialPort.Open();
                        bOpened = mSerialPort.IsOpen;

                        LogMgr.WriteLog(LogMgr.LogType.COM, string.Format("{0}({1}) - {2}", SerialName, mSerialPort.PortName, mSerialPort.IsOpen ? "Open" : "Open Failed"));
                    }
                    catch (Exception ex)
                    {
                        LogMgr.WriteLog(LogMgr.LogType.COM, ex.Message);
                    }
                }
                else
                {
                    Close();
                    Open();
                }
                    
            }

            return bOpened;
        }

        /// <summary>
        /// 시리얼 포트 닫기
        /// </summary>
        /// <returns>시리얼 포트가 닫혔는지 유무</returns>
        public bool Close()
        {
            bool bIsClosed = false;

            if (mSerialPort.IsOpen)
            {
                mSerialPort.Close();
                bIsClosed = !mSerialPort.IsOpen;

                LogMgr.WriteLog(LogMgr.LogType.COM, string.Format("{0}({1}) - {2}", SerialName, mSerialPort.PortName, mSerialPort.IsOpen ? "Close" : "Close Failed"));
            }
            else
                bIsClosed = true;

            return bIsClosed;
        }

        /// <summary>
        /// Serial 데이터를 수신 받았을 때 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int nLength = mSerialPort.BytesToRead;
            byte[] buffer = new byte[nLength];
            StringBuilder stringBuilder = new StringBuilder();

            mSerialPort.Read(buffer, 0, nLength);

            foreach (byte bData in buffer)
            {
                mDataBuffer.Add(bData);
            }

            int nSize = mDataBuffer.Count;
            if (nSize > 2)
            {
                if ((byte)mDataBuffer[nSize - 2] == '\r' &&
                    (byte)mDataBuffer[nSize - 1] == '\n')
                {
                    stringBuilder.AppendFormat("{0}{1}: ", Languages.Log_Receive, "\t");
                    foreach(byte bData in mDataBuffer)
                    {
                        if (bData == '\r' ||
                            bData == '\n')
                            break;
                        stringBuilder.Append(Convert.ToChar(bData));
                    }
                    stringBuilder.AppendLine();

                    mDataBuffer.Clear();
                }
            }

            if (WriteLogEvent != null)
                WriteLogEvent(stringBuilder.ToString());

            if (LogSave)
            {
                DateTime dateNow = DateTime.Now;
                string strDateNow = string.Format("{0}_{1}{2:D2}{3:D2}{4}", SerialName, dateNow.Year, dateNow.Month, dateNow.Day, LogMgr.LOG_EXTENSION);
                string strLogPath = string.Empty;

                if (LogSavePath.LastIndexOf(@"\") != LogSavePath.Length - 1)
                    strLogPath = string.Format(@"{0}{1}{2}", LogSavePath, Path.DirectorySeparatorChar, strDateNow);
                else
                    strLogPath = string.Format(@"{0}{1}", LogSavePath, strDateNow);

                LogMgr.WriteLog(strLogPath, stringBuilder.ToString(), true);
            }
        }

        /// <summary>
        /// 딜레이 시간마다 자동으로 데이터를 Send하는 스레드에서 사용하는 메소드
        /// </summary>
        private void DelaySend()
        {
            while (mThreadRun)
            {
                if (RunDelay > 0 &&
                    mMacroList.Count > 0 &&
                    MacroEnable)
                {
                    //lock (Const.LOCK_OBJ)
                    {
                        foreach (MacroStruct macroStruct in mMacroList)
                        {
                            if (macroStruct.Enable)
                                SendData(macroStruct.Macro);
                            Thread.Sleep(RunDelay);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void AutoPortOpen()
        {
            while (mThreadRun)
            {
                if (mSerialPort.IsOpen == false)
                    Open();
                Thread.Sleep(1000);
            }
        }

        public void SendData(string strData)
        {
            if (string.IsNullOrEmpty(strData) == false)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (mSerialPort.IsOpen)
                {
                    try
                    {
                        mSerialPort.Write(strData);
                        stringBuilder.AppendFormat("{0}{1}: {2}", Languages.Log_Send, "\t", strData);
                        stringBuilder.AppendLine();
                    }
                    catch (Exception ex)
                    {
                        LogMgr.WriteLog(LogMgr.LogType.COM, ex.Message);
                    }
                }
                else
                {
                    stringBuilder.AppendFormat("{0}{1}: {2} - {3}", Languages.Log_Send, "\t", strData, Languages.Log_Fail);
                    stringBuilder.AppendLine();
                }

                if (WriteLogEvent != null)
                    WriteLogEvent(stringBuilder.ToString());

                if (LogSave)
                {
                    DateTime dateNow = DateTime.Now;
                    string strDateNow = string.Format("{0}_{1}{2:D2}{3:D2}{4}", SerialName, dateNow.Year, dateNow.Month, dateNow.Day, LogMgr.LOG_EXTENSION);
                    string strLogPath = string.Empty;

                    if (LogSavePath.LastIndexOf(@"\") != LogSavePath.Length - 1)
                        strLogPath = string.Format(@"{0}{1}{2}", LogSavePath, Path.DirectorySeparatorChar, strDateNow);
                    else
                        strLogPath = string.Format(@"{0}{1}", LogSavePath, strDateNow);

                    LogMgr.WriteLog(strLogPath, strData, true);
                }
            }
        }


        /// <summary>
        /// 인덱스 번호를 보드 레이트로 변환
        /// </summary>
        /// <param name="nIdx">인덱스</param>
        /// <returns>보드 레이트</returns>
        public static BaudR IndexToBaudRate(int nIdx)
        {
            BaudR eBaud = BaudR.BR9600;

            switch (nIdx)
            {
                case (int)BaudR.Idx2400:
                    eBaud = BaudR.BR2400;
                    break;
                case (int)BaudR.Idx4800:
                    eBaud = BaudR.BR4800;
                    break;
                case (int)BaudR.Idx9600:
                    eBaud = BaudR.BR9600;
                    break;
                case (int)BaudR.Idx14400:
                    eBaud = BaudR.BR14400;
                    break;
                case (int)BaudR.Idx19200:
                    eBaud = BaudR.BR19200;
                    break;
                case (int)BaudR.Idx38400:
                    eBaud = BaudR.BR38400;
                    break;
                case (int)BaudR.Idx57600:
                    eBaud = BaudR.BR57600;
                    break;
                case (int)BaudR.Idx115200:
                    eBaud = BaudR.BR115200;
                    break;
                case (int)BaudR.Idx230400:
                    eBaud = BaudR.BR230400;
                    break;
                case (int)BaudR.Idx460800:
                    eBaud = BaudR.BR460800;
                    break;
                case (int)BaudR.Idx921600:
                    eBaud = BaudR.BR921600;
                    break;
            }

            return eBaud;
        }
        public static BaudR IndexToBaudRate(BaudR eIdx)
        {
            return IndexToBaudRate((int)eIdx);
        }

        /// <summary>
        /// 보드 레이트를 인덱스 번호로 변환
        /// </summary>
        /// <param name="baudR">보드 레이트</param>
        /// <returns>인덱스 번호</returns>
        public static BaudR BaudRateToIndex(BaudR baudR)
        {
            BaudR eIdx = BaudR.Idx9600;

            switch (eIdx)
            {
                case BaudR.BR2400:
                    eIdx = BaudR.Idx2400;
                    break;
                case BaudR.BR4800:
                    eIdx = BaudR.Idx4800;
                    break;
                case BaudR.BR9600:
                    eIdx = BaudR.Idx9600;
                    break;
                case BaudR.BR14400:
                    eIdx = BaudR.Idx14400;
                    break;
                case BaudR.BR19200:
                    eIdx = BaudR.Idx19200;
                    break;
                case BaudR.BR38400:
                    eIdx = BaudR.Idx38400;
                    break;
                case BaudR.BR57600:
                    eIdx = BaudR.Idx57600;
                    break;
                case BaudR.BR115200:
                    eIdx = BaudR.Idx115200;
                    break;
                case BaudR.BR230400:
                    eIdx = BaudR.Idx230400;
                    break;
                case BaudR.BR460800:
                    eIdx = BaudR.Idx460800;
                    break;
                case BaudR.BR921600:
                    eIdx = BaudR.Idx921600;
                    break;
            }

            return eIdx;
        }
        public static BaudR BaudRateToIndex(int nBaud)
        {
            return BaudRateToIndex((BaudR)nBaud);
        }

        /// <summary>
        /// 인덱스 번호를 데이터 비트로 변환
        /// </summary>
        /// <param name="nIdx">인덱스</param>
        /// <returns>데이터 비트</returns>
        public static DataB IndexToDataBit(int nIdx)
        {
            DataB dataB = DataB.Data8;

            switch (nIdx)
            {
                case (int)DataB.IdxData5:
                    dataB = DataB.Data5;
                    break;
                case (int)DataB.IdxData6:
                    dataB = DataB.Data6;
                    break;
                case (int)DataB.IdxData7:
                    dataB = DataB.Data7;
                    break;
                case (int)DataB.IdxData8:
                    dataB = DataB.Data8;
                    break;
            }

            return dataB;
        }
        public static DataB IndexToDataBit(DataB eDataB)
        {
            return IndexToDataBit((int)eDataB);
        }

        /// <summary>
        /// 데이터 비트를 인덱스 번호로 변환
        /// </summary>
        /// <param name="eDataB">데이터 비트</param>
        /// <returns>인덱스</returns>
        public static DataB DataBitToIndex(DataB eDataB)
        {
            DataB eIdx = DataB.IdxData8;

            switch (eDataB)
            {
                case DataB.Data5:
                    eIdx = DataB.IdxData5;
                    break;
                case DataB.Data6:
                    eIdx = DataB.IdxData6;
                    break;
                case DataB.Data7:
                    eIdx = DataB.IdxData7;
                    break;
                case DataB.Data8:
                    eIdx = DataB.IdxData8;
                    break;
            }

            return eIdx;
        }
        public static DataB DataBitToIndex(int nDataB)
        {
            return DataBitToIndex((DataB)nDataB);
        }

        /// <summary>
        /// Log Token을 인덱스 번호로 변환
        /// </summary>
        /// <param name="eToken"></param>
        /// <returns></returns>
        public static int TokenToIndex(Const.LogToken eToken)
        {
            int nIdx = -1;

            if (eToken >= 0 &&
                eToken < Const.LogToken.Max)
            {
                nIdx = (int)eToken;
            }

            return nIdx;
        }
        public static int TokenToIndex(string strToken)
        {
            int nIdx = -1;

            if (strToken.Equals(","))
                nIdx = (int)Const.LogToken.Token_Comma;
            else if (strToken.Equals("."))
                nIdx = (int)Const.LogToken.Token_Dot;
            else if (strToken.Equals(":"))
                nIdx = (int)Const.LogToken.Token_Colon;
            else if (strToken.Equals(";"))
                nIdx = (int)Const.LogToken.Token_SemiColon;
            else if (strToken.Equals("_"))
                nIdx = (int)Const.LogToken.Token_Underbar;
            else if (strToken.Equals("-"))
                nIdx = (int)Const.LogToken.Token_Bar;
            else if (strToken.Equals("="))
                nIdx = (int)Const.LogToken.Token_Equal;
            else if (strToken.Equals("+"))
                nIdx = (int)Const.LogToken.Token_Plus;
            else if (strToken.Equals("|"))
                nIdx = (int)Const.LogToken.Token_ShiftRSlash;
            else if (strToken.Equals(@"\"))
                nIdx = (int)Const.LogToken.Token_RSlash;
            else if (strToken.Equals("/"))
                nIdx = (int)Const.LogToken.Token_Slash;
            else if (strToken.Equals("!"))
                nIdx = (int)Const.LogToken.Token_Excm;
            else if (strToken.Equals("@"))
                nIdx = (int)Const.LogToken.Token_a;
            else if (strToken.Equals("#"))
                nIdx = (int)Const.LogToken.Token_Sharp;
            else if (strToken.Equals("$"))
                nIdx = (int)Const.LogToken.Token_Dollar;
            else if (strToken.Equals("%"))
                nIdx = (int)Const.LogToken.Token_Percent;
            else if (strToken.Equals("^"))
                nIdx = (int)Const.LogToken.Token_SSix;
            else if (strToken.Equals("&"))
                nIdx = (int)Const.LogToken.Token_And;
            else if (strToken.Equals("*"))
                nIdx = (int)Const.LogToken.Token_Multiple;

            //@",", @".", @":", @";", @"_", @"-", @"=", @"+", @"|", @"\", @"/", @"!", @"@", @"#", @"$", @"%", @"^", @"&&", @"*"
            return nIdx;
        }

        public void Dispose()
        {
            Close();

            mThreadRun = false;
            mThreadSend.Abort();
        }
    }
}
