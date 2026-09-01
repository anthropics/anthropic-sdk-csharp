using System.IO;
using System.Net.Http.Headers;

namespace Anthropic.Core;

/// <summary>
/// A class representing a binary stream of data with its associated (optional) file
/// name and content type.
/// </summary>
public sealed record class BinaryContent
{
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
        new() { Stream = new MemoryStream(bytes) };
}
