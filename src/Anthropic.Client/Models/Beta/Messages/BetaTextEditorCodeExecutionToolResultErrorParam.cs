using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionToolResultErrorParam>))]
public sealed record class BetaTextEditorCodeExecutionToolResultErrorParam
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionToolResultErrorParam>
{
    public required ApiEnum<string, ErrorCode2> ErrorCode
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

            return JsonSerializer.Deserialize<ApiEnum<string, ErrorCode2>>(
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

    public string? ErrorMessage
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

    public override void Validate()
    {
        this.ErrorCode.Validate();
        _ = this.Type;
        _ = this.ErrorMessage;
    }

    public BetaTextEditorCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultErrorParam(
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
    BetaTextEditorCodeExecutionToolResultErrorParam(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionToolResultErrorParam(ApiEnum<string, ErrorCode2> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

[JsonConverter(typeof(ErrorCode2Converter))]
public enum ErrorCode2
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
}

sealed class ErrorCode2Converter : JsonConverter<ErrorCode2>
{
    public override ErrorCode2 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCode2.InvalidToolInput,
            "unavailable" => ErrorCode2.Unavailable,
            "too_many_requests" => ErrorCode2.TooManyRequests,
            "execution_time_exceeded" => ErrorCode2.ExecutionTimeExceeded,
            "file_not_found" => ErrorCode2.FileNotFound,
            _ => (ErrorCode2)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorCode2 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorCode2.InvalidToolInput => "invalid_tool_input",
                ErrorCode2.Unavailable => "unavailable",
                ErrorCode2.TooManyRequests => "too_many_requests",
                ErrorCode2.ExecutionTimeExceeded => "execution_time_exceeded",
                ErrorCode2.FileNotFound => "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
