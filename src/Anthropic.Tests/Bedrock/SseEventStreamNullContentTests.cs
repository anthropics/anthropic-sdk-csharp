#pragma warning disable xUnit1051 // ReadAsStreamAsync CancellationToken overload not available on net472
using System;
using System.Buffers.Binary;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Xunit;

namespace Anthropic.Tests.Bedrock;

public class SseEventStreamNullContentTests
{
    /// <summary>
    /// Builds a single AWS event-stream message (prelude + prelude CRC +
    /// headers + payload + message CRC) with the given JSON payload. A minimal
    /// ":event-type" header is included because the parser rejects messages
    /// with a zero header length.
    /// </summary>
    private static byte[] BuildEventStreamMessage(string payloadJson)
    {
        var payload = Encoding.UTF8.GetBytes(payloadJson);

        var headerName = Encoding.UTF8.GetBytes(":event-type");
        var headerValue = Encoding.UTF8.GetBytes("chunk");
        // Header format: name_len(1) + name + type(1) + value_len(2) + value
        var headerLen = 1 + headerName.Length + 1 + 2 + headerValue.Length;

        var totalLength = 16 + headerLen + payload.Length; // 8 prelude + 4 prelude CRC + headers + payload + 4 message CRC
        var message = new byte[totalLength];

        // Prelude: total_length(4) + header_length(4) + prelude_crc(4)
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(0, 4), totalLength);
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(4, 4), headerLen);
        var preludeCrc = AwsEventStreamHelpers.CRC32.ComputeChecksum(message.AsSpan(0, 8));
        BinaryPrimitives.WriteUInt32BigEndian(message.AsSpan(8, 4), preludeCrc);

        // Headers
        var offset = 12;
        message[offset++] = (byte)headerName.Length;
        headerName.CopyTo(message.AsSpan(offset));
        offset += headerName.Length;
        message[offset++] = 7; // string type
        BinaryPrimitives.WriteUInt16BigEndian(message.AsSpan(offset), (ushort)headerValue.Length);
        offset += 2;
        headerValue.CopyTo(message, offset);
        offset += headerValue.Length;

        // Payload
        payload.CopyTo(message, offset);
        offset += payload.Length;

        // Message CRC (over everything except the last 4 bytes)
        var messageCrc = AwsEventStreamHelpers.CRC32.ComputeChecksum(message.AsSpan(0, offset));
        BinaryPrimitives.WriteUInt32BigEndian(message.AsSpan(offset, 4), messageCrc);

        return message;
    }

    [Fact]
    public async Task ReadAsync_NullContentEvent_IsSkipped_AndNextEventIsRead()
    {
        // A control event with no "bytes" field followed by a content event.
        var control = BuildEventStreamMessage("{\"type\":\"messageStart\"}");
        var contentBytes = Convert.ToBase64String(Encoding.UTF8.GetBytes("{\"content\":\"hi\"}"));
        var content = BuildEventStreamMessage(
            "{\"type\":\"chunk\",\"bytes\":\"" + contentBytes + "\"}"
        );

        using var wrapper = new SseEventContentWrapper(
            new MemoryStream(Concat(control, content))
        );
        using var contentStream = await wrapper.ReadAsStreamAsync();

        var buffer = new byte[4096];
        var read = await contentStream.ReadAsync(
            buffer,
            TestContext.Current.CancellationToken
        );

        Assert.True(
            read > 0,
            "expected the content event to be read after skipping the control event"
        );
        var text = Encoding.UTF8.GetString(buffer, 0, read);
        Assert.StartsWith("event:chunk", text);
        Assert.Contains("\"content\":\"hi\"", text);
    }

    [Fact]
    public async Task ReadAsync_NullContentEvent_AtEndOfStream_ReturnsZeroWithoutThrowing()
    {
        // A stream that ends right after a null-content control event must
        // terminate cleanly instead of crashing on a null payload.
        var control = BuildEventStreamMessage("{\"type\":\"messageStart\"}");

        using var wrapper = new SseEventContentWrapper(new MemoryStream(control));
        using var contentStream = await wrapper.ReadAsStreamAsync();

        var buffer = new byte[64];
        var read = await contentStream.ReadAsync(
            buffer,
            TestContext.Current.CancellationToken
        );

        Assert.Equal(0, read);
    }

    private static byte[] Concat(params byte[][] parts)
    {
        var result = new byte[parts.Sum(p => p.Length)];
        var offset = 0;
        foreach (var part in parts)
        {
            part.CopyTo(result, offset);
            offset += part.Length;
        }
        return result;
    }
}
