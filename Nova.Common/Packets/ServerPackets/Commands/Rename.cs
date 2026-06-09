using ProtoBuf;

namespace Nova.Packets.ServerPackets
{
    [ProtoContract]
    public class Rename : IPacket
    {
        [ProtoMember(1)]
        public string Path { get; set; }

        [ProtoMember(2)]
        public string NewPath { get; set; }

        [ProtoMember(3)]
        public bool IsDir { get; set; }

        public Rename() { }
        public Rename(string path, string newpath, bool isdir)
        {
            this.Path = path;
            this.NewPath = newpath;
            this.IsDir = isdir;
        }
    }
}
