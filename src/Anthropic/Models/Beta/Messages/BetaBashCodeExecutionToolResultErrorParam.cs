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
        BetaBashCodeExecutionToolResultErrorParam,
        BetaBashCodeExecutionToolResultErrorParamFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionToolResultErrorParam : ModelBase
{
    public required ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> ErrorCode
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode>
            >(this.RawData, "error_code");
        }
        init { ModelBase.Set(this._rawData, "error_code", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

    public BetaBashCodeExecutionToolResultErrorParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionToolResultErrorParam(
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorParamErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaBashCodeExecutionToolResultErrorParamFromRaw
    : IFromRaw<BetaBashCodeExecutionToolResultErrorParam>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionToolResultErrorParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaBashCodeExecutionToolResultErrorParamErrorCodeConverter))]
public enum BetaBashCodeExecutionToolResultErrorParamErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    OutputFileTooLarge,
}

sealed class BetaBashCodeExecutionToolResultErrorParamErrorCodeConverter
    : JsonConverter<BetaBashCodeExecutionToolResultErrorParamErrorCode>
{
    public override BetaBashCodeExecutionToolResultErrorParamErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" =>
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput,
            "unavailable" => BetaBashCodeExecutionToolResultErrorParamErrorCode.Unavailable,
            "too_many_requests" =>
                BetaBashCodeExecutionToolResultErrorParamErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaBashCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded,
            "output_file_too_large" =>
                BetaBashCodeExecutionToolResultErrorParamErrorCode.OutputFileTooLarge,
            _ => (BetaBashCodeExecutionToolResultErrorParamErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBashCodeExecutionToolResultErrorParamErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaBashCodeExecutionToolResultErrorParamErrorCode.InvalidToolInput =>
                    "invalid_tool_input",
                BetaBashCodeExecutionToolResultErrorParamErrorCode.Unavailable => "unavailable",
                BetaBashCodeExecutionToolResultErrorParamErrorCode.TooManyRequests =>
                    "too_many_requests",
                BetaBashCodeExecutionToolResultErrorParamErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                BetaBashCodeExecutionToolResultErrorParamErrorCode.OutputFileTooLarge =>
                    "output_file_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
