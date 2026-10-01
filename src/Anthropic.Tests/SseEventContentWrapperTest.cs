#pragma warning disable xUnit1051 // ReadAsStreamAsync CancellationToken overload not available on net472
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Tests;

public class SseEventContentWrapperTest
{
    /// <summary>
    /// Builds a binary AWS EventStream message containing a JSON payload
    /// with a base64-encoded inner event, matching the Bedrock response format.
    /// </summary>
    private static byte[] BuildEventStreamMessage(string eventType, string eventJson)
    {
        var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(eventJson));
        return BuildFrame(
            [(":event-type", eventType), (":message-type", "event")],
            Encoding.UTF8.GetBytes($"{{\"bytes\":\"{base64}\"}}")
        );
    }

    /// <summary>
    /// Builds a binary AWS EventStream message with string-valued headers.
    /// </summary>
    private static byte[] BuildFrame((string Name, string Value)[] headers, byte[] payloadBytes)
    {
        // Header format: name_len(1) + name + type(1) + value_len(2) + value
        var headerBytes = new MemoryStream();
        foreach (var (name, value) in headers)
        {
            var nameBytes = Encoding.UTF8.GetBytes(name);
            var valueBytes = Encoding.UTF8.GetBytes(value);
            headerBytes.WriteByte((byte)nameBytes.Length);
            headerBytes.Write(nameBytes, 0, nameBytes.Length);
            headerBytes.WriteByte(7); // string type
            var valueLength = new byte[2];
            BinaryPrimitives.WriteUInt16BigEndian(valueLength, (ushort)valueBytes.Length);
            headerBytes.Write(valueLength, 0, 2);
            headerBytes.Write(valueBytes, 0, valueBytes.Length);
        }
        var headerLen = (int)headerBytes.Length;

        var totalLen = 12 + headerLen + payloadBytes.Length + 4; // prelude(12) + headers + payload + message_crc(4)
        var message = new byte[totalLen];

        // Prelude: total_length(4) + header_length(4) + prelude_crc(4)
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(0), totalLen);
        BinaryPrimitives.WriteInt32BigEndian(message.AsSpan(4), headerLen);
        var preludeCrc = Crc32(message.AsSpan(0, 8));
        BinaryPrimitives.WriteUInt32BigEndian(message.AsSpan(8), preludeCrc);

        var offset = 12;
        headerBytes.ToArray().CopyTo(message, offset);
        offset += headerLen;

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

    private const string MessageStart =
        "{\"type\":\"message_start\",\"message\":{\"id\":\"msg_bdrk_01\",\"type\":\"message\",\"role\":\"assistant\",\"content\":[]}}";
    private const string ContentBlockStart =
        "{\"type\":\"content_block_start\",\"index\":0,\"content_block\":{\"type\":\"text\",\"text\":\"\"}}";
    private const string MessageStop = "{\"type\":\"message_stop\"}";

    private static async Task CollectEventTypes(List<string> eventTypes, params byte[][] frames)
    {
        using var response = new HttpResponseMessage
        {
            Content = new SseEventContentWrapper(
                new MemoryStream([.. frames.SelectMany(frame => frame)])
            ),
        };
        await foreach (
            var streamEvent in Sse.Enumerate<JsonElement>(
                response,
                TestContext.Current.CancellationToken
            )
        )
        {
            eventTypes.Add(streamEvent.GetProperty("type").GetString()!);
        }
    }

    [Fact]
    public async Task ExceptionFrame_ThrowsSseErrorAfterPrecedingEvents()
    {
        var eventTypes = new List<string>();
        var exception = await Assert.ThrowsAsync<AnthropicSseException>(() =>
            CollectEventTypes(
                eventTypes,
                BuildEventStreamMessage("chunk", MessageStart),
                BuildEventStreamMessage("chunk", ContentBlockStart),
                BuildFrame(
                    [
                        (":exception-type", "throttlingException"),
                        (":content-type", "application/json"),
                        (":message-type", "exception"),
                    ],
                    Encoding.UTF8.GetBytes(
                        "{\"message\":\"Too many requests, please wait before trying again.\"}"
                    )
                )
            )
        );

        Assert.Equal(["message_start", "content_block_start"], eventTypes);
        Assert.Equal(
            "SSE error returned from server: '{\"type\":\"error\",\"error\":{\"type\":\"throttlingException\",\"message\":\"Too many requests, please wait before trying again.\"}}'",
            exception.Message
        );
    }

    [Fact]
    public async Task ErrorFrame_ThrowsSseErrorAfterPrecedingEvents()
    {
        var eventTypes = new List<string>();
        var exception = await Assert.ThrowsAsync<AnthropicSseException>(() =>
            CollectEventTypes(
                eventTypes,
                BuildEventStreamMessage("chunk", MessageStart),
                BuildFrame(
                    [
                        (":error-code", "InternalFailure"),
                        (":error-message", "An internal error occurred."),
                        (":message-type", "error"),
                    ],
                    []
                )
            )
        );

        Assert.Equal(["message_start"], eventTypes);
        Assert.Equal(
            "SSE error returned from server: '{\"type\":\"error\",\"error\":{\"type\":\"InternalFailure\",\"message\":\"An internal error occurred.\"}}'",
            exception.Message
        );
    }

    [Fact]
    public async Task TypelessChunk_IsSkipped()
    {
        var frames = new[]
        {
            BuildEventStreamMessage("chunk", MessageStart),
            BuildEventStreamMessage("chunk", "{\"amazon-bedrock-invocationMetrics\":{}}"),
            BuildEventStreamMessage("chunk", MessageStop),
        };
        using var stream = new MemoryStream([.. frames.SelectMany(frame => frame)]);
        var wrapper = new SseEventContentWrapper(stream);
        var contentStream = await wrapper.ReadAsStreamAsync();
        var allData = new MemoryStream();

        await contentStream.CopyToAsync(allData, 81920, TestContext.Current.CancellationToken);

        var result = Encoding.UTF8.GetString(allData.ToArray());

        Assert.Equal(
            $"event:message_start\ndata:{MessageStart}\n\nevent:message_stop\ndata:{MessageStop}\n\n",
            result
        );
    }
}
