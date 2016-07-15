using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace SoftManager
{
    /// <summary>
    /// таблица в которой отображается полученный с компьютера при сканировании список програмного обеспечения
    /// </summary>
    class SoftGridView : DataGridView
    {
            DataGridViewCheckBoxColumn enable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            DataGridViewTextBoxColumn IdentifyingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn SoftName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn InstallDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            string admin;

            public string Admin
            {
                get { return admin; }
                set { admin = value; }
            }

            string password;

            public string Password
            {
                get { return password; }
                set { password = value; }
            }

            string computer;

            public string Computer
            {
                get { return computer; }
                set { computer = value; }
            }

        public SoftGridView()
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            
            this.BackgroundColor = System.Drawing.SystemColors.Window;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            enable,
            this.IdentifyingNumber,
            this.SoftName,
            this.Version,
            this.InstallDate});
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "softGridView";
            this.RowHeadersVisible = false;
            this.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Size = new System.Drawing.Size(576, 467);
            this.TabIndex = 0;

            this.enable.Frozen = true;
            this.enable.HeaderText = Properties.Resources.Select;
            this.enable.Name = "enable";
            this.enable.Width = 57;

            this.IdentifyingNumber.Frozen = true;
            this.IdentifyingNumber.HeaderText = Properties.Resources.ApplicationID;
            this.IdentifyingNumber.Name = "IdentifyingNumber";
            this.IdentifyingNumber.Visible = false;
            this.IdentifyingNumber.Width = 112;

            this.SoftName.Frozen = true;
            this.SoftName.HeaderText = Properties.Resources.Application;
            this.SoftName.Name = "SoftName";
            this.SoftName.ReadOnly = true;
            this.SoftName.Width = 91;

            this.Version.Frozen = true;
            this.Version.HeaderText = Properties.Resources.Version;
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Width = 69;

            this.InstallDate.Frozen = true;
            this.InstallDate.HeaderText = Properties.Resources.DateOfInstalation;
            this.InstallDate.Name = "InstallDate";
            this.InstallDate.ReadOnly = true;
            this.InstallDate.Width = 106;
            this.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MultiSelect = false;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
