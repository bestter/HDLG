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

            LinkLabelFile.Visible = false;

            if (!string.IsNullOrEmpty(folderBrowserDialogInput.SelectedPath))
            {
                //Get data
                HDLG.Objects.Directory directory = DirectoryBusiness.GetDirectoryInformation(folderBrowserDialogInput.SelectedPath);

                string directoryPath = AppDomain.CurrentDomain.BaseDirectory;

                //Save data
                if (radioButtonHTML.Checked)
                {
                    string filePath = Path.Combine(directoryPath, directory.DirectoryInformation.Name + ".html");
                    DirectoryBusiness.SaveToHtml(directory, filePath);

                    LinkLabelFile.Text = filePath;
                    LinkLabelFile.Visible = true;
                }
                else if (radioButtonXML.Checked)
                {
                    string filePath = Path.Combine(directoryPath, directory.DirectoryInformation.Name + ".xml");
                    DirectoryBusiness.SaveToXML(directory, filePath);

                    LinkLabelFile.Text = filePath;
                    LinkLabelFile.Visible = true;
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

        /// <summary>
        /// Open file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabelFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel LinkLabelFile = (LinkLabel)sender;

            System.Diagnostics.Process.Start(LinkLabelFile.Text);

        }
    }
}
