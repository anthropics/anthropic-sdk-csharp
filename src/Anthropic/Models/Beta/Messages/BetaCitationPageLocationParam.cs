using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaCitationPageLocationParam, BetaCitationPageLocationParamFromRaw>)
)]
public sealed record class BetaCitationPageLocationParam : JsonModel
{
    public required string CitedText
    {
        get { return this._rawData.GetNotNullClass<string>("cited_text"); }
        init { this._rawData.Set("cited_text", value); }
    }

    public required long DocumentIndex
    {
        get { return this._rawData.GetNotNullStruct<long>("document_index"); }
        init { this._rawData.Set("document_index", value); }
    }

    public required string? DocumentTitle
    {
        get { return this._rawData.GetNullableClass<string>("document_title"); }
        init { this._rawData.Set("document_title", value); }
    }

    public required long EndPageNumber
    {
        get { return this._rawData.GetNotNullStruct<long>("end_page_number"); }
        init { this._rawData.Set("end_page_number", value); }
    }

    public required long StartPageNumber
    {
        get { return this._rawData.GetNotNullStruct<long>("start_page_number"); }
        init { this._rawData.Set("start_page_number", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
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

    public BetaCitationPageLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

    public BetaCitationPageLocationParam(
        BetaCitationPageLocationParam betaCitationPageLocationParam
    )
        : base(betaCitationPageLocationParam) { }

    public BetaCitationPageLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationPageLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationPageLocationParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationPageLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationPageLocationParamFromRaw : IFromRawJson<BetaCitationPageLocationParam>
{
    /// <inheritdoc/>
    public BetaCitationPageLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationPageLocationParam.FromRawUnchecked(rawData);
}
