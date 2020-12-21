namespace SeeReal.Struct
{
    partial class TileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileForm));
            this.tabTileForm = new MetroFramework.Controls.MetroTabControl();
            this.pageMacro = new MetroFramework.Controls.MetroTabPage();
            this.btnMacroSave = new MetroFramework.Controls.MetroButton();
            this.gridMacro = new MetroFramework.Controls.MetroGrid();
            this.ColMacroName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMacro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMacroEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pageLog = new MetroFramework.Controls.MetroTabPage();
            this.tboxLog = new MetroFramework.Controls.MetroTextBox();
            this.pageSettings = new MetroFramework.Controls.MetroTabPage();
            this.cboxLogToken = new MetroFramework.Controls.MetroComboBox();
            this.lblLogToken = new MetroFramework.Controls.MetroLabel();
            this.cboxLogSaveType = new MetroFramework.Controls.MetroComboBox();
            this.lblLogType = new MetroFramework.Controls.MetroLabel();
            this.btnLogPathFind = new MetroFramework.Controls.MetroButton();
            this.lblLogEnable = new MetroFramework.Controls.MetroLabel();
            this.toggleLogSave = new MetroFramework.Controls.MetroToggle();
            this.tboxLogSavePath = new MetroFramework.Controls.MetroTextBox();
            this.lblLogSavePath = new MetroFramework.Controls.MetroLabel();
            this.cboxTileColor = new MetroFramework.Controls.MetroComboBox();
            this.cboxFlow = new MetroFramework.Controls.MetroComboBox();
            this.cboxStopBit = new MetroFramework.Controls.MetroComboBox();
            this.cboxParity = new MetroFramework.Controls.MetroComboBox();
            this.cboxDataBit = new MetroFramework.Controls.MetroComboBox();
            this.cboxBaudRate = new MetroFramework.Controls.MetroComboBox();
            this.cboxPort = new MetroFramework.Controls.MetroComboBox();
            this.tboxSerialName = new MetroFramework.Controls.MetroTextBox();
            this.lblFlow = new MetroFramework.Controls.MetroLabel();
            this.lblStopBit = new MetroFramework.Controls.MetroLabel();
            this.lblParity = new MetroFramework.Controls.MetroLabel();
            this.lblDataBit = new MetroFramework.Controls.MetroLabel();
            this.lblBaudRate = new MetroFramework.Controls.MetroLabel();
            this.lblPort = new MetroFramework.Controls.MetroLabel();
            this.lblSerialName = new MetroFramework.Controls.MetroLabel();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnAdapt = new MetroFramework.Controls.MetroButton();
            this.lblTileColor = new MetroFramework.Controls.MetroLabel();
            this.btnDelayDown = new MetroFramework.Controls.MetroButton();
            this.tboxDelay = new MetroFramework.Controls.MetroTextBox();
            this.btnDelayUp = new MetroFramework.Controls.MetroButton();
            this.lblDelay = new MetroFramework.Controls.MetroLabel();
            this.lblMacroEnable = new MetroFramework.Controls.MetroLabel();
            this.toggleEnable = new MetroFramework.Controls.MetroToggle();
            this.ctrlTileThemeMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabTileForm.SuspendLayout();
            this.pageMacro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMacro)).BeginInit();
            this.pageLog.SuspendLayout();
            this.pageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTileThemeMgr)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTileForm
            // 
            this.tabTileForm.Controls.Add(this.pageMacro);
            this.tabTileForm.Controls.Add(this.pageLog);
            this.tabTileForm.Controls.Add(this.pageSettings);
            resources.ApplyResources(this.tabTileForm, "tabTileForm");
            this.tabTileForm.Name = "tabTileForm";
            this.tabTileForm.SelectedIndex = 2;
            this.tabTileForm.UseSelectable = true;
            // 
            // pageMacro
            // 
            this.pageMacro.Controls.Add(this.btnMacroSave);
            this.pageMacro.Controls.Add(this.gridMacro);
            this.pageMacro.HorizontalScrollbarBarColor = true;
            this.pageMacro.HorizontalScrollbarHighlightOnWheel = false;
            this.pageMacro.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.pageMacro, "pageMacro");
            this.pageMacro.Name = "pageMacro";
            this.pageMacro.VerticalScrollbarBarColor = true;
            this.pageMacro.VerticalScrollbarHighlightOnWheel = false;
            this.pageMacro.VerticalScrollbarSize = 10;
            // 
            // btnMacroSave
            // 
            resources.ApplyResources(this.btnMacroSave, "btnMacroSave");
            this.btnMacroSave.Name = "btnMacroSave";
            this.btnMacroSave.UseSelectable = true;
            this.btnMacroSave.Click += new System.EventHandler(this.btnMacroSave_Click);
            // 
            // gridMacro
            // 
            this.gridMacro.AllowUserToResizeRows = false;
            this.gridMacro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridMacro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridMacro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridMacro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMacro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridMacro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMacro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMacroName,
            this.ColMacro,
            this.ColMacroEnable});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMacro.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridMacro.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.gridMacro, "gridMacro");
            this.gridMacro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridMacro.Name = "gridMacro";
            this.gridMacro.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMacro.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridMacro.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMacro.RowTemplate.Height = 23;
            this.gridMacro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // ColMacroName
            // 
            resources.ApplyResources(this.ColMacroName, "ColMacroName");
            this.ColMacroName.Name = "ColMacroName";
            this.ColMacroName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColMacro
            // 
            resources.ApplyResources(this.ColMacro, "ColMacro");
            this.ColMacro.Name = "ColMacro";
            this.ColMacro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColMacroEnable
            // 
            resources.ApplyResources(this.ColMacroEnable, "ColMacroEnable");
            this.ColMacroEnable.Name = "ColMacroEnable";
            // 
            // pageLog
            // 
            this.pageLog.Controls.Add(this.tboxLog);
            this.pageLog.HorizontalScrollbarBarColor = true;
            this.pageLog.HorizontalScrollbarHighlightOnWheel = false;
            this.pageLog.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.pageLog, "pageLog");
            this.pageLog.Name = "pageLog";
            this.pageLog.VerticalScrollbarBarColor = true;
            this.pageLog.VerticalScrollbarHighlightOnWheel = false;
            this.pageLog.VerticalScrollbarSize = 10;
            // 
            // tboxLog
            // 
            // 
            // 
            // 
            this.tboxLog.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.tboxLog.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.tboxLog.CustomButton.Name = "";
            this.tboxLog.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.tboxLog.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tboxLog.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.tboxLog.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tboxLog.CustomButton.UseSelectable = true;
            this.tboxLog.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.tboxLog.Lines = new string[0];
            resources.ApplyResources(this.tboxLog, "tboxLog");
            this.tboxLog.MaxLength = 32767;
            this.tboxLog.Multiline = true;
            this.tboxLog.Name = "tboxLog";
            this.tboxLog.PasswordChar = '\0';
            this.tboxLog.ReadOnly = true;
            this.tboxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxLog.SelectedText = "";
            this.tboxLog.SelectionLength = 0;
            this.tboxLog.SelectionStart = 0;
            this.tboxLog.ShortcutsEnabled = true;
            this.tboxLog.UseSelectable = true;
            this.tboxLog.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tboxLog.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.cboxLogToken);
            this.pageSettings.Controls.Add(this.lblLogToken);
            this.pageSettings.Controls.Add(this.cboxLogSaveType);
            this.pageSettings.Controls.Add(this.lblLogType);
            this.pageSettings.Controls.Add(this.btnLogPathFind);
            this.pageSettings.Controls.Add(this.lblLogEnable);
            this.pageSettings.Controls.Add(this.toggleLogSave);
            this.pageSettings.Controls.Add(this.tboxLogSavePath);
            this.pageSettings.Controls.Add(this.lblLogSavePath);
            this.pageSettings.Controls.Add(this.cboxTileColor);
            this.pageSettings.Controls.Add(this.cboxFlow);
            this.pageSettings.Controls.Add(this.cboxStopBit);
            this.pageSettings.Controls.Add(this.cboxParity);
            this.pageSettings.Controls.Add(this.cboxDataBit);
            this.pageSettings.Controls.Add(this.cboxBaudRate);
            this.pageSettings.Controls.Add(this.cboxPort);
            this.pageSettings.Controls.Add(this.tboxSerialName);
            this.pageSettings.Controls.Add(this.lblFlow);
            this.pageSettings.Controls.Add(this.lblStopBit);
            this.pageSettings.Controls.Add(this.lblParity);
            this.pageSettings.Controls.Add(this.lblDataBit);
            this.pageSettings.Controls.Add(this.lblBaudRate);
            this.pageSettings.Controls.Add(this.lblPort);
            this.pageSettings.Controls.Add(this.lblSerialName);
            this.pageSettings.Controls.Add(this.btnCancel);
            this.pageSettings.Controls.Add(this.btnAdapt);
            this.pageSettings.Controls.Add(this.lblTileColor);
            this.pageSettings.Controls.Add(this.btnDelayDown);
            this.pageSettings.Controls.Add(this.tboxDelay);
            this.pageSettings.Controls.Add(this.btnDelayUp);
            this.pageSettings.Controls.Add(this.lblDelay);
            this.pageSettings.Controls.Add(this.lblMacroEnable);
            this.pageSettings.Controls.Add(this.toggleEnable);
            this.pageSettings.HorizontalScrollbarBarColor = true;
            this.pageSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.pageSettings.HorizontalScrollbarSize = 10;
            resources.ApplyResources(this.pageSettings, "pageSettings");
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.VerticalScrollbarBarColor = true;
            this.pageSettings.VerticalScrollbarHighlightOnWheel = false;
            this.pageSettings.VerticalScrollbarSize = 10;
            // 
            // cboxLogToken
            // 
            this.cboxLogToken.FormattingEnabled = true;
            resources.ApplyResources(this.cboxLogToken, "cboxLogToken");
            this.cboxLogToken.Name = "cboxLogToken";
            this.cboxLogToken.UseSelectable = true;
            // 
            // lblLogToken
            // 
            resources.ApplyResources(this.lblLogToken, "lblLogToken");
            this.lblLogToken.Name = "lblLogToken";
            // 
            // cboxLogSaveType
            // 
            this.cboxLogSaveType.FormattingEnabled = true;
            resources.ApplyResources(this.cboxLogSaveType, "cboxLogSaveType");
            this.cboxLogSaveType.Name = "cboxLogSaveType";
            this.cboxLogSaveType.UseSelectable = true;
            // 
            // lblLogType
            // 
            resources.ApplyResources(this.lblLogType, "lblLogType");
            this.lblLogType.Name = "lblLogType";
            // 
            // btnLogPathFind
            // 
            resources.ApplyResources(this.btnLogPathFind, "btnLogPathFind");
            this.btnLogPathFind.Name = "btnLogPathFind";
            this.btnLogPathFind.UseSelectable = true;
            this.btnLogPathFind.Click += new System.EventHandler(this.btnLogPathFind_Click);
            // 
            // lblLogEnable
            // 
            resources.ApplyResources(this.lblLogEnable, "lblLogEnable");
            this.lblLogEnable.Name = "lblLogEnable";
            // 
            // toggleLogSave
            // 
            resources.ApplyResources(this.toggleLogSave, "toggleLogSave");
            this.toggleLogSave.Name = "toggleLogSave";
            this.toggleLogSave.UseSelectable = true;
            // 
            // tboxLogSavePath
            // 
            // 
            // 
            // 
            this.tboxLogSavePath.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.tboxLogSavePath.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.tboxLogSavePath.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.tboxLogSavePath.CustomButton.Name = "";
            this.tboxLogSavePath.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.tboxLogSavePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tboxLogSavePath.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.tboxLogSavePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tboxLogSavePath.CustomButton.UseSelectable = true;
            this.tboxLogSavePath.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.tboxLogSavePath.Lines = new string[0];
            resources.ApplyResources(this.tboxLogSavePath, "tboxLogSavePath");
            this.tboxLogSavePath.MaxLength = 32767;
            this.tboxLogSavePath.Name = "tboxLogSavePath";
            this.tboxLogSavePath.PasswordChar = '\0';
            this.tboxLogSavePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tboxLogSavePath.SelectedText = "";
            this.tboxLogSavePath.SelectionLength = 0;
            this.tboxLogSavePath.SelectionStart = 0;
            this.tboxLogSavePath.ShortcutsEnabled = true;
            this.tboxLogSavePath.UseSelectable = true;
            this.tboxLogSavePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tboxLogSavePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLogSavePath
            // 
            resources.ApplyResources(this.lblLogSavePath, "lblLogSavePath");
            this.lblLogSavePath.Name = "lblLogSavePath";
            // 
            // cboxTileColor
            // 
            this.cboxTileColor.FormattingEnabled = true;
            resources.ApplyResources(this.cboxTileColor, "cboxTileColor");
            this.cboxTileColor.Name = "cboxTileColor";
            this.cboxTileColor.UseSelectable = true;
            // 
            // cboxFlow
            // 
            this.cboxFlow.FormattingEnabled = true;
            resources.ApplyResources(this.cboxFlow, "cboxFlow");
            this.cboxFlow.Name = "cboxFlow";
            this.cboxFlow.UseSelectable = true;
            // 
            // cboxStopBit
            // 
            this.cboxStopBit.FormattingEnabled = true;
            resources.ApplyResources(this.cboxStopBit, "cboxStopBit");
            this.cboxStopBit.Name = "cboxStopBit";
            this.cboxStopBit.UseSelectable = true;
            // 
            // cboxParity
            // 
            this.cboxParity.FormattingEnabled = true;
            resources.ApplyResources(this.cboxParity, "cboxParity");
            this.cboxParity.Name = "cboxParity";
            this.cboxParity.UseSelectable = true;
            // 
            // cboxDataBit
            // 
            this.cboxDataBit.FormattingEnabled = true;
            resources.ApplyResources(this.cboxDataBit, "cboxDataBit");
            this.cboxDataBit.Name = "cboxDataBit";
            this.cboxDataBit.UseSelectable = true;
            // 
            // cboxBaudRate
            // 
            this.cboxBaudRate.FormattingEnabled = true;
            resources.ApplyResources(this.cboxBaudRate, "cboxBaudRate");
            this.cboxBaudRate.Name = "cboxBaudRate";
            this.cboxBaudRate.UseSelectable = true;
            // 
            // cboxPort
            // 
            this.cboxPort.FormattingEnabled = true;
            resources.ApplyResources(this.cboxPort, "cboxPort");
            this.cboxPort.Name = "cboxPort";
            this.cboxPort.UseSelectable = true;
            // 
            // tboxSerialName
            // 
            // 
            // 
            // 
            this.tboxSerialName.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.tboxSerialName.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.tboxSerialName.CustomButton.Name = "";
            this.tboxSerialName.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.tboxSerialName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tboxSerialName.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.tboxSerialName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tboxSerialName.CustomButton.UseSelectable = true;
            this.tboxSerialName.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.tboxSerialName.Lines = new string[0];
            resources.ApplyResources(this.tboxSerialName, "tboxSerialName");
            this.tboxSerialName.MaxLength = 32767;
            this.tboxSerialName.Name = "tboxSerialName";
            this.tboxSerialName.PasswordChar = '\0';
            this.tboxSerialName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tboxSerialName.SelectedText = "";
            this.tboxSerialName.SelectionLength = 0;
            this.tboxSerialName.SelectionStart = 0;
            this.tboxSerialName.ShortcutsEnabled = true;
            this.tboxSerialName.UseSelectable = true;
            this.tboxSerialName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tboxSerialName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblFlow
            // 
            resources.ApplyResources(this.lblFlow, "lblFlow");
            this.lblFlow.Name = "lblFlow";
            // 
            // lblStopBit
            // 
            resources.ApplyResources(this.lblStopBit, "lblStopBit");
            this.lblStopBit.Name = "lblStopBit";
            // 
            // lblParity
            // 
            resources.ApplyResources(this.lblParity, "lblParity");
            this.lblParity.Name = "lblParity";
            // 
            // lblDataBit
            // 
            resources.ApplyResources(this.lblDataBit, "lblDataBit");
            this.lblDataBit.Name = "lblDataBit";
            // 
            // lblBaudRate
            // 
            resources.ApplyResources(this.lblBaudRate, "lblBaudRate");
            this.lblBaudRate.Name = "lblBaudRate";
            // 
            // lblPort
            // 
            resources.ApplyResources(this.lblPort, "lblPort");
            this.lblPort.Name = "lblPort";
            // 
            // lblSerialName
            // 
            resources.ApplyResources(this.lblSerialName, "lblSerialName");
            this.lblSerialName.Name = "lblSerialName";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdapt
            // 
            resources.ApplyResources(this.btnAdapt, "btnAdapt");
            this.btnAdapt.Name = "btnAdapt";
            this.btnAdapt.UseSelectable = true;
            this.btnAdapt.Click += new System.EventHandler(this.btnAdapt_Click);
            // 
            // lblTileColor
            // 
            resources.ApplyResources(this.lblTileColor, "lblTileColor");
            this.lblTileColor.Name = "lblTileColor";
            // 
            // btnDelayDown
            // 
            resources.ApplyResources(this.btnDelayDown, "btnDelayDown");
            this.btnDelayDown.Name = "btnDelayDown";
            this.btnDelayDown.UseSelectable = true;
            this.btnDelayDown.Click += new System.EventHandler(this.btnDelayDown_Click);
            // 
            // tboxDelay
            // 
            // 
            // 
            // 
            this.tboxDelay.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.tboxDelay.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.tboxDelay.CustomButton.Name = "";
            this.tboxDelay.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.tboxDelay.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tboxDelay.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.tboxDelay.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tboxDelay.CustomButton.UseSelectable = true;
            this.tboxDelay.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible3")));
            this.tboxDelay.Lines = new string[0];
            resources.ApplyResources(this.tboxDelay, "tboxDelay");
            this.tboxDelay.MaxLength = 32767;
            this.tboxDelay.Name = "tboxDelay";
            this.tboxDelay.PasswordChar = '\0';
            this.tboxDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tboxDelay.SelectedText = "";
            this.tboxDelay.SelectionLength = 0;
            this.tboxDelay.SelectionStart = 0;
            this.tboxDelay.ShortcutsEnabled = true;
            this.tboxDelay.UseSelectable = true;
            this.tboxDelay.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tboxDelay.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tboxDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxDelay_KeyPress);
            // 
            // btnDelayUp
            // 
            resources.ApplyResources(this.btnDelayUp, "btnDelayUp");
            this.btnDelayUp.Name = "btnDelayUp";
            this.btnDelayUp.UseSelectable = true;
            this.btnDelayUp.Click += new System.EventHandler(this.btnDelayUp_Click);
            // 
            // lblDelay
            // 
            resources.ApplyResources(this.lblDelay, "lblDelay");
            this.lblDelay.Name = "lblDelay";
            // 
            // lblMacroEnable
            // 
            resources.ApplyResources(this.lblMacroEnable, "lblMacroEnable");
            this.lblMacroEnable.Name = "lblMacroEnable";
            // 
            // toggleEnable
            // 
            resources.ApplyResources(this.toggleEnable, "toggleEnable");
            this.toggleEnable.Name = "toggleEnable";
            this.toggleEnable.UseSelectable = true;
            // 
            // ctrlTileThemeMgr
            // 
            this.ctrlTileThemeMgr.Owner = this;
            // 
            // TileForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabTileForm);
            this.Name = "TileForm";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileForm_FormClosing);
            this.tabTileForm.ResumeLayout(false);
            this.pageMacro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMacro)).EndInit();
            this.pageLog.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.pageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlTileThemeMgr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabTileForm;
        private MetroFramework.Controls.MetroTabPage pageMacro;
        private MetroFramework.Controls.MetroTabPage pageSettings;
        private MetroFramework.Controls.MetroGrid gridMacro;
        private MetroFramework.Controls.MetroButton btnDelayUp;
        private MetroFramework.Controls.MetroLabel lblDelay;
        private MetroFramework.Controls.MetroLabel lblMacroEnable;
        private MetroFramework.Controls.MetroToggle toggleEnable;
        private MetroFramework.Controls.MetroButton btnDelayDown;
        private MetroFramework.Controls.MetroTextBox tboxDelay;
        private MetroFramework.Controls.MetroLabel lblTileColor;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnAdapt;
        private MetroFramework.Components.MetroStyleManager ctrlTileThemeMgr;
        private MetroFramework.Controls.MetroButton btnMacroSave;
        private MetroFramework.Controls.MetroLabel lblSerialName;
        private MetroFramework.Controls.MetroLabel lblStopBit;
        private MetroFramework.Controls.MetroLabel lblParity;
        private MetroFramework.Controls.MetroLabel lblDataBit;
        private MetroFramework.Controls.MetroLabel lblBaudRate;
        private MetroFramework.Controls.MetroLabel lblPort;
        private MetroFramework.Controls.MetroComboBox cboxFlow;
        private MetroFramework.Controls.MetroComboBox cboxStopBit;
        private MetroFramework.Controls.MetroComboBox cboxParity;
        private MetroFramework.Controls.MetroComboBox cboxDataBit;
        private MetroFramework.Controls.MetroComboBox cboxBaudRate;
        private MetroFramework.Controls.MetroComboBox cboxPort;
        private MetroFramework.Controls.MetroTextBox tboxSerialName;
        private MetroFramework.Controls.MetroLabel lblFlow;
        private MetroFramework.Controls.MetroComboBox cboxTileColor;
        private MetroFramework.Controls.MetroTabPage pageLog;
        private MetroFramework.Controls.MetroTextBox tboxLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMacroName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMacro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColMacroEnable;
        private MetroFramework.Controls.MetroLabel lblLogSavePath;
        private MetroFramework.Controls.MetroButton btnLogPathFind;
        private MetroFramework.Controls.MetroLabel lblLogEnable;
        private MetroFramework.Controls.MetroToggle toggleLogSave;
        private MetroFramework.Controls.MetroTextBox tboxLogSavePath;
        private MetroFramework.Controls.MetroComboBox cboxLogSaveType;
        private MetroFramework.Controls.MetroLabel lblLogType;
        private MetroFramework.Controls.MetroComboBox cboxLogToken;
        private MetroFramework.Controls.MetroLabel lblLogToken;
    }
}