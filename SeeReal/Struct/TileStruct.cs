using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Const = SeeReal.GlobalConstants;

namespace SeeReal.Struct
{
    public class TileStruct : MetroTile
    {
        /// <summary>
        /// 타일의 고유 번호
        /// </summary>
        public int TileNo { get; set; }
        /// <summary>
        /// 시리얼 통신명
        /// </summary>
        public string SerialName { get; set; }
        /// <summary>
        /// 해당 타일을 클릭하여 다이얼로그가 생성되었는지 유무
        /// </summary>
        public bool IsDialogOpened { get { return mDialogOpened; }}
        /// <summary>
        /// 메인 테마 타입 (공통 설정값)
        /// </summary>
        public Const.ThemeType MainThemeType { get; set; }
        /// <summary>
        /// 메인 스타일 타입 (공통 설정값)
        /// </summary>
        public Const.StyleType MainStyleType { get; set; }
        /// <summary>
        /// 타일의 개별 색상 스타일
        /// </summary>
        public Const.StyleType TileColor { get; set; }
        /// <summary>
        /// Serial 정보
        /// </summary>
        public SerialStruct SerialData { get; set; }
        /// <summary>
        /// Serial 데이터 저장 딜리게이트
        /// </summary>
        public event Const.SaveSerialDelegate SaveSerialDataEvent = null;
        /// <summary>
        /// 새로고침 딜리게이트
        /// </summary>
        public event Const.RefreshDelegate RefreshEvent = null;


        private bool mDialogOpened = false;

        public TileStruct(int nTileNo, string strName)
        {
            TileNo = nTileNo;
            SerialData = new SerialStruct 
            {
                SerialName = string.Format("{0}{1}", strName, TileNo)
            };
            SerialData.Open();
        }

        public new void Dispose()
        {
            base.Dispose();

            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    SerialData.Dispose();
                }));
            }
            else
                SerialData.Dispose();
        }


        /// <summary>
        /// 생성된 타일이 클릭되었을 때 발생하는 이벤트
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            if (IsDialogOpened == false)
            {
                TileForm tileForm = new TileForm();
                if (SaveSerialDataEvent != null)
                    tileForm.SaveSerialDataEvent += SaveSerialDataEvent;
                if (RefreshEvent != null)
                    tileForm.RefreshEvent += RefreshEvent;
                tileForm.SetDialog(this);
                tileForm.Show();

                mDialogOpened = true;
            }

            base.OnClick(e);
        }

        public TileStruct Copy()
        {
            return (TileStruct)MemberwiseClone();
        }

        public void CloseDialog()
        {
            mDialogOpened = false;
        }

        public void RefreshButton()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate ()
                {
                    Style = (MetroFramework.MetroColorStyle)(TileColor + 1);
                }));
            }
            else
                Style = (MetroFramework.MetroColorStyle)(TileColor + 1);
        }
    }

}
