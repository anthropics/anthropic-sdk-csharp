using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        CitationSearchResultLocationParam,
        CitationSearchResultLocationParamFromRaw
    >)
)]
public sealed record class CitationSearchResultLocationParam : JsonModel
{
    public required string CitedText
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { JsonModel.Set(this._rawData, "cited_text", value); }
    }

    public required long EndBlockIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "end_block_index"); }
        init { JsonModel.Set(this._rawData, "end_block_index", value); }
    }

    public required long SearchResultIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "search_result_index"); }
        init { JsonModel.Set(this._rawData, "search_result_index", value); }
    }

    public required string Source
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
    }

    public required long StartBlockIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "start_block_index"); }
        init { JsonModel.Set(this._rawData, "start_block_index", value); }
    }

    public required string? Title
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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
                JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationSearchResultLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

    public CitationSearchResultLocationParam(
        CitationSearchResultLocationParam citationSearchResultLocationParam
    )
        : base(citationSearchResultLocationParam) { }

    public CitationSearchResultLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationSearchResultLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationSearchResultLocationParamFromRaw.FromRawUnchecked"/>
    public static CitationSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationSearchResultLocationParamFromRaw : IFromRawJson<CitationSearchResultLocationParam>
{
    /// <inheritdoc/>
    public CitationSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationSearchResultLocationParam.FromRawUnchecked(rawData);
}
