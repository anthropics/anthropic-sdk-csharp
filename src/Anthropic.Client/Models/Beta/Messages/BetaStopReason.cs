using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaStopReasonConverter))]
public enum BetaStopReason
{
    EndTurn,
    MaxTokens,
    StopSequence,
    ToolUse,
    PauseTurn,
    Refusal,
    ModelContextWindowExceeded,
}

sealed class BetaStopReasonConverter : JsonConverter<BetaStopReason>
{
    public override BetaStopReason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_turn" => BetaStopReason.EndTurn,
            "max_tokens" => BetaStopReason.MaxTokens,
            "stop_sequence" => BetaStopReason.StopSequence,
            "tool_use" => BetaStopReason.ToolUse,
            "pause_turn" => BetaStopReason.PauseTurn,
            "refusal" => BetaStopReason.Refusal,
            "model_context_window_exceeded" => BetaStopReason.ModelContextWindowExceeded,
            _ => (BetaStopReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaStopReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaStopReason.EndTurn => "end_turn",
                BetaStopReason.MaxTokens => "max_tokens",
                BetaStopReason.StopSequence => "stop_sequence",
                BetaStopReason.ToolUse => "tool_use",
                BetaStopReason.PauseTurn => "pause_turn",
                BetaStopReason.Refusal => "refusal",
                BetaStopReason.ModelContextWindowExceeded => "model_context_window_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
