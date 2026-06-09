using ProtoBuf;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class UserStatus : IPacket
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        public UserStatus() { }
        public UserStatus(string message)
        {
            Message = message;
        }
    }
}
