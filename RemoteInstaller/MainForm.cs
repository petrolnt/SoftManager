using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

///<summary>
///Программа удаленно устанавливает msi и exe-пакеты на компьютеры под управлением Windows 2000/2003/xp/vista/seven
///с помощью вызова соответствующего метода WMI
///</summary>

namespace SoftManager
{
    public partial class MainForm : Form, IParrentForm
    {
        FormSoftManager softManager;
        public delegate uint AsyncMethodCaller();
        private string optionRestart;
        public Hashtable computersTable = new Hashtable();
        string randomFolderName;
        bool oneFile;
        bool anotherUser;
        Ping pingSender;
        PingOptions pingOptions;
        //private DataGridView dataGridView = new DataGridView();
        private BindingSource bindingSource = new BindingSource();
        ManualResetEvent doneEvent;
        ManualResetEvent[] doneEvents;

        string[] selectedComputers;

        /// <summary>
        /// конструктор со ссылкой на родительское окно
        /// </summary>
        /// <param name="parrent"></param>
        public MainForm(FormSoftManager parrent)
        {
            softManager = parrent;
            InitializeComponent();
            compNameField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            optionRestart = "REBOOT=norestart";//"REBOOT = ReallySuppress";
            randomFolderName = "";
            oneFile = true;
            anotherUser = false;
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;


        }

        /// <summary>
        /// Очистка всех заполненных коллекций и множеств заполненных
        /// во время предыдущей установки софта
        /// </summary>
        public void cleanData()
        {

            computersTable = new Hashtable();
            //dataGridView = new DataGridView();
            bindingSource = new BindingSource();
        }

        /// <summary>
        /// открытие окна выбора msi-пакета для установки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

            private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

        }

        /// <summary>
        /// извлекает имена ip-адреса и NET-BIOS имена компьютеров разделенных ';'
        /// из списка и возвращает массив типа String содержащие их
        /// </summary>
        /// <returns></returns>
        private string[] getSelectedComputers()
        {
            string comps = compNameField.Text;
            string[] selectedComputers;
            char[] splitters = { ';' };
            comps = comps.Replace("\r\n", String.Empty);
            selectedComputers = comps.Split(splitters);
            selectedComputers = selectedComputers.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            return selectedComputers;
        }

        /// <summary>
        /// Нажатие кнопки OK начинающей установку выбранного пакета
        /// на выбранные компьютеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //проверка указаны ли целевые компьютеры и пакет msi для установки
            //если нет то выход
            if (compNameField.Text.Length == 0)
            {
                string message = "Необходимо указать имя компьютера!";
                string caption = "Ошибка ввода данных!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, button);
                return;
            }

            if (filePathField.Text.Length == 0)
            {

                string message = "Необходимо указать пакет msi!";
                string caption = "Ошибка ввода данных!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, button);
                return;
            }

            //получение случайного имени для временной папки, которая будет создана
            //на каждом из целевых компьютеров для копирования установочных файлов
            randomFolderName = FolderName.GetDirName();
            //установка из одного файла или использовать всю папку?
            oneFile = useOneFile.Checked;
            //от имени другого пользователя или от текукщего?
            anotherUser = checkBox1.Checked;
            //получаем массив с ip-адресами/именами компьютеров выбранных для развертывания
            selectedComputers = getSelectedComputers();
            //создаем ThreadPool для параллельного запуска установки программы на нескольких
            //ПК одновременно, ограничиваем количество одновременных установок - 5
            ThreadPool.SetMaxThreads(5, 5);
            startInstall();

            //открываем окно с таблицей прогресса установки и передаем в него
            //заполненную данными таблицу dataGridView
            ProgressTable progressTable = new ProgressTable(bindingSource, this, doneEvents);

