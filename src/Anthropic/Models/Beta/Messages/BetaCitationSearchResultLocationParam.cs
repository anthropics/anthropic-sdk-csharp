using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaCitationSearchResultLocationParam,
        BetaCitationSearchResultLocationParamFromRaw
    >)
)]
public sealed record class BetaCitationSearchResultLocationParam : ModelBase
{
    public required string CitedText
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "cited_text"); }
        init { ModelBase.Set(this._rawData, "cited_text", value); }
    }

    public required long EndBlockIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "end_block_index"); }
        init { ModelBase.Set(this._rawData, "end_block_index", value); }
    }

    public required long SearchResultIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "search_result_index"); }
        init { ModelBase.Set(this._rawData, "search_result_index", value); }
    }

    public required string Source
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    public required long StartBlockIndex
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "start_block_index"); }
        init { ModelBase.Set(this._rawData, "start_block_index", value); }
    }

    public required string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
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

    public BetaCitationSearchResultLocationParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

    public BetaCitationSearchResultLocationParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationSearchResultLocationParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationSearchResultLocationParamFromRaw.FromRawUnchecked"/>
    public static BetaCitationSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationSearchResultLocationParamFromRaw : IFromRaw<BetaCitationSearchResultLocationParam>
{
    /// <inheritdoc/>
    public BetaCitationSearchResultLocationParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationSearchResultLocationParam.FromRawUnchecked(rawData);
}
