using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(BashCodeExecutionToolResultErrorCodeConverter))]
public enum BashCodeExecutionToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    OutputFileTooLarge,
}

sealed class BashCodeExecutionToolResultErrorCodeConverter
    : JsonConverter<BashCodeExecutionToolResultErrorCode>
{
    public override BashCodeExecutionToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BashCodeExecutionToolResultErrorCode.InvalidToolInput,
            "unavailable" => BashCodeExecutionToolResultErrorCode.Unavailable,
            "too_many_requests" => BashCodeExecutionToolResultErrorCode.TooManyRequests,
            "execution_time_exceeded" => BashCodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
            "output_file_too_large" => BashCodeExecutionToolResultErrorCode.OutputFileTooLarge,
            _ => (BashCodeExecutionToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BashCodeExecutionToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BashCodeExecutionToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                BashCodeExecutionToolResultErrorCode.Unavailable => "unavailable",
                BashCodeExecutionToolResultErrorCode.TooManyRequests => "too_many_requests",
                BashCodeExecutionToolResultErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                BashCodeExecutionToolResultErrorCode.OutputFileTooLarge => "output_file_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
