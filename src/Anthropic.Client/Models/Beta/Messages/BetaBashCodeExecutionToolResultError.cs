using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaBashCodeExecutionToolResultError>))]
public sealed record class BetaBashCodeExecutionToolResultError
    : ModelBase,
        IFromRaw<BetaBashCodeExecutionToolResultError>
{
    public required ApiEnum<string, ErrorCode> ErrorCode
    {
        get
        {
            if (!this._properties.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "error_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
        _ = this.Type;
    }

    public BetaBashCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

    public BetaBashCodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaBashCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionToolResultError(ApiEnum<string, ErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    OutputFileTooLarge,
}

sealed class ErrorCodeConverter : JsonConverter<ErrorCode>
{
    public override ErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCode.InvalidToolInput,
            "unavailable" => ErrorCode.Unavailable,
            "too_many_requests" => ErrorCode.TooManyRequests,
            "execution_time_exceeded" => ErrorCode.ExecutionTimeExceeded,
            "output_file_too_large" => ErrorCode.OutputFileTooLarge,
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
                ErrorCode.OutputFileTooLarge => "output_file_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
