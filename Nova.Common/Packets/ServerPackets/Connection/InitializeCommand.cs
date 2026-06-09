using ProtoBuf;
namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class InitializeCommand : IPacket
    {
        public InitializeCommand() { }
    }
}
