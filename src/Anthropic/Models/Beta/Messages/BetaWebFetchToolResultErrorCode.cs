using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebFetchToolResultErrorCodeConverter))]
public enum BetaWebFetchToolResultErrorCode
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

sealed class BetaWebFetchToolResultErrorCodeConverter
    : JsonConverter<BetaWebFetchToolResultErrorCode>
{
    public override BetaWebFetchToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaWebFetchToolResultErrorCode.InvalidToolInput,
            "url_too_long" => BetaWebFetchToolResultErrorCode.UrlTooLong,
            "url_not_allowed" => BetaWebFetchToolResultErrorCode.UrlNotAllowed,
            "url_not_accessible" => BetaWebFetchToolResultErrorCode.UrlNotAccessible,
            "unsupported_content_type" => BetaWebFetchToolResultErrorCode.UnsupportedContentType,
            "too_many_requests" => BetaWebFetchToolResultErrorCode.TooManyRequests,
            "max_uses_exceeded" => BetaWebFetchToolResultErrorCode.MaxUsesExceeded,
            "unavailable" => BetaWebFetchToolResultErrorCode.Unavailable,
            _ => (BetaWebFetchToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebFetchToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                BetaWebFetchToolResultErrorCode.UrlTooLong => "url_too_long",
                BetaWebFetchToolResultErrorCode.UrlNotAllowed => "url_not_allowed",
                BetaWebFetchToolResultErrorCode.UrlNotAccessible => "url_not_accessible",
                BetaWebFetchToolResultErrorCode.UnsupportedContentType =>
                    "unsupported_content_type",
                BetaWebFetchToolResultErrorCode.TooManyRequests => "too_many_requests",
                BetaWebFetchToolResultErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                BetaWebFetchToolResultErrorCode.Unavailable => "unavailable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
