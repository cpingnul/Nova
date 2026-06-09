using Nova.Common.Helper;
using Nova.Packets;
using Nova.Packets.ClientPackets;
using Nova.Settings;
using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Nova
{
    public class Client
    {
        //加密压缩
        private const bool EncryptionEnabled = true;
        private byte[] KEY;
        private const bool compressionEnabled = true;
        private bool _disconnecting = false;
        private bool _queueSending = false;
        //服务类
        private readonly Server _parentServer;
        private readonly AsyncOperation _asyncOperation;
        //客户端 socket
        private Socket _socket;
        //接收的缓冲区大小设置
        public int BufferSize { get; set; }
        //***用户状态***
        public UserState Value { get; set; }
        //连接状态是否
        public bool Connected { get; private set; }
        //protobuf-net 协议的索引加入
        private int _typeIndex = 0;
        //对端信息
        private IPEndPoint _endPoint;
        public IPEndPoint EndPoint
        {
            get
            {
                return _endPoint ?? new IPEndPoint(IPAddress.None, 0);
            }
        }
        private SocketAsyncEventArgs _sendArgs;
        private SocketAsyncEventArgs _receiveArgs;
        //发送队列
        private Queue<byte[]> _sendQueue;
        private int _sendIndex;
        private byte[] _sendBuffer;
        private int _readIndex;
        private byte[] _readBuffer;

        internal Client(Server server, Socket sock, int size, Type[] packets)
        {
            try
            {
                AddTypesToSerializer(typeof(IPacket), packets);

                _parentServer = server;
                _asyncOperation = AsyncOperationManager.CreateOperation(null);
                Initialize();
                _receiveArgs.SetBuffer(new byte[size], 0, size);
                _socket = sock;
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                _socket.NoDelay = true;
                //缓冲区大小
                BufferSize = size;
                _endPoint = (IPEndPoint)_socket.RemoteEndPoint;
                //链接中
                Connected = true;
                if (!_socket.ReceiveAsync(_receiveArgs))
                    Process(null, _receiveArgs);
            }
            catch (Exception ex)
            {
                Disconnect(ex);
            }
        }
        private void Initialize()
        {
            KEY = Convert.FromBase64String(XMLSettings.Password);
            _disconnecting = false;
            _queueSending = false;
            _sendIndex = 0;
            _readIndex = 0;
            _sendBuffer = new byte[0];
            _readBuffer = new byte[0];
            _sendQueue = new Queue<byte[]>();

            _sendArgs = new SocketAsyncEventArgs();
            _sendArgs.Completed += Process;
            _receiveArgs = new SocketAsyncEventArgs();
            _receiveArgs.Completed += Process;
        }
        public void Disconnect(Exception ex)
        {
            SLogger.Error(ex.ToString());
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
            Value = null;
            _endPoint = null;
            if (raise)
                _asyncOperation.Post(x => OnClientState(false), null);
        }

        private void Send(byte[] data)
        {
            if (!Connected)
                return;
            if (compressionEnabled)
                data = NovaCompression.Compress(data);
            if (EncryptionEnabled)
                data = AesHelper.Encrypt(data,KEY);
            // 统计流量
            _parentServer.BytesSent += data.LongLength;
            // 加入队列（一个一个protobuf数据包)
            _sendQueue.Enqueue(data);
            // 如果不在发送中，开始处理队列
            //反正数据包已经进自己的队列了，需要等SOCKET那边处理完数据再发
            if (!_queueSending)
            {
                _queueSending = true;
                // 开始发送
                HandleSendQueue();
            }
        }
        private byte[] Header(byte[] data)
        {
            byte[] T = new byte[data.Length + 4];
            Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, T, 0, 4);
            Buffer.BlockCopy(data, 0, T, 4, data.Length);
            return T;
        }
        private void HandleSendQueue()
        {
            if (_sendIndex >= _sendBuffer.Length)
            {
                if (_sendQueue.Count == 0)
                {   
                    //如果队列个数是0，说明没数据了。重置flag
                    _queueSending = false;
                    return;
                }
                _sendIndex = 0;
                _sendBuffer = Header(_sendQueue.Dequeue());
            }
            int write = Math.Min(_sendBuffer.Length - _sendIndex, BufferSize);
            //参数（缓冲区，游标，发送多少）
            _sendArgs.SetBuffer(_sendBuffer, _sendIndex, write);
            //这里是网络链的发送，但是是异步的
            if (!_socket.SendAsync(_sendArgs))
                Process(null, _sendArgs);
        }
        //这里的Send是一个简单调用，注意看下面的Send
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
                        //这个Send功能主要是进队列
                        Send(data);
                    }
                }
                catch
                {
                    return;
                }
            }
        }
        private void Process(object s, SocketAsyncEventArgs e)
        {
            try
            {
                if (e.SocketError == SocketError.Success)
                {
                    switch (e.LastOperation)
                    {
                        case SocketAsyncOperation.Receive:
                            if (!Connected)
                                return;
                            if (e.BytesTransferred > 0)
                            {
                                HandleRead(e.Buffer, 0, e.BytesTransferred);
                                e.SetBuffer(new byte[BufferSize], 0, BufferSize);
                                if (!_socket.ReceiveAsync(e))Process(null, e);
                            }
                            else
                            {
                                // 这里才是真正的关闭
                                SLogger.Info("服务器主动断开或连接重置");
                                Disconnect();
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
                    SLogger.Error($"连接断开。SocketError: {e.SocketError}, BytesTransferred: {e.BytesTransferred}");
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                Disconnect(ex);
            }
        }
        private void HandleRead(byte[] data, int index, int length)
        {
            try
            {
                //_readBuffer是动态变化的，这个的意思是read没满再         
                if (_readIndex >= _readBuffer.Length)
                {
                    _readIndex = 0;
                    //TODO 这里可能有异常，如果数据是一个字节来的或
                    int len = BitConverter.ToInt32(data, index);
                    Array.Resize(ref _readBuffer, (len < 0) ? _readBuffer.Length : len);
                    index += 4;
                }
                //_readBuffer.Length - _readIndex 是接下来需要读的数据
                //length-index 是真实还有多少数据
                int read = Math.Min(_readBuffer.Length - _readIndex, length - index);
                Buffer.BlockCopy(data, index, _readBuffer, _readIndex, read);
                //真实读的游标移动
                _readIndex += read;
                //判断如果满了包处理
                if (_readIndex >= _readBuffer.Length)
                {
                    // 创建副本，避免被后续修改
                    byte[] copy = new byte[_readBuffer.Length];
                    Buffer.BlockCopy(_readBuffer, 0, copy, 0, _readBuffer.Length);
                    _asyncOperation.Post(x => OnClientRead((byte[])x), copy);
                }
                //这次读的 小于 这次函数调用的总数据？
                if (read < (length - index))
                {
                    HandleRead(data, index + read, length);
                }
            }
            catch (Exception ex)
            {
                Disconnect(ex);
            }
        }
        public event ClientReadEventHandler ClientRead;
        public delegate void ClientReadEventHandler(Client s, IPacket packet);
        private void OnClientRead(byte[] e)
        {
            if (ClientRead != null)
            {
                try
                {
                    _parentServer.BytesReceived += e.LongLength;
                    if (EncryptionEnabled)
                        e = AesHelper.Decrypt(e, KEY);
                    if (compressionEnabled)
                        e = NovaCompression.Decompress(e);

                    using (MemoryStream deserialized = new MemoryStream(e))
                    {
                        IPacket packet = Serializer.DeserializeWithLengthPrefix<IPacket>(deserialized, PrefixStyle.Fixed32);
                        if (packet.GetType() == typeof(KeepAliveResponse))
                        {
                            _parentServer.HandleKeepAlivePacket((KeepAliveResponse)packet, this);
                        }
                        else
                            ClientRead(this, packet);
                    }
                }
                catch (Exception ex)
                {
                    SLogger.Error(ex.ToString());               
                }
            }
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
        public event ClientStateEventHandler ClientState;
        public delegate void ClientStateEventHandler(Client s, bool connected);
        private void OnClientState(bool connected)
        {
            ClientState?.Invoke(this, connected);
        }
    }
}
