using System;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchProperties;

/// <summary>
/// Processing status of the Message Batch.
/// </summary>
[JsonConverter(typeof(EnumConverter<ProcessingStatus, string>))]
public sealed record class ProcessingStatus(string value) : IEnum<ProcessingStatus, string>
{
    public static readonly ProcessingStatus InProgress = new("in_progress");

    public static readonly ProcessingStatus Canceling = new("canceling");

    public static readonly ProcessingStatus Ended = new("ended");

    readonly string _value = value;

    public enum Value
    {
        InProgress,
        Canceling,
        Ended,
    }

    public Value Known() =>
        _value switch
        {
            "in_progress" => Value.InProgress,
            "canceling" => Value.Canceling,
            "ended" => Value.Ended,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static ProcessingStatus FromRaw(string value)
    {
        return new(value);
    }
}
