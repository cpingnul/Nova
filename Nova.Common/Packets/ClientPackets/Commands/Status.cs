using ProtoBuf;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class Status : IPacket
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        public Status() { }
        public Status(string message)
        {
            Message = message;
        }
    }
}
