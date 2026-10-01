using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Anthropic.Core;

/// <summary>
/// A class representing a binary stream of data with its associated (optional) file
/// name and content type.
/// </summary>
public sealed record class BinaryContent
{
    /// <summary>
    /// The content as a stream. A request whose body reads from a caller-supplied stream is sent once and never
    /// retried, because the first attempt reads the stream to its end and disposes of it; a request whose file
    /// parts were all created from byte arrays is retried as usual. Every attempt sends such an array in full,
    /// whatever this stream's position.
    /// </summary>
    public required Stream Stream { get; init; }
    string? _fileName;

    /// <summary>
    /// The file name sent with the content. When unset and <see cref="Stream"/> is a
    /// <see cref="FileStream"/>, defaults to that file's name without its directory.
    /// </summary>
    public string? FileName
    {
        get
        {
            return _fileName
                ?? (Stream is FileStream fileStream ? Path.GetFileName(fileStream.Name) : null);
        }
        init { _fileName = value; }
    }
    public MediaTypeHeaderValue ContentType { get; set; } = new("application/octet-stream");

    public static implicit operator BinaryContent(Stream stream) => new() { Stream = stream };

    public static implicit operator BinaryContent(byte[] bytes) =>
        new() { Stream = new BytesStream(bytes) };

    /// <summary>
    /// Whether a request that sends this content can send it again on a retry. True only for content created from
    /// a byte array, which every attempt can send again; a caller's stream is read and disposed of by the first
    /// attempt.
    /// </summary>
    internal bool IsRepeatable
    {
        get { return Stream is BytesStream; }
    }

    /// <summary>
    /// The HTTP content for one attempt at a request that sends this content: the byte array it was created from,
    /// or else <see cref="Stream"/>.
    /// </summary>
    internal HttpContent ToHttpContent() =>
        Stream is BytesStream bytesStream
            ? new ByteArrayContent(bytesStream.Bytes)
            : new StreamContent(Stream);

    /// <summary>
    /// A read-only stream over the byte array the content was created from; see <see cref="IsRepeatable"/>.
    /// </summary>
    sealed class BytesStream : MemoryStream
    {
        internal BytesStream(byte[] bytes)
            : base(bytes, writable: false)
        {
            Bytes = bytes;
        }

        internal byte[] Bytes { get; }
    }
}
