using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SoftManager;
using System.IO;

/// <summary>
/// Это форма для выбора программы подлежащей удалению, список известных приложению программ создается во время сканирования компьютеров,
/// и сохраняется в файле SoftList.csv, находящемся в одной папке с бинарником
/// </summary>

namespace SoftManager
{
    public partial class ChoseItem : Form
    {
        FormChoseComp formChoseComp;
        //string admin;
        //string password;
        //string domain;
        //bool isSoftList = false;
        //public ChoseItem(FormChoseComp parrent, string admin, string password, string domain)
        //{
        //    InitializeComponent();
        //    formChoseComp = parrent;
        //    this.admin = admin;
        //    this.password = password;
        //    this.domain = domain;
        //    setComputers();
        //    lbItems.Sorted = true;
        //}
        public ChoseItem(FormChoseComp parrent)
        {
            InitializeComponent();
            formChoseComp = parrent;
            setSoft();
            lbItems.Sorted = true;
            //isSoftList = true;
        }

        protected void setSoft()
        {
            if(File.Exists("SoftList.csv"))
            {
            string[] softList = File.ReadAllText("SoftList.csv").Split('\t');
            for (int i = 0; i < softList.Length; i++)
            {
                if (softList[i].Length > 0)
                {
                    lbItems.Items.Add(softList[i]);
                }
            }
            }
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            string selectedItem = lbItems.SelectedItem.ToString();
            //if (!isSoftList)
            //    formChoseComp.setComputerName(selectedItem);
            //else
                formChoseComp.setSoftName(selectedItem);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
