using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(EnumConverter<StopReason, string>))]
public sealed record class StopReason(string value) : IEnum<StopReason, string>
{
    public static readonly StopReason EndTurn = new("end_turn");

    public static readonly StopReason MaxTokens = new("max_tokens");

    public static readonly StopReason StopSequence = new("stop_sequence");

    public static readonly StopReason ToolUse = new("tool_use");

    public static readonly StopReason PauseTurn = new("pause_turn");

    public static readonly StopReason Refusal = new("refusal");

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

    public static StopReason FromRaw(string value)
    {
        return new(value);
    }
}
