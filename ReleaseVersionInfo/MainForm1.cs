using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ReleaseVersionInfo
{
    public partial class MainForm : Form
    {
        private SortableBindingList<FilePackageInfo> _packageInfos;

        public MainForm()
        {
            InitializeComponent();
            for (var i = 0; i < clbExtentions.Items.Count; i++)
            {
                clbExtentions.SetItemChecked(i, true);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog browserDialog = new FolderBrowserDialog())
            {
                browserDialog.SelectedPath = !string.IsNullOrWhiteSpace(txtDirectory.Text) ? txtDirectory.Text : "C:\\";
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectory.Text = browserDialog.SelectedPath;
                }
                else { return; }
            }

            if (Directory.Exists(txtDirectory.Text))
            {
                var request = new RequestInfo();
                request.Extentions= new List<string>();
                foreach (var item in clbExtentions.CheckedItems)
                {
                    request.Extentions.Add(item.ToString());
                }

                request.FilePath = txtDirectory.Text;
                request.IncludeSubDir = cbSubdirectories.Checked;

                _packageInfos = ReleaseInfo.GetDirectoryInfo(request);
                var source = new BindingSource(_packageInfos, null);
                dgvPackageInfo.DataSource = source;
                btnExport.Enabled = true;
                dgvPackageInfo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPackageInfo.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvPackageInfo.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = !string.IsNullOrWhiteSpace(txtExportFile.Text) ? txtExportFile.Text : "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtExportFile.Text = sfd.FileName;

                var success = ReleaseInfo.ExportCsvFile(dgvPackageInfo, txtExportFile.Text);
                var message = success
                    ? $"{txtExportFile.Text} Was created successfully!"
                    : $"Unable to Export data to {txtExportFile.Text}!";

                MessageBox.Show(message, "Export File", MessageBoxButtons.OK);
            }
        }
    }
}
