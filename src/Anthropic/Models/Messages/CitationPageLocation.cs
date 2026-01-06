using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CitationPageLocation, CitationPageLocationFromRaw>))]
public sealed record class CitationPageLocation : JsonModel
{
    public required string CitedText
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { JsonModel.Set(this._rawData, "cited_text", value); }
    }

    public required long DocumentIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "document_index"); }
        init { JsonModel.Set(this._rawData, "document_index", value); }
    }

    public required string? DocumentTitle
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "document_title"); }
        init { JsonModel.Set(this._rawData, "document_title", value); }
    }

    public required long EndPageNumber
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "end_page_number"); }
        init { JsonModel.Set(this._rawData, "end_page_number", value); }
    }

    public required string? FileID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "file_id"); }
        init { JsonModel.Set(this._rawData, "file_id", value); }
    }

    public required long StartPageNumber
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "start_page_number"); }
        init { JsonModel.Set(this._rawData, "start_page_number", value); }
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
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndPageNumber;
        _ = this.FileID;
        _ = this.StartPageNumber;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"page_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationPageLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

    public CitationPageLocation(CitationPageLocation citationPageLocation)
        : base(citationPageLocation) { }

    public CitationPageLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationPageLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationPageLocationFromRaw.FromRawUnchecked"/>
    public static CitationPageLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationPageLocationFromRaw : IFromRawJson<CitationPageLocation>
{
    /// <inheritdoc/>
    public CitationPageLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationPageLocation.FromRawUnchecked(rawData);
}
