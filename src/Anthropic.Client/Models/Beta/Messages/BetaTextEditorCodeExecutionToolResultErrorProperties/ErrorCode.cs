using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultErrorProperties;

[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
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
            "too_many_requests" => ErrorCode.TooManyRequests,
            "execution_time_exceeded" => ErrorCode.ExecutionTimeExceeded,
            "file_not_found" => ErrorCode.FileNotFound,
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
                ErrorCode.TooManyRequests => "too_many_requests",
                ErrorCode.ExecutionTimeExceeded => "execution_time_exceeded",
                ErrorCode.FileNotFound => "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
