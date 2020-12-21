using MetroFramework.Controls;
using MetroFramework.Forms;
using SeeReal.Language;
using SeeReal.Struct;
using SeeReal.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Const = SeeReal.GlobalConstants;

namespace SeeReal
{
    public partial class MainDlg : MetroForm
    {
        /// <summary>
        /// 설정에서 사용할 구조체
        /// </summary>
        public SettingStruct mSettingStruct = new SettingStruct();
        /// <summary>
        /// 메인 판넬에 추가되는 MetroTile 객체를 저장하는 ArrayList
        /// </summary>
        public ArrayList mTileList = new ArrayList();
        /// <summary>
        /// 메인 판넬의 크기
        /// </summary>
        private int mMainPanelRight = 0;
        /// <summary>
        /// 테마 변경 딜리게이트
        /// </summary>
        private event Const.ThemeChangeDelegate ThemeChangeEvent = null;
        /// <summary>
        /// 스타일 변경 딜리게이트
        /// </summary>
        private event Const.StyleChangeDelegate StyleChangeEvent = null;

        public MainDlg()
        {
            InitializeComponent();

            InitSettings();
            InitVariables();
            InitFolder();
            InitControls();
        }
        
        /// <summary>
        /// 폴더 확인
        /// </summary>
        private void InitFolder()
        {
            string strFolderPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + Const.PATH_SERIAL_FOLDER;
            DirectoryInfo directoryInfo = new DirectoryInfo(strFolderPath);

            // Serial List 폴더가 없을 때 폴더를 생성
            if (directoryInfo.Exists == false)
            {
                directoryInfo.Create();
            }
            // Serial List 폴더가 있을 때 버튼 초기화
            else
            {
                XmlMgr.LoadResult loadResult = XmlMgr.LoadSerialData(ref mTileList);
                
                switch (loadResult)
                {
                    case XmlMgr.LoadResult.Success:
                        {
                            foreach (TileStruct tileStruct in mTileList)
                            {
                                ButtonMaker(tileStruct);
                            }
                            break;
                        }
                    case XmlMgr.LoadResult.NoData:
                        {
                            break;
                        }
                    case XmlMgr.LoadResult.Fail_FileLoad:
                        {
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 설정값 불러오기
        /// </summary>
        private void InitSettings()
        {
            #region 버튼간 Margin 값
            try
            {
                mSettingStruct.Margin = int.Parse(AppConfigMgr.GetAppConfig(Const.APP_SETTING_MARGIN));
                if (mSettingStruct.Margin < 0)
                    mSettingStruct.Margin = Const.DEFAULT_MARGIN;
            }
            catch (ArgumentNullException)
            {
                mSettingStruct.Margin = Const.DEFAULT_MARGIN;
            }
            #endregion

            #region 언어 설정값
            try
            {
                int nLangType = int.Parse(AppConfigMgr.GetAppConfig(Const.APP_SETTING_LANGUAGE));
                if (nLangType > (int)Const.LanguageType.Max)
                    mSettingStruct.LanguageType = Const.DEFAULT_LANGUAGE;
                else
                    mSettingStruct.LanguageType = (Const.LanguageType)nLangType;
            }
            catch (ArgumentNullException)
            {
                mSettingStruct.LanguageType = Const.DEFAULT_LANGUAGE;
            }

            switch (mSettingStruct.LanguageType)
            {
                case Const.LanguageType.English:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
                case Const.LanguageType.Korean:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ko-KR");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
            }
            #endregion

            #region 테마 설정값
            try
            {
                int nThemeType = int.Parse(AppConfigMgr.GetAppConfig(Const.APP_SETTING_THEME));
                if (nThemeType > (int)Const.ThemeType.Max)
                    mSettingStruct.ThemeType = Const.DEFAULT_THEME;
                else
                    mSettingStruct.ThemeType = (Const.ThemeType)nThemeType;
            }
            catch (ArgumentNullException)
            {
                mSettingStruct.ThemeType = Const.DEFAULT_THEME;
            }
            #endregion

            #region 스타일 설정값
            try
            {
                int nStyleType = int.Parse(AppConfigMgr.GetAppConfig(Const.APP_SETTING_STYLE));
                if (nStyleType > (int)Const.StyleType.Max)
                    mSettingStruct.StyleType = Const.DEFAULT_STYLE;
                else
                    mSettingStruct.StyleType = (Const.StyleType)nStyleType;
            }
            catch (ArgumentNullException)
            {
                mSettingStruct.StyleType = Const.DEFAULT_STYLE;
            }
            #endregion

            #region 트레이 아이콘 사용 유무
            try
            {
                string strTrue = AppConfigMgr.GetAppConfig(Const.APP_SETTING_TRAYICON);
                if (strTrue != null)
                {
                    if (strTrue.Equals(Const.STRING_TRUE))
                        mSettingStruct.TrayIconEnable = true;
                    else
                        mSettingStruct.TrayIconEnable = false;
                }
                else
                    mSettingStruct.TrayIconEnable = false;
            }
            catch (ArgumentNullException)
            {
                mSettingStruct.TrayIconEnable = false;
            }
            #endregion
        }

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitControls()
        {
            #region 테마 및 스타일 변경
            ThemeChangeEvent(mSettingStruct.ThemeType);
            StyleChangeEvent(mSettingStruct.StyleType);
            #endregion

            #region 타이틀 텍스트
            Text = Languages.MainTitle;
            #endregion

            #region 설정 버튼
            tileSettings.Text = Languages.SettingsTitle;
            #endregion

            #region 트레이 아이콘
            TrayIcon.ContextMenuStrip = ctrlTrayMenu;
            TrayIcon.Visible = mSettingStruct.TrayIconEnable;
            TrayIcon.Text = Languages.MainTitle;
            #endregion
        }


        /// <summary>
        /// 변수 초기화
        /// </summary>
        private void InitVariables()
        {
            mMainPanelRight = panMain.Location.X + panMain.Size.Width;

            if (ThemeChangeEvent == null)
                ThemeChangeEvent += ThemeChange;
            if (StyleChangeEvent == null)
                StyleChangeEvent += StyleChange;
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
                    ctrlMainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case Const.ThemeType.Dark:
                    ctrlMainThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
            }

            foreach (TileStruct tileStruct in mTileList)
            {
                tileStruct.MainThemeType = eType;
            }

            Theme = ctrlMainThemeMgr.Theme;
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
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Black;
                    break;
                case Const.StyleType.White:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.White;
                    break;
                case Const.StyleType.Silver:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Silver;
                    break;
                case Const.StyleType.Blue:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case Const.StyleType.Green:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case Const.StyleType.Lime:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Lime;
                    break;
                case Const.StyleType.Teal:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Teal;
                    break;
                case Const.StyleType.Orange:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Const.StyleType.Brown:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Brown;
                    break;
                case Const.StyleType.Pink:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case Const.StyleType.Magenta:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case Const.StyleType.Purple:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Purple;
                    break;
                case Const.StyleType.Red:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case Const.StyleType.Yellow:
                    ctrlMainThemeMgr.Style = MetroFramework.MetroColorStyle.Yellow;
                    break;
            }

            foreach (TileStruct tileStruct in mTileList)
            {
                tileStruct.RefreshButton();
            }

            Style = ctrlMainThemeMgr.Style;
        }

        /// <summary>
        /// Serial 데이터를 저장하는 이벤트
        /// </summary>
        public void SaveSerialData()
        {
            XmlMgr.SaveSerialData(mTileList);
        }

        /// <summary>
        /// 특정 데이터를 새로고침 하는 이벤트
        /// </summary>
        /// <param name="nIdx">데이터의 인덱스(-1일 경우 전체 데이터 새로고침)</param>
        public void RefreshData(int nIdx)
        {
            if (nIdx == -1)
            {
                panMain.Controls.Clear();
                InitFolder();
            }
        }

        /// <summary>
        /// + 버튼 액션
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrlBtnAdd_Click(object sender, EventArgs e)
        {
            ButtonMaker();
            SaveSerialData();
        }

        /// <summary>
        /// 버튼을 생성하는 메소드
        /// </summary>
        /// <param name="ctrlNewTile">버튼 데이터 구조체</param>
        private void ButtonMaker(TileStruct ctrlNewTile = null)
        {
            #region 현재 + 버튼의 위치를 가져옴

            Point curPlusPos = tileAdd.Location;
            Size curPlusSize = tileAdd.Size;

            #endregion

            #region 새롭게 추가할 버튼

            bool bIsNextLined = false;
            bool bIsNew = false;
            if (ctrlNewTile == null)
            {
                ctrlNewTile = new TileStruct(mTileList.Count, "새로운 연결")
                {
                    Text = "새로운 연결",
                    MainThemeType = mSettingStruct.ThemeType,
                    MainStyleType = mSettingStruct.StyleType,
                    Name = (mTileList.Count + 1).ToString()
                };
                bIsNew = true;
            }
            else
            {
                ctrlNewTile.MainThemeType = mSettingStruct.ThemeType;
                ctrlNewTile.MainStyleType = mSettingStruct.StyleType;
                ctrlNewTile.Name = ctrlNewTile.TileNo.ToString();
            }
            ctrlNewTile.SaveSerialDataEvent += SaveSerialData;
            ctrlNewTile.RefreshEvent += RefreshData;

            Point ptNewPoint = new Point(curPlusPos.X, curPlusPos.Y);
            if (mMainPanelRight < ptNewPoint.X + Const.DEFAULT_BUTTON_WIDTH)
            {
                ptNewPoint.X = Const.DEFAULT_MARGIN;
                ptNewPoint.Y = curPlusPos.Y + Const.DEFAULT_BUTTON_HEIGHT + Const.DEFAULT_MARGIN;
                bIsNextLined = true;
            }
            ctrlNewTile.Location = ptNewPoint;
            ctrlNewTile.Size = Const.DEFAULT_BUTTON_SIZE;
            //ctrlNewTile.TileNo = ++mCurNewTileNum;
            if (bIsNew)
                mTileList.Add(ctrlNewTile);

            #endregion

            #region 버튼 패널에 붙임
            if (bIsNew)
            {
                // 버튼에 현재 테마 적용
                ThemeChangeEvent(mSettingStruct.ThemeType);
                StyleChangeEvent(mSettingStruct.StyleType);

                panMain.Controls.Add(mTileList[mTileList.Count - 1] as TileStruct);
            }
            else
                panMain.Controls.Add(mTileList[ctrlNewTile.TileNo] as TileStruct);

            #endregion

            #region +버튼 옮기기

            curPlusPos.X = ptNewPoint.X + Const.DEFAULT_BUTTON_WIDTH + Const.DEFAULT_MARGIN;
            if (bIsNextLined == false)
            {
                if (mMainPanelRight < curPlusPos.X + Const.DEFAULT_PLUS_BUTTON_WIDTH)
                {
                    curPlusPos.X = Const.DEFAULT_MARGIN;
                    curPlusPos.Y = ptNewPoint.Y + Const.DEFAULT_BUTTON_HEIGHT + Const.DEFAULT_MARGIN;
                }
            }
            else
                curPlusPos.Y = ptNewPoint.Y;
            tileAdd.Location = curPlusPos;

            #endregion
            
        }

        /// <summary>
        /// 설정 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.SetDialog(mSettingStruct);
                DialogResult dialogResult = settingsForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    InitSettings();
                    InitControls();
                }
            }
        }

        /// <summary>
        /// 다이얼로그 리사이즈 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDlg_Resize(object sender, EventArgs e)
        {
            // 최소화 시켰을 때
            if (mSettingStruct.TrayIconEnable)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Visible = false;            // 창 숨기기
                    ShowInTaskbar = false;      // 하단 작업 표시줄 숨기기
                    TrayIcon.Visible = true;    // 트레이 아이콘 활성화
                }
            }
        }

        /// <summary>
        /// 트레이 아이콘 - 더블 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mSettingStruct.TrayIconEnable)
            {
                Visible = true;             // 창 숨기기
                ShowInTaskbar = true;       // 하단 작업 표시줄 숨기기
                TrayIcon.Visible = false;   // 트레이 아이콘 활성화
                WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// 트레이 아이콘 - 종료 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrlMenuExit_Click(object sender, EventArgs e)
        {
            if (mSettingStruct.TrayIconEnable)
                Application.Exit();
        }

        private void MainDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < mTileList.Count; i++)
            {
                (mTileList[i] as TileStruct).Dispose();
            }
            mTileList.Clear();
        }
    }
}
