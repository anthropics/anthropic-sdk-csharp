using System.IO;
using System.IO.Compression;
using Net = System.Net;

namespace Anthropic.Core;

static class DecompressionMethods
{
    internal static readonly Net::DecompressionMethods Available;

    static DecompressionMethods()
    {
        try
        {
            // Minimal valid GZip payload (empty body).
            var gzipPayload = new byte[]
            {
                0x1f,
                0x8b,
                0x08,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x03,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
            };
            using var memoryStream = new MemoryStream(gzipPayload);
            using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
            gzipStream.CopyTo(Stream.Null);
            Available = Net::DecompressionMethods.GZip;
        }
        catch
        {
            Available = Net::DecompressionMethods.None;
        }
    }
}
