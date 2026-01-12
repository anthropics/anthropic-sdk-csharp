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
        BetaTextEditorCodeExecutionToolResultErrorParam,
        BetaTextEditorCodeExecutionToolResultErrorParamFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultErrorParam : JsonModel
{
    public required ApiEnum<
        string,
        BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
    > ErrorCode
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
            >(this.RawData, "error_code");
        }
        init { JsonModel.Set(this._rawData, "error_code", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    public string? ErrorMessage
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "error_message"); }
        init { JsonModel.Set(this._rawData, "error_message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
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
        _ = this.ErrorMessage;
    }

    public BetaTextEditorCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result_error\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultErrorParam(
        BetaTextEditorCodeExecutionToolResultErrorParam betaTextEditorCodeExecutionToolResultErrorParam
    )
        : base(betaTextEditorCodeExecutionToolResultErrorParam) { }

    public BetaTextEditorCodeExecutionToolResultErrorParam(
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
    BetaTextEditorCodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionToolResultErrorParam(
        ApiEnum<string, BetaTextEditorCodeExecutionToolResultErrorParamErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaTextEditorCodeExecutionToolResultErrorParamFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionToolResultErrorParam>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionToolResultErrorParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionToolResultErrorParamErrorCodeConverter))]
public enum BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    FileNotFound,
}

sealed class BetaTextEditorCodeExecutionToolResultErrorParamErrorCodeConverter
    : JsonConverter<BetaTextEditorCodeExecutionToolResultErrorParamErrorCode>
{
    public override BetaTextEditorCodeExecutionToolResultErrorParamErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" =>
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            "unavailable" => BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.Unavailable,
            "too_many_requests" =>
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded,
            "file_not_found" =>
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.FileNotFound,
            _ => (BetaTextEditorCodeExecutionToolResultErrorParamErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextEditorCodeExecutionToolResultErrorParamErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput =>
                    "invalid_tool_input",
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.Unavailable =>
                    "unavailable",
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.TooManyRequests =>
                    "too_many_requests",
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                BetaTextEditorCodeExecutionToolResultErrorParamErrorCode.FileNotFound =>
                    "file_not_found",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
