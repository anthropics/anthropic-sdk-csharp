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
        BetaBashCodeExecutionToolResultError,
        BetaBashCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionToolResultError : JsonModel
{
    public required ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode>
            >("error_code");
        }
        init { this._rawData.Set("error_code", value); }
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBashCodeExecutionToolResultError(
        BetaBashCodeExecutionToolResultError betaBashCodeExecutionToolResultError
    )
        : base(betaBashCodeExecutionToolResultError) { }
#pragma warning restore CS8618

    public BetaBashCodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionToolResultError(
        ApiEnum<string, BetaBashCodeExecutionToolResultErrorErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaBashCodeExecutionToolResultErrorFromRaw
    : IFromRawJson<BetaBashCodeExecutionToolResultError>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionToolResultError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaBashCodeExecutionToolResultErrorErrorCodeConverter))]
public enum BetaBashCodeExecutionToolResultErrorErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    OutputFileTooLarge,
}

sealed class BetaBashCodeExecutionToolResultErrorErrorCodeConverter
    : JsonConverter<BetaBashCodeExecutionToolResultErrorErrorCode>
{
    public override BetaBashCodeExecutionToolResultErrorErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput,
            "unavailable" => BetaBashCodeExecutionToolResultErrorErrorCode.Unavailable,
            "too_many_requests" => BetaBashCodeExecutionToolResultErrorErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaBashCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded,
            "output_file_too_large" =>
                BetaBashCodeExecutionToolResultErrorErrorCode.OutputFileTooLarge,
            _ => (BetaBashCodeExecutionToolResultErrorErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBashCodeExecutionToolResultErrorErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaBashCodeExecutionToolResultErrorErrorCode.InvalidToolInput =>
                    "invalid_tool_input",
                BetaBashCodeExecutionToolResultErrorErrorCode.Unavailable => "unavailable",
                BetaBashCodeExecutionToolResultErrorErrorCode.TooManyRequests =>
                    "too_many_requests",
                BetaBashCodeExecutionToolResultErrorErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                BetaBashCodeExecutionToolResultErrorErrorCode.OutputFileTooLarge =>
                    "output_file_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
