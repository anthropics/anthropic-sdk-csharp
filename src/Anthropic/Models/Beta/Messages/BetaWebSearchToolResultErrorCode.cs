using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultErrorCodeConverter))]
public enum BetaWebSearchToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    MaxUsesExceeded,
    TooManyRequests,
    QueryTooLong,
}

sealed class BetaWebSearchToolResultErrorCodeConverter
    : JsonConverter<BetaWebSearchToolResultErrorCode>
{
    public override BetaWebSearchToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaWebSearchToolResultErrorCode.InvalidToolInput,
            "unavailable" => BetaWebSearchToolResultErrorCode.Unavailable,
            "max_uses_exceeded" => BetaWebSearchToolResultErrorCode.MaxUsesExceeded,
            "too_many_requests" => BetaWebSearchToolResultErrorCode.TooManyRequests,
            "query_too_long" => BetaWebSearchToolResultErrorCode.QueryTooLong,
            _ => (BetaWebSearchToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWebSearchToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                BetaWebSearchToolResultErrorCode.Unavailable => "unavailable",
                BetaWebSearchToolResultErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                BetaWebSearchToolResultErrorCode.TooManyRequests => "too_many_requests",
                BetaWebSearchToolResultErrorCode.QueryTooLong => "query_too_long",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
