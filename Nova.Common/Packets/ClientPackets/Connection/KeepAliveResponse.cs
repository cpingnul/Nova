using Nova.Packets;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class KeepAliveResponse : IPacket
    {
        [ProtoMember(1)]
        public DateTime TimeSent { get; set; }
    }
}
