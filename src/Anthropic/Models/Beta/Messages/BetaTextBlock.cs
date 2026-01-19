using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaTextBlock, BetaTextBlockFromRaw>))]
public sealed record class BetaTextBlock : JsonModel
{
    /// <summary>
    /// Citations supporting the text block.
    ///
    /// <para>The type of citation returned will depend on the type of document being
    /// cited. Citing a PDF results in `page_location`, plain text results in `char_location`,
    /// and content document results in `content_block_location`.</para>
    /// </summary>
    public required IReadOnlyList<BetaTextCitation>? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaTextCitation>>("citations");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTextCitation>?>(
                "citations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

    public BetaTextBlock(BetaTextBlock betaTextBlock)
        : base(betaTextBlock) { }

    public BetaTextBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextBlockFromRaw.FromRawUnchecked"/>
    public static BetaTextBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextBlockFromRaw : IFromRawJson<BetaTextBlock>
{
    /// <inheritdoc/>
    public BetaTextBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaTextBlock.FromRawUnchecked(rawData);
}
