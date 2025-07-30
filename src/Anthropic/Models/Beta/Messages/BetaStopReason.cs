using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(EnumConverter<BetaStopReason, string>))]
public sealed record class BetaStopReason(string value) : IEnum<BetaStopReason, string>
{
    public static readonly BetaStopReason EndTurn = new("end_turn");

    public static readonly BetaStopReason MaxTokens = new("max_tokens");

    public static readonly BetaStopReason StopSequence = new("stop_sequence");

    public static readonly BetaStopReason ToolUse = new("tool_use");

    public static readonly BetaStopReason PauseTurn = new("pause_turn");

    public static readonly BetaStopReason Refusal = new("refusal");

    readonly string _value = value;

    public enum Value
    {
        EndTurn,
        MaxTokens,
        StopSequence,
        ToolUse,
        PauseTurn,
        Refusal,
    }

    public Value Known() =>
        _value switch
        {
            "end_turn" => Value.EndTurn,
            "max_tokens" => Value.MaxTokens,
            "stop_sequence" => Value.StopSequence,
            "tool_use" => Value.ToolUse,
            "pause_turn" => Value.PauseTurn,
            "refusal" => Value.Refusal,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static BetaStopReason FromRaw(string value)
    {
        return new(value);
    }
}
