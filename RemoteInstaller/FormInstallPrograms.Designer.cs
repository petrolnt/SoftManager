namespace SoftManager
{
    partial class FormInstallPrograms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstallPrograms));
            this.compNameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathField = new System.Windows.Forms.TextBox();
            this.btnChoosePackage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.userNameField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.useOneFile = new System.Windows.Forms.RadioButton();
            this.useDirectory = new System.Windows.Forms.RadioButton();
            this.importComp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.afterInstalPanel = new System.Windows.Forms.Panel();
            this.rebootAfterInstall = new System.Windows.Forms.RadioButton();
            this.noReboot = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExeOptions = new System.Windows.Forms.Label();
            this.tbExeOptions = new System.Windows.Forms.TextBox();
            this.afterInstalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // compNameField
            // 
            resources.ApplyResources(this.compNameField, "compNameField");
            this.compNameField.Name = "compNameField";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // filePathField
            // 
            resources.ApplyResources(this.filePathField, "filePathField");
            this.filePathField.Name = "filePathField";
            this.filePathField.TextChanged += new System.EventHandler(this.filePathField_TextChanged);
            // 
            // btnChoosePackage
            // 
            resources.ApplyResources(this.btnChoosePackage, "btnChoosePackage");
            this.btnChoosePackage.Name = "btnChoosePackage";
            this.btnChoosePackage.UseVisualStyleBackColor = true;
            this.btnChoosePackage.Click += new System.EventHandler(this.btnChoosePackage_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnInstall
            // 
            resources.ApplyResources(this.btnInstall, "btnInstall");
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // userNameField
            // 
            resources.ApplyResources(this.userNameField, "userNameField");
            this.userNameField.Name = "userNameField";
            // 
            // passwordField
            // 
            resources.ApplyResources(this.passwordField, "passwordField");
            this.passwordField.Name = "passwordField";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // useOneFile
            // 
            resources.ApplyResources(this.useOneFile, "useOneFile");
            this.useOneFile.Checked = true;
            this.useOneFile.Name = "useOneFile";
            this.useOneFile.TabStop = true;
            this.useOneFile.UseVisualStyleBackColor = true;
            // 
            // useDirectory
            // 
            resources.ApplyResources(this.useDirectory, "useDirectory");
            this.useDirectory.Name = "useDirectory";
            this.useDirectory.UseVisualStyleBackColor = true;
            // 
            // importComp
            // 
            resources.ApplyResources(this.importComp, "importComp");
            this.importComp.Name = "importComp";
            this.toolTip1.SetToolTip(this.importComp, resources.GetString("importComp.ToolTip"));
            this.importComp.UseVisualStyleBackColor = true;
            this.importComp.Click += new System.EventHandler(this.importComp_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // afterInstalPanel
            // 
            this.afterInstalPanel.Controls.Add(this.rebootAfterInstall);
            this.afterInstalPanel.Controls.Add(this.noReboot);
            this.afterInstalPanel.Controls.Add(this.label5);
            resources.ApplyResources(this.afterInstalPanel, "afterInstalPanel");
            this.afterInstalPanel.Name = "afterInstalPanel";
            // 
            // rebootAfterInstall
            // 
            resources.ApplyResources(this.rebootAfterInstall, "rebootAfterInstall");
            this.rebootAfterInstall.Name = "rebootAfterInstall";
            this.rebootAfterInstall.TabStop = true;
            this.rebootAfterInstall.UseVisualStyleBackColor = true;
            this.rebootAfterInstall.CheckedChanged += new System.EventHandler(this.rebootAfterInstall_CheckedChanged);
            // 
            // noReboot
            // 
            resources.ApplyResources(this.noReboot, "noReboot");
            this.noReboot.Checked = true;
            this.noReboot.Name = "noReboot";
            this.noReboot.TabStop = true;
            this.noReboot.UseVisualStyleBackColor = true;
            this.noReboot.CheckedChanged += new System.EventHandler(this.noReboot_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblExeOptions
            // 
            resources.ApplyResources(this.lblExeOptions, "lblExeOptions");
            this.lblExeOptions.Name = "lblExeOptions";
            // 
            // tbExeOptions
            // 
            resources.ApplyResources(this.tbExeOptions, "tbExeOptions");
            this.tbExeOptions.Name = "tbExeOptions";
            // 
            // FormInstallPrograms
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.tbExeOptions);
            this.Controls.Add(this.lblExeOptions);
            this.Controls.Add(this.afterInstalPanel);
            this.Controls.Add(this.importComp);
            this.Controls.Add(this.useDirectory);
            this.Controls.Add(this.useOneFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.userNameField);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChoosePackage);
            this.Controls.Add(this.filePathField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compNameField);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInstallPrograms";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.afterInstalPanel.ResumeLayout(false);
            this.afterInstalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathField;
        private System.Windows.Forms.Button btnChoosePackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox userNameField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton useOneFile;
        private System.Windows.Forms.RadioButton useDirectory;
        private System.Windows.Forms.Button importComp;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox compNameField;
        private System.Windows.Forms.Panel afterInstalPanel;
        private System.Windows.Forms.RadioButton noReboot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rebootAfterInstall;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExeOptions;
        private System.Windows.Forms.TextBox tbExeOptions;
        
    }
}

