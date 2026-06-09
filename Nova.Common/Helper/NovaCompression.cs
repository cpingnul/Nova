using System.IO;
using System.IO.Compression;
namespace Nova.Common.Helper
{
    public static class NovaCompression
    {
        public static byte[] Compress(byte[] data)
        {
            using (var ms = new MemoryStream())
            {
                using (var gzip = new GZipStream(ms, CompressionLevel.Optimal))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
        public static byte[] Decompress(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            using (var gzip = new GZipStream(ms, CompressionMode.Decompress))
            using (var result = new MemoryStream())
            {
                gzip.CopyTo(result);
                return result.ToArray();
            }
        }
    }
}
