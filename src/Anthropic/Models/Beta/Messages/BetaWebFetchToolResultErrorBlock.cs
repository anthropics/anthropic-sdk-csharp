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
        BetaWebFetchToolResultErrorBlock,
        BetaWebFetchToolResultErrorBlockFromRaw
    >)
)]
public sealed record class BetaWebFetchToolResultErrorBlock : JsonModel
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

    public BetaWebFetchToolResultErrorBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

    public BetaWebFetchToolResultErrorBlock(
        BetaWebFetchToolResultErrorBlock betaWebFetchToolResultErrorBlock
    )
        : base(betaWebFetchToolResultErrorBlock) { }

    public BetaWebFetchToolResultErrorBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultErrorBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchToolResultErrorBlockFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaWebFetchToolResultErrorBlock(
        ApiEnum<string, BetaWebFetchToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaWebFetchToolResultErrorBlockFromRaw : IFromRawJson<BetaWebFetchToolResultErrorBlock>
{
    /// <inheritdoc/>
    public BetaWebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultErrorBlock.FromRawUnchecked(rawData);
}
