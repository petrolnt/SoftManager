
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Management;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SoftManager
{
    static class StaticWMIProcess
    {
        static string uninstalllException = String.Empty;
        static uint errorCode = 3333;
        static string path = String.Empty;
        

        public static ArrayList getSoftList(String computerName, String admin, String password, SoftGridView softGridView)
        {
            ArrayList softList = new ArrayList();
            try
            {
                
                ConnectionOptions connOptions = new ConnectionOptions();
                if (admin.Length > 0 && password.Length > 0)
                {
                    connOptions.Username = admin;
                    connOptions.Password = password;
                }
                ManagementScope managementScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                    computerName), connOptions);
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Product");

                ManagementObjectSearcher searcher =
                     new ManagementObjectSearcher(managementScope, query);

                foreach (ManagementObject queryObj in searcher.Get())
                {

                    object[] row = { false, queryObj["IdentifyingNumber"].ToString(), queryObj["Name"].ToString(), queryObj["Version"].ToString(),
                                       queryObj["InstallDate"].ToString() };

                    softList.Add(row);
                }
            }
            catch (NullReferenceException e)
            {

            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return softList;
        }

        public static int deleteProgram(String computerName, String identifyingNumber, String programName, 
            String programVersion, String admin, String password)
        {
                             
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
                
 //               manScope.Connect();

                ObjectGetOptions objectGetOptions = new ObjectGetOptions();
                
                path = string.Format("Win32_Product.IdentifyingNumber='{0}',Name='{1}',Version='{2}'", identifyingNumber,
                    programName, programVersion);
                
                ManagementPath managementPath = new ManagementPath(path);
                using (ManagementObject progObject = new ManagementObject(manScope, managementPath, objectGetOptions))
                {
                    ManagementBaseObject outParams = progObject.InvokeMethod("Uninstall", null, null);
                    errorCode = (uint)(outParams.Properties["ReturnValue"].Value);
                    //uninstalllException = new Win32Exception((int)errorCode).Message;
                }
            }
            catch (ManagementException err)
            {
                uninstalllException = "Management Exception " + err.Message + ":" + path;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                uninstalllException = "COMException " + ex.Message;
            }
            catch (Exception ex)
            {
                uninstalllException = "Exception" + ex.Message;
            }
            return (int)errorCode;
        }

        public static string deleteProgram(string computerName, string programName, string admin, string password)
        {
            try
            {
                ConnectionOptions connOptions = new ConnectionOptions();
                if (admin.Length > 0 && password.Length > 0)
                {
                    connOptions.Username = admin;
                    connOptions.Password = password;
                }
                ManagementScope managementScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2",
                    computerName), connOptions);
                ObjectQuery objQuery = new ObjectQuery("SELECT * FROM Win32_Product WHERE Name = '" + programName + "'");
                ManagementObjectSearcher mos = new ManagementObjectSearcher(managementScope, objQuery);
                
                foreach (ManagementObject mo in mos.Get())
                {
                    try
                    {
                        if (mo["Name"].ToString() == programName)
                        {
                            ManagementBaseObject outParams = mo.InvokeMethod("Uninstall", null, null);

                            errorCode = (uint)(outParams.Properties["ReturnValue"].Value);
                            uninstalllException = new Win32Exception((int)errorCode).Message;
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }

                //was not found...
                return uninstalllException;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    //public static Array getSoftList()
    //{
    // //   string[][,,] softListArray = new string[][,,];

    //}
}


