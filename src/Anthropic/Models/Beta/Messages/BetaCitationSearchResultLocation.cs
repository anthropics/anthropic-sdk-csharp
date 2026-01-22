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
        BetaCitationSearchResultLocation,
        BetaCitationSearchResultLocationFromRaw
    >)
)]
public sealed record class BetaCitationSearchResultLocation : JsonModel
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

    public required long EndBlockIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("end_block_index");
        }
        init { this._rawData.Set("end_block_index", value); }
    }

    public required long SearchResultIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("search_result_index");
        }
        init { this._rawData.Set("search_result_index", value); }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required long StartBlockIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("start_block_index");
        }
        init { this._rawData.Set("start_block_index", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.EndBlockIndex;
        _ = this.SearchResultIndex;
        _ = this.Source;
        _ = this.StartBlockIndex;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("search_result_location")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCitationSearchResultLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCitationSearchResultLocation(
        BetaCitationSearchResultLocation betaCitationSearchResultLocation
    )
        : base(betaCitationSearchResultLocation) { }
#pragma warning restore CS8618

    public BetaCitationSearchResultLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationSearchResultLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationSearchResultLocationFromRaw.FromRawUnchecked"/>
    public static BetaCitationSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationSearchResultLocationFromRaw : IFromRawJson<BetaCitationSearchResultLocation>
{
    /// <inheritdoc/>
    public BetaCitationSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationSearchResultLocation.FromRawUnchecked(rawData);
}
