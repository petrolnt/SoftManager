using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoftManager;
using System.Threading;


namespace SoftManager
{
    /// <summary>
    /// форма отображает список програмного обеспечения на просканированных компьютерах, предоставляет возможность выбора и удаления выбранных программ,
    /// сохраняет названия и версии найденных программ в файле SoftList.csv расположенном в одном каталоге с исполняемым файлом этой программы
    /// </summary>
    public partial class FormSoftList : Form, IParrentForm
    {
        //private string[] computers;
        private string admin = String.Empty;
        private string password = String.Empty;
        private TabControl tabControl;
        private TabPage tabPage;
       // SoftGridView softGridView;
        TabPage selectedTab;
        ArrayList resultList = new ArrayList();
        ArrayList dataViewes;
        
        public FormSoftList(ArrayList dataViewes, string admin, string password)
        {
            this.dataViewes = dataViewes;
            InitializeComponent();
            this.admin = admin;
            this.password = password;
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // DoWork требуется для запуска длительной задачи (метода) в фоновом потоке
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

            // RunWorkerCompleted требуется для изменения элементов формы, после окончания расчета (например, результаты отобразить)
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

            // ProgressChanged вызывается каждый раз, когда в процессе расчета нужно что-нибудь поменять на форме.
            // Например, изменить значение прогрессбара или какой-нибудь метки и т.п.
            // Чтобы вызвать ProgressChanged используется метод ReportProgress c одним или двумя параметрами
            // Например, backgroundWorker1.ReportProgress(n, "Working..."); или backgroundWorker1.ReportProgress(n);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);

            // WorkerReportsProgress нужно установить в true, чтобы пользоваться методом ReportProgress
            backgroundWorker1.WorkerReportsProgress = true;

            //создаем вкладки для каждого компьютера размещаем в них таблицы со списком програмного обеспечения
            foreach (SoftGridView softGridView in dataViewes)
            {
                if (softGridView.Rows.Count > 0)
                {
                    tabPage = new TabPage();
                    tabPage.Text = softGridView.Name;
                    tabPage.AutoScroll = true;
                    tabPage.Controls.Add(softGridView);
                    tabControl.Controls.Add(tabPage);
                }
            }
            this.Text = "Список программного обеспечения на компьютере ";
            this.panel.Controls.Add(tabControl);
            WriteSoftList();
        }

