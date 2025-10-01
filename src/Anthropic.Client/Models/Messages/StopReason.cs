using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(StopReasonConverter))]
public enum StopReason
{
    EndTurn,
    MaxTokens,
    StopSequence,
    ToolUse,
    PauseTurn,
    Refusal,
    ModelContextWindowExceeded,
}

sealed class StopReasonConverter : JsonConverter<StopReason>
{
    public override StopReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_turn" => StopReason.EndTurn,
            "max_tokens" => StopReason.MaxTokens,
            "stop_sequence" => StopReason.StopSequence,
            "tool_use" => StopReason.ToolUse,
            "pause_turn" => StopReason.PauseTurn,
            "refusal" => StopReason.Refusal,
            "model_context_window_exceeded" => StopReason.ModelContextWindowExceeded,
            _ => (StopReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StopReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StopReason.EndTurn => "end_turn",
                StopReason.MaxTokens => "max_tokens",
                StopReason.StopSequence => "stop_sequence",
                StopReason.ToolUse => "tool_use",
                StopReason.PauseTurn => "pause_turn",
                StopReason.Refusal => "refusal",
                StopReason.ModelContextWindowExceeded => "model_context_window_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
