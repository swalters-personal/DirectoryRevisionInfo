namespace ReleaseVersionInfo
{
    partial class MainForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPackageInfo = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtExportFile = new System.Windows.Forms.TextBox();
            this.cbSubdirectories = new System.Windows.Forms.CheckBox();
            this.clbExtentions = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Location = new System.Drawing.Point(713, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 31);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(96, 16);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(601, 22);
            this.txtDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Directory:";
            // 
            // dgvPackageInfo
            // 
            this.dgvPackageInfo.AllowUserToAddRows = false;
            this.dgvPackageInfo.AllowUserToDeleteRows = false;
            this.dgvPackageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPackageInfo.Location = new System.Drawing.Point(15, 91);
            this.dgvPackageInfo.Name = "dgvPackageInfo";
            this.dgvPackageInfo.RowTemplate.Height = 24;
            this.dgvPackageInfo.Size = new System.Drawing.Size(773, 347);
            this.dgvPackageInfo.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(15, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 29);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtExportFile
            // 
            this.txtExportFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportFile.Location = new System.Drawing.Point(96, 47);
            this.txtExportFile.Name = "txtExportFile";
            this.txtExportFile.ReadOnly = true;
            this.txtExportFile.Size = new System.Drawing.Size(437, 22);
            this.txtExportFile.TabIndex = 5;
            // 
            // cbSubdirectories
            // 
            this.cbSubdirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSubdirectories.AutoSize = true;
            this.cbSubdirectories.Checked = true;
            this.cbSubdirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubdirectories.Location = new System.Drawing.Point(618, 49);
            this.cbSubdirectories.Name = "cbSubdirectories";
            this.cbSubdirectories.Size = new System.Drawing.Size(170, 21);
            this.cbSubdirectories.TabIndex = 6;
            this.cbSubdirectories.Text = "include Subdirectories";
            this.cbSubdirectories.UseVisualStyleBackColor = true;
            // 
            // clbExtentions
            // 
            this.clbExtentions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbExtentions.FormattingEnabled = true;
            this.clbExtentions.Items.AddRange(new object[] {
            ".dll",
            ".js"});
            this.clbExtentions.Location = new System.Drawing.Point(539, 44);
            this.clbExtentions.Name = "clbExtentions";
            this.clbExtentions.Size = new System.Drawing.Size(73, 53);
            this.clbExtentions.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clbExtentions);
            this.Controls.Add(this.cbSubdirectories);
            this.Controls.Add(this.txtExportFile);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvPackageInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnBrowse);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Directory Revision Info";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPackageInfo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtExportFile;
        private System.Windows.Forms.CheckBox cbSubdirectories;
        private System.Windows.Forms.CheckedListBox clbExtentions;
    }
}

