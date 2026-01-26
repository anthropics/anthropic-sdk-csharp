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
    public string? FileName { get; init; }
    public MediaTypeHeaderValue ContentType { get; set; } = new("application/octet-stream");

    public static implicit operator BinaryContent(Stream stream) =>
        new()
        {
            Stream = stream,
            FileName = stream is FileStream fileStream ? Path.GetFileName(fileStream.Name) : null,
        };

    public static implicit operator BinaryContent(byte[] bytes) =>
        new() { Stream = new MemoryStream(bytes) };
}
