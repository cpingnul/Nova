using ProtoBuf;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class MonitorsResponse : IPacket
    {
        [ProtoMember(1)]
        public int Number { get; set; }

        public MonitorsResponse() { }
        public MonitorsResponse(int number)
        {
            this.Number = number;
        }
    }
}