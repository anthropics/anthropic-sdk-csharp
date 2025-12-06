using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationCharLocation, CitationCharLocationFromRaw>))]
public sealed record class CitationCharLocation : ModelBase
{
    public required string CitedText
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { ModelBase.Set(this._rawData, "cited_text", value); }
    }

    public required long DocumentIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "document_index"); }
        init { ModelBase.Set(this._rawData, "document_index", value); }
    }

    public required string? DocumentTitle
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "document_title"); }
        init { ModelBase.Set(this._rawData, "document_title", value); }
    }

    public required long EndCharIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "end_char_index"); }
        init { ModelBase.Set(this._rawData, "end_char_index", value); }
    }

    public required string? FileID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
    }

    public required long StartCharIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "start_char_index"); }
        init { ModelBase.Set(this._rawData, "start_char_index", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CitedText;
        _ = this.DocumentIndex;
        _ = this.DocumentTitle;
        _ = this.EndCharIndex;
        _ = this.FileID;
        _ = this.StartCharIndex;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"char_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationCharLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

    public CitationCharLocation(CitationCharLocation citationCharLocation)
        : base(citationCharLocation) { }

    public CitationCharLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationCharLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationCharLocationFromRaw.FromRawUnchecked"/>
    public static CitationCharLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationCharLocationFromRaw : IFromRaw<CitationCharLocation>
{
    /// <inheritdoc/>
    public CitationCharLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationCharLocation.FromRawUnchecked(rawData);
}
