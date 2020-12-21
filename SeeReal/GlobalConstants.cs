using SeeReal.Struct;
using System.Drawing;

namespace SeeReal
{
    public class GlobalConstants
    {
        public static string APP_SETTING_MARGIN = "Settings_ButtonMargin";
        public static string APP_SETTING_LANGUAGE = "Settings_Language";
        public static string APP_SETTING_THEME = "Settings_Theme";
        public static string APP_SETTING_STYLE = "Settings_Style";
        public static string APP_SETTING_TRAYICON = "Settings_TrayIcon";

        public static string STRING_TRUE = "True";
        public static string STRING_FALSE = "False";

        public static string PATH_SERIAL_FOLDER = "SerialList";

        public static int DEFAULT_MARGIN = 5;
        public static int DEFAULT_BUTTON_WIDTH = 150;
        public static int DEFAULT_BUTTON_HEIGHT = 80;

        public static int DEFAULT_PLUS_BUTTON_WIDTH = 80;
        public static int DEFAULT_PLUS_BUTTON_HEIGHT = DEFAULT_BUTTON_HEIGHT;

        public static LanguageType DEFAULT_LANGUAGE = LanguageType.English;
        public static ThemeType DEFAULT_THEME = ThemeType.Light;
        public static StyleType DEFAULT_STYLE = StyleType.Blue;

        public static Size DEFAULT_BUTTON_SIZE = new Size(DEFAULT_BUTTON_WIDTH, DEFAULT_BUTTON_HEIGHT);

        public static int MAX_SERIAL_PORT = 30;

        public delegate void ThemeChangeDelegate(ThemeType eType);
        public delegate void StyleChangeDelegate(StyleType eType);
        public delegate void SaveSerialDelegate();
        public delegate void RefreshDelegate(int nIdx);
        public delegate void WriteLogDelegate(string strLog);

        public static object LOCK_OBJ = new object();

        /// <summary>
        /// 언어 타입
        /// </summary>
        public enum LanguageType
        {
            English = 0,
            Korean,
            Max
        }

        /// <summary>
        /// 테마 타입
        /// </summary>
        public enum ThemeType
        {
            Light = 0,      // <- Default
            Dark,
            Max
        }

        /// <summary>
        /// 스타일 타입
        /// </summary>
        public enum StyleType
        {
            Black = 0,
            White,
            Silver,
            Blue,           // <- Default
            Green,
            Lime,
            Teal,
            Orange,
            Brown,
            Pink,
            Magenta,
            Purple,
            Red,
            Yellow,
            Max
        }

        /// <summary>
        /// 설정 - 로그 저장 타입
        /// </summary>
        public enum LogSaveType
        {
            SendReceive = 0,
            Send,
            Receive,
            Max
        }

        /// <summary>
        /// 설정 - 로그 구분자
        /// </summary>
        public enum LogToken
        {
            Token_Comma = 0,
            Token_Dot,
            Token_Colon,
            Token_SemiColon,
            Token_Underbar,
            Token_Bar,
            Token_Equal,
            Token_Plus,
            Token_ShiftRSlash,
            Token_RSlash,
            Token_Slash,
            Token_Excm,
            Token_a,
            Token_Sharp,
            Token_Dollar,
            Token_Percent,
            Token_SSix,
            Token_And,
            Token_Multiple,
            Max
        }
    }
}
