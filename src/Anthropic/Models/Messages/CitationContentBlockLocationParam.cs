using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(ModelConverter<
        CitationContentBlockLocationParam,
        CitationContentBlockLocationParamFromRaw
    >)
)]
public sealed record class CitationContentBlockLocationParam : ModelBase
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

    public required long EndBlockIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "end_block_index"); }
        init { ModelBase.Set(this._rawData, "end_block_index", value); }
    }

    public required long StartBlockIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "start_block_index"); }
        init { ModelBase.Set(this._rawData, "start_block_index", value); }
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
        _ = this.EndBlockIndex;
        _ = this.StartBlockIndex;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationContentBlockLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"");
    }

    public CitationContentBlockLocationParam(
        CitationContentBlockLocationParam citationContentBlockLocationParam
    )
        : base(citationContentBlockLocationParam) { }

    public CitationContentBlockLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationContentBlockLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationContentBlockLocationParamFromRaw.FromRawUnchecked"/>
    public static CitationContentBlockLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CitationContentBlockLocationParamFromRaw : IFromRaw<CitationContentBlockLocationParam>
{
    /// <inheritdoc/>
    public CitationContentBlockLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CitationContentBlockLocationParam.FromRawUnchecked(rawData);
}
