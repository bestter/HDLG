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
using System.IO;

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
            mainFormErrorProvider.Clear();

            if (!string.IsNullOrEmpty(folderBrowserDialogInput.SelectedPath))
            {
                //Get data
                HDLG.Objects.Directory directory = DirectoryBusiness.GetDirectoryInformation(folderBrowserDialogInput.SelectedPath);

                string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

                //Save data
                if (radioButtonHTML.Checked)
                {
                    DirectoryBusiness.SaveToHtml(directory, Path.Combine(directoryPath, directory.DirectoryInformation.Name + ".html"));
                }
                else if (radioButtonXML.Checked)
                {
                    DirectoryBusiness.SaveToXML(directory, Path.Combine(directoryPath, directory.DirectoryInformation.Name + ".xml"));
                }
                else
                {
                    mainFormErrorProvider.SetError(groupBoxFileType, "Must select type of file");
                }
            }
            else
            {
                mainFormErrorProvider.SetError(buttonChooseSourceDirectory, "Must select source directory");
            }
        }
    }
}
