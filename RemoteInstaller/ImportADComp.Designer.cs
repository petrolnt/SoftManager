using System.Collections;
namespace SoftManager
{
    partial class ImportADComp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.adButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.adListBox = new System.Windows.Forms.ListBox();
            this.installListBox = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.adButton);
            this.panel1.Location = new System.Drawing.Point(-1, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 39);
            this.panel1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(198, 10);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(13, 10);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "<<";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // adButton
            // 
            this.adButton.Location = new System.Drawing.Point(103, 10);
            this.adButton.Name = "adButton";
            this.adButton.Size = new System.Drawing.Size(75, 23);
            this.adButton.TabIndex = 0;
            this.adButton.Text = ">>";
            this.adButton.UseVisualStyleBackColor = true;
            this.adButton.Click += new System.EventHandler(this.adButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 229);
            this.panel2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.adListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.installListBox);
            this.splitContainer1.Size = new System.Drawing.Size(377, 229);
            this.splitContainer1.SplitterDistance = 181;
            this.splitContainer1.TabIndex = 0;
            // 
            // adListBox
            // 
            this.adListBox.FormattingEnabled = true;
            this.adListBox.Location = new System.Drawing.Point(0, 4);
            this.adListBox.Name = "adListBox";
            this.adListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.adListBox.Size = new System.Drawing.Size(175, 225);
            this.adListBox.TabIndex = 0;
            this.adListBox.DoubleClick += new System.EventHandler(this.adButton_Click);
            // 
            // installListBox
            // 
            this.installListBox.FormattingEnabled = true;
            this.installListBox.Location = new System.Drawing.Point(5, 4);
            this.installListBox.Name = "installListBox";
            this.installListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.installListBox.Size = new System.Drawing.Size(183, 225);
            this.installListBox.TabIndex = 0;
            this.installListBox.SelectedIndexChanged += new System.EventHandler(this.installListBox_SelectedIndexChanged);
            this.installListBox.DoubleClick += new System.EventHandler(this.removeButton_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(290, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ImportADComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(375, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportADComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Импорт из Active Directory";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button adButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox adListBox;
        private System.Windows.Forms.ListBox installListBox;
        private System.Windows.Forms.Button btnCancel;


    }
}