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
        BetaCitationsWebSearchResultLocation,
        BetaCitationsWebSearchResultLocationFromRaw
    >)
)]
public sealed record class BetaCitationsWebSearchResultLocation : JsonModel
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

    public BetaCitationsWebSearchResultLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_result_location");
    }

    public BetaCitationsWebSearchResultLocation(
        BetaCitationsWebSearchResultLocation betaCitationsWebSearchResultLocation
    )
        : base(betaCitationsWebSearchResultLocation) { }

    public BetaCitationsWebSearchResultLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsWebSearchResultLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationsWebSearchResultLocationFromRaw.FromRawUnchecked"/>
    public static BetaCitationsWebSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationsWebSearchResultLocationFromRaw
    : IFromRawJson<BetaCitationsWebSearchResultLocation>
{
    /// <inheritdoc/>
    public BetaCitationsWebSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationsWebSearchResultLocation.FromRawUnchecked(rawData);
}
