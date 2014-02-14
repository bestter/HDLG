using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HDLG.WindowsForms
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            //Init
            string content = null;
            RichTextBoxLicense.Clear();

            //Get file
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "COPYING.txt");


            if (File.Exists(filePath))
            {
                //Get content
                content = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(content))
                {
                    RichTextBoxLicense.Text = content;
                }
            }
        }
    }
}
