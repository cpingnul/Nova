using ProtoBuf;
using System;

namespace Nova.Packets.ClientPackets
{
    [ProtoContract]
    public class ShellCommandResponse : IPacket
    {
        [ProtoMember(1)]
        public string Output { get; set; }

        public ShellCommandResponse() {
            //Console.WriteLine($"[CTOR] New instance created: {GetHashCode()}");
        }
        public ShellCommandResponse(string output)
        {
            this.Output = output;
        }
    }
}