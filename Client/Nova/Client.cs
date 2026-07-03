using Nova.Common.Helper;
using Nova.Packets;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Nova
{
    public class Client
    {
        private const bool EncryptionEnabled = true;
        private byte[] KEY;
        private const bool CompressionEnabled = true;
        private readonly AsyncOperation _asyncOperation;
        //Client需要 后面传给 Args开空间
        public int BufferSize { get; set; }

        private Queue<byte[]> _sendQueue;
        private int _sendIndex;
        private byte[] _sendBuffer;
        private int _readIndex;
        private byte[] _readBuffer;

        private SocketAsyncEventArgs _sendArgs;
        private SocketAsyncEventArgs _connectReceiveArgs;
        public bool Connected { get; private set; }

        private bool _disconnecting = false;
        private bool _queueSending = false;

        private IPEndPoint _endPoint;
        public IPEndPoint EndPoint
        {
            get
            {
                return _endPoint ?? new IPEndPoint(IPAddress.None, 0);
            }
        }
        private Socket _socket;
        private int _typeIndex = 0;
        private void Initialize()
        {
            KEY = Convert.FromBase64String(Settings.PASSWORD);
            _disconnecting = false;
            _queueSending = false;

            _sendIndex = 0;
            _readIndex = 0;
            _sendBuffer = new byte[0];
            _readBuffer = new byte[0];
            _sendQueue = new Queue<byte[]>();

            _connectReceiveArgs = new SocketAsyncEventArgs();
            _connectReceiveArgs.Completed += Process;

            _sendArgs = new SocketAsyncEventArgs();
            _sendArgs.Completed += Process;
        }
        public void Connect(string host, ushort port)
        {
            try
            {
                //断开连接
                Disconnect();
                // 等待资源释放
                Thread.Sleep(50);
                Initialize();

                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                _socket.NoDelay = true;
                _connectReceiveArgs.RemoteEndPoint = new IPEndPoint(GetAddress(host), port);
                //真正连接
                if (!_socket.ConnectAsync(_connectReceiveArgs))
                    Process(null, _connectReceiveArgs);
            }
            catch (Exception ex)
            {
                SLogger.Error(ex.ToString());
                Disconnect(ex);
            }
        }
        public event ClientStateEventHandler ClientState;
        public delegate void ClientStateEventHandler(Client s, bool connected);
        private void OnClientState(bool connected)
        {
            ClientState?.Invoke(this, connected);
        }

        public event ClientReadEventHandler ClientRead;
        public delegate void ClientReadEventHandler(Client s, IPacket packet);
        private void OnClientRead(byte[] e)
        {
            if (ClientRead != null)
            {
                try
                {
                    if (EncryptionEnabled)
                        e = AesHelper.Decrypt(e, KEY);

                    if (CompressionEnabled)
                        e = NovaCompression.Decompress(e);

                    using (MemoryStream deserialized = new MemoryStream(e))
                    {
                        IPacket packet = Serializer.DeserializeWithLengthPrefix<IPacket>(deserialized, PrefixStyle.Fixed32);    
                        ClientRead(this, packet);
                    }
                }
                catch (Exception ex)
                {
                    SLogger.Warning(ex.ToString());
                }
            }
        }
        public Client(int bufferSize)
        {
            _asyncOperation = AsyncOperationManager.CreateOperation(null);
            BufferSize = bufferSize;
        }
        private void Process(object s, SocketAsyncEventArgs e)
        {
            try
            {
                if (e.SocketError == SocketError.Success)
                {
                    switch (e.LastOperation)
                    {
                        case SocketAsyncOperation.Connect:
                            _endPoint = (IPEndPoint)_socket.RemoteEndPoint;
                            Connected = true;
                            //_connectReceiveArgs
                            e.SetBuffer(new byte[BufferSize], 0, BufferSize);
                            //状态
                            _asyncOperation.Post(x => OnClientState((bool)x), true);
                            if (!_socket.ReceiveAsync(e))
                                Process(null, e);
                            break;
                        case SocketAsyncOperation.Receive:
                            if (!Connected)
                                return;
                            if (e.BytesTransferred != 0)
                            {
                                //接收到数据处理数据
                                HandleRead(e.Buffer, 0, e.BytesTransferred);
                                e.SetBuffer(new byte[BufferSize], 0, BufferSize);
                                if (!_socket.ReceiveAsync(e))
                                    Process(null, e);
                            }
                            else
                            {
                                Disconnect(new Exception("e.BytesTransferred == 0"));
                            }
                            break;
                        case SocketAsyncOperation.Send:
                            if (!Connected)
                                return;
                            _sendIndex += e.BytesTransferred;
                            HandleSendQueue();
                            break;
                    }
                }
                else
                {
                    SLogger.Error($"SocketError : {e.SocketError}，LastOperation: {e.LastOperation}");
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Disconnect(ex);
            }
        }
        public void Send<T>(T packet) where T : IPacket
        {
            lock (_sendQueue)
            {
                if (!Connected) return;
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Serializer.SerializeWithLengthPrefix<T>(ms, (T)packet, PrefixStyle.Fixed32);
                        byte[] data = ms.ToArray();
                        Send(data);
                    }
                }
                catch (Exception ex)
                {
                    SLogger.Error(ex.ToString());
                }
            }
        }
        private void Send(byte[] data)
        {
            if (!Connected)
                return;

            if (CompressionEnabled)
                data = NovaCompression.Compress(data);
            if (EncryptionEnabled)
                data = AesHelper.Encrypt(data, KEY);

            _sendQueue.Enqueue(data);

            if (!_queueSending)
            {
                _queueSending = true;
                HandleSendQueue();
            }
        }
        private void HandleSendQueue()
        {
            if (_sendIndex >= _sendBuffer.Length)
            {
                if (_sendQueue.Count == 0)
                {
                    _queueSending = false;
                    return;
                }
                _sendIndex = 0;
                _sendBuffer = Header(_sendQueue.Dequeue());
            }
            int write = Math.Min(_sendBuffer.Length - _sendIndex, BufferSize);

            _sendArgs.SetBuffer(_sendBuffer, _sendIndex, write);
            if (!_socket.SendAsync(_sendArgs))
                Process(null, _sendArgs);
            return;
        }
        public void Disconnect(Exception ex)
        {
            SLogger.Debug("[" + ex.ToString() + "] Connected = " + Connected);
            Disconnect();
        }
        public void Disconnect()
        {
            if (_disconnecting)
                return;
            _disconnecting = true;

            bool raise = Connected;

            Connected = false;

            if (_socket != null)
                _socket.Close();
            if (_sendQueue != null)
                _sendQueue.Clear();
            _sendBuffer = new byte[0];
            _readBuffer = new byte[0];
            _endPoint = null;

            if (raise)
                _asyncOperation.Post(x => OnClientState(false), null);
        }
        private void HandleRead(byte[] data, int index, int length)
        {
            //data 是接收的实体数据
            //输入: [4字节头][100字节体]（共104字节）
            //输入: [4字节头][50字节体]（包体需要100字节）
            //输入: [4字节头][101字节体]（包1共104字节）
            //输入: [包1完整104字节][包2完整104字节]
            //输入: [包1的50字节体][包2的4字节头][包2的部分体]
            try
            {
                if (_readIndex >= _readBuffer.Length)
                {
                    _readIndex = 0;

                    // 检查当前数据是否足够读取完整包头
                    if (length - index < 4)
                    {
                        // 包头不完整，缓存起来等下次
                        Array.Resize(ref _readBuffer, 4);
                        Buffer.BlockCopy(data, index, _readBuffer, 0, length - index);
                        _readIndex = length - index;
                        return;
                    }

                    int len = BitConverter.ToInt32(data, index);
                    Array.Resize(ref _readBuffer, (len < 0) ? _readBuffer.Length : len);
                    index += 4;
                }
                int read = Math.Min(_readBuffer.Length - _readIndex, length - index);
                Buffer.BlockCopy(data, index, _readBuffer, _readIndex, read);
                _readIndex += read;

                if (_readIndex >= _readBuffer.Length)
                {
                    // 创建副本，避免被后续修改
                    byte[] copy = new byte[_readBuffer.Length];
                    Buffer.BlockCopy(_readBuffer, 0, copy, 0, _readBuffer.Length);
                    _asyncOperation.Post(x => OnClientRead((byte[])x), copy);
                }

                if (read < (length - index))
                {
                    HandleRead(data, index + read, length);
                }
            }
            catch (Exception ex)
            {
                SLogger.Error(ex.ToString());
                Disconnect(ex);
            }
        }

        private IPAddress GetAddress(string host)
        {
            IPAddress[] hosts = Dns.GetHostAddresses(host);

            foreach (IPAddress h in hosts)
                if (h.AddressFamily == AddressFamily.InterNetwork)
                    return h;

            return null;
        }
        private byte[] Header(byte[] data)
        {
            byte[] tData = new byte[data.Length + 4];
            Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, tData, 0, 4);
            Buffer.BlockCopy(data, 0, tData, 4, data.Length);
            return tData;
        }
        public void AddTypeToSerializer(Type parent, Type type)
        {
            if (type == null || parent == null)
                throw new ArgumentNullException();

            bool isAdded = false;
            foreach (SubType subType in RuntimeTypeModel.Default[parent].GetSubtypes())
                if (subType.DerivedType.Type == type)
                    isAdded = true;

            if (!isAdded)
                RuntimeTypeModel.Default[parent].AddSubType(_typeIndex += 1, type);
        }

        public void AddTypesToSerializer(Type parent, params Type[] types)
        {
            foreach (Type type in types)
                AddTypeToSerializer(parent, type);
        }
    }
}
