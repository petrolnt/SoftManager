using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftManager;
using System.Threading;

/// <summary>
/// форма для выбора компьютера(ов) програмным обеспечением которого хотим управлять, также можно сразу выбрать программу которую хотим удалять(если точно знаем имя и 
/// версию программы), так же можно запустить сканирование установленного програмного обеспечения на выбранных компьютерах
/// </summary>

namespace SoftManager
{
    public partial class FormRemovePrograms : Form, IParrentForm
    {
        private bool isCurrentUser = true;
        private string admin = "";
        private string password = "";
        private string domain = "";
        FormSoftManager softManager;
        private string optionRestart="REBOOT=norestart";
        private BindingSource bindingSource = new BindingSource();
        private DataGridView dataGridView = new DataGridView();
        ManualResetEvent doneEvent;

        /// <summary>
        /// //конструктор со ссылкой на родительское окно
        /// </summary>
        /// <param name="softManager"></param>
        public FormRemovePrograms(FormSoftManager softManager)
        {
            InitializeComponent();
            this.softManager = softManager;
            tbAdmin.Enabled = false;
            tbPassword.Enabled = false;
            
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            softManager.Visible = true;
            this.Close();
        }

        /// <summary>
        /// получение массива string[] выбраных компьюетров из TextBox
        /// </summary>
        /// <returns></returns>
        private string[] getSelectedComputers()
        {
            string comps = tbComputer.Text;
            string[] selectedComputers;
            char[] splitters = { ';' };
            comps = comps.Replace("\r\n", null);
            selectedComputers = comps.Split(splitters);
            selectedComputers = selectedComputers.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            return selectedComputers;
        }

        /// <summary>
        /// нажатие кнопки для импорта компьютеров из Active Directory, если не указано имя пользователя и пароль то поиск выполняется в домене по умолчанию с 
        /// правами текущего пользователя, если указан другой пользователь то домен для поиска берется из имени пользователя которое должно быть: domain\username,
        /// поиск выполняется с правами указанного пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompsImport_Click(object sender, EventArgs e)
        {
            if (!isCurrentUser)
            {
                admin = tbAdmin.Text;
                password = tbPassword.Text;
                if (admin.IndexOf('\\') > -1)
                {
                    char[] splitters = { '\\' };
                    string[] userDomain = admin.Split(splitters);
                    admin = userDomain[1];
                    domain = "LDAP://" + userDomain[0];
                }
                
            }
            if (tbComputer.Text != "")
            {
                ImportADComp adComp = new ImportADComp(this, getSelectedComputers(),
                    admin, password, domain);
                adComp.ShowDialog(this);
            }
            else
            {
                ImportADComp adComp = new ImportADComp(this, admin, password, domain);
                adComp.ShowDialog(this);
            }
            
        }

        /// <summary>
        /// метод для заполнения TextBox со списком компьютеров, компьютерами выбранными в окне импорта из Active Directory
        /// </summary>
        /// <param name="str">имя компьютера</param>
        public void setComputers(string str)
        {
            tbComputer.AppendText(str);
        }

      // public void setSoftGridView(SoftGridView sv) { }

        /// <summary>
        /// событие выбора управления софтом от имени другого пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cBanotherUser_CheckedChanged(object sender, EventArgs e)
        {
            isCurrentUser = cBanotherUser.Checked ? true : false;
            if (isCurrentUser)
            {
                tbAdmin.Enabled = true;
                tbPassword.Enabled = true;
            }
            else
            {
                
                tbAdmin.Enabled = false;
                tbPassword.Enabled = false;
                tbAdmin.Text = String.Empty;
                tbPassword.Text = String.Empty;
            }
        }

        //public void setComputerName(String computer)
        //{
        //    tbComputer.Text = computer;
        //}

        /// <summary>
        /// установка выбранной программы в TextBox
        /// </summary>
        /// <param name="softName">Имя программы подлежащей удалению</param>
        public void setSoftName(string softName)
        {
            tbSoftName.Text = softName;
        }
        private void tbComputer_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// нажатие кнопки выбрать программу, открывается окно ChoseItem в котором отображается список известного програмного обеспечения(см. ChoseItem.cs)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoseSoft_Click(object sender, EventArgs e)
        {
            ChoseItem choseItem = new ChoseItem(this);
            choseItem.Visible = true;
        }

        /// <summary>
        /// очистка данных
        /// </summary>
        public void cleanData()
        {

            dataGridView = new DataGridView();
            bindingSource = new BindingSource();

        }

