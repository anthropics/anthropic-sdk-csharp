using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Client.Models.Messages.WebSearchToolRequestErrorProperties;

[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    InvalidToolInput,
    Unavailable,
    MaxUsesExceeded,
    TooManyRequests,
    QueryTooLong,
}

sealed class ErrorCodeConverter : JsonConverter<ErrorCode>
{
    public override ErrorCode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCode.InvalidToolInput,
            "unavailable" => ErrorCode.Unavailable,
            "max_uses_exceeded" => ErrorCode.MaxUsesExceeded,
            "too_many_requests" => ErrorCode.TooManyRequests,
            "query_too_long" => ErrorCode.QueryTooLong,
            _ => (ErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorCode.InvalidToolInput => "invalid_tool_input",
                ErrorCode.Unavailable => "unavailable",
                ErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                ErrorCode.TooManyRequests => "too_many_requests",
                ErrorCode.QueryTooLong => "query_too_long",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
