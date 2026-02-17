using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ToolSearchToolResultErrorCodeConverter))]
public enum ToolSearchToolResultErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
}

sealed class ToolSearchToolResultErrorCodeConverter : JsonConverter<ToolSearchToolResultErrorCode>
{
    public override ToolSearchToolResultErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ToolSearchToolResultErrorCode.InvalidToolInput,
            "unavailable" => ToolSearchToolResultErrorCode.Unavailable,
            "too_many_requests" => ToolSearchToolResultErrorCode.TooManyRequests,
            "execution_time_exceeded" => ToolSearchToolResultErrorCode.ExecutionTimeExceeded,
            _ => (ToolSearchToolResultErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolSearchToolResultErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolSearchToolResultErrorCode.InvalidToolInput => "invalid_tool_input",
                ToolSearchToolResultErrorCode.Unavailable => "unavailable",
                ToolSearchToolResultErrorCode.TooManyRequests => "too_many_requests",
                ToolSearchToolResultErrorCode.ExecutionTimeExceeded => "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
