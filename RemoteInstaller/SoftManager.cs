using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoftManager;


namespace SoftManager
{
    /// <summary>
    /// главное окно программы
    /// </summary>
    public partial class FormSoftManager : Form
    {
        private const string helpfile = "SoftManager.chm";
        //HelpNavigator navigator = HelpNavigator.TableOfContents;
        public FormSoftManager()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm remoteInstaller = new MainForm(this);
            this.Visible = false;
            remoteInstaller.Visible = true;
        }

        private void btnRemoteUninstaller_Click(object sender, EventArgs e)
        {
            FormChoseComp choseComp = new FormChoseComp(this);
            this.Visible = false;
            choseComp.Visible = true;
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.Show();
        }

        private void installProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm remoteInstaller = new MainForm(this);
            this.Visible = false;
            remoteInstaller.Visible = true;
        }

        private void uninstallProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChoseComp choseComp = new FormChoseComp(this);
            this.Visible = false;
            choseComp.Visible = true;
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpNavigator navigator = HelpNavigator.TableOfContents;
            Help.ShowHelp(this, helpfile, navigator);
        }

       

        
    }
}
