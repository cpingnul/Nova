using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class GetSystemInfo : IPacket
    {
        public GetSystemInfo() { }

    }
}
