namespace HDLG.WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonChooseSourceDirectory = new System.Windows.Forms.Button();
            this.folderBrowserDialogInput = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonCreateFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFileType = new System.Windows.Forms.GroupBox();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.radioButtonHTML = new System.Windows.Forms.RadioButton();
            this.mainFormErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelDirectoryInput = new System.Windows.Forms.Label();
            this.LinkLabelFile = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxFileType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormErrorProvider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChooseSourceDirectory
            // 
            resources.ApplyResources(this.buttonChooseSourceDirectory, "buttonChooseSourceDirectory");
            this.buttonChooseSourceDirectory.Name = "buttonChooseSourceDirectory";
            this.buttonChooseSourceDirectory.UseVisualStyleBackColor = true;
            this.buttonChooseSourceDirectory.Click += new System.EventHandler(this.buttonChooseSourceDirectory_Click);
            // 
            // buttonCreateFile
            // 
            resources.ApplyResources(this.buttonCreateFile, "buttonCreateFile");
            this.buttonCreateFile.Name = "buttonCreateFile";
            this.buttonCreateFile.UseVisualStyleBackColor = true;
            this.buttonCreateFile.Click += new System.EventHandler(this.buttonCreateFile_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // groupBoxFileType
            // 
            this.groupBoxFileType.Controls.Add(this.radioButtonXML);
            this.groupBoxFileType.Controls.Add(this.radioButtonHTML);
            resources.ApplyResources(this.groupBoxFileType, "groupBoxFileType");
            this.groupBoxFileType.Name = "groupBoxFileType";
            this.groupBoxFileType.TabStop = false;
            // 
            // radioButtonXML
            // 
            resources.ApplyResources(this.radioButtonXML, "radioButtonXML");
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.UseVisualStyleBackColor = true;
            // 
            // radioButtonHTML
            // 
            resources.ApplyResources(this.radioButtonHTML, "radioButtonHTML");
            this.radioButtonHTML.Name = "radioButtonHTML";
            this.radioButtonHTML.TabStop = true;
            this.radioButtonHTML.UseVisualStyleBackColor = true;
            // 
            // mainFormErrorProvider
            // 
            this.mainFormErrorProvider.ContainerControl = this;
            // 
            // labelDirectoryInput
            // 
            resources.ApplyResources(this.labelDirectoryInput, "labelDirectoryInput");
            this.labelDirectoryInput.Name = "labelDirectoryInput";
            // 
            // LinkLabelFile
            // 
            resources.ApplyResources(this.LinkLabelFile, "LinkLabelFile");
            this.LinkLabelFile.Name = "LinkLabelFile";
            this.LinkLabelFile.TabStop = true;
            this.LinkLabelFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelFile_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LinkLabelFile);
            this.Controls.Add(this.groupBoxFileType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateFile);
            this.Controls.Add(this.labelDirectoryInput);
            this.Controls.Add(this.buttonChooseSourceDirectory);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.groupBoxFileType.ResumeLayout(false);
            this.groupBoxFileType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormErrorProvider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseSourceDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogInput;
        private System.Windows.Forms.Button buttonCreateFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxFileType;
        private System.Windows.Forms.RadioButton radioButtonHTML;
        private System.Windows.Forms.RadioButton radioButtonXML;
        private System.Windows.Forms.ErrorProvider mainFormErrorProvider;
        private System.Windows.Forms.Label labelDirectoryInput;
        private System.Windows.Forms.LinkLabel LinkLabelFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

