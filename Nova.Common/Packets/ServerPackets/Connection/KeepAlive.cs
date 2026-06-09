using Nova.Packets;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class KeepAlive : IPacket
    {
        [ProtoMember(1)]
        public DateTime TimeSent { get; private set; }

    }
}
