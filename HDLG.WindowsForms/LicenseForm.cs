﻿/*
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