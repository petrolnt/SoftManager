namespace SoftManager
{
    partial class ChoseItem
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
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(4, 13);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(361, 225);
            this.lbItems.TabIndex = 0;
            this.lbItems.DoubleClick += new System.EventHandler(this.btnChose_Click);
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(209, 246);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(75, 23);
            this.btnChose.TabIndex = 1;
            this.btnChose.Text = "Выбрать";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChoseItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 281);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChose);
            this.Controls.Add(this.lbItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChoseItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор программы";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnCancel;
    }
}