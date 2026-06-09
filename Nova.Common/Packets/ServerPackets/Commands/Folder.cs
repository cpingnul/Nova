using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class Folder : IPacket
    {
        [ProtoMember(1)]
        public string RemotePath { get; set; }

        public Folder() { }
        public Folder(string remotepath)
        {
            this.RemotePath = remotepath;
        }
    }
}
