using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultErrorCodeConverter))]
public enum BetaCodeExecutionToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
}

sealed class BetaCodeExecutionToolResultErrorCodeConverter
    : JsonConverter<BetaCodeExecutionToolResultErrorCode>
{
    public override BetaCodeExecutionToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaCodeExecutionToolResultErrorCode.InvalidToolInput,
            "unavailable" => BetaCodeExecutionToolResultErrorCode.Unavailable,
            "too_many_requests" => BetaCodeExecutionToolResultErrorCode.TooManyRequests,
            "execution_time_exceeded" => BetaCodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
            _ => (BetaCodeExecutionToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCodeExecutionToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaCodeExecutionToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                BetaCodeExecutionToolResultErrorCode.Unavailable => "unavailable",
                BetaCodeExecutionToolResultErrorCode.TooManyRequests => "too_many_requests",
                BetaCodeExecutionToolResultErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
