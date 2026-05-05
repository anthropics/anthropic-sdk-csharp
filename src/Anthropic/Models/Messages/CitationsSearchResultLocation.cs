using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CitationsSearchResultLocation, CitationsSearchResultLocationFromRaw>)
)]
public sealed record class CitationsSearchResultLocation : JsonModel
{
    /// <summary>
    /// The full text of the cited block range, concatenated.
    ///
    /// <para>Always equals the contents of `content[start_block_index:end_block_index]`
    /// joined together. The text block is the minimal citable unit; this field is
    /// never a substring of a single block. Not counted toward output tokens, and
    /// not counted toward input tokens when sent back in subsequent turns.</para>
    /// </summary>
    public required string CitedText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cited_text");
        }
        init { this._rawData.Set("cited_text", value); }
    }

    /// <summary>
    /// Exclusive 0-based end index of the cited block range in the source's `content` array.
    ///
    /// <para>Always greater than `start_block_index`; a single-block citation has
    /// `end_block_index = start_block_index + 1`.</para>
    /// </summary>
    public required long EndBlockIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("end_block_index");
        }
        init { this._rawData.Set("end_block_index", value); }
    }

    /// <summary>
    /// 0-based index of the cited search result among all `search_result` content
    /// blocks in the request, in the order they appear across messages and tool results.
    ///
    /// <para>Counted separately from `document_index`; server-side web search results
    /// are not included in this count.</para>
    /// </summary>
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

    /// <summary>
    /// 0-based index of the first cited block in the source's `content` array.
    /// </summary>
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

    public CitationsSearchResultLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CitationsSearchResultLocation(
        CitationsSearchResultLocation citationsSearchResultLocation
    )
        : base(citationsSearchResultLocation) { }
#pragma warning restore CS8618

    public CitationsSearchResultLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("search_result_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsSearchResultLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsSearchResultLocationFromRaw.FromRawUnchecked"/>
    public static CitationsSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationsSearchResultLocationFromRaw : IFromRawJson<CitationsSearchResultLocation>
{
    /// <inheritdoc/>
    public CitationsSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationsSearchResultLocation.FromRawUnchecked(rawData);
}
