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
        BetaCitationWebSearchResultLocationParam,
        BetaCitationWebSearchResultLocationParamFromRaw
    >)
)]
public sealed record class BetaCitationWebSearchResultLocationParam : JsonModel
{
    public required string CitedText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cited_text");
        }
        init { this._rawData.Set("cited_text", value); }
    }

    public required string EncryptedIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("encrypted_index");
        }
        init { this._rawData.Set("encrypted_index", value); }
    }

    public required string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
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

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EncryptedIndex;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_search_result_location")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BetaCitationWebSearchResultLocationParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_result_location");
    }

    public BetaCitationWebSearchResultLocationParam(
        BetaCitationWebSearchResultLocationParam betaCitationWebSearchResultLocationParam
    )
        : base(betaCitationWebSearchResultLocationParam) { }

    public BetaCitationWebSearchResultLocationParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationWebSearchResultLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationWebSearchResultLocationParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationWebSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationWebSearchResultLocationParamFromRaw
    : IFromRawJson<BetaCitationWebSearchResultLocationParam>
{
    /// <inheritdoc/>
    public BetaCitationWebSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationWebSearchResultLocationParam.FromRawUnchecked(rawData);
}
