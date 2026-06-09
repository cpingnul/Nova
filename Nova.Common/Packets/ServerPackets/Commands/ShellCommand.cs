using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class ShellCommand : IPacket
    {
        [ProtoMember(1)]
        public string Command { get; set; }

        public ShellCommand() { }
        public ShellCommand(string command)
        {
            this.Command = command;
        }
    }
}
