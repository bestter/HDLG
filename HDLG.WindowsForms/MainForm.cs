/*
    This file is part of HTML Directory List Generator (HDLG).

    HDLG is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    HDLG is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with HDLG.  If not, see <http://www.gnu.org/licenses/>.
*/

using HDLG.Business;
using System;
using System.IO;
using System.Windows.Forms;

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

        /// <summary>
        /// Quit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Show about box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxHDLG aboutBox = new AboutBoxHDLG();
            aboutBox.Show(this);
        }
    }
}