        /// <summary>
        /// нажатие кнопки удаление программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //создаем ThreadPool для параллельного запуска установки программы на нескольких
            //ПК одновременно, ограничиваем количество одновременных установок - 5
            ThreadPool.SetMaxThreads(5, 5);
            string[] selectedComputers = getSelectedComputers();
            ManualResetEvent[] doneEvents = new ManualResetEvent[selectedComputers.Length];
            int i = 0;
            //создаем источник данных о состоянии удаления, для отображения прогресса в ProgressTable, создаем обьект WMIProcess для каждого компьютера,
            //и помещаем их ThreadPool
            foreach (string comp in selectedComputers)
            {
                ComputerEntry entry = new ComputerEntry(comp);
                bindingSource.Add(entry);
                doneEvent = new ManualResetEvent(false);
                doneEvents[i] = doneEvent;
                WMIProcess process = new WMIProcess(entry, doneEvent);
                process.ProgramName = tbSoftName.Text;
                process.OptionRestart = optionRestart;
                process.RemoteMachine = comp;
                process.UserName = tbAdmin.Text;
                process.Password = tbPassword.Text;
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(process.deleteProgram));
                i++;
            }
            //создаем ProgressTable с данными о состоянии задач удаления на выбранных компьютерах
            string formName = "Результаты удаления";
            string firstColumnName = "Имя компьютера";
            string secondColumnName = "Состояние процесса";
            ProgressTable progressTable = new ProgressTable(bindingSource, this, formName, firstColumnName, secondColumnName, doneEvents);
            progressTable.ShowDialog();
            
        }

        /// <summary>
        /// Нажатие кнопки сканирования, запускает процессы получения списка установленного ПО на выбранных компьютерах, после завершения сканирования отобразит окно
        /// FormSoftList со списком установленных программ для каждого компьютера на отдельной вкладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScan_Click(object sender, EventArgs e)
        {
            string[] computers = getSelectedComputers();

            //doneEvents нужно для того чтобы программа определила что задача сканирования для каждого из компьютеров завершена
            ManualResetEvent[] doneEvents = new ManualResetEvent[computers.Length];

            int i = 0;
            ArrayList dataViewes = new ArrayList();
            ThreadPool.SetMaxThreads(5, 5);
            foreach (string computer in computers)
            {
                SoftGridView softGridView = new SoftGridView();
                softGridView.Name = computer;
                dataViewes.Add(softGridView);
                ComputerEntry entry = new ComputerEntry(computer);
                bindingSource.Add(entry);
                doneEvent = new ManualResetEvent(false);
                doneEvents[i] = doneEvent;
                WMIProcess process = new WMIProcess(entry, softGridView, doneEvent);
                process.ProgramName = tbSoftName.Text;
                process.OptionRestart = optionRestart;
                process.RemoteMachine = computer;
                process.UserName = tbAdmin.Text;
                process.Password = tbPassword.Text;
                ThreadPool.QueueUserWorkItem(new WaitCallback(process.getSoftList));
                i++;
            }

            string formName = "Получение списка установленных программ";
            string firstColumnName = "Имя компьютера";
            string secondColumnName = "Состояние процесса";
            ProgressTable progressTable = new ProgressTable(bindingSource, this, formName, firstColumnName, secondColumnName, doneEvents);
            progressTable.ShowDialog();
            
            //создаем форму со списком установленного ПО, передаем в него имя пользователя и пароль, для возможности удаления программ с правами укаазанного пользователя
            //(если он указан) в новом окне
            FormSoftList softList = new FormSoftList(dataViewes, tbAdmin.Text, tbPassword.Text);
            softList.Visible = true;

        }

        private void tbComputer_TextChanged(object sender, EventArgs e)
        {
            btnScan.Enabled = tbComputer.Text.Length > 0 ? true : false;
            if (tbComputer.Text.Length > 0 && tbSoftName.Text.Length > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        //опции перезагружать/не перезагружать, передается в WMIProcess
        private void rbNoReboot_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNoReboot.Checked)
            optionRestart = "REBOOT=norestart";
            
        }

        private void rbReboot_CheckedChanged(object sender, EventArgs e)
        {
            if(rbReboot.Checked)
            optionRestart = "REBOOT=forcerestart";
            
        }

        private void tbSoftName_TextChanged(object sender, EventArgs e)
        {
            if (tbSoftName.Text.Length > 0 && tbComputer.Text.Length > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            softManager.Visible = true;
        }


    }
}
