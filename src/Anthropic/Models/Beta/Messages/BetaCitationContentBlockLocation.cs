using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaCitationContentBlockLocation,
        BetaCitationContentBlockLocationFromRaw
    >)
)]
public sealed record class BetaCitationContentBlockLocation : JsonModel
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

    public required long EndBlockIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "end_block_index"); }
        init { JsonModel.Set(this._rawData, "end_block_index", value); }
    }

    public required string? FileID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "file_id"); }
        init { JsonModel.Set(this._rawData, "file_id", value); }
    }

    public required long StartBlockIndex
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "start_block_index"); }
        init { JsonModel.Set(this._rawData, "start_block_index", value); }
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
        _ = this.EndBlockIndex;
        _ = this.FileID;
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

    public BetaCitationContentBlockLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"");
    }

    public BetaCitationContentBlockLocation(
        BetaCitationContentBlockLocation betaCitationContentBlockLocation
    )
        : base(betaCitationContentBlockLocation) { }

    public BetaCitationContentBlockLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationContentBlockLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationContentBlockLocationFromRaw.FromRawUnchecked"/>
    public static BetaCitationContentBlockLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCitationContentBlockLocationFromRaw : IFromRawJson<BetaCitationContentBlockLocation>
{
    /// <inheritdoc/>
    public BetaCitationContentBlockLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCitationContentBlockLocation.FromRawUnchecked(rawData);
}
