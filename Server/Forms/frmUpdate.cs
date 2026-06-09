using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nova.Forms
{
    public partial class frmUpdate : Form
    {
        private int selectedClients;
        public frmUpdate(int selected)
        {
            selectedClients = selected;
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _Update.DownloadURL = txtURL.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("Nova - 更新 [选择: {0}]", selectedClients);
            this.lblInformation.Text = "确认新的客户端一样的配置文件";
            txtURL.Text = _Update.DownloadURL;
            btnUpdate.Text = "更新";
        }
    }
    public class _Update
    {
        public static string DownloadURL { get; set; }
    }
}
