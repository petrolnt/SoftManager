using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Threading;

//обьект осуществляющий пингование, копирование и последущую установку заданных файлов на заданный компутер
//а также выполняет изменение полей записи ComputerEntry для соответствующего компутера

namespace SoftManager
{
    class WMIProcess
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomainName, String lpszPassword,
            int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        //идентификатор созданного процесса установки
        int installProcessID;

        //значение возвращаемое процессом установки exe файла
        int installProcessExitCode;

        //Событие сообщающее основному потоку об окончании выполнения процесса
        ManualResetEvent doneEvent;

        //установка от текущего пользователя?
        private bool anotherUser;

        public bool AnotherUser
        {
            get { return anotherUser; }
            set { anotherUser = value; }
        }
        //msi пакет распространяется из одного файла?
        private bool oneFile;

        public bool OneFile
        {
            get { return oneFile; }
            set { oneFile = value; }
        }
        //Имя удаляемой программы
        private string programName;

        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }
        //разрешить перезагрузку?(если необходимо)
        private string optionRestart;

        public string OptionRestart
        {
            get { return optionRestart; }
            set { optionRestart = value; }
        }
        //имя или ip-адрес компутера на который нужно поставить msi-пакет
        private string remoteMachine;

        public string RemoteMachine
        {
            get { return remoteMachine; }
            set { remoteMachine = value; }
        }
        //если не от текущего пользователя, то имя пользователя и пароль
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        //сгенерированное имя для временной папки
        private string randomFolderName;

        public string RandomFolderName
        {
            get { return randomFolderName; }
            set { randomFolderName = value; }
        }
        //путь до устанавливаемого пакета
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string exeOptions;

        public string ExeOptions
        {
            get { return exeOptions; }
            set { exeOptions = value; }
        }

        private static IntPtr tokenHandle = new IntPtr(0);

        //переменные для выполнения пинга
        Ping pingSender;
        int timeout = 120;
        PingOptions pingOptions;
        //запись этого компутера, обьект поля которого отражают текущее состояние установки для этого пк
        SoftGridView softGridView;
        ComputerEntry entry;
        uint errorCode = 33333;

        public WMIProcess(ComputerEntry computerEntry, ManualResetEvent doneEvent)
        {
            entry = computerEntry;
            this.doneEvent = doneEvent;
        }

        public WMIProcess(ComputerEntry computerEntry, SoftGridView softGridView, ManualResetEvent doneEvent)
        {
            entry = computerEntry;
            this.softGridView = softGridView;
            this.doneEvent = doneEvent;
        }

        /// <summary>
        /// рекурсивное копирование директории
        /// </summary>
        /// <param name="FromDir"></param>
        /// <param name="ToDir"></param>

        void CopyDir(string FromDir, string ToDir)
        {

            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        /// <summary>
        /// процесс установки msi пакета
        /// </summary>
        public void installProcess(Object stateInfo)
        {
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            int timeout = 120;
            string remoteFolder = String.Empty;
            try
            {
                PingReply reply = pingSender.Send(remoteMachine, timeout);

                if (reply.Status != IPStatus.Success)
                {
                    entry.Status = "Узел недоступен";
                }
                else
                {
                    try
                    {
                        ImpersonateUser iU = new ImpersonateUser();
                        if (userName.Length > 0)
                        {

                            if (userName.IndexOf('\\') > -1)
                            {
                                char[] splitters = { '\\' };
                                string[] userDomain = userName.Split(splitters);
                                iU.Impersonate(userDomain[0], userDomain[1], password);
                            }

                            else
                                iU.Impersonate(String.Empty, userName, password);
                            
                        }
                        entry.Status = "Копирование файлов...";
                        remoteFolder = @"\\" + remoteMachine + @"\c$\" + randomFolderName + @"\";

                        string sourceFilePath = filePath;

                        string fileName = Path.GetFileName(sourceFilePath);
                        string destinationFilePath = System.IO.Path.Combine(@"c:\" + randomFolderName + @"\", fileName);

                        //пакет распространяется из одного файла или из директории

                        System.IO.Directory.CreateDirectory(remoteFolder);
                        if (oneFile)
                        {
                            string remoteFile = System.IO.Path.Combine(remoteFolder, fileName);
                            System.IO.File.Copy(sourceFilePath, remoteFile, true);
                        }

                        else
                        {
                            string localFolder = Path.GetDirectoryName(filePath);
                            CopyDir(localFolder, remoteFolder);
                        }

                        if (iU != null) iU.Undo();

                        //подключение к службе WMI и запуск метода установки
                        entry.Status = "Установка...";
                        ConnectionOptions connOptions = new ConnectionOptions();
                        if (userName.Length > 0)
                        {
                            connOptions.Username = userName;
                            connOptions.Password = password;
                        }
                        connOptions.Impersonation = ImpersonationLevel.Impersonate;
                        connOptions.EnablePrivileges = true;
                        ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                            remoteMachine), connOptions);
                        manScope.Connect();
                        ObjectGetOptions objectGetOptions = new ObjectGetOptions();

                        ManagementPath managementPath = new ManagementPath("Win32_Product");

                        ManagementClass processClass = new ManagementClass(manScope, managementPath, objectGetOptions);
                        ManagementBaseObject inParams =
                            processClass.GetMethodParameters("Install");

                        // добавление входных параметров
                        inParams["AllUsers"] = true;
                        inParams["Options"] = optionRestart + " " + exeOptions;
                        inParams["PackageLocation"] = destinationFilePath;//+ " " + optionRestart;

                        // выполнение метода установки и получение кода события возвращенного методом
                        ManagementBaseObject outParams =
                        processClass.InvokeMethod("Install", inParams, null);

                        

                        errorCode = (uint)(outParams.Properties["ReturnValue"].Value);
                        //из кода события получаем соответствующее текстовое сообщение и записываем в запись о компутере
                        entry.Status = new Win32Exception((int)errorCode).Message;
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    //при установке некоторых программ например фаерволов, на короткое время разрываются все сетевые подключения
                    //это событие вызывает нижеследующее исключение
                    catch (System.Runtime.InteropServices.COMException ex)
                    {

                        entry.Status = ex.Message;

                    }

                    //все остальные исключения
                    catch (Exception ex)
                    {

                        entry.Status = ex.Message;

                    }

                   
                }

            }
            catch (PingException ex)
            {
                entry.Status = ex.Message;
                
            }
            catch (SocketException ex)
            {

                entry.Status = ex.Message;
                
            }

            finally
            {
                if(Directory.Exists(remoteFolder))
                System.IO.Directory.Delete(Path.GetDirectoryName(remoteFolder), true);
                doneEvent.Set();
            }

        }

        /// <summary>
        /// процесс установки из установочного exe файла
        /// </summary>
        public void exeInstallProcess(Object stateInfo)
        {
            
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            int timeout = 120;
            string remoteFolder = String.Empty;
            try
            {
                PingReply reply = pingSender.Send(remoteMachine, timeout);

                if (reply.Status != IPStatus.Success)
                {
                    entry.Status = "Узел недоступен";
                }
                else
                {
                    try
                    {
                        //получения токена безопасности для получения доступа к административному ресурсу C$ на который будет копироваться дистрибутив
                        ImpersonateUser iU = new ImpersonateUser();
                        if (userName.Length > 0)
                        {

                            iU.Impersonate(remoteMachine, userName, password);
                        }

                        entry.Status = "Копирование файлов...";
                        remoteFolder = @"\\" + remoteMachine + @"\c$\" + randomFolderName + @"\";

                        string sourceFilePath = filePath;

                        string fileName = Path.GetFileName(sourceFilePath);
                        string destinationFilePath = System.IO.Path.Combine(@"c:\" + randomFolderName + @"\", fileName);

                        //пакет распространяется из одного файла или из директории

                        System.IO.Directory.CreateDirectory(remoteFolder);
                        if (oneFile)
                        {
                            string remoteFile = System.IO.Path.Combine(remoteFolder, fileName);
                            System.IO.File.Copy(sourceFilePath, remoteFile, true);
                        }

                        else
                        {
                            string localFolder = Path.GetDirectoryName(filePath);
                            CopyDir(localFolder, remoteFolder);
                        }

                        if (iU != null) iU.Undo();


                        //подключение к службе WMI и запуск процесса установки с параметрами
                        entry.Status = "Установка...";
                        ConnectionOptions connOptions = new ConnectionOptions();
                        if (userName.Length > 0)
                        {
                            connOptions.Username = userName;
                            connOptions.Password = password;
                        }
                        connOptions.Impersonation = ImpersonationLevel.Impersonate;
                        connOptions.EnablePrivileges = true;
                        ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                            remoteMachine), connOptions);
                        manScope.Connect();
                        ObjectGetOptions objectGetOptions = new ObjectGetOptions();

                        ManagementPath managementPath = new ManagementPath("Win32_Process");

                        ManagementClass processClass = new ManagementClass(manScope, managementPath, objectGetOptions);
                        ManagementBaseObject inParams =
                            processClass.GetMethodParameters("Create");

                        // добавление входных параметров
                        inParams["CommandLine"] = destinationFilePath + " " + exeOptions;

                        // выполнение метода установки и получение кода события возвращенного методом
                        ManagementBaseObject outParams =
                        processClass.InvokeMethod("Create", inParams, null);
                        installProcessID = (int)(uint)outParams.Properties["processId"].Value;

                        WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM Win32_ProcessStopTrace WHERE ProcessID = " + installProcessID);

                        ManagementEventWatcher watcher = new ManagementEventWatcher(manScope, query);
                        ManagementBaseObject eventObj = watcher.WaitForNextEvent();
                        watcher.EventArrived += new EventArrivedEventHandler(this.ProcessStopEventArrived);

                        //из кода события получаем соответствующее текстовое сообщение и записываем в запись о компутере
                        entry.Status = new Win32Exception((int)installProcessExitCode).Message;

                        System.IO.Directory.Delete(Path.GetDirectoryName(remoteFolder), true);
                    }
                    catch (FileNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    //при установке некоторых программ например фаерволов, на короткое время разрываются все сетевые подключения
                    //это событие вызывает нижеследующее исключение
                    catch (System.Runtime.InteropServices.COMException ex)
                    {

                        entry.Status = ex.Message;


                    }

                    //все остальные исключения
                    catch (Exception ex)
                    {

                        entry.Status = ex.Message;


                    }

                    
                }

            }
            catch (PingException ex)
            {
                entry.Status = ex.Message;
                
            }
            catch (SocketException ex)
            {

                entry.Status = ex.Message;
                
            }

            finally
            {
                if (Directory.Exists(remoteFolder))
                System.IO.Directory.Delete(Path.GetDirectoryName(remoteFolder), true);
                doneEvent.Set();
            }
        }

        public void ProcessStopEventArrived(object sender, EventArrivedEventArgs e)
        {
            if ((uint)e.NewEvent.Properties["ProcessId"].Value == installProcessID)
            {
                installProcessExitCode = (int)(uint)e.NewEvent.Properties["ExitStatus"].Value;
            }
        }

        /// <summary>
        /// процесс удаления программы по ее названию и версии
        /// </summary>
        /// <param name="stateInfo"></param>
        public void deleteProgram(Object stateInfo)
        {
            string uninstallException;
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;

            try
            {
                PingReply reply = pingSender.Send(remoteMachine, timeout);

                if (reply.Status != IPStatus.Success)
                {
                    entry.Status = "Узел недоступен";
                }
                else
                {
                    try
                    {
                        entry.Status = "Поиск программы...";
                        ConnectionOptions connOptions = new ConnectionOptions();
                        if (userName.Length > 0 && password.Length > 0)
                        {
                            connOptions.Username = userName;
                            connOptions.Password = password;
                        }
                        ManagementScope managementScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                            remoteMachine), connOptions);
                        ObjectGetOptions objectGetOptions = new ObjectGetOptions();

                        ManagementPath managementPath = new ManagementPath("Win32_Product");

                        //ManagementClass processClass = new ManagementClass(managementScope, managementPath, objectGetOptions);
                        //ManagementBaseObject inParams =
                        //    processClass.GetMethodParameters("Uninstall");
                        //inParams["Options"] = optionRestart + exeOptions;

                        ObjectQuery objQuery = new ObjectQuery("SELECT * FROM Win32_Product WHERE Name = '" + programName + "'");
                        ManagementObjectSearcher mos = new ManagementObjectSearcher(managementScope, objQuery);
                        ManagementObjectCollection collection = mos.Get();
                        if (collection.Count > 0)
                        {
                            foreach (ManagementObject mo in collection)
                            {
                                try
                                {
                                    if (mo["Name"].ToString() == programName)
                                    {
                                        entry.Status = "Удаление...";
                                        ManagementBaseObject outParams = mo.InvokeMethod("Uninstall", null, null);

                                        errorCode = (uint)(outParams.Properties["ReturnValue"].Value);
                                        uninstallException = new Win32Exception((int)errorCode).Message;
                                        entry.Status = uninstallException;
                                    }

                                }
                                //при установке некоторых программ например фаерволов, на короткое время разрываются все сетевые подключения
                                //это событие вызывает нижеследующее исключение
                                catch (System.Runtime.InteropServices.COMException ex)
                                {

                                    entry.Status = ex.Message;

                                }

                                catch (Exception ex)
                                {
                                    entry.Status = ex.Message;
                                }

                                finally
                                {
                                    doneEvent.Set();
                                }
                            }
                        }
                        else entry.Status = "Программа не найдена";

                    }

                    catch (Exception ex)
                    {
                        entry.Status = ex.Message;
                    }

                    finally
                    {
                        doneEvent.Set();
                    }
                }
            }
            catch (PingException ex)
            {
                entry.Status = ex.Message;
            }
            catch (SocketException ex)
            {

                entry.Status = ex.Message;

            }

            finally
            {
                doneEvent.Set();
            }

        }

        /// <summary>
        /// статический метод вызываемый из формы FormSoftList
        /// </summary>
        /// <param name="computerName">Имя компьютера</param>
        /// <param name="identifyingNumber">GUID программы</param>
        /// <param name="programName">Имя программы</param>
        /// <param name="programVersion">Версия программы</param>
        /// <param name="admin">Пользователь</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public static int deleteProgram(String computerName, String identifyingNumber, String programName,
            String programVersion, String admin, String password)
        {
            string path = "";
            
            uint errorCode = 3333;
            try
            {

                ConnectionOptions connOptions = new ConnectionOptions();
                if (admin.Length > 0 && password.Length > 0)
                {
                    connOptions.Username = admin;
                    connOptions.Password = password;
                }
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope =
                        new ManagementScope(string.Format(@"\\{0}\ROOT\CIMV2", computerName), connOptions);

                ObjectGetOptions objectGetOptions = new ObjectGetOptions();

                path = string.Format("Win32_Product.IdentifyingNumber='{0}',Name='{1}',Version='{2}'", identifyingNumber,
                    programName, programVersion);

                ManagementPath managementPath = new ManagementPath(path);
                using (ManagementObject progObject = new ManagementObject(manScope, managementPath, objectGetOptions))
                {
                    ManagementBaseObject outParams = progObject.InvokeMethod("Uninstall", null, null);
                    errorCode = (uint)(outParams.Properties["ReturnValue"].Value);
                }
            }
            catch (ManagementException err)
            {

                return (int)err.ErrorCode;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                return ex.ErrorCode;
            }
            catch (Exception ex)
            {
                var w32ex = ex as Win32Exception;
                return w32ex.ErrorCode;
            }

            return (int)errorCode;
        }

        /// <summary>
        /// получение списка програмного обеспечения
        /// </summary>
        /// <param name="stateInfo"></param>
        public void getSoftList(Object stateInfo)
        {
            pingSender = new Ping();
            pingOptions = new PingOptions();
            pingOptions.DontFragment = true;
            try
            {
                PingReply reply = pingSender.Send(remoteMachine, timeout);

                if (reply.Status != IPStatus.Success)
                {
                    entry.Status = "Узел недоступен";
                }
                else
                {
                    try
                    {

                        ConnectionOptions connOptions = new ConnectionOptions();
                        if (userName.Length > 0 && password.Length > 0)
                        {
                            connOptions.Username = userName;
                            connOptions.Password = password;
                        }
                        entry.Status = "Сканирование";
                        ManagementScope managementScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                            remoteMachine), connOptions);
                        ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Product");

                        ManagementObjectSearcher searcher =
                             new ManagementObjectSearcher(managementScope, query);

                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            if (queryObj.Path.ClassName.Length > 0) //почему то с некоторых компов прилетают пустые ссылки на objQuery
                            {
                                object[] row = { false, queryObj["IdentifyingNumber"].ToString(), queryObj["Name"].ToString(), queryObj["Version"].ToString(),
                                       queryObj["InstallDate"].ToString() };
                                softGridView.Rows.Add(row);
                            }
                        }

                        entry.Status = "Сканирование завершено";
                    }
                    catch (NullReferenceException e)
                    {
                        entry.Status =  e.Message;
                    }
                    catch (ManagementException e)
                    {
                        entry.Status = e.Message;
                    }
                    catch (System.Runtime.InteropServices.COMException ex)
                    {
                        entry.Status = ex.Message;
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        entry.Status = e.Message;
                    }

                 }
            }
            catch (PingException ex)
            {
                entry.Status = ex.Message;
            }
            catch (SocketException ex)
            {

                entry.Status = ex.Message;

            }

            finally
            {
                doneEvent.Set();
            }


        }
    }
}