using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class Uninstall : IPacket
    {
        public Uninstall() { }
    }
}
