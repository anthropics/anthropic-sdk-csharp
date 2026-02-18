using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultErrorCodeConverter))]
public enum WebSearchToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    MaxUsesExceeded,
    TooManyRequests,
    QueryTooLong,
    RequestTooLarge,
}

sealed class WebSearchToolResultErrorCodeConverter : JsonConverter<WebSearchToolResultErrorCode>
{
    public override WebSearchToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => WebSearchToolResultErrorCode.InvalidToolInput,
            "unavailable" => WebSearchToolResultErrorCode.Unavailable,
            "max_uses_exceeded" => WebSearchToolResultErrorCode.MaxUsesExceeded,
            "too_many_requests" => WebSearchToolResultErrorCode.TooManyRequests,
            "query_too_long" => WebSearchToolResultErrorCode.QueryTooLong,
            "request_too_large" => WebSearchToolResultErrorCode.RequestTooLarge,
            _ => (WebSearchToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebSearchToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                WebSearchToolResultErrorCode.Unavailable => "unavailable",
                WebSearchToolResultErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                WebSearchToolResultErrorCode.TooManyRequests => "too_many_requests",
                WebSearchToolResultErrorCode.QueryTooLong => "query_too_long",
                WebSearchToolResultErrorCode.RequestTooLarge => "request_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
