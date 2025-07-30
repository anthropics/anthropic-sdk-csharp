using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(EnumConverter<BetaWebSearchToolResultErrorCode, string>))]
public sealed record class BetaWebSearchToolResultErrorCode(string value)
    : IEnum<BetaWebSearchToolResultErrorCode, string>
{
    public static readonly BetaWebSearchToolResultErrorCode InvalidToolInput = new(
        "invalid_tool_input"
    );

    public static readonly BetaWebSearchToolResultErrorCode Unavailable = new("unavailable");

    public static readonly BetaWebSearchToolResultErrorCode MaxUsesExceeded = new(
        "max_uses_exceeded"
    );

    public static readonly BetaWebSearchToolResultErrorCode TooManyRequests = new(
        "too_many_requests"
    );

    public static readonly BetaWebSearchToolResultErrorCode QueryTooLong = new("query_too_long");

    readonly string _value = value;

    public enum Value
    {
        InvalidToolInput,
        Unavailable,
        MaxUsesExceeded,
        TooManyRequests,
        QueryTooLong,
    }

    public Value Known() =>
        _value switch
        {
            "invalid_tool_input" => Value.InvalidToolInput,
            "unavailable" => Value.Unavailable,
            "max_uses_exceeded" => Value.MaxUsesExceeded,
            "too_many_requests" => Value.TooManyRequests,
            "query_too_long" => Value.QueryTooLong,
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

    public static BetaWebSearchToolResultErrorCode FromRaw(string value)
    {
        return new(value);
    }
}
