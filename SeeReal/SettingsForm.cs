using MetroFramework.Forms;
using SeeReal.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Const = SeeReal.GlobalConstants;

namespace SeeReal
{
    public partial class SettingsForm : MetroForm
    {
        /// <summary>
        /// 설정용 데이터 클래스
        /// </summary>
        private SettingStruct mSettingStruct = null;
        /// <summary>
        /// 테마 변경 딜리게이트
        /// </summary>
        private event Const.ThemeChangeDelegate ThemeChangeEvent = null;
        /// <summary>
        /// 스타일 변경 딜리게이트
        /// </summary>
        private event Const.StyleChangeDelegate StyleChangeEvent = null;

        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 변수 초기화
        /// </summary>
        private void InitVariables()
        {
            if (ThemeChangeEvent == null)
                ThemeChangeEvent += ThemeChange;
            if (StyleChangeEvent == null)
                StyleChangeEvent += StyleChange;
        }


        /// <summary>
        /// 다이얼로그 설정
        /// </summary>
        /// <param name="settingStruct">설정 구조체(메인에 있는것 그대로)</param>
        public void SetDialog(SettingStruct settingStruct)
        {
            mSettingStruct = settingStruct;

            InitVariables();
            InitControls();
        }

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitControls()
        {
            if (mSettingStruct != null)
            {
                #region 타이틀 텍스트
                Text = Languages.SettingsTitle;

                btnCancel.Text = Languages.Tab_Btn_Cancel;
                btnAdapt.Text = Languages.Tab_Btn_Apply;
                #endregion

                #region 언어 설정 콤보 박스
                lblLanguage.Text = Languages.Settings_Title_Language;

                string[] strArrLang = new string[(int)Const.LanguageType.Max]
                {
                    Languages.Settings_Language_English,
                    Languages.Settings_Language_Korean
                };
                if (cboxLanguage.Items.Count > 0)
                    cboxLanguage.Items.Clear();
                cboxLanguage.Items.AddRange(strArrLang);
                cboxLanguage.SelectedIndex = (int)mSettingStruct.LanguageType;
                #endregion

                #region 메인 테마 콤보 박스
                lblMainTheme.Text = Languages.Settings_Title_Theme;

                string[] strArrTheme = new string[(int)Const.ThemeType.Max]
                {
                    Languages.Settings_Theme_Light,
                    Languages.Settings_Theme_Dark
                };
                if (cboxMainTheme.Items.Count > 0)
                    cboxMainTheme.Items.Clear();
                cboxMainTheme.Items.AddRange(strArrTheme);
                cboxMainTheme.SelectedIndex = (int)mSettingStruct.ThemeType;
                #endregion

                #region 서브 스타일 콤보 박스
                lblSubStyle.Text = Languages.Settings_Title_SubStyle;

                string[] strArrStyle = new string[(int)Const.StyleType.Max]
                {
                    Languages.Settings_Style_Black,
                    Languages.Settings_Style_White,
                    Languages.Settings_Style_Silver,
                    Languages.Settings_Style_Blue,
                    Languages.Settings_Style_Green,
                    Languages.Settings_Style_Lime,
                    Languages.Settings_Style_Teal,
                    Languages.Settings_Style_Orange,
                    Languages.Settings_Style_Brown,
                    Languages.Settings_Style_Pink,
                    Languages.Settings_Style_Magenta,
                    Languages.Settings_Style_Purple,
                    Languages.Settings_Style_Red,
                    Languages.Settings_Style_Yellow,
                };
                if (cboxSubStyle.Items.Count > 0)
                    cboxSubStyle.Items.Clear();
                cboxSubStyle.Items.AddRange(strArrStyle);
                cboxSubStyle.SelectedIndex = (int)mSettingStruct.StyleType;
                #endregion

                #region 트레이 아이콘 토글
                lblTrayIcon.Text = Languages.Settings_Title_TrayIcon;
                toggleTrayIcon.Checked = mSettingStruct.TrayIconEnable;
                #endregion

                #region 테마 및 스타일 변경
                ThemeChangeEvent(mSettingStruct.ThemeType);
                StyleChangeEvent(mSettingStruct.StyleType);
                #endregion
            }
        }

        /// <summary>
        /// 테마 변경 이벤트
        /// </summary>
        /// <param name="eType">테마 타입</param>
        public void ThemeChange(Const.ThemeType eType)
        {
            switch (eType)
            {
                case Const.ThemeType.Light:
                    ctrlSettingsThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case Const.ThemeType.Dark:
                    ctrlSettingsThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
            }

            Theme = ctrlSettingsThemeMgr.Theme;
        }

        /// <summary>
        /// 스타일 변경 이벤트
        /// </summary>
        /// <param name="eType"></param>
        public void StyleChange(Const.StyleType eType)
        {
            switch (eType)
            {
                case Const.StyleType.Black:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Black;
                    break;
                case Const.StyleType.White:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.White;
                    break;
                case Const.StyleType.Silver:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Silver;
                    break;
                case Const.StyleType.Blue:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case Const.StyleType.Green:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case Const.StyleType.Lime:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Lime;
                    break;
                case Const.StyleType.Teal:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Teal;
                    break;
                case Const.StyleType.Orange:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Const.StyleType.Brown:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Brown;
                    break;
                case Const.StyleType.Pink:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case Const.StyleType.Magenta:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case Const.StyleType.Purple:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Purple;
                    break;
                case Const.StyleType.Red:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case Const.StyleType.Yellow:
                    ctrlSettingsThemeMgr.Style = MetroFramework.MetroColorStyle.Yellow;
                    break;
            }

            Style = ctrlSettingsThemeMgr.Style;
        }

        /// <summary>
        /// 적용 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdapt_Click(object sender, EventArgs e)
        {
            bool bIsLangChanged = false;
            mSettingStruct.ThemeType = (Const.ThemeType)cboxMainTheme.SelectedIndex;
            mSettingStruct.StyleType = (Const.StyleType)cboxSubStyle.SelectedIndex;
            if (mSettingStruct.LanguageType != (Const.LanguageType)cboxLanguage.SelectedIndex)
            {
                mSettingStruct.LanguageType = (Const.LanguageType)cboxLanguage.SelectedIndex;
                bIsLangChanged = true;
            }

            AppConfigMgr.SetAppConfig(Const.APP_SETTING_THEME, (int)mSettingStruct.ThemeType);
            AppConfigMgr.SetAppConfig(Const.APP_SETTING_STYLE, (int)mSettingStruct.StyleType);
            AppConfigMgr.SetAppConfig(Const.APP_SETTING_LANGUAGE, (int)mSettingStruct.LanguageType);
            if (toggleTrayIcon.Checked)
                AppConfigMgr.SetAppConfig(Const.APP_SETTING_TRAYICON, Const.STRING_TRUE);
            else
                AppConfigMgr.SetAppConfig(Const.APP_SETTING_TRAYICON, Const.STRING_FALSE);
            mSettingStruct.TrayIconEnable = toggleTrayIcon.Checked;

            if (bIsLangChanged)
            {
                DialogResult result = MessageBox.Show("언어가 변경되었습니다. 재시작 하시겠습니까?", "언어 변경", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("언어는 재시작 이후에 적용됩니다.");
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// 취소 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
