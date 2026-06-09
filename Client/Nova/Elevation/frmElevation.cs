using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nova.Elevation
{
    public partial class frmElevation : Form
    {
        public frmElevation()
        {
            InitializeComponent();

            picError.Image = SystemIcons.Error.ToBitmap();
            SetLanguage();
        }
        private void SetLanguage()
        {
            this.ShowIcon = false;
            string CountryCode = System.Globalization.RegionInfo.CurrentRegion.TwoLetterISORegionName;
            switch (CountryCode)
            {
                case "CN":
                    this.Text = "权限请求";
                    lblHead.Text = "需要管理员权限";
                    lblText.Text = "系统检测到当前操作需要提升权限才能继续执行。\n为了确保操作成功并保护系统安全，请授予此应用程序管理权限。\n\n" +
                                   "当前目录：" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\n" +
                                   "请求级别：系统管理员 (Administrator)";
                    btnRestore.Text = "以管理员身份运行";
                    btnRestoreAndCheck.Text = "重试并请求最高权限";
                    linkError.Text = "为什么此操作需要管理员权限？";
                    break;

                default:
                    this.Text = "Permission Request";
                    lblHead.Text = "Administrator Privileges Required";
                    lblText.Text = "The system has detected that the current operation requires elevated privileges to proceed.\nTo ensure success and protect system security, please grant administrative access.\n\n" +
                                   "Target directory: " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\n" +
                                   "Requested level: System Administrator";
                    btnRestore.Text = "Run as Administrator";
                    btnRestoreAndCheck.Text = "Retry with Elevated Privileges";
                    linkError.Text = "Why do I need administrator privileges?";
                    break;

            }
        }
        private void frmElevation_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, new Point(0, panelBot.Location.Y - 1), new Point(this.Width, panelBot.Location.Y - 1));
        }
        private void btnRestore_Click(object sender, EventArgs e)
        {
            ClientInfo.UserAgree = true;
            this.Close();
        }
        private void btnRestoreAndCheck_Click(object sender, EventArgs e)
        {
            ClientInfo.UserAgree = true;
            this.Close();
        }
        private void linkError_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn.microsoft.com/en-us/library/windows/desktop/ms681381(v=vs.85).aspx");
        }
    }
}
