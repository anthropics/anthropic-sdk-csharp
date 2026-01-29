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
    typeof(JsonModelConverter<
        BetaTextEditorCodeExecutionToolResultError,
        BetaTextEditorCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultError : JsonModel
{
    public required ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorErrorCode>
            >("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public required string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        _ = this.ErrorMessage;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionToolResultError(
        BetaTextEditorCodeExecutionToolResultError betaTextEditorCodeExecutionToolResultError
    )
        : base(betaTextEditorCodeExecutionToolResultError) { }
#pragma warning restore CS8618

    public BetaTextEditorCodeExecutionToolResultError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionToolResultErrorFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionToolResultError>
{
    /// <inheritdoc/>
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
