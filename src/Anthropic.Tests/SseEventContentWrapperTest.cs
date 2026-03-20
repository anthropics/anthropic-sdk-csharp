#pragma warning disable xUnit1051 // ReadAsStreamAsync CancellationToken overload not available on net472
using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;

namespace Anthropic.Tests;

public class SseEventContentWrapperTest
{
    /// <summary>
    /// Builds a binary AWS EventStream message containing a JSON payload
    /// with a base64-encoded inner event, matching the Bedrock response format.
    /// </summary>
    private static byte[] BuildEventStreamMessage(string eventType, string eventJson)
    {
        // Inner payload: base64-encode the event JSON
        var innerBytes = Encoding.UTF8.GetBytes(eventJson);
        var base64 = Convert.ToBase64String(innerBytes);
        var outerJson = $"{{\"bytes\":\"{base64}\"}}";
        var payloadBytes = Encoding.UTF8.GetBytes(outerJson);

        // Build a minimal header: ":event-type" -> eventType (string type = 7)
        var headerName = ":event-type"u8;
        var headerValue = Encoding.UTF8.GetBytes(eventType);
        // Header format: name_len(1) + name + type(1) + value_len(2) + value
        var headerLen = 1 + headerName.Length + 1 + 2 + headerValue.Length;

        var totalLen = 12 + headerLen + payloadBytes.Length + 4; // prelude(12) + headers + payload + message_crc(4)
        var message = new byte[totalLen];

        // Prelude: total_length(4) + header_length(4) + prelude_crc(4)
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(0), totalLen);
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(4), headerLen);
        var preludeCrc = Crc32(message.AsSpan(0, 8));
        BinaryPrimitives.WriteUInt32BigEndian(message.AsSpan(8), preludeCrc);

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
        payloadBytes.CopyTo(message, offset);
        offset += payloadBytes.Length;

        // Message CRC (over everything except the last 4 bytes)
        var messageCrc = Crc32(message.AsSpan(0, offset));
        BinaryPrimitives.WriteUInt32BigEndian(message.AsSpan(offset), messageCrc);

        return message;
    }

    private static uint Crc32(ReadOnlySpan<byte> data) =>
        AwsEventStreamHelpers.CRC32.ComputeChecksum(data);

    [Fact]
    public async Task ReadAsync_HandlesEventLargerThanBuffer()
    {
        // Build an event with a large payload that will exceed a small read buffer
        var largeContent = new string('x', 2000);
        var eventJson =
            $"{{\"type\":\"content_block_delta\",\"delta\":{{\"text\":\"{largeContent}\"}}}}";
        var messageBytes = BuildEventStreamMessage("chunk", eventJson);

        using var stream = new MemoryStream(messageBytes);
        var wrapper = new SseEventContentWrapper(stream);
        var contentStream = await wrapper.ReadAsStreamAsync();

        // Read with a deliberately small buffer (256 bytes)
        var allData = new MemoryStream();
        var buffer = new byte[256];
        int bytesRead;
        while (
            (
                bytesRead = await contentStream.ReadAsync(
                    buffer,
                    TestContext.Current.CancellationToken
                )
            ) > 0
        )
        {
            allData.Write(buffer, 0, bytesRead);
        }

        var result = Encoding.UTF8.GetString(allData.ToArray());

        // The result should be a valid SSE event
        Assert.StartsWith("event:", result);
        Assert.Contains("content_block_delta", result);
        Assert.Contains(largeContent, result);
        Assert.EndsWith("\n\n", result);
    }

    [Fact]
    public async Task ReadAsync_HandlesSmallEvent()
    {
        var eventJson = "{\"type\":\"ping\"}";
        var messageBytes = BuildEventStreamMessage("chunk", eventJson);

        using var stream = new MemoryStream(messageBytes);
        var wrapper = new SseEventContentWrapper(stream);
        var contentStream = await wrapper.ReadAsStreamAsync();

        // Use a large buffer — should fit in one read
        var buffer = new byte[8192];
        var bytesRead = await contentStream.ReadAsync(
            buffer,
            TestContext.Current.CancellationToken
        );

        var result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Assert.StartsWith("event:", result);
        Assert.Contains("ping", result);
    }
}
