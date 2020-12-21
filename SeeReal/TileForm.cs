using MetroFramework.Forms;
using SeeReal.Language;
using SeeReal.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Const = SeeReal.GlobalConstants;

namespace SeeReal.Struct
{
    public partial class TileForm : MetroForm
    {
        private enum GridStuff
        {
            GridIdx_Name = 0,
            GridIdx_Macro,
            GridIdx_Enable,
            GridIdxMax,

            GridRat_Name = 2,
            GridRat_Macro = 4,
            GridRat_Enable = 1,
            GridRatMax = GridRat_Name + GridRat_Macro + GridRat_Enable
        }

        /// <summary>
        /// 타일용 클래스
        /// </summary>
        private TileStruct mTileStruct = null;
        /// <summary>
        /// 테마 변경 딜리게이트
        /// </summary>
        private event Const.ThemeChangeDelegate ThemeChangeEvent = null;
        /// <summary>
        /// 스타일 변경 딜리게이트
        /// </summary>
        private event Const.StyleChangeDelegate StyleChangeEvent = null;
        /// <summary>
        /// Serial 데이터 저장 딜리게이트
        /// </summary>
        public event Const.SaveSerialDelegate SaveSerialDataEvent = null;
        /// <summary>
        /// 새로고침 딜리게이트
        /// </summary>
        public event Const.RefreshDelegate RefreshEvent = null;


        public TileForm()
        {
            InitializeComponent();

            InitControls();
            InitVariables();
        }

