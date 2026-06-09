using Nova;
using System;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmRemoteShell : Form
    {
        private Client cClient;
        public frmRemoteShell(Client c)
        {
            cClient = c;
            cClient.Value.frmRS = this;

            InitializeComponent();

            txtConsoleOutput.Text = ">> Type 'exit' to close this session" + Environment.NewLine;
        }

        private void frmRemoteShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            cClient.Send(new Nova.Packets.ServerPackets.ShellCommand("exit"));
            if (cClient.Value != null)
                cClient.Value.frmRS = null;
        }

        private void txtConsoleOutput_TextChanged(object sender, EventArgs e)
        {
            txtConsoleOutput.SelectionStart = txtConsoleOutput.TextLength;
            txtConsoleOutput.ScrollToCaret();
        }

        private void txtConsoleOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)2)
            {
                txtConsoleInput.Text += e.KeyChar.ToString();
                txtConsoleInput.Focus();
                txtConsoleInput.SelectionStart = txtConsoleOutput.TextLength;
                //txtConsoleInput.SelectionStart = txtConsoleInput.Text.Length;
                txtConsoleInput.ScrollToCaret();
            }
        }

        private void txtConsoleInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtConsoleInput.Text.Trim()))
            {
                string input = txtConsoleInput.Text;
                txtConsoleInput.Text = string.Empty;

                switch (input)
                {
                    case "cls":
                        txtConsoleOutput.Text = string.Empty;
                        break;
                    default:
                        cClient.Send(new Nova.Packets.ServerPackets.ShellCommand(input));
                        break;
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void frmRemoteShell_Load(object sender, EventArgs e)
        {
            if (cClient != null)
                this.Text = string.Format("Nova - 远程Shell [{0}:{1}]", cClient.EndPoint.Address.ToString(), cClient.EndPoint.Port.ToString());
        }
    }
}
