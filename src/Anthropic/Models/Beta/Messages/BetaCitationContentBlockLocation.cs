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
    /// <summary>
    /// The full text of the cited block range, concatenated.
    ///
    /// <para>Always equals the contents of `content[start_block_index:end_block_index]`
    /// joined together. The text block is the minimal citable unit; this field is
    /// never a substring of a single block. Not counted toward output tokens, and
    /// not counted toward input tokens when sent back in subsequent turns.</para>
    /// </summary>
    public required string CitedText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cited_text");
        }
        init { this._rawData.Set("cited_text", value); }
    }

    public required long DocumentIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("document_index");
        }
        init { this._rawData.Set("document_index", value); }
    }

    public required string? DocumentTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("document_title");
        }
        init { this._rawData.Set("document_title", value); }
    }

    /// <summary>
    /// Exclusive 0-based end index of the cited block range in the source's `content` array.
    ///
    /// <para>Always greater than `start_block_index`; a single-block citation has
    /// `end_block_index = start_block_index + 1`.</para>
    /// </summary>
    public required long EndBlockIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("end_block_index");
        }
        init { this._rawData.Set("end_block_index", value); }
    }

    public required string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// 0-based index of the first cited block in the source's `content` array.
    /// </summary>
    public required long StartBlockIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("start_block_index");
        }
        init { this._rawData.Set("start_block_index", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
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
                JsonSerializer.SerializeToElement("content_block_location")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCitationContentBlockLocation()
    {
        this.Type = JsonSerializer.SerializeToElement("content_block_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCitationContentBlockLocation(
        BetaCitationContentBlockLocation betaCitationContentBlockLocation
    )
        : base(betaCitationContentBlockLocation) { }
#pragma warning restore CS8618

    public BetaCitationContentBlockLocation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content_block_location");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationContentBlockLocation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
