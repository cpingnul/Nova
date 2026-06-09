using Nova.Common.Helper;
using Nova.Packets;
using Nova.Packets.ClientPackets;
using Nova.Packets.ServerPackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Nova
{
    public class Server
    {
        public int ConnectedClients { get; set; }
        public int AllTimeConnectedClients { get; set; }
        public long BytesReceived { get; set; }
        public long BytesSent { get; set; }
        public bool Listening { get; private set; }

        private Socket _socket;
        private SocketAsyncEventArgs _serverArgs;
        private bool Processing { get; set; }
        public int BufferSize { get; set; }
        private List<Type> PacketTypes { get; set; }
        private readonly List<Client> _clientList;
        // 记录每个客户端最后收到心跳响应的时间
        private readonly Dictionary<Client, DateTime> _clientLastHeartbeat;
        // 心跳锁
        private readonly object _heartbeatLock = new object();  
        public Client[] Clients
        {
            get
            {
                return Listening ? _clientList.ToArray() : new Client[0];
            }
        }
        //构造
        public Server(int bufferSize)
        {
            PacketTypes = new List<Type>();
            BufferSize = bufferSize;
           
            _clientList = new List<Client>();
            // 记录每个客户端最后心跳时间
            _clientLastHeartbeat = new Dictionary<Client, DateTime>();  
        }
        //监听
        public void Listen(ushort port)
        {
            try
            {
                if (!Listening)
                {
                    _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _socket.Bind(new IPEndPoint(IPAddress.Any, port));
                    _socket.Listen(1000);
                    //
                    Listening = true;
                    OnServerState(Listening);
                    Processing = false;
                   
                    _serverArgs = new SocketAsyncEventArgs();
                    _serverArgs.Completed += Process;
                    // 启动心跳系统
                    StartHeartbeatSystem();  
                    if (!_socket.AcceptAsync(_serverArgs))
                        Process(null, _serverArgs);
                }
            }
            catch (Exception)
            {
                Disconnect();
            }
        }
        private void Process(object s, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                // 先取出需要的信息
                Socket acceptSocket = e.AcceptSocket;
                string endpoint = acceptSocket.RemoteEndPoint?.ToString() ?? "unknown";
                int handle = acceptSocket.Handle.ToInt32();
                Client T = new Client(this, e.AcceptSocket, BufferSize, PacketTypes.ToArray());
                lock (_clientList)
                {
                    //SLogger.Info($"新连上了: {endpoint} 句柄:{handle}");
                    _clientList.Add(T);
                    T.ClientState += HandleState;
                    T.ClientRead += OnClientRead;
                    //T.ClientWrite += OnClientWrite;
                    OnClientState(T, true);
                    //SLogger.Info($"安排上了: {endpoint} 句柄:{handle} 数量: {_clientList.Count}");
                }
                // 初始化心跳时间
                lock (_heartbeatLock)
                {
                    _clientLastHeartbeat[T] = DateTime.UtcNow;
                } 
                e.AcceptSocket = null;
                if (!_socket.AcceptAsync(e))
                    Process(null, e);
            }
            else
            {
                Disconnect();
            }
        }
        
        // ========== 心跳系统 ==========
        private void StartHeartbeatSystem()
        {
            // 一个线程：每10秒发送一次心跳 + 检查超时
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);  // 每10秒执行一次
                    List<Client> timeoutClients = new List<Client>();
                    // 1. 为所有客户端发送心跳包
                    Client[] currentClients = Clients;
                    SLogger.Debug($"心跳检查开始，当前客户端数: {currentClients.Length}");
                    DateTime sendTime = DateTime.UtcNow;  // 记录发送时间
                    foreach (Client client in currentClients)
                    {
                        try
                        {
                            // 发送心跳包
                            client.Send(new KeepAlive());
                            SLogger.Debug($"发送心跳给 {client.EndPoint.Port}");
                        }
                        catch (Exception ex)
                        {
                            SLogger.Error($"发送心跳给 {client.EndPoint.Port} 失败: {ex.Message}");
                        }
                    }

                    // 2. 检查超时（超过30秒没收到响应的断开）
                    DateTime now = DateTime.UtcNow;
                    lock (_heartbeatLock)
                    {
                        foreach (var kvp in _clientLastHeartbeat.ToList())  // ToList 避免遍历时修改
                        {
                            double secondsSinceLastHeartbeat = (now - kvp.Value).TotalSeconds;
                            if (secondsSinceLastHeartbeat > 60)
                            {
                                timeoutClients.Add(kvp.Key);
                                _clientLastHeartbeat.Remove(kvp.Key);
                                // SLogger.Debug($"客户端 {kvp.Key.EndPoint.Port} 心跳超时，最后响应时间: {kvp.Value}，已过 {secondsSinceLastHeartbeat} 秒");
                            }
                        }
                    }
                    // 3. 断开超时的客户端
                    foreach (var client in timeoutClients)
                    {
                        SLogger.Debug($"客户端 {client.EndPoint} 心跳超时30秒，断开连接");
                        client.Disconnect();
                    }

                    SLogger.Debug($"心跳检查结束，超时客户端: {timeoutClients.Count}");
                }
            })
            { IsBackground = true }.Start();
        }

        internal void HandleKeepAlivePacket(KeepAliveResponse packet, Client client)
        {
            // 收到心跳响应，更新最后响应时间
            lock (_heartbeatLock)
            {
                _clientLastHeartbeat[client] = DateTime.UtcNow;
                SLogger.Debug($"收到心跳响应 {client.EndPoint.Port}，TimeSent={packet.TimeSent}，更新时间={DateTime.UtcNow}");
            }
        }
        public void Disconnect()
        {
            if (Processing)
                return;
            Processing = true;

            if (_socket != null)
                _socket.Close();

            lock (_clientList)
            {
                foreach (var client in _clientList.ToList())
                {
                    client.Disconnect();
                }
                _clientList.Clear();
            }
            lock (_heartbeatLock)
            {
                _clientLastHeartbeat.Clear();
            }

            Listening = false;
            OnServerState(Listening);
        }

        private void HandleState(Client s, bool open)
        {
            lock (_clientList)
            {
                _clientList.Remove(s);
                OnClientState(s, false);
            }
            // 清理心跳记录
            lock (_heartbeatLock)
            {
                _clientLastHeartbeat.Remove(s);
            }
        }
        public event ClientReadEventHandler ClientRead;
        public delegate void ClientReadEventHandler(Server s, Client c, IPacket packet);
        private void OnClientRead(Client c, IPacket packet)
        {
            ClientRead?.Invoke(this, c, packet);
        }
        public event ClientStateEventHandler ClientState;
        public delegate void ClientStateEventHandler(Server s, Client c, bool connected);
        private void OnClientState(Client c, bool connected)
        {
            ClientState?.Invoke(this, c, connected);
        }

        public void AddTypeToSerializer(Type parent, Type type)
        {
            if (type == null || parent == null)
                throw new ArgumentNullException();
            PacketTypes.Add(type);
        }
        public void AddTypesToSerializer(Type parent, params Type[] types)
        {
            foreach (Type type in types)
                AddTypeToSerializer(parent, type);
        }
        public event ServerStateEventHandler ServerState;
        public delegate void ServerStateEventHandler(Server s, bool listening);
        private void OnServerState(bool listening)
        {
            ServerState?.Invoke(this, listening);
        }
    }
}