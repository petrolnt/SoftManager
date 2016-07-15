using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace SoftManager
{
    public partial class ProgressTable : Form
    {        
        IParrentForm mainForm;
        BindingSource bSource;
        DataGridView dataGridView;
        ManualResetEvent[] doneEvents;
        delegate void SetControlValueCallback(Button btn, string propName, object value);

        public ProgressTable()
        {
            InitializeComponent();
        }
        //конструктор с таблицей dataGridView проинициализированной и наполненной начальной информацией,
        //и со ссылкой на родительское окно
        public ProgressTable(BindingSource bindingSource, IParrentForm mainForm, ManualResetEvent[] doneEvents)
        {           
            InitializeComponent();
            dataGridView = new DataGridView();
            bSource = bindingSource;
            dataGridView.DataSource = bindingSource;
            this.Text = Properties.Resources.InstalationResults;
            this.mainForm = mainForm;
            //подготовка внешнего вида и привязка данных к таблице DataGridView
            //которую впоследствии передадим для инициализации окна с результатами развертывания пакета
            dataGridView.AutoGenerateColumns = false;
            
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = Properties.Resources.ComputerName;
            dataGridView.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Status";
            column.Name = Properties.Resources.InstalationStatus;
            dataGridView.Columns.Add(column);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.panel.Controls.Add(dataGridView);
            this.doneEvents = doneEvents;
            Thread t = new Thread(unlockControls);
            t.Start();
        }

        //конструктор задающий заголовок окна и заголовки столбцов в таблице
        public ProgressTable(BindingSource bindingSource, IParrentForm mainForm, string formname, string firstColumnName, string secondColumnName, ManualResetEvent[] doneEvents)
        {
            InitializeComponent();
            dataGridView = new DataGridView();
            bSource = bindingSource;
            dataGridView.DataSource = bindingSource;
            this.Text = formname;
            this.mainForm = mainForm;
            //подготовка внешнего вида и привязка данных к таблице DataGridView
            //которую впоследствии передадим для инициализации окна с результатами развертывания пакета
            dataGridView.AutoGenerateColumns = false;
            //dataGridView.AutoSize = true;
            
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = firstColumnName;
            dataGridView.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Status";
            column.Name = secondColumnName;
            dataGridView.Columns.Add(column);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.panel.Controls.Add(dataGridView);
            this.doneEvents = doneEvents;
            Thread t = new Thread(unlockControls);
            t.Start();
        }

        //конструктор задающий заголовок окна и заголовки столбцов в таблице
        public ProgressTable(BindingSource bindingSource, IParrentForm mainForm, string formname, string firstColumnName, string secondColumnName)
        {
            InitializeComponent();
            dataGridView = new DataGridView();
            bSource = bindingSource;
            dataGridView.DataSource = bindingSource;
            this.Text = formname;
            this.mainForm = mainForm;
            //подготовка внешнего вида и привязка данных к таблице DataGridView
            //которую впоследствии передадим для инициализации окна с результатами развертывания пакета
            dataGridView.AutoGenerateColumns = false;
            //dataGridView.AutoSize = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = firstColumnName;
            dataGridView.Columns.Add(column);
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Status";
            column.Name = secondColumnName;
            dataGridView.Columns.Add(column);
            dataGridView.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.panel.Controls.Add(dataGridView);
            btnExport.Enabled = true;
            OK.Enabled = true;
            
        }
        
        //по окончанию установки все данные очищаются и окно с таблицей прогресса закрывается
        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.cleanData();
        }

        private void ProgressTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.cleanData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string strExport = "";
            foreach(DataGridViewColumn column in dataGridView.Columns)
            {
                strExport += column.Name + ";";
            }
            strExport += Environment.NewLine.ToString();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                strExport += row.Cells[0].Value + ";" + row.Cells[1].Value + ";" + Environment.NewLine.ToString();
            }
            System.IO.TextWriter tw = new System.IO.StreamWriter((saveFileDialog.FileName), false, Encoding.Default);
            tw.Write(strExport);
            tw.Close();
            
        }

        void unlockControls()
        {
            WaitHandle.WaitAll(doneEvents);
            SetControlPropertyValue(btnExport, "Enabled", true);
            SetControlPropertyValue(OK, "Enabled", true);
        }

        //разблокирование кнопок после завершения всех процессов
         void SetControlPropertyValue(Button btn, string propName, object value)
        {
            if (btn.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                btn.Invoke(d, new object[] { btn, propName, value });
            }
            else
            {
                btn.Enabled = true;
            }
       
        }
    }
}