        ~TileForm()
        {

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
        /// 컨트롤 초기화
        /// </summary>
        private void InitControls()
        {
            #region 텍스트 언어

            #region 텍스트 언어 - 매크로
            pageMacro.Text = Languages.Tab_MainTitle_Macro;

            gridMacro.Columns[(int)GridStuff.GridIdx_Name].HeaderText = Languages.Grid_Title_MacroName;
            gridMacro.Columns[(int)GridStuff.GridIdx_Macro].HeaderText = Languages.Grid_Title_Macro;
            gridMacro.Columns[(int)GridStuff.GridIdx_Enable].HeaderText = Languages.Grid_Title_Enable;
            #endregion

            #region 텍스트 언어 - 기록
            pageLog.Text = Languages.Tab_Log;
            #endregion

            #region 텍스트 언어 - 설정
            pageSettings.Text = Languages.Tab_MainTitle_Settings;

            lblSerialName.Text = Languages.Tab_Title_SerialName;
            lblPort.Text = Languages.Tab_Title_Port;
            lblBaudRate.Text = Languages.Tab_Title_BaudRate;
            lblDataBit.Text = Languages.Tab_Title_DataBit;
            lblParity.Text = Languages.Tab_Title_Parity;
            lblStopBit.Text = Languages.Tab_Title_StopBit;
            lblFlow.Text = Languages.Tab_Title_Flow;

            lblMacroEnable.Text = Languages.Tab_Title_MacroEnable;
            lblDelay.Text = Languages.Tab_Title_Delay;
            lblTileColor.Text = Languages.Tab_Tile_Color;

            lblLogEnable.Text = Languages.Tab_Title_Log_SaveEnable;
            lblLogType.Text = Languages.Tab_Title_Log_SaveType;
            lblLogToken.Text = Languages.Tab_Title_Log_Token;
            lblLogSavePath.Text = Languages.Tab_Title_Log_SavePath;
            btnLogPathFind.Text = Languages.Tab_Btn_Log_Find;

            btnCancel.Text = Languages.Tab_Btn_Cancel;
            btnAdapt.Text = Languages.Tab_Btn_Apply;
            #endregion

            #endregion

            #region 매크로 - 그리드

            #region 매크로 - 그리드 - 헤더 크기
            int nRowHeaderSize = gridMacro.Rows[0].HeaderCell.Size.Width;   // Row 헤더의 넓이
            int nGridWidth = gridMacro.Size.Width - nRowHeaderSize;         // Row 헤더를 뺀 실질적인 그리드의 가로 넓이
            int[] nArrGridWidth = new int[(int)GridStuff.GridIdxMax];       // 그리드의 셀별 가로 길이
            int nDivider = nGridWidth / (int)GridStuff.GridRatMax;

            nArrGridWidth[(int)GridStuff.GridIdx_Name] = nDivider * (int)GridStuff.GridRat_Name;
            nArrGridWidth[(int)GridStuff.GridIdx_Macro] = nDivider * (int)GridStuff.GridRat_Macro;
            nArrGridWidth[(int)GridStuff.GridIdx_Enable] = nGridWidth - (((int)GridStuff.GridRatMax - (int)GridStuff.GridRat_Enable) * nDivider);

            for (int i = (int)GridStuff.GridIdx_Name; i < (int)GridStuff.GridIdxMax; i++)
                gridMacro.Columns[i].Width = nArrGridWidth[i];
            #endregion


            #endregion

            #region 설정

            #region 설정 - 포트
            if (cboxPort.Items.Count > 0)
                cboxPort.Items.Clear();
            for (int i = 0; i <= Const.MAX_SERIAL_PORT; i++)
            {
                cboxPort.Items.Add(string.Format("COM{0}", i));
            }
            #endregion

            #region 설정 - 보드레이트
            if (cboxBaudRate.Items.Count > 0)
                cboxBaudRate.Items.Clear();
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR2400));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR4800));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR9600));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR14400));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR19200));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR38400));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR57600));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR115200));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR230400));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR460800));
            cboxBaudRate.Items.Add(string.Format("{0}", (int)SerialStruct.BaudR.BR921600));
            #endregion

            #region 설정 - 데이터 비트
            if (cboxDataBit.Items.Count > 0)
                cboxDataBit.Items.Clear();
            cboxDataBit.Items.Add(string.Format("{0}", (int)SerialStruct.DataB.Data5));
            cboxDataBit.Items.Add(string.Format("{0}", (int)SerialStruct.DataB.Data6));
            cboxDataBit.Items.Add(string.Format("{0}", (int)SerialStruct.DataB.Data7));
            cboxDataBit.Items.Add(string.Format("{0}", (int)SerialStruct.DataB.Data8));
            #endregion

            #region 설정 - 패리티 코드
            string[] strArrParity = new string[] { Languages.Parity_None, Languages.Parity_Odd, Languages.Parity_Even };
            if (cboxParity.Items.Count > 0)
                cboxParity.Items.Clear();
            cboxParity.Items.AddRange(strArrParity);
            #endregion

            #region 설정 - 정지 비트
            string[] strArrStopBit = new string[] { "0", "1", "2", "1.5" };
            if (cboxStopBit.Items.Count > 0)
                cboxStopBit.Items.Clear();
            cboxStopBit.Items.AddRange(strArrStopBit);
            #endregion

            #region 설정 - 흐름 제어
            string[] strArrFlow = new string[] { Languages.Parity_None, "xONxOFF", "RTS CTS" };
            if (cboxFlow.Items.Count > 0)
                cboxFlow.Items.Clear();
            cboxFlow.Items.AddRange(strArrFlow);
            #endregion

            #region 설정 - 타일 색상
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
            if (cboxTileColor.Items.Count > 0)
                cboxTileColor.Items.Clear();
            cboxTileColor.Items.AddRange(strArrStyle);
            #endregion

            #region 설정 - 로그 저장 타입
            string[] strArrSaveType = new string[(int)Const.LogSaveType.Max]
            {
                Languages.Combo_LogType_SendRcv, Languages.Combo_LogType_Send, Languages.Combo_LogType_Rcv
            };
            if (cboxLogSaveType.Items.Count > 0)
                cboxLogSaveType.Items.Clear();
            cboxLogSaveType.Items.AddRange(strArrSaveType);
            #endregion

            #region 설정 - 구분자
            string[] strArrToken = new string[(int)Const.LogToken.Max]
            {
               @",", @".", @":", @";", @"_", @"-", @"=", @"+", @"|", @"\", @"/", @"!", @"@", @"#", @"$", @"%", @"^", @"&&", @"*"
            };
            if (cboxLogToken.Items.Count > 0)
                cboxLogToken.Items.Clear();
            cboxLogToken.Items.AddRange(strArrToken);
            #endregion

            #endregion
        }

        // TODO 타일 폼 만들기
        /// <summary>
        /// 다이얼로그 설정 메소드
        /// </summary>
        /// <param name="tileStruct">타일 데이터</param>
        public void SetDialog(TileStruct tileStruct)
        {
            mTileStruct = tileStruct;

            #region 타이틀 텍스트
            Text = mTileStruct.SerialName;
            #endregion

            #region 테마 및 스타일 변경
            ThemeChangeEvent(mTileStruct.MainThemeType);
            StyleChangeEvent(mTileStruct.MainStyleType);
            #endregion

            #region 매크로

            #region 매크로 - 데이터 매칭
            if (tileStruct.SerialData.MacroList.Count > 0)
            {
                foreach (MacroStruct macroStruct in tileStruct.SerialData.MacroList)
                {
                    #region 매크로 Row
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewCell[] cells = new DataGridViewCell[(int)GridStuff.GridIdxMax];

                    #region 매크로 Row - 매크로명
                    cells[(int)GridStuff.GridIdx_Name] = new DataGridViewTextBoxCell();
                    ((DataGridViewTextBoxCell)cells[(int)GridStuff.GridIdx_Name]).Value = macroStruct.MacroName;
                    #endregion

                    #region 매크로 Row - 매크로
                    cells[(int)GridStuff.GridIdx_Macro] = new DataGridViewTextBoxCell();
                    ((DataGridViewTextBoxCell)cells[(int)GridStuff.GridIdx_Macro]).Value = macroStruct.Macro;
                    #endregion

                    #region 매크로 Row - 활성화
                    cells[(int)GridStuff.GridIdx_Enable] = new DataGridViewCheckBoxCell();
                    ((DataGridViewCheckBoxCell)cells[(int)GridStuff.GridIdx_Enable]).Value = macroStruct.Enable;
                    #endregion

                    row.Cells.AddRange(cells);
                    gridMacro.Rows.Add(row);
                    #endregion
                }
            }
            #endregion

            #endregion

            #region 기록
            tileStruct.SerialData.WriteLogEvent += WriteLogToTBox;
            #endregion

            #region 설정

            // 시리얼명
            tboxSerialName.Text = mTileStruct.SerialData.SerialName;
            // 포트
            cboxPort.SelectedIndex = mTileStruct.SerialData.PortNum;
            // 보드 레이트
            cboxBaudRate.SelectedIndex = (int)SerialStruct.BaudRateToIndex(mTileStruct.SerialData.BaudRate);
            // 데이터 비트
            cboxDataBit.SelectedIndex = (int)SerialStruct.DataBitToIndex(mTileStruct.SerialData.DataBit);
            // 패리티 코드
            cboxParity.SelectedIndex = (int)mTileStruct.SerialData.ParityCode;
            // 정지 비트
            cboxStopBit.SelectedIndex = (int)mTileStruct.SerialData.StopBitCode;
            // 흐름 제어
            cboxFlow.SelectedIndex = (int)mTileStruct.SerialData.FlowControl;

            // 매크로 활성화
            toggleEnable.Checked = mTileStruct.SerialData.MacroEnable;
            // 반복 딜레이
            tboxDelay.Text = mTileStruct.SerialData.RunDelay.ToString();
            // 타일 색상
            cboxTileColor.SelectedIndex = (int)mTileStruct.TileColor;

            // 로그 저장
            toggleLogSave.Checked = mTileStruct.SerialData.LogSave;
            // 로그 저장 타입
            cboxLogSaveType.SelectedIndex = (int)mTileStruct.SerialData.LogSaveType;
            // 로그 구분자
            cboxLogToken.SelectedIndex = (int)mTileStruct.SerialData.LogToken;
            // 로그 저장 경로
            tboxLogSavePath.Text = mTileStruct.SerialData.LogSavePath;

            #endregion


        }

        /// <summary>
        /// 다이얼로그 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mTileStruct.CloseDialog();
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
                    ctrlTileThemeMgr.Theme = MetroFramework.MetroThemeStyle.Light;
                    break;
                case Const.ThemeType.Dark:
                    ctrlTileThemeMgr.Theme = MetroFramework.MetroThemeStyle.Dark;
                    break;
            }

            Theme = ctrlTileThemeMgr.Theme;
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
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Black;
                    break;
                case Const.StyleType.White:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.White;
                    break;
                case Const.StyleType.Silver:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Silver;
                    break;
                case Const.StyleType.Blue:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case Const.StyleType.Green:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case Const.StyleType.Lime:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Lime;
                    break;
                case Const.StyleType.Teal:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Teal;
                    break;
                case Const.StyleType.Orange:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Orange;
                    break;
                case Const.StyleType.Brown:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Brown;
                    break;
                case Const.StyleType.Pink:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case Const.StyleType.Magenta:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case Const.StyleType.Purple:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Purple;
                    break;
                case Const.StyleType.Red:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Red;
                    break;
                case Const.StyleType.Yellow:
                    ctrlTileThemeMgr.Style = MetroFramework.MetroColorStyle.Yellow;
                    break;
            }

            Style = ctrlTileThemeMgr.Style;
        }

        /// <summary>
        /// 기록 - 로그를 기록하는 이벤트
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteLogToTBox(string strLog)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    tboxLog.AppendText(strLog);
                }));
            }
        }

        /// <summary>
        /// 설정 - 적용 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdapt_Click(object sender, EventArgs e)
        {
            #region 시리얼명
            if (string.IsNullOrEmpty(tboxSerialName.Text))
            {
                MessageBox.Show(Languages.Msg_NoTitle);
                return;
            }
            mTileStruct.SerialName = tboxSerialName.Text;
            mTileStruct.SerialData.SerialName = tboxSerialName.Text;
            mTileStruct.Text = tboxSerialName.Text;
            #endregion

            #region 포트
            mTileStruct.SerialData.PortNum = cboxPort.SelectedIndex;
            #endregion

            #region 보드레이트
            mTileStruct.SerialData.BaudRate = (int)SerialStruct.IndexToBaudRate(cboxBaudRate.SelectedIndex);
            #endregion

            #region 데이터 비트
            mTileStruct.SerialData.DataBit = (int)SerialStruct.IndexToDataBit(cboxDataBit.SelectedIndex);
            #endregion

            #region 패리티 코드
            mTileStruct.SerialData.ParityCode = (Parity)cboxParity.SelectedIndex;
            #endregion

            #region 정지 비트
            mTileStruct.SerialData.StopBitCode = (StopBits)cboxStopBit.SelectedIndex;
            #endregion

            #region 흐름 제어
            mTileStruct.SerialData.FlowControl = (SerialStruct.FlowC)cboxFlow.SelectedIndex;
            #endregion

            #region 매크로 활성화
            mTileStruct.SerialData.MacroEnable = toggleEnable.Checked;
            #endregion

            #region 반복 딜레이
            mTileStruct.SerialData.RunDelay = int.Parse(tboxDelay.Text);
            #endregion

            #region 타일 색상
            mTileStruct.TileColor = (Const.StyleType)cboxTileColor.SelectedIndex;
            #endregion

            #region 로그 관련

            mTileStruct.SerialData.LogSave = toggleLogSave.Checked;
            mTileStruct.SerialData.LogSaveType = (Const.LogSaveType)cboxLogSaveType.SelectedIndex;
            mTileStruct.SerialData.LogToken = (Const.LogToken)cboxLogToken.SelectedIndex;
            mTileStruct.SerialData.LogSavePath = tboxLogSavePath.Text;

            #endregion

            SaveSerialDataEvent();
            mTileStruct.SerialData.Open();
            mTileStruct.RefreshButton();
        }

        /// <summary>
        /// 매크로 - 저장 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMacroSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Languages.Msg_Macro_Save, Languages.Msg_Title_Save, MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                //lock (Const.LOCK_OBJ)
                {
                    int nMacroCnt = gridMacro.RowCount;
                    if (nMacroCnt > 0)
                    {
                        mTileStruct.SerialData.MacroList.Clear();

                        for (int i = 0; i < nMacroCnt - 1; i++)
                        {
                            MacroStruct macroStruct = new MacroStruct() ;
                            macroStruct.MacroName = gridMacro.Rows[i].Cells[(int)GridStuff.GridIdx_Name].Value.ToString();
                            macroStruct.Macro = gridMacro.Rows[i].Cells[(int)GridStuff.GridIdx_Macro].Value.ToString();

                            macroStruct.Enable = (bool)gridMacro.Rows[i].Cells[(int)GridStuff.GridIdx_Enable].EditedFormattedValue;

                            mTileStruct.SerialData.MacroList.Add(macroStruct);
                        }
                    }
                }
                SaveSerialDataEvent();

                MessageBox.Show("완료");
            }
        }

        /// <summary>
        /// 설정 - 반복 딜레이 - 입력값이 숫자인지 확인하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tboxDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || 
                  e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 설정 - 반복 딜레이 - ▲ 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelayUp_Click(object sender, EventArgs e)
        {
            int nCurDelay = int.Parse(tboxDelay.Text);
            tboxDelay.Text = (nCurDelay + 1).ToString();
        }

        /// <summary>
        /// 설정 - 반복 딜레이 - ▼ 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelayDown_Click(object sender, EventArgs e)
        {
            int nCurDelay = int.Parse(tboxDelay.Text);
            nCurDelay -= 1;
            if (nCurDelay < 0)
                tboxDelay.Text = "0";
            else
                tboxDelay.Text = nCurDelay.ToString();
        }

        /// <summary>
        /// 설정 - 로그 저장 경로 - 찾아 보기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogPathFind_Click(object sender, EventArgs e)
        {
            using (CommonOpenFileDialog dlgFind = new CommonOpenFileDialog())
            {
                dlgFind.IsFolderPicker = true;
                if (dlgFind.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tboxLogSavePath.Text = dlgFind.FileName;
                }
            }
            FocusMe();
        }

        /// <summary>
        /// 설정 - 취소 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
