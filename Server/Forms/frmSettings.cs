using Nova.Settings;
using System;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmSettings : Form
    {
        Nova.Server listenServer;
        public frmSettings(Nova.Server listenServer)
        {
            this.listenServer = listenServer;

            InitializeComponent();

            if (listenServer.Listening)
            {
                btnListen.Text = "停止";
                ncPort.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ncPort.Value = XMLSettings.ListenPort;
            chkAutoListen.Checked = XMLSettings.AutoListen;
            chkPopup.Checked = XMLSettings.ShowPopup;
            txtPassword.Text = XMLSettings.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XMLSettings.WriteValue("ListenPort", ncPort.Value.ToString());
            XMLSettings.ListenPort = ushort.Parse(ncPort.Value.ToString());

            XMLSettings.WriteValue("AutoListen", chkAutoListen.Checked.ToString());
            XMLSettings.AutoListen = chkAutoListen.Checked;

            XMLSettings.WriteValue("ShowPopup", chkPopup.Checked.ToString());
            XMLSettings.ShowPopup = chkPopup.Checked;

            XMLSettings.WriteValue("Password", txtPassword.Text);
            XMLSettings.Password = txtPassword.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (btnListen.Text == "开始" && !listenServer.Listening)
            {
                listenServer.Listen(ushort.Parse(ncPort.Value.ToString()));
                btnListen.Text = "停止";
                ncPort.Enabled = false;
                txtPassword.Enabled = false;
            }
            else if (btnListen.Text == "停止" && listenServer.Listening)
            {
                listenServer.Disconnect();
                btnListen.Text = "开始";
                ncPort.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}
