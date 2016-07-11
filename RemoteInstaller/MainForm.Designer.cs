namespace SoftManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.compNameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathField = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.button3 = new System.Windows.Forms.Button();
            this.lblExeOptions = new System.Windows.Forms.Label();
            this.tbExeOptions = new System.Windows.Forms.TextBox();
            this.afterInstalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // compNameField
            // 
            this.compNameField.Location = new System.Drawing.Point(19, 31);
            this.compNameField.Multiline = true;
            this.compNameField.Name = "compNameField";
            this.compNameField.Size = new System.Drawing.Size(297, 47);
            this.compNameField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите сетевое имя компьютеров или IP-адреса через ;";
            // 
            // filePathField
            // 
            this.filePathField.Location = new System.Drawing.Point(19, 105);
            this.filePathField.Name = "filePathField";
            this.filePathField.Size = new System.Drawing.Size(297, 20);
            this.filePathField.TabIndex = 2;
            this.filePathField.TextChanged += new System.EventHandler(this.filePathField_TextChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(38, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "...";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выберите установочный файл";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Установить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 243);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(216, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Установить от другого пользователя";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // userNameField
            // 
            this.userNameField.Enabled = false;
            this.userNameField.Location = new System.Drawing.Point(19, 284);
            this.userNameField.Name = "userNameField";
            this.userNameField.Size = new System.Drawing.Size(166, 20);
            this.userNameField.TabIndex = 7;
            // 
            // passwordField
            // 
            this.passwordField.Enabled = false;
            this.passwordField.Location = new System.Drawing.Point(191, 284);
            this.passwordField.Name = "passwordField";
            this.passwordField.PasswordChar = '*';
            this.passwordField.Size = new System.Drawing.Size(173, 20);
            this.passwordField.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Имя пользователя:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пароль:";
            // 
            // useOneFile
            // 
            this.useOneFile.AutoSize = true;
            this.useOneFile.Checked = true;
            this.useOneFile.Location = new System.Drawing.Point(19, 184);
            this.useOneFile.Name = "useOneFile";
            this.useOneFile.Size = new System.Drawing.Size(228, 17);
            this.useOneFile.TabIndex = 11;
            this.useOneFile.TabStop = true;
            this.useOneFile.Text = "Использовать один установочный файл";
            this.useOneFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.useOneFile.UseVisualStyleBackColor = true;
            // 
            // useDirectory
            // 
            this.useDirectory.AutoSize = true;
            this.useDirectory.Location = new System.Drawing.Point(19, 207);
            this.useDirectory.Name = "useDirectory";
            this.useDirectory.Size = new System.Drawing.Size(153, 17);
            this.useDirectory.TabIndex = 12;
            this.useDirectory.Text = "Использовать всю папку";
            this.useDirectory.UseVisualStyleBackColor = true;
            // 
            // importComp
            // 
            this.importComp.Location = new System.Drawing.Point(327, 31);
            this.importComp.Name = "importComp";
            this.importComp.Size = new System.Drawing.Size(37, 23);
            this.importComp.TabIndex = 14;
            this.importComp.Text = "...";
            this.toolTip1.SetToolTip(this.importComp, "Импортировать из Active Directory");
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
            this.afterInstalPanel.Location = new System.Drawing.Point(12, 321);
            this.afterInstalPanel.Name = "afterInstalPanel";
            this.afterInstalPanel.Size = new System.Drawing.Size(352, 94);
            this.afterInstalPanel.TabIndex = 15;
            // 
            // rebootAfterInstall
            // 
            this.rebootAfterInstall.AutoSize = true;
            this.rebootAfterInstall.Location = new System.Drawing.Point(6, 58);
            this.rebootAfterInstall.Name = "rebootAfterInstall";
            this.rebootAfterInstall.Size = new System.Drawing.Size(182, 17);
            this.rebootAfterInstall.TabIndex = 3;
            this.rebootAfterInstall.TabStop = true;
            this.rebootAfterInstall.Text = "Принудительная перезагрузка";
            this.rebootAfterInstall.UseVisualStyleBackColor = true;
            this.rebootAfterInstall.CheckedChanged += new System.EventHandler(this.rebootAfterInstall_CheckedChanged);
            // 
            // noReboot
            // 
            this.noReboot.AutoSize = true;
            this.noReboot.Checked = true;
            this.noReboot.Location = new System.Drawing.Point(6, 29);
            this.noReboot.Name = "noReboot";
            this.noReboot.Size = new System.Drawing.Size(119, 17);
            this.noReboot.TabIndex = 1;
            this.noReboot.TabStop = true;
            this.noReboot.Text = "Не перезагружать";
            this.noReboot.UseVisualStyleBackColor = true;
            this.noReboot.CheckedChanged += new System.EventHandler(this.noReboot_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Действия после  установки:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(289, 439);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblExeOptions
            // 
            this.lblExeOptions.AutoSize = true;
            this.lblExeOptions.Location = new System.Drawing.Point(19, 139);
            this.lblExeOptions.Name = "lblExeOptions";
            this.lblExeOptions.Size = new System.Drawing.Size(127, 13);
            this.lblExeOptions.TabIndex = 17;
            this.lblExeOptions.Text = "Парпаметры установки";
            // 
            // tbExeOptions
            // 
            this.tbExeOptions.Location = new System.Drawing.Point(22, 158);
            this.tbExeOptions.Name = "tbExeOptions";
            this.tbExeOptions.Size = new System.Drawing.Size(294, 20);
            this.tbExeOptions.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 474);
            this.Controls.Add(this.tbExeOptions);
            this.Controls.Add(this.lblExeOptions);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.afterInstalPanel);
            this.Controls.Add(this.importComp);
            this.Controls.Add(this.useDirectory);
            this.Controls.Add(this.useOneFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.userNameField);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.filePathField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compNameField);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Установка программ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.afterInstalPanel.ResumeLayout(false);
            this.afterInstalPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathField;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblExeOptions;
        private System.Windows.Forms.TextBox tbExeOptions;
        
    }
}