        //создаем или добавляем в существующий файл названия и версии полученных программ, если таких в нем не содержится
        void WriteSoftList()
        {
            String file = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SoftManager\\SoftList.csv";
            if (!File.Exists(file))
            {
                System.IO.FileStream fs = System.IO.File.Create(file);
                fs.Close();
            }

            string[] values = File.ReadAllText(file).Split('\t');

            foreach (TabPage page in this.tabControl.Controls)
            {
                SoftGridView softGridView = (SoftGridView)page.Controls[0];
                foreach (DataGridViewRow row in softGridView.Rows)
                {
                    string softName = row.Cells[2].Value.ToString();
                    if (!values.Contains(softName))
                    {
                        File.AppendAllText(file, softName);
                        File.AppendAllText(file, "\t");
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// нажатие кнопки удаление, удаляются поочереди все выбранные программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            lblProgress.Visible = true;
            selectedTab = this.tabControl.SelectedTab;
            btnDelete.Enabled = false;
            btnExport.Enabled = false;
            tabControl.Enabled = false;
            backgroundWorker1.RunWorkerAsync(); 
        }

        // Точка запуска удаления программ
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            try
            {
                string computer = selectedTab.Text;
                SoftGridView softGreedView = ((SoftGridView)selectedTab.Controls[computer]);
                int count = 0;
                ArrayList arSoftList = new ArrayList();
                double percentOfTask = 0;
                foreach (DataGridViewRow row in softGreedView.Rows)
                {
                    //создаем ArrayList содержащий список программ подлежащий удалению
                    if ((Boolean)row.Cells[0].Value == true)
                    {
                        string[] array = new string[4];
                        array[0] = row.Cells[1].Value.ToString();
                        array[1] = row.Cells[2].Value.ToString();
                        array[2] = row.Cells[3].Value.ToString();
                        arSoftList.Add(array);
                    }
                }
                //для подсчета шкалы прогресса
                int programCount = arSoftList.Count;
                //удаление
                foreach (string[] array in arSoftList)
                {
                    string identifyingNumber = array[0];
                    string programName = array[1];
                    string programVersion = array[2];
                    count++;
                    percentOfTask = ((double)count / programCount) * 100;
                    int returnMessage = WMIProcess.deleteProgram(computer, identifyingNumber,
                        programName, programVersion, admin, password);
                    array[3] = returnMessage.ToString();
                    worker.ReportProgress((int)percentOfTask, array);
                }
            }
            catch (InvalidOperationException iex)
            {
                MessageBox.Show(iex.Message);
            }
        }

        // Изменяет элементы формы в фоновом потоке
        // Для вызова этого метода используется метод ReportProgress
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage; // Меняю данные прогрессбара
            string[] program = e.UserState as string[];
            string programName = program[1] + " " + program[2];
            if (!string.IsNullOrEmpty(programName))
            {
                lblProgress.Text = "Удаление " + programName;
            }
            resultList.Add(program);
        }

        //по завершении установки активируем нужные кнопки, удаляем из таблицы удаленные программы
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblProgress.Text = e.Error.Message;
            }
            else
            lblProgress.Text = "Готово!";
            btnExport.Enabled = true;
            btnDelete.Enabled = true;
            tabControl.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            deleteRow();
            resultList.Clear();
        }

        //ревлизация методов IParrentForm
        public void setComputers(string str)
        {
        }

        public void cleanData()
        {
        }
        
        /// <summary>
        /// метод для удаления строк из таблицы
        /// </summary>
        private void deleteRow()
        {
            BindingSource bindingSource = new BindingSource();
            SoftGridView softGridView = (SoftGridView)tabControl.SelectedTab.Controls[0];

            //из ArrayList со списком результатов удаления
            foreach (string[] array in resultList)
            {    
                int error = Convert.ToInt32(array[3]);
                string uninstallException = new Win32Exception(error).Message;
                ComputerEntry entry = new ComputerEntry(array[1], uninstallException);
                bindingSource.Add(entry);
                int rowIndex;
                //если в процессе удаления не произошло ошибки
                if (error == 0)
                {
                    string searchString = array[0];
                    //ищем программу в таблице и удаляем
                    foreach (DataGridViewRow row in softGridView.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchString))
                        {
                            rowIndex = row.Index;
                            softGridView.Rows.RemoveAt(rowIndex);
                            break;
                        }
                    }

                }
            }
            //отображаем форму с таблицей результатов удаления
            string formName = "Результаты удаления";
            string firstColumnName = "Программа";
            string secondColumnName = "Результаты удаления";
            ProgressTable progressTable = new ProgressTable(bindingSource, this, formName, firstColumnName, secondColumnName);
            progressTable.ShowDialog();
            
        }

        //экспорт результатов
        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SoftGridView softGridView = (SoftGridView)tabControl.SelectedTab.Controls[0];
            string strExport = "Имя программы;" + "Версия;" + "Дата установки;";
           
            strExport += Environment.NewLine.ToString();
            foreach (DataGridViewRow row in softGridView.Rows)
            {
                strExport += row.Cells[2].Value + ";" + row.Cells[3].Value + ";" + row.Cells[4].Value + ";" 
                    + Environment.NewLine.ToString();
            }
            System.IO.TextWriter tw = new System.IO.StreamWriter((saveFileDialog.FileName), false, Encoding.Default);
            tw.Write(strExport);
            tw.Close();
        }
    }
}
