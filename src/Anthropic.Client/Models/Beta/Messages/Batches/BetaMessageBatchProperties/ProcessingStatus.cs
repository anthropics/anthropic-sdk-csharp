using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Client.Models.Beta.Messages.Batches.BetaMessageBatchProperties;

/// <summary>
/// Processing status of the Message Batch.
/// </summary>
[JsonConverter(typeof(ProcessingStatusConverter))]
public enum ProcessingStatus
{
    InProgress,
    Canceling,
    Ended,
}

sealed class ProcessingStatusConverter : JsonConverter<ProcessingStatus>
{
    public override ProcessingStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in_progress" => ProcessingStatus.InProgress,
            "canceling" => ProcessingStatus.Canceling,
            "ended" => ProcessingStatus.Ended,
            _ => (ProcessingStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProcessingStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProcessingStatus.InProgress => "in_progress",
                ProcessingStatus.Canceling => "canceling",
                ProcessingStatus.Ended => "ended",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
