using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Const = SeeReal.GlobalConstants;

namespace SeeReal
{
    public class SettingStruct
    {
        /// <summary>
        /// 버튼간 간격
        /// </summary>
        public int Margin { get; set; }

        /// <summary>
        /// 언어 설정값
        /// </summary>
        public Const.LanguageType LanguageType { get; set; }

        /// <summary>
        /// 테마 설정값
        /// </summary>
        public Const.ThemeType ThemeType { get; set; }

        /// <summary>
        /// 스타일 설정값
        /// </summary>
        public Const.StyleType StyleType { get; set; }

        /// <summary>
        /// Tray Icon 사용 유무
        /// </summary>
        public bool TrayIconEnable { get; set; }
    }
}
