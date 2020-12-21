namespace SeeReal
{
    partial class SettingsForm
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
            this.lblLanguage = new MetroFramework.Controls.MetroLabel();
            this.cboxLanguage = new MetroFramework.Controls.MetroComboBox();
            this.lblMainTheme = new MetroFramework.Controls.MetroLabel();
            this.cboxMainTheme = new MetroFramework.Controls.MetroComboBox();
            this.lblSubStyle = new MetroFramework.Controls.MetroLabel();
            this.cboxSubStyle = new MetroFramework.Controls.MetroComboBox();
            this.ctrlSettingsThemeMgr = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnAdapt = new MetroFramework.Controls.MetroButton();
            this.toggleTrayIcon = new MetroFramework.Controls.MetroToggle();
            this.lblTrayIcon = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSettingsThemeMgr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(23, 73);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(69, 19);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "언어 설정";
            // 
            // cboxLanguage
            // 
            this.cboxLanguage.FormattingEnabled = true;
            this.cboxLanguage.ItemHeight = 23;
            this.cboxLanguage.Location = new System.Drawing.Point(177, 68);
            this.cboxLanguage.Name = "cboxLanguage";
            this.cboxLanguage.Size = new System.Drawing.Size(121, 29);
            this.cboxLanguage.TabIndex = 1;
            this.cboxLanguage.UseSelectable = true;
            // 
            // lblMainTheme
            // 
            this.lblMainTheme.AutoSize = true;
            this.lblMainTheme.Location = new System.Drawing.Point(23, 120);
            this.lblMainTheme.Name = "lblMainTheme";
            this.lblMainTheme.Size = new System.Drawing.Size(69, 19);
            this.lblMainTheme.TabIndex = 2;
            this.lblMainTheme.Text = "메인 테마";
            // 
            // cboxMainTheme
            // 
            this.cboxMainTheme.FormattingEnabled = true;
            this.cboxMainTheme.ItemHeight = 23;
            this.cboxMainTheme.Location = new System.Drawing.Point(177, 116);
            this.cboxMainTheme.Name = "cboxMainTheme";
            this.cboxMainTheme.Size = new System.Drawing.Size(121, 29);
            this.cboxMainTheme.TabIndex = 3;
            this.cboxMainTheme.UseSelectable = true;
            // 
            // lblSubStyle
            // 
            this.lblSubStyle.AutoSize = true;
            this.lblSubStyle.Location = new System.Drawing.Point(23, 167);
            this.lblSubStyle.Name = "lblSubStyle";
            this.lblSubStyle.Size = new System.Drawing.Size(83, 19);
            this.lblSubStyle.TabIndex = 4;
            this.lblSubStyle.Text = "서브 스타일";
            // 
            // cboxSubStyle
            // 
            this.cboxSubStyle.FormattingEnabled = true;
            this.cboxSubStyle.ItemHeight = 23;
            this.cboxSubStyle.Location = new System.Drawing.Point(177, 164);
            this.cboxSubStyle.Name = "cboxSubStyle";
            this.cboxSubStyle.Size = new System.Drawing.Size(121, 29);
            this.cboxSubStyle.TabIndex = 5;
            this.cboxSubStyle.UseSelectable = true;
            // 
            // ctrlSettingsThemeMgr
            // 
            this.ctrlSettingsThemeMgr.Owner = this;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 41);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdapt
            // 
            this.btnAdapt.Location = new System.Drawing.Point(588, 425);
            this.btnAdapt.Name = "btnAdapt";
            this.btnAdapt.Size = new System.Drawing.Size(97, 41);
            this.btnAdapt.TabIndex = 7;
            this.btnAdapt.Text = "적용";
            this.btnAdapt.UseSelectable = true;
            this.btnAdapt.Click += new System.EventHandler(this.btnAdapt_Click);
            // 
            // toggleTrayIcon
            // 
            this.toggleTrayIcon.AutoSize = true;
            this.toggleTrayIcon.Location = new System.Drawing.Point(597, 74);
            this.toggleTrayIcon.Name = "toggleTrayIcon";
            this.toggleTrayIcon.Size = new System.Drawing.Size(80, 16);
            this.toggleTrayIcon.TabIndex = 8;
            this.toggleTrayIcon.Text = "Off";
            this.toggleTrayIcon.UseSelectable = true;
            // 
            // lblTrayIcon
            // 
            this.lblTrayIcon.AutoSize = true;
            this.lblTrayIcon.Location = new System.Drawing.Point(443, 73);
            this.lblTrayIcon.Name = "lblTrayIcon";
            this.lblTrayIcon.Size = new System.Drawing.Size(97, 19);
            this.lblTrayIcon.TabIndex = 9;
            this.lblTrayIcon.Text = "트레이 아이콘";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 489);
            this.Controls.Add(this.lblTrayIcon);
            this.Controls.Add(this.toggleTrayIcon);
            this.Controls.Add(this.btnAdapt);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboxSubStyle);
            this.Controls.Add(this.lblSubStyle);
            this.Controls.Add(this.cboxMainTheme);
            this.Controls.Add(this.lblMainTheme);
            this.Controls.Add(this.cboxLanguage);
            this.Controls.Add(this.lblLanguage);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Resizable = false;
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSettingsThemeMgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblLanguage;
        private MetroFramework.Controls.MetroComboBox cboxLanguage;
        private MetroFramework.Controls.MetroLabel lblMainTheme;
        private MetroFramework.Controls.MetroComboBox cboxMainTheme;
        private MetroFramework.Controls.MetroLabel lblSubStyle;
        private MetroFramework.Controls.MetroComboBox cboxSubStyle;
        private MetroFramework.Components.MetroStyleManager ctrlSettingsThemeMgr;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnAdapt;
        private MetroFramework.Controls.MetroLabel lblTrayIcon;
        private MetroFramework.Controls.MetroToggle toggleTrayIcon;
    }
}