using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaWebFetchToolResultErrorBlockParam,
        BetaWebFetchToolResultErrorBlockParamFromRaw
    >)
)]
public sealed record class BetaWebFetchToolResultErrorBlockParam : JsonModel
{
    public required ApiEnum<string, BetaWebFetchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWebFetchToolResultErrorCode>>(
                "error_code"
            );
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
                JsonSerializer.SerializeToElement("web_fetch_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchToolResultErrorBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchToolResultErrorBlockParam(
        BetaWebFetchToolResultErrorBlockParam betaWebFetchToolResultErrorBlockParam
    )
        : base(betaWebFetchToolResultErrorBlockParam) { }
#pragma warning restore CS8618

    public BetaWebFetchToolResultErrorBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultErrorBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchToolResultErrorBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchToolResultErrorBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchToolResultErrorBlockParam(
        ApiEnum<string, BetaWebFetchToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaWebFetchToolResultErrorBlockParamFromRaw
    : IFromRawJson<BetaWebFetchToolResultErrorBlockParam>
{
    /// <inheritdoc/>
    public BetaWebFetchToolResultErrorBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultErrorBlockParam.FromRawUnchecked(rawData);
}
