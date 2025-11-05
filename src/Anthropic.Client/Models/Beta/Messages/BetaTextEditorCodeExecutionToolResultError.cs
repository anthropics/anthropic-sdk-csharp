using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionToolResultError>))]
public sealed record class BetaTextEditorCodeExecutionToolResultError
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionToolResultError>
{
    public required ApiEnum<string, ErrorCode1> ErrorCode
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

            return JsonSerializer.Deserialize<ApiEnum<string, ErrorCode1>>(
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

    public required string? ErrorMessage
    {
        get
        {
            if (!this._properties.TryGetValue("error_message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["error_message"] = JsonSerializer.SerializeToElement(
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
        _ = this.ErrorMessage;
        _ = this.Type;
    }

    public BetaTextEditorCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultError(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ErrorCode1Converter))]
public enum ErrorCode1
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
}

sealed class ErrorCode1Converter : JsonConverter<ErrorCode1>
{
    public override ErrorCode1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCode1.InvalidToolInput,
            "unavailable" => ErrorCode1.Unavailable,
            "too_many_requests" => ErrorCode1.TooManyRequests,
            "execution_time_exceeded" => ErrorCode1.ExecutionTimeExceeded,
            "file_not_found" => ErrorCode1.FileNotFound,
            _ => (ErrorCode1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorCode1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorCode1.InvalidToolInput => "invalid_tool_input",
                ErrorCode1.Unavailable => "unavailable",
                ErrorCode1.TooManyRequests => "too_many_requests",
                ErrorCode1.ExecutionTimeExceeded => "execution_time_exceeded",
                ErrorCode1.FileNotFound => "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
