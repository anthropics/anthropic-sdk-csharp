using System;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.WebSearchToolResultErrorProperties;

[JsonConverter(typeof(EnumConverter<ErrorCode, string>))]
public sealed record class ErrorCode(string value) : IEnum<ErrorCode, string>
{
    public static readonly ErrorCode InvalidToolInput = new("invalid_tool_input");

    public static readonly ErrorCode Unavailable = new("unavailable");

    public static readonly ErrorCode MaxUsesExceeded = new("max_uses_exceeded");

    public static readonly ErrorCode TooManyRequests = new("too_many_requests");

    public static readonly ErrorCode QueryTooLong = new("query_too_long");

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

    public static ErrorCode FromRaw(string value)
    {
        return new(value);
    }
}
