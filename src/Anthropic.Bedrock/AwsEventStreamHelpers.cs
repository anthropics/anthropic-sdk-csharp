using System.Buffers;
using System.Buffers.Binary;
using System.IO.Pipelines;
using System.Text.Json;
using System.Text.Json.Nodes;
using Amazon.Runtime.EventStreams;

namespace Anthropic.Bedrock;

/// <summary>
/// Provides helper methods for processing Server-Sent Events (SSE) from AWS Bedrock event streams.
/// Handles parsing, validation, and synchronization of event stream messages encoded according to
/// the AWS event stream encoding specification.
/// </summary>
/// <remarks>
/// Reference: https://docs.aws.amazon.com/lexv2/latest/dg/event-stream-encoding.html
/// </remarks>
internal static class AwsEventStreamHelpers
{
    private static readonly JsonSerializerOptions? _jsonOptions = new() { WriteIndented = false };

    /// <returns>The next SSE event, or <c>null</c> at the end of the stream.</returns>
    public static async Task<string?> ReadStreamMessage(
        Stream source,
        CancellationToken cancellationToken
    )
    {
        while (true)
        {
            var (data, readData) = await ReadFrame(source, cancellationToken).ConfigureAwait(false);
            if (!readData || data is not null)
            {
                return data;
            }
        }
    }

    private static async Task<(string? Data, bool readData)> ReadFrame(
        Stream source,
        CancellationToken cancellationToken
    )
    {
        /*
        events come in the form of the event stream.
        https://docs.aws.amazon.com/lexv2/latest/dg/event-stream-encoding.html
        |                Prelude                  |             |            Data                 |
        | Total Byte Length | Headers Byte Length | Prelude CRC | Headers | Payload | Message CRC |
        | 4 byte            | 4byte               | 4byte       |                                 |
        */

        Memory<byte> preamble = new byte[12];
        try
        {
            await source.ReadExactlyAsync(preamble, cancellationToken).ConfigureAwait(false);
        }
        // only catch exceptions here as at every other occasion it's not expected.
        catch (EndOfStreamException)
        {
            return (null, false);
        }

        if (!Crc32ChecksumValidation(preamble[..8].Span, preamble[8..].Span))
        {
            throw new InvalidDataException(
                $"The preamble at position {source.Position} is invalid"
            );
        }

        if (
            !BinaryPrimitives.TryReadInt32BigEndian(preamble[0..4].Span, out var totalLength)
            || !BinaryPrimitives.TryReadInt32BigEndian(preamble[4..8].Span, out var headerLength)
            || totalLength <= 0
            || headerLength <= 0
        )
        {
            throw new InvalidDataException($"The preamble lengths are invalid");
        }

        var header = new byte[headerLength];
        await source.ReadExactlyAsync(header, cancellationToken).ConfigureAwait(false);

        // total length is without the preamble (8bytes) + preamble crc (4bytes) + headers but do not take the message crc (4 bytes)
        var messageLength = totalLength - 12 - headerLength - 4;
        using var bodyData = MemoryPool<byte>.Shared.Rent(messageLength);
        Memory<byte> messageSpan = bodyData.Memory[0..messageLength];
        await source.ReadExactlyAsync(messageSpan, cancellationToken).ConfigureAwait(false); // read the message part

        Memory<byte> messageCrc = new byte[4];
        await source.ReadExactlyAsync(messageCrc, cancellationToken).ConfigureAwait(false); // advance 4 bytes for EOM crc sum
        if (
            !Crc32ChecksumValidation(
                [.. preamble.Span, .. header, .. messageSpan.Span],
                messageCrc.Span
            )
        )
        {
            throw new InvalidDataException(
                "The calculated crc checksum for the message content does not match the provided value from the server."
            );
        }
        var result = await Parse(
                ReadStringHeaders(header),
                new ReadOnlySequence<byte>(messageSpan),
                cancellationToken
            )
            .ConfigureAwait(false);
        return (result, true);
    }

