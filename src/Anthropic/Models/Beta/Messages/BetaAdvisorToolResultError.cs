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
    typeof(JsonModelConverter<BetaAdvisorToolResultError, BetaAdvisorToolResultErrorFromRaw>)
)]
public sealed record class BetaAdvisorToolResultError : JsonModel
{
    public required ApiEnum<string, ErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ErrorCode>>("error_code");
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
                JsonSerializer.SerializeToElement("advisor_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorToolResultError(BetaAdvisorToolResultError betaAdvisorToolResultError)
        : base(betaAdvisorToolResultError) { }
#pragma warning restore CS8618

    public BetaAdvisorToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorToolResultError(ApiEnum<string, ErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaAdvisorToolResultErrorFromRaw : IFromRawJson<BetaAdvisorToolResultError>
{
    /// <inheritdoc/>
    public BetaAdvisorToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorToolResultError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    MaxUsesExceeded,
    PromptTooLong,
    TooManyRequests,
    Overloaded,
    Unavailable,
    ExecutionTimeExceeded,
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
            "max_uses_exceeded" => ErrorCode.MaxUsesExceeded,
            "prompt_too_long" => ErrorCode.PromptTooLong,
            "too_many_requests" => ErrorCode.TooManyRequests,
            "overloaded" => ErrorCode.Overloaded,
            "unavailable" => ErrorCode.Unavailable,
            "execution_time_exceeded" => ErrorCode.ExecutionTimeExceeded,
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
                ErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                ErrorCode.PromptTooLong => "prompt_too_long",
                ErrorCode.TooManyRequests => "too_many_requests",
                ErrorCode.Overloaded => "overloaded",
                ErrorCode.Unavailable => "unavailable",
                ErrorCode.ExecutionTimeExceeded => "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
