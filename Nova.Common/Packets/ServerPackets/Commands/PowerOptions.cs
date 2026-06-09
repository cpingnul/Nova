using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class PowerOptions : IPacket
    {
        [ProtoMember(1)]
        public int Mode { get; set; }

        public PowerOptions() { }
        public PowerOptions(int mode)
        {
            this.Mode = mode;
        }
    }
}
