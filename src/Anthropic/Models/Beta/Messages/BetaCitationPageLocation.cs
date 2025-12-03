using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationPageLocation, BetaCitationPageLocationFromRaw>))]
public sealed record class BetaCitationPageLocation : ModelBase
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

    public required string? FileID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "file_id"); }
        init { ModelBase.Set(this._rawData, "file_id", value); }
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

    public BetaCitationPageLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

    public BetaCitationPageLocation(BetaCitationPageLocation betaCitationPageLocation)
        : base(betaCitationPageLocation) { }

    public BetaCitationPageLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"page_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationPageLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationPageLocationFromRaw.FromRawUnchecked"/>
    public static BetaCitationPageLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationPageLocationFromRaw : IFromRaw<BetaCitationPageLocation>
{
    /// <inheritdoc/>
    public BetaCitationPageLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationPageLocation.FromRawUnchecked(rawData);
}
