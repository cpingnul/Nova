using ProtoBuf;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class DrivesResponse : IPacket
    {
        [ProtoMember(1)]
        public string[] Drives { get; set; }

        public DrivesResponse() { }
        public DrivesResponse(string[] drives)
        {
            this.Drives = drives;
        }
    }
}