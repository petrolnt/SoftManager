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
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripInstallProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUninstallProgramm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
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
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(297, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInstallProgramm,
            this.toolStripUninstallProgramm,
            this.toolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripInstallProgramm
            // 
            this.toolStripInstallProgramm.Name = "toolStripInstallProgramm";
            this.toolStripInstallProgramm.Size = new System.Drawing.Size(190, 22);
            this.toolStripInstallProgramm.Text = "Установка программ";
            this.toolStripInstallProgramm.Click += new System.EventHandler(this.installProgramToolStripMenuItem_Click);
            // 
            // toolStripUninstallProgramm
            // 
            this.toolStripUninstallProgramm.Name = "toolStripUninstallProgramm";
            this.toolStripUninstallProgramm.Size = new System.Drawing.Size(190, 22);
            this.toolStripUninstallProgramm.Text = "Удаление программ";
            this.toolStripUninstallProgramm.Click += new System.EventHandler(this.uninstallProgramToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItem1.Text = "Закрыть";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.helpToolStripMenuItem.Text = "Справка";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Установка программ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Удаление программ";
            // 
            // btnRemoteUninstaller
            // 
            this.btnRemoteUninstaller.BackgroundImage = global::SoftManager.Properties.Resources.SystemUninstallIcon;
            this.btnRemoteUninstaller.Location = new System.Drawing.Point(157, 54);
            this.btnRemoteUninstaller.Name = "btnRemoteUninstaller";
            this.btnRemoteUninstaller.Size = new System.Drawing.Size(128, 128);
            this.btnRemoteUninstaller.TabIndex = 1;
            this.btnRemoteUninstaller.UseVisualStyleBackColor = true;
            this.btnRemoteUninstaller.Click += new System.EventHandler(this.btnRemoteUninstaller_Click);
            // 
            // btnRemoteInstaller
            // 
            this.btnRemoteInstaller.BackgroundImage = global::SoftManager.Properties.Resources.SystemInstallIcon;
            this.btnRemoteInstaller.Location = new System.Drawing.Point(12, 54);
            this.btnRemoteInstaller.Name = "btnRemoteInstaller";
            this.btnRemoteInstaller.Size = new System.Drawing.Size(128, 128);
            this.btnRemoteInstaller.TabIndex = 0;
            this.btnRemoteInstaller.UseVisualStyleBackColor = true;
            this.btnRemoteInstaller.Click += new System.EventHandler(this.button1_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "D:\\programming\\C#\\Справка по SoftManager\\SoftManager.chm";
            // 
            // FormSoftManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 192);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoteUninstaller);
            this.Controls.Add(this.btnRemoteInstaller);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormSoftManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoftManager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoteInstaller;
        private System.Windows.Forms.Button btnRemoteUninstaller;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripInstallProgramm;
        private System.Windows.Forms.ToolStripMenuItem toolStripUninstallProgramm;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

