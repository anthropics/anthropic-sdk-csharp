using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaTextEditorCodeExecutionToolResultError,
        BetaTextEditorCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultError : ModelBase
{
    public required ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            if (!this._rawData.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "error_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? ErrorMessage
    {
        get
        {
            if (!this._rawData.TryGetValue("error_message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
        _ = this.ErrorMessage;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_tool_result_error\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionToolResultErrorFromRaw
    : IFromRaw<BetaTextEditorCodeExecutionToolResultError>
{
    public BetaTextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionToolResultError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionToolResultErrorErrorCodeConverter))]
public enum BetaTextEditorCodeExecutionToolResultErrorErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
}

sealed class BetaTextEditorCodeExecutionToolResultErrorErrorCodeConverter
    : JsonConverter<BetaTextEditorCodeExecutionToolResultErrorErrorCode>
{
    public override BetaTextEditorCodeExecutionToolResultErrorErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" =>
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            "unavailable" => BetaTextEditorCodeExecutionToolResultErrorErrorCode.Unavailable,
            "too_many_requests" =>
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded,
            "file_not_found" => BetaTextEditorCodeExecutionToolResultErrorErrorCode.FileNotFound,
            _ => (BetaTextEditorCodeExecutionToolResultErrorErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextEditorCodeExecutionToolResultErrorErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.InvalidToolInput =>
                    "invalid_tool_input",
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.Unavailable => "unavailable",
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.TooManyRequests =>
                    "too_many_requests",
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                BetaTextEditorCodeExecutionToolResultErrorErrorCode.FileNotFound =>
                    "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
