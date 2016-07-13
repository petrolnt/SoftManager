namespace SoftManager
{
    partial class FormSoftManager
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSoftManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInstallProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUninstallProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSoftwareInstall = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoteUninstaller = new System.Windows.Forms.Button();
            this.btnRemoteInstaller = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFile,
            this.tsmHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // tsmFile
            // 
            this.tsmFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsInstallProgramm,
            this.tsUninstallProgramm,
            this.tsMenuClose});
            this.tsmFile.Name = "tsmFile";
            resources.ApplyResources(this.tsmFile, "tsmFile");
            // 
            // tsInstallProgramm
            // 
            this.tsInstallProgramm.Name = "tsInstallProgramm";
            resources.ApplyResources(this.tsInstallProgramm, "tsInstallProgramm");
            this.tsInstallProgramm.Click += new System.EventHandler(this.installProgramToolStripMenuItem_Click);
            // 
            // tsUninstallProgramm
            // 
            this.tsUninstallProgramm.Name = "tsUninstallProgramm";
            resources.ApplyResources(this.tsUninstallProgramm, "tsUninstallProgramm");
            this.tsUninstallProgramm.Click += new System.EventHandler(this.uninstallProgramToolStripMenuItem_Click);
            // 
            // tsMenuClose
            // 
            this.tsMenuClose.Name = "tsMenuClose";
            resources.ApplyResources(this.tsMenuClose, "tsMenuClose");
            this.tsMenuClose.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsHelp,
            this.tsAbout});
            this.tsmHelp.Name = "tsmHelp";
            resources.ApplyResources(this.tsmHelp, "tsmHelp");
            // 
            // tsHelp
            // 
            this.tsHelp.Name = "tsHelp";
            resources.ApplyResources(this.tsHelp, "tsHelp");
            this.tsHelp.Click += new System.EventHandler(this.справкаToolStripMenuItem1_Click);
            // 
            // tsAbout
            // 
            this.tsAbout.Name = "tsAbout";
            resources.ApplyResources(this.tsAbout, "tsAbout");
            this.tsAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblSoftwareInstall
            // 
            resources.ApplyResources(this.lblSoftwareInstall, "lblSoftwareInstall");
            this.lblSoftwareInstall.Name = "lblSoftwareInstall";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnRemoteUninstaller
            // 
            this.btnRemoteUninstaller.BackgroundImage = global::SoftManager.Properties.Resources.SystemUninstallIcon;
            resources.ApplyResources(this.btnRemoteUninstaller, "btnRemoteUninstaller");
            this.btnRemoteUninstaller.Name = "btnRemoteUninstaller";
            this.btnRemoteUninstaller.UseVisualStyleBackColor = true;
            this.btnRemoteUninstaller.Click += new System.EventHandler(this.btnRemoteUninstaller_Click);
            // 
            // btnRemoteInstaller
            // 
            this.btnRemoteInstaller.BackgroundImage = global::SoftManager.Properties.Resources.SystemInstallIcon;
            resources.ApplyResources(this.btnRemoteInstaller, "btnRemoteInstaller");
            this.btnRemoteInstaller.Name = "btnRemoteInstaller";
            this.btnRemoteInstaller.UseVisualStyleBackColor = true;
            this.btnRemoteInstaller.Click += new System.EventHandler(this.button1_Click);
            // 
            // helpProvider1
            // 
            resources.ApplyResources(this.helpProvider1, "helpProvider1");
            // 
            // FormSoftManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSoftwareInstall);
            this.Controls.Add(this.btnRemoteUninstaller);
            this.Controls.Add(this.btnRemoteInstaller);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSoftManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoteInstaller;
        private System.Windows.Forms.Button btnRemoteUninstaller;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmFile;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsMenuClose;
        private System.Windows.Forms.ToolStripMenuItem tsAbout;
        private System.Windows.Forms.Label lblSoftwareInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem tsInstallProgramm;
        private System.Windows.Forms.ToolStripMenuItem tsUninstallProgramm;
        private System.Windows.Forms.ToolStripMenuItem tsHelp;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

