using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.DirectoryServices;
using System.Collections;
using System.Windows.Forms;
namespace SoftManager
{

    //статический класс, метод getComputers() которого выбирает все учетные записи компьютеров из Active Directory
    public static class ComputersSet
    {

        public static ArrayList getComputers(string admin, string passwd, string domain)
        {
            ArrayList computers = new ArrayList();
            DirectoryEntry de = new DirectoryEntry();

            if (admin != "" && passwd != "")
            {
                de.Path = domain;
                de.Username = admin;
                de.Password = passwd;
                
            }
           
            try
            {
                DirectorySearcher ser = new DirectorySearcher(de);
                ser.Filter = "(&ObjectCategory=computer)";
                ser.PropertiesToLoad.Add("cn");
                SearchResultCollection results = ser.FindAll();

                foreach (SearchResult res in results)
                {
                    ResultPropertyValueCollection valueColection = res.Properties["cn"];
                    computers.Add(valueColection[0].ToString());
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                de.Dispose();
            }

            return computers;
        }
    }
}