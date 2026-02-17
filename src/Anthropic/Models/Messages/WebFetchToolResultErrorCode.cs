using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebFetchToolResultErrorCodeConverter))]
public enum WebFetchToolResultErrorCode
{
    InvalidToolInput,
    UrlTooLong,
    UrlNotAllowed,
    UrlNotAccessible,
    UnsupportedContentType,
    TooManyRequests,
    MaxUsesExceeded,
    Unavailable,
}

sealed class WebFetchToolResultErrorCodeConverter : JsonConverter<WebFetchToolResultErrorCode>
{
    public override WebFetchToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => WebFetchToolResultErrorCode.InvalidToolInput,
            "url_too_long" => WebFetchToolResultErrorCode.UrlTooLong,
            "url_not_allowed" => WebFetchToolResultErrorCode.UrlNotAllowed,
            "url_not_accessible" => WebFetchToolResultErrorCode.UrlNotAccessible,
            "unsupported_content_type" => WebFetchToolResultErrorCode.UnsupportedContentType,
            "too_many_requests" => WebFetchToolResultErrorCode.TooManyRequests,
            "max_uses_exceeded" => WebFetchToolResultErrorCode.MaxUsesExceeded,
            "unavailable" => WebFetchToolResultErrorCode.Unavailable,
            _ => (WebFetchToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebFetchToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebFetchToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                WebFetchToolResultErrorCode.UrlTooLong => "url_too_long",
                WebFetchToolResultErrorCode.UrlNotAllowed => "url_not_allowed",
                WebFetchToolResultErrorCode.UrlNotAccessible => "url_not_accessible",
                WebFetchToolResultErrorCode.UnsupportedContentType => "unsupported_content_type",
                WebFetchToolResultErrorCode.TooManyRequests => "too_many_requests",
                WebFetchToolResultErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                WebFetchToolResultErrorCode.Unavailable => "unavailable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
