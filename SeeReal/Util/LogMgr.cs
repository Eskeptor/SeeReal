using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeeReal.Util
{
    public class LogMgr
    {
        public enum LogType
        {
            GUI = 0,    // 프로그램 로그
            COM,        // 통신 로그
            COM_IND,    // 개별 통신 로그
        }

        public static string LOG_FOLDER = "Log";        // 로그 폴더명
        public static string LOG_EXTENSION = ".log";    // 로그 파일 확장자
        public static string LOG_COM_FILEEX = "_COM";   // 통신 로그 파일명
        public static string LOG_GUI_FILEEX = "_GUI";   // 프로그램 로그 파일명

        /// <summary>
        /// 로그를 쓰는 메소드
        /// </summary>
        /// <param name="logType">로그의 타입(enum LogType)</param>
        /// <param name="strLog">로그 내용</param>
        /// <param name="bIsWriteDate">로그파일의 내용에 시간을 넣을지 유무</param>
        public static void WriteLog(LogType logType, string strLog, bool bIsWriteDate = true)
        {
            DateTime dateNow = DateTime.Now;
            string strDateNow = string.Format("_{0}{1:D2}{2:D2}", dateNow.Year, dateNow.Month, dateNow.Day);
            string strCurExeFile = Path.GetFileName(Assembly.GetEntryAssembly().Location);
            string strFileName = strCurExeFile.Substring(0, strCurExeFile.Length - 4);
            string strPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + LOG_FOLDER;

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(strPath);

                if (directoryInfo.Exists == false)
                    directoryInfo.Create();

                switch (logType)
                {
                    case LogType.GUI:
                        strPath += Path.DirectorySeparatorChar + strFileName + LOG_GUI_FILEEX + strDateNow + LOG_EXTENSION;
                        break;
                    case LogType.COM:
                        strPath += Path.DirectorySeparatorChar + strFileName + LOG_COM_FILEEX + strDateNow + LOG_EXTENSION;
                        break;
                    default:
                        return;
                }

                WriteLog(strPath, strLog, bIsWriteDate);
            }
            catch
            {
                MessageBox.Show("로그 폴더를 생성할 수 없습니다.");
            }
        }

        /// <summary>
        /// 로그를 쓰는 메소드
        /// </summary>
        /// <param name="strPath">로그 파일 경로</param>
        /// <param name="strLog">로그 내용</param>
        /// <param name="bIsWriteDate">로그파일의 내용에 시간을 넣을지 유무</param>
        public static void WriteLog(string strPath, string strLog, bool bIsWriteDate)
        {
            if (string.IsNullOrEmpty(strLog) == false &&
                string.IsNullOrEmpty(strPath) == false)
            {
                FileInfo fileInfo = new FileInfo(strPath);

                try
                {
                    if (fileInfo.Exists == false)
                    {
                        using (StreamWriter writer = new StreamWriter(strPath))
                        {
                            string strTemp = string.Empty;
                            if (bIsWriteDate)
                                strTemp = string.Format("[{0}] {1}", DateTime.Now, strLog);
                            else
                                strTemp = strLog;
                            writer.WriteLine(strTemp);
                        }
                    }
                    else
                    {
                        using (StreamWriter writer = File.AppendText(strPath))
                        {
                            string strTemp = string.Empty;
                            if (bIsWriteDate)
                                strTemp = string.Format("[{0}] {1}", DateTime.Now, strLog);
                            else
                                strTemp = strLog;
                            writer.WriteLine(strTemp);
                        }
                    }
                }
                catch { }
            }
        }

    }
}
