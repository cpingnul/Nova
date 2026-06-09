using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class StartProcess : IPacket
    {
        [ProtoMember(1)]
        public string Processname { get; set; }

        public StartProcess() { }
        public StartProcess(string processname)
        {
            this.Processname = processname;
        }
    }
}
