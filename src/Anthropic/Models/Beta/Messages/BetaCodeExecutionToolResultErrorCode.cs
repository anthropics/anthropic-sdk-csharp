using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::EnumConverter<BetaCodeExecutionToolResultErrorCode, string>))]
public sealed record class BetaCodeExecutionToolResultErrorCode(string value)
    : Anthropic::IEnum<BetaCodeExecutionToolResultErrorCode, string>
{
    public static readonly BetaCodeExecutionToolResultErrorCode InvalidToolInput = new(
        "invalid_tool_input"
    );

    public static readonly BetaCodeExecutionToolResultErrorCode Unavailable = new("unavailable");

    public static readonly BetaCodeExecutionToolResultErrorCode TooManyRequests = new(
        "too_many_requests"
    );

    public static readonly BetaCodeExecutionToolResultErrorCode ExecutionTimeExceeded = new(
        "execution_time_exceeded"
    );

    readonly string _value = value;

    public enum Value
    {
        InvalidToolInput,
        Unavailable,
        TooManyRequests,
        ExecutionTimeExceeded,
    }

    public Value Known() =>
        _value switch
        {
            "invalid_tool_input" => Value.InvalidToolInput,
            "unavailable" => Value.Unavailable,
            "too_many_requests" => Value.TooManyRequests,
            "execution_time_exceeded" => Value.ExecutionTimeExceeded,
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

    public static BetaCodeExecutionToolResultErrorCode FromRaw(string value)
    {
        return new(value);
    }
}