            progressTable.ShowDialog();


        }

        /// <summary>
        /// запуск процесса установки выбранной программы на указанные компьютеры
        /// </summary>
        private void startInstall()
        {
            
            //события окончания фоновых процессов
            doneEvents = new ManualResetEvent[selectedComputers.Length];
            int i = 0;
            //для каждого из компьютеров создаем обьект ComputerEntry, поля которого
            //отображают состояние установки на этот компутер и привязаны в качестве источника
            //данных для таблицы прогресса dataGridView. А также для каждого компутера создается
            //обьект InstallProcess который будет выполнять установку пакета на этот компутер и 
            //отображать изменяющююся информацию о процессе установки и запускаем метод pingHost
            //этого обьекта в потоке помещенном в ThreadPool
            foreach (string comp in selectedComputers)
            {
                if (comp.Length > 0)
                {

                    ComputerEntry entry = new ComputerEntry(comp);
                    bindingSource.Add(entry);
                    doneEvent = new ManualResetEvent(false);
                    doneEvents[i] = doneEvent;
                    WMIProcess process = new WMIProcess(entry, doneEvent);
                    process.OneFile = oneFile;
                    process.OptionRestart = optionRestart;
                    process.RemoteMachine = comp;
                    process.UserName = userNameField.Text;
                    process.Password = passwordField.Text;
                    process.RandomFolderName = randomFolderName;
                    process.FilePath = filePathField.Text;
                    process.ExeOptions = tbExeOptions.Text;
                    //если программа устанавливается из exe файла
                    if(filePathField.Text.ToLower().EndsWith("exe"))
                        ThreadPool.QueueUserWorkItem(new WaitCallback(process.exeInstallProcess));
                    //msi
                    else
                        ThreadPool.QueueUserWorkItem(new WaitCallback(process.installProcess));
                }
                i++;
            }
        }

        public void setComputers(string str)
        {
            compNameField.AppendText(str);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string file = openFileDialog1.FileName;
            try
            {

                filePathField.Text = file;
            }
            catch (IOException)
            {
            }
        }

        //выбор установки от другого пользователя
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                userNameField.Enabled = true;
                passwordField.Enabled = true;
                anotherUser = true;
            }
            else
            {
                userNameField.Enabled = false;
                passwordField.Enabled = false;
                userNameField.Text = String.Empty;
                passwordField.Text = String.Empty;
                anotherUser = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.Show();
        }




        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        //вызов формы выборки компутеров из базы Active Directory
        private void importComp_Click(object sender, EventArgs e)
        {
            String admin = userNameField.Text;
            String passwd = passwordField.Text;
            String domain = System.String.Empty;
           
            //если от другого пользователя
            if (anotherUser)
            {

                if (admin.IndexOf('\\') > -1)
                {
                    char[] splitters = { '\\' };
                    string[] userDomain = admin.Split(splitters);
                    admin = userDomain[1];
                    domain = "LDAP://" + userDomain[0];

                }           
                    passwd = passwordField.Text;
               
            }
            if (compNameField.Text != "")
            {
                ImportADComp adComp = new ImportADComp(this, getSelectedComputers(),
                    admin, passwd, domain);
                adComp.ShowDialog(this);
            }
            else
            {
                ImportADComp adComp = new ImportADComp(this, admin, passwd, domain);
                adComp.ShowDialog(this);
            }
        }

        private void compNameField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void noReboot_CheckedChanged(object sender, EventArgs e)
        {
            if(noReboot.Checked)
            optionRestart = "REBOOT=norestart";
        }

        private void rebootAfterInstall_CheckedChanged(object sender, EventArgs e)
        {
            if(rebootAfterInstall.Checked)
            optionRestart = "REBOOT=forcerestart";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            softManager.Visible = true;
            
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            softManager.Visible = true;
        }

        //добавление пути для установочного файла
        private void filePathField_TextChanged(object sender, EventArgs e)
        {
            string package = filePathField.Text;
            
            //if (package.Length > 0)
            //{
                
            //    if (package.ToLower().EndsWith("exe"))
            //    {
            //        tbExeOptions.Enabled = true;
            //    }
            //    else
            //        tbExeOptions.Enabled = false;
            //}
        }

    }
}

