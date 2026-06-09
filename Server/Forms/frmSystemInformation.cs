using Nova;
using Nova.Commands;
using System;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmSystemInformation : Form
    {
        private Client cClient;
        public frmSystemInformation(Client c)
        {
            cClient = c;
            cClient.Value.frmSI = this;
            InitializeComponent();
        }

        private void frmSystemInformation_Load(object sender, EventArgs e)
        {
            if (cClient != null)
            {
                this.Text = string.Format("NORAT - 系统信息 [{0}:{1}]", cClient.EndPoint.Address.ToString(), cClient.EndPoint.Port.ToString());
                cClient.Send(new Nova.Packets.ServerPackets.GetSystemInfo());
                
                if (cClient.Value != null)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { "Operating System", cClient.Value.OperatingSystem });
                    lstSystem.Items.Add(lvi);
                    lvi = new ListViewItem(new string[] { "Architecture", (cClient.Value.OperatingSystem.Contains("32 Bit")) ? "x86 (32 Bit)" : "x64 (64 Bit)" });
                    lstSystem.Items.Add(lvi);
                    lvi = new ListViewItem(new string[] { "", "获取更多信息中..." });
                    lstSystem.Items.Add(lvi);
                }
            }
        }

        private void frmSystemInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cClient.Value != null)
                cClient.Value.frmSI = null;
        }

        private void ctxtCopy_Click(object sender, EventArgs e)
        {
            if (lstSystem.SelectedItems.Count != 0)
            {
                string output = string.Empty;

                foreach (ListViewItem lvi in lstSystem.SelectedItems)
                {
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                        output += lvs.Text + " : ";

                    output = output.Remove(output.Length - 3);
                    output = output + "\r\n";
                }
                Clipboard.SetText(output);
            }
        }
    }
}
