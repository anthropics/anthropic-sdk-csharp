using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CitationCharLocationParam, CitationCharLocationParamFromRaw>)
)]
public sealed record class CitationCharLocationParam : JsonModel
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

    public required long EndCharIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "end_char_index"); }
        init { JsonModel.Set(this._rawData, "end_char_index", value); }
    }

    public required long StartCharIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "start_char_index"); }
        init { JsonModel.Set(this._rawData, "start_char_index", value); }
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
        _ = this.EndCharIndex;
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

    public CitationCharLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

    public CitationCharLocationParam(CitationCharLocationParam citationCharLocationParam)
        : base(citationCharLocationParam) { }

    public CitationCharLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"char_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationCharLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationCharLocationParamFromRaw.FromRawUnchecked"/>
    public static CitationCharLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationCharLocationParamFromRaw : IFromRawJson<CitationCharLocationParam>
{
    /// <inheritdoc/>
    public CitationCharLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationCharLocationParam.FromRawUnchecked(rawData);
}
