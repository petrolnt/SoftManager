using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

///<summary>
///Форма с помощью которой можно импортировать компьютеры в список установки/удаления из
///базы Active Directory
///</summary>

namespace SoftManager
{
    public partial class ImportADComp : Form
    {
        IParrentForm mainForm;
        string admin ;
        string passwd ;
        string domain;
       //конструктор со ссылкой на родительское окно
        public ImportADComp(IParrentForm parrent, string admin, string passwd, string domain)
        {
            mainForm = parrent;
            InitializeComponent();
            this.admin = admin;
            this.passwd = passwd;
            this.domain = domain;
            setComputers();
            adListBox.Sorted = true;
            installListBox.Sorted = true;
            
        }
        //конструктор со ссылкой на родительское окно и массивом
        //содержащим имена компутеров которые были выбраны до этого
        public ImportADComp(IParrentForm parrent, string[] selectedComputers, string admin, string passwd, string domain)
        {
            
            mainForm = parrent;
            InitializeComponent();
            this.admin = admin;
            this.passwd = passwd;
            this.domain = domain;
            setComputers();
            adListBox.Sorted = true;
            installListBox.Sorted = true;           
            foreach (string s in selectedComputers)
            {
                if (s != "")
                {
                    installListBox.Items.Add(s);
                    adListBox.Items.Remove(s);
                }
            }
        }
        protected void setComputers()
        {
            ArrayList list = ComputersSet.getComputers(this.admin, this.passwd, this.domain);
            foreach (object s in list)
            {
                adListBox.Items.Add(s);
            }
            
        }

        private void adButton_Click(object sender, EventArgs e)
        {
            addItemsToListBox(adListBox, installListBox);
        }
        //добавление/удаление компутеров в правую часть списка(в список для установки)
        private void addItemsToListBox(ListBox sourceListBox, ListBox destListBox)
        {
            String strItem;
            ArrayList removeItems = new ArrayList();
            foreach (object selectedItem in sourceListBox.SelectedItems)
            {
                strItem = selectedItem as String;
                destListBox.Items.Add(strItem);
                removeItems.Add(strItem);
            }
            foreach (object removeItem in removeItems)
            {
               sourceListBox.Items.Remove(removeItem);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            addItemsToListBox(installListBox, adListBox);
        }

        private void installListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //при нажатии кнопки OK форма закрывается и в нее передается строка
        //содержащая все выбранные компьютеры разделенные ';'
        private void okButton_Click(object sender, EventArgs e)
        {
            
            string str = System.String.Empty;
            ArrayList destComputers = new ArrayList(installListBox.Items);
            foreach (String s in destComputers)
            {
                
                if ((str.Length + s.Length) > 40)
                {
                    str += '\n';
                    mainForm.setComputers(str);
                    str = "";
                }
                str += s + ";";
            }
            mainForm.setComputers(str);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
