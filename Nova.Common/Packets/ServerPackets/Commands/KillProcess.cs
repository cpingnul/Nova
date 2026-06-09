using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class KillProcess : IPacket
    {
        [ProtoMember(1)]
        public int PID { get; set; }

        public KillProcess() { }
        public KillProcess(int pid)
        {
            this.PID = pid;
        }
    }
}
