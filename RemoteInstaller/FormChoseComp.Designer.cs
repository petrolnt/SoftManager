namespace SoftManager
{
    partial class FormChoseComp
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbComputer = new System.Windows.Forms.TextBox();
            this.btnCompsImport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cBanotherUser = new System.Windows.Forms.CheckBox();
            this.tbAdmin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.MaskedTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbSoftName = new System.Windows.Forms.TextBox();
            this.btnChoseSoft = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rbNoReboot = new System.Windows.Forms.RadioButton();
            this.rbReboot = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя компьютера";
            // 
            // tbComputer
            // 
            this.tbComputer.Location = new System.Drawing.Point(10, 51);
            this.tbComputer.Multiline = true;
            this.tbComputer.Name = "tbComputer";
            this.tbComputer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComputer.Size = new System.Drawing.Size(306, 49);
            this.tbComputer.TabIndex = 1;
            this.tbComputer.TextChanged += new System.EventHandler(this.tbComputer_TextChanged);
            // 
            // btnCompsImport
            // 
            this.btnCompsImport.Location = new System.Drawing.Point(322, 51);
            this.btnCompsImport.Name = "btnCompsImport";
            this.btnCompsImport.Size = new System.Drawing.Size(34, 20);
            this.btnCompsImport.TabIndex = 2;
            this.btnCompsImport.Text = "...";
            this.btnCompsImport.UseVisualStyleBackColor = true;
            this.btnCompsImport.Click += new System.EventHandler(this.btnCompsImport_Click);
            // 
            // btnScan
            // 
            this.btnScan.AutoEllipsis = true;
            this.btnScan.Enabled = false;
            this.btnScan.Location = new System.Drawing.Point(101, 309);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(83, 23);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "Сканировать";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Выход";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cBanotherUser
            // 
            this.cBanotherUser.AutoSize = true;
            this.cBanotherUser.Location = new System.Drawing.Point(14, 152);
            this.cBanotherUser.Name = "cBanotherUser";
            this.cBanotherUser.Size = new System.Drawing.Size(190, 17);
            this.cBanotherUser.TabIndex = 5;
            this.cBanotherUser.Text = "От имени другого пользователя";
            this.cBanotherUser.UseVisualStyleBackColor = true;
            this.cBanotherUser.CheckedChanged += new System.EventHandler(this.cBanotherUser_CheckedChanged);
            // 
            // tbAdmin
            // 
            this.tbAdmin.Location = new System.Drawing.Point(10, 194);
            this.tbAdmin.Name = "tbAdmin";
            this.tbAdmin.Size = new System.Drawing.Size(143, 20);
            this.tbAdmin.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пользователь";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Укажите NETBIOS имя компьютера или IP-адрес";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(175, 194);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(141, 20);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(190, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbSoftName
            // 
            this.tbSoftName.Location = new System.Drawing.Point(10, 119);
            this.tbSoftName.Name = "tbSoftName";
            this.tbSoftName.Size = new System.Drawing.Size(306, 20);
            this.tbSoftName.TabIndex = 13;
            this.tbSoftName.TextChanged += new System.EventHandler(this.tbSoftName_TextChanged);
            // 
            // btnChoseSoft
            // 
            this.btnChoseSoft.Location = new System.Drawing.Point(322, 119);
            this.btnChoseSoft.Name = "btnChoseSoft";
            this.btnChoseSoft.Size = new System.Drawing.Size(34, 20);
            this.btnChoseSoft.TabIndex = 14;
            this.btnChoseSoft.Text = "...";
            this.btnChoseSoft.UseVisualStyleBackColor = true;
            this.btnChoseSoft.Click += new System.EventHandler(this.btnChoseSoft_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Имя программы";
            // 
            // rbNoReboot
            // 
            this.rbNoReboot.AutoSize = true;
            this.rbNoReboot.Checked = true;
            this.rbNoReboot.Location = new System.Drawing.Point(10, 232);
            this.rbNoReboot.Name = "rbNoReboot";
            this.rbNoReboot.Size = new System.Drawing.Size(202, 17);
            this.rbNoReboot.TabIndex = 16;
            this.rbNoReboot.TabStop = true;
            this.rbNoReboot.Text = "Не перезагружать после удаления";
            this.rbNoReboot.UseVisualStyleBackColor = true;
            this.rbNoReboot.CheckedChanged += new System.EventHandler(this.rbNoReboot_CheckedChanged);
            // 
            // rbReboot
            // 
            this.rbReboot.AutoSize = true;
            this.rbReboot.Location = new System.Drawing.Point(10, 256);
            this.rbReboot.Name = "rbReboot";
            this.rbReboot.Size = new System.Drawing.Size(181, 17);
            this.rbReboot.TabIndex = 17;
            this.rbReboot.TabStop = true;
            this.rbReboot.Text = "Принудительно перезагрузить";
            this.rbReboot.UseVisualStyleBackColor = true;
            this.rbReboot.CheckedChanged += new System.EventHandler(this.rbReboot_CheckedChanged);
            // 
            // FormChoseComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 348);
            this.Controls.Add(this.rbReboot);
            this.Controls.Add(this.rbNoReboot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnChoseSoft);
            this.Controls.Add(this.tbSoftName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAdmin);
            this.Controls.Add(this.cBanotherUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnCompsImport);
            this.Controls.Add(this.tbComputer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormChoseComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор компьютера";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComputer;
        private System.Windows.Forms.Button btnCompsImport;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cBanotherUser;
        private System.Windows.Forms.TextBox tbAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox tbPassword;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbSoftName;
        private System.Windows.Forms.Button btnChoseSoft;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbNoReboot;
        private System.Windows.Forms.RadioButton rbReboot;
    }
}