using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(TextEditorCodeExecutionToolResultErrorCodeConverter))]
public enum TextEditorCodeExecutionToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
}

sealed class TextEditorCodeExecutionToolResultErrorCodeConverter
    : JsonConverter<TextEditorCodeExecutionToolResultErrorCode>
{
    public override TextEditorCodeExecutionToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput,
            "unavailable" => TextEditorCodeExecutionToolResultErrorCode.Unavailable,
            "too_many_requests" => TextEditorCodeExecutionToolResultErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                TextEditorCodeExecutionToolResultErrorCode.ExecutionTimeExceeded,
            "file_not_found" => TextEditorCodeExecutionToolResultErrorCode.FileNotFound,
            _ => (TextEditorCodeExecutionToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextEditorCodeExecutionToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextEditorCodeExecutionToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                TextEditorCodeExecutionToolResultErrorCode.Unavailable => "unavailable",
                TextEditorCodeExecutionToolResultErrorCode.TooManyRequests => "too_many_requests",
                TextEditorCodeExecutionToolResultErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                TextEditorCodeExecutionToolResultErrorCode.FileNotFound => "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