    private static async Task<string?> Parse(
        Dictionary<string, string> headers,
        ReadOnlySequence<byte> bodyData,
        CancellationToken cancellationToken
    )
    {
        headers.TryGetValue(":message-type", out var messageType);
        switch (messageType)
        {
            // Bedrock ends the stream with an exception or error frame, which we surface like a
            // mid-stream SSE `error` event from the Anthropic API.
            case "exception":
                headers.TryGetValue(":exception-type", out var exceptionType);
                var payload = await JsonSerializer
                    .DeserializeAsync<JsonObject>(
                        PipeReader.Create(bodyData),
                        _jsonOptions,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
                return ErrorEvent(
                    exceptionType,
                    payload?["message"] is JsonValue value && value.TryGetValue(out string? message)
                        ? message
                        : null
                );
            case "error":
                headers.TryGetValue(":error-code", out var errorCode);
                headers.TryGetValue(":error-message", out var errorMessage);
                return ErrorEvent(errorCode, errorMessage);
        }

        var eventLine = await JsonSerializer
            .DeserializeAsync<JsonObject>(
                PipeReader.Create(bodyData),
                _jsonOptions,
                cancellationToken
            )
            .ConfigureAwait(false);
        var eventContents = eventLine?["bytes"]?.AsValue().GetValue<string>();
        if (string.IsNullOrWhiteSpace(eventContents))
        {
            return null;
        }

        var parsedEvent = await JsonSerializer
            .DeserializeAsync<JsonObject>(
                PipeReader.Create(
                    new ReadOnlySequence<byte>(Convert.FromBase64String(eventContents))
                ),
                _jsonOptions,
                cancellationToken
            )
            .ConfigureAwait(false);
        if (parsedEvent?["type"] is not JsonValue type || !type.TryGetValue(out string? eventType))
        {
            return null;
        }

        return ToSse(eventType, parsedEvent);
    }

    private static string ErrorEvent(string? type, string? message) =>
        ToSse(
            "error",
            new JsonObject
            {
                ["type"] = "error",
                ["error"] = new JsonObject { ["type"] = type, ["message"] = message },
            }
        );

    // add double linebreaks at the end to force the StreamReader to emit an empty line for parsing.
    private static string ToSse(string eventType, JsonObject data) =>
        $"event:{eventType}\ndata:{data.ToJsonString(_jsonOptions)}\n\n";

    private static Dictionary<string, string> ReadStringHeaders(byte[] headers)
    {
        var result = new Dictionary<string, string>(StringComparer.Ordinal);
        var offset = 0;
        while (offset < headers.Length)
        {
            var header = EventStreamHeader.FromBuffer(headers, offset, ref offset);
            if (header.HeaderType == EventStreamHeaderType.String)
            {
                result[header.Name] = header.AsString();
            }
        }
        return result;
    }

    private static bool Crc32ChecksumValidation(
        ReadOnlySpan<byte> data,
        ReadOnlySpan<byte> checksum
    )
    {
        var dataChecksum = CRC32.ComputeChecksum(data);
        var reference = BinaryPrimitives.ReadUInt32BigEndian(checksum);
        return dataChecksum == reference;
    }

    public class CRC32
    {
        private static readonly uint[] CrcTable;

        static CRC32()
        {
            const uint polynomial = 0xedb88320;
            CrcTable = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint crc = i;
                for (uint j = 8; j > 0; j--)
                {
                    crc = (crc & 1) == 1 ? (crc >> 1) ^ polynomial : crc >> 1;
                }
                CrcTable[i] = crc;
            }
        }

        public static uint ComputeChecksum(ReadOnlySpan<byte> bytes)
        {
            uint crc = 0xffffffff;
            foreach (byte b in bytes)
            {
                byte tableIndex = (byte)((crc ^ b) & 0xff);
                crc = (crc >> 8) ^ CrcTable[tableIndex];
            }
            return ~crc;
        }
    }
}
