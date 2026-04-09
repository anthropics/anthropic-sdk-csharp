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
        BetaAdvisorToolResultErrorParam,
        BetaAdvisorToolResultErrorParamFromRaw
    >)
)]
public sealed record class BetaAdvisorToolResultErrorParam : JsonModel
{
    public required ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode>
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
                JsonSerializer.SerializeToElement("advisor_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAdvisorToolResultErrorParam()
    {
        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAdvisorToolResultErrorParam(
        BetaAdvisorToolResultErrorParam betaAdvisorToolResultErrorParam
    )
        : base(betaAdvisorToolResultErrorParam) { }
#pragma warning restore CS8618

    public BetaAdvisorToolResultErrorParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("advisor_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAdvisorToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAdvisorToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static BetaAdvisorToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAdvisorToolResultErrorParam(
        ApiEnum<string, BetaAdvisorToolResultErrorParamErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaAdvisorToolResultErrorParamFromRaw : IFromRawJson<BetaAdvisorToolResultErrorParam>
{
    /// <inheritdoc/>
    public BetaAdvisorToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAdvisorToolResultErrorParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaAdvisorToolResultErrorParamErrorCodeConverter))]
public enum BetaAdvisorToolResultErrorParamErrorCode
{
    MaxUsesExceeded,
    PromptTooLong,
    TooManyRequests,
    Overloaded,
    Unavailable,
    ExecutionTimeExceeded,
}

sealed class BetaAdvisorToolResultErrorParamErrorCodeConverter
    : JsonConverter<BetaAdvisorToolResultErrorParamErrorCode>
{
    public override BetaAdvisorToolResultErrorParamErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "max_uses_exceeded" => BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded,
            "prompt_too_long" => BetaAdvisorToolResultErrorParamErrorCode.PromptTooLong,
            "too_many_requests" => BetaAdvisorToolResultErrorParamErrorCode.TooManyRequests,
            "overloaded" => BetaAdvisorToolResultErrorParamErrorCode.Overloaded,
            "unavailable" => BetaAdvisorToolResultErrorParamErrorCode.Unavailable,
            "execution_time_exceeded" =>
                BetaAdvisorToolResultErrorParamErrorCode.ExecutionTimeExceeded,
            _ => (BetaAdvisorToolResultErrorParamErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAdvisorToolResultErrorParamErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAdvisorToolResultErrorParamErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                BetaAdvisorToolResultErrorParamErrorCode.PromptTooLong => "prompt_too_long",
                BetaAdvisorToolResultErrorParamErrorCode.TooManyRequests => "too_many_requests",
                BetaAdvisorToolResultErrorParamErrorCode.Overloaded => "overloaded",
                BetaAdvisorToolResultErrorParamErrorCode.Unavailable => "unavailable",
                BetaAdvisorToolResultErrorParamErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
