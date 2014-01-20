using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using HDLG.Objects;
using HDLG.Business;

namespace HDLG.WindowsForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {            
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            InitializeComponent();
        }

        /// <summary>
        /// Select directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseSourceDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogInput.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                labelDirectoryInput.Text = folderBrowserDialogInput.SelectedPath;

                groupBoxFileType.Enabled = true;
                buttonCreateFile.Enabled = true;
            }

        }

        /// <summary>
        /// Create file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(folderBrowserDialogInput.SelectedPath))
            {
                Directory directory = DirectoryBusiness.GetDirectoryInformation(folderBrowserDialogInput.SelectedPath);

            }
        }
    }
}
