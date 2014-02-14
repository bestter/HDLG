namespace HDLG.WindowsForms
{
    partial class LicenseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RichTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.TableLicensePnl = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.TableLicensePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RichTextBoxLicense
            // 
            this.RichTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBoxLicense.Location = new System.Drawing.Point(3, 3);
            this.RichTextBoxLicense.Name = "RichTextBoxLicense";
            this.RichTextBoxLicense.ReadOnly = true;
            this.RichTextBoxLicense.Size = new System.Drawing.Size(519, 367);
            this.RichTextBoxLicense.TabIndex = 0;
            this.RichTextBoxLicense.Text = "";
            // 
            // TableLicensePnl
            // 
            this.TableLicensePnl.AutoSize = true;
            this.TableLicensePnl.ColumnCount = 1;
            this.TableLicensePnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLicensePnl.Controls.Add(this.RichTextBoxLicense, 0, 0);
            this.TableLicensePnl.Controls.Add(this.buttonClose, 0, 1);
            this.TableLicensePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLicensePnl.Location = new System.Drawing.Point(0, 0);
            this.TableLicensePnl.Name = "TableLicensePnl";
            this.TableLicensePnl.RowCount = 2;
            this.TableLicensePnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.TableLicensePnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TableLicensePnl.Size = new System.Drawing.Size(525, 439);
            this.TableLicensePnl.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.AutoSize = true;
            this.buttonClose.Location = new System.Drawing.Point(447, 413);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "OK";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 439);
            this.Controls.Add(this.TableLicensePnl);
            this.Name = "LicenseForm";
            this.Text = "License";
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.TableLicensePnl.ResumeLayout(false);
            this.TableLicensePnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBoxLicense;
        private System.Windows.Forms.TableLayoutPanel TableLicensePnl;
        private System.Windows.Forms.Button buttonClose;
    }
}