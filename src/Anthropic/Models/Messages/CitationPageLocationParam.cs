using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CitationPageLocationParam, CitationPageLocationParamFromRaw>))]
public sealed record class CitationPageLocationParam : ModelBase
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

    public required long EndPageNumber
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "end_page_number"); }
        init { ModelBase.Set(this._rawData, "end_page_number", value); }
    }

    public required long StartPageNumber
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "start_page_number"); }
        init { ModelBase.Set(this._rawData, "start_page_number", value); }
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
        _ = this.EndPageNumber;
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

    public CitationPageLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

    public CitationPageLocationParam(CitationPageLocationParam citationPageLocationParam)
        : base(citationPageLocationParam) { }

    public CitationPageLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationPageLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationPageLocationParamFromRaw.FromRawUnchecked"/>
    public static CitationPageLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationPageLocationParamFromRaw : IFromRaw<CitationPageLocationParam>
{
    /// <inheritdoc/>
    public CitationPageLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationPageLocationParam.FromRawUnchecked(rawData);
}
