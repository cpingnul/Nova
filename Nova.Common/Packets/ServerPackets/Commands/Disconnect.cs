using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class Disconnect : IPacket
    {
        public Disconnect() { }
    }
}
