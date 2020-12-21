namespace SeeReal
{
    partial class MainDlg
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
            this.panMain = new MetroFramework.Controls.MetroPanel();
            this.tileAdd = new MetroFramework.Controls.MetroTile();
            this.ctrlMainThemeMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tileSettings = new MetroFramework.Controls.MetroTile();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctrlTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctrlMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctrlMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlMainThemeMgr)).BeginInit();
            this.ctrlTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            resources.ApplyResources(this.panMain, "panMain");
            this.panMain.Controls.Add(this.tileAdd);
            this.panMain.HorizontalScrollbarBarColor = true;
            this.panMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panMain.HorizontalScrollbarSize = 10;
            this.panMain.Name = "panMain";
            this.panMain.VerticalScrollbarBarColor = true;
            this.panMain.VerticalScrollbarHighlightOnWheel = false;
            this.panMain.VerticalScrollbarSize = 10;
            // 
            // tileAdd
            // 
            this.tileAdd.ActiveControl = null;
            resources.ApplyResources(this.tileAdd, "tileAdd");
            this.tileAdd.Name = "tileAdd";
            this.tileAdd.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tileAdd.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tileAdd.UseSelectable = true;
            this.tileAdd.Click += new System.EventHandler(this.ctrlBtnAdd_Click);
            // 
            // ctrlMainThemeMgr
            // 
            this.ctrlMainThemeMgr.Owner = this;
            // 
            // tileSettings
            // 
            this.tileSettings.ActiveControl = null;
            resources.ApplyResources(this.tileSettings, "tileSettings");
            this.tileSettings.Name = "tileSettings";
            this.tileSettings.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tileSettings.UseSelectable = true;
            this.tileSettings.Click += new System.EventHandler(this.tileSettings_Click);
            // 
            // TrayIcon
            // 
            resources.ApplyResources(this.TrayIcon, "TrayIcon");
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // ctrlTrayMenu
            // 
            this.ctrlTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlMenuOpen,
            this.ctrlMenuExit});
            this.ctrlTrayMenu.Name = "ctrlTrayMenu";
            resources.ApplyResources(this.ctrlTrayMenu, "ctrlTrayMenu");
            // 
            // ctrlMenuOpen
            // 
            this.ctrlMenuOpen.Name = "ctrlMenuOpen";
            resources.ApplyResources(this.ctrlMenuOpen, "ctrlMenuOpen");
            // 
            // ctrlMenuExit
            // 
            this.ctrlMenuExit.Name = "ctrlMenuExit";
            resources.ApplyResources(this.ctrlMenuExit, "ctrlMenuExit");
            this.ctrlMenuExit.Click += new System.EventHandler(this.ctrlMenuExit_Click);
            // 
            // MainDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tileSettings);
            this.Controls.Add(this.panMain);
            this.MaximizeBox = false;
            this.Name = "MainDlg";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDlg_FormClosing);
            this.Resize += new System.EventHandler(this.MainDlg_Resize);
            this.panMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlMainThemeMgr)).EndInit();
            this.ctrlTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panMain;
        private MetroFramework.Controls.MetroTile tileAdd;
        private MetroFramework.Components.MetroStyleManager ctrlMainThemeMgr;
        private MetroFramework.Controls.MetroTile tileSettings;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip ctrlTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem ctrlMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem ctrlMenuExit;
    }
}

