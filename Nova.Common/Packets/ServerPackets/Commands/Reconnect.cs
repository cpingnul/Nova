using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class Reconnect : IPacket
    {
        public Reconnect() { }

    }
}
