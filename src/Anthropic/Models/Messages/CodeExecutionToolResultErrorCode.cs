using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(CodeExecutionToolResultErrorCodeConverter))]
public enum CodeExecutionToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
}

sealed class CodeExecutionToolResultErrorCodeConverter
    : JsonConverter<CodeExecutionToolResultErrorCode>
{
    public override CodeExecutionToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => CodeExecutionToolResultErrorCode.InvalidToolInput,
            "unavailable" => CodeExecutionToolResultErrorCode.Unavailable,
            "too_many_requests" => CodeExecutionToolResultErrorCode.TooManyRequests,
            "execution_time_exceeded" => CodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
            _ => (CodeExecutionToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CodeExecutionToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CodeExecutionToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                CodeExecutionToolResultErrorCode.Unavailable => "unavailable",
                CodeExecutionToolResultErrorCode.TooManyRequests => "too_many_requests",
                CodeExecutionToolResultErrorCode.ExecutionTimeExceeded => "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
