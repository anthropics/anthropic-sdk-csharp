using System.Buffers;
using System.Buffers.Binary;
using System.IO.Pipelines;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Anthropic.Bedrock;

/// <summary>
/// Provides helper methods for processing Server-Sent Events (SSE) from AWS Bedrock event streams.
/// Handles parsing, validation, and synchronization of event stream messages encoded according to
/// the AWS event stream encoding specification.
/// </summary>
/// <remarks>
/// Reference: https://docs.aws.amazon.com/lexv2/latest/dg/event-stream-encoding.html
/// </remarks>
internal static class SseEventHelpers
{
    private static readonly JsonSerializerOptions? _jsonOptions = new() { WriteIndented = false };

    public static async Task<bool> SyncStreamMessage(
        Stream source,
        Stream target,
        CancellationToken cancellationToken
    )
    {
        var (data, success) = await ReadStreamMessage(source, cancellationToken)
            .ConfigureAwait(false);
        if (!success)
        {
            return false;
        }
        await target
            .WriteAsync(Encoding.UTF8.GetBytes(data!), cancellationToken)
            .ConfigureAwait(false);
        return true;
    }

    public static async Task<(string? Data, bool readData)> ReadStreamMessage(
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

        Span<byte> preamble = stackalloc byte[12];
        try
        {
            source.ReadExactly(preamble); // we cannot use Async methods here as they require Memory<byte> which lives on the heap
        }
        catch (EndOfStreamException) // exceptions for control flow are bad but its how this works. Only catch it here as at every other occasion its not expected.
        {
            return (null, false);
        }

        if (!Crc32ChecksumValidation(preamble[..8], preamble[8..]))
        {
            throw new InvalidDataException(
                $"The preamble at position {source.Position} is invalid"
            );
        }

        if (
            !BinaryPrimitives.TryReadInt32BigEndian(preamble[0..4], out var totalLength)
            || !BinaryPrimitives.TryReadInt32BigEndian(preamble[4..8], out var headerLength)
            || totalLength <= 0
            || headerLength <= 0
        )
        {
            throw new InvalidDataException($"The preamble lengths are invalid");
        }

        // we dont care about headers so skip them
        Span<byte> header =
            headerLength < 1024 ? stackalloc byte[headerLength] : new byte[headerLength];
        source.ReadExactly(header);

        // total length is without the preamble (8bytes) + preamble crc (4bytes) + headers but do not take the message crc (4 bytes)
        var messageLength = totalLength - 12 - headerLength - 4;
        var bodyData = ArrayPool<byte>.Shared.Rent(messageLength);
        try
        {
            Memory<byte> messageSpan = bodyData.AsMemory()[0..messageLength];
            source.ReadExactly(messageSpan.Span); // read the message part

            Span<byte> messageCrc = stackalloc byte[4];
            source.ReadExactly(messageCrc); // advance 4 bytes for EOM crc sum
            if (!Crc32ChecksumValidation([.. preamble, .. header, .. messageSpan.Span], messageCrc))
            {
                throw new InvalidDataException(
                    "The calculated crc checksum for the message content does not match the provided value from the server."
                );
            }
            var result = await Parse(new ReadOnlySequence<byte>(messageSpan), cancellationToken)
                .ConfigureAwait(false);
            return (result, true);
        } // do not catch the EndOfStream exception here as its still unexpected to happen here and should bubble up
        finally
        {
            ArrayPool<byte>.Shared.Return(bodyData);
        }
    }

    private static async Task<string?> Parse(
        ReadOnlySequence<byte> bodyData,
        CancellationToken cancellationToken
    )
    {
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
        if (parsedEvent is null)
        {
            return null;
        }

        return $"event:{parsedEvent["type"]}\ndata:{parsedEvent.ToJsonString(_jsonOptions)}\n\n"; // add double linebreaks at the end to force the StreamReader to emit an empty line for parsing.
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
