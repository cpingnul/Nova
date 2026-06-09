using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class GetProcesses : IPacket
    {
        public GetProcesses() { }

    }
}
