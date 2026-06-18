using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Marks the point in `content` where one model's output gives way to the next.
///
/// <para>One block appears per hop where a preceding model actually ran this turn
/// and declined. A turn where no preceding model ran and declined has no such boundary
/// and carries no block — the signal for whether a fallback model served the response
/// is the presence of a `fallback_message` entry in `usage.iterations`, not this block.</para>
///
/// <para>The block is treated like a server-tool content block for streaming: it
/// arrives via the standard `content_block_start` / `content_block_stop` pair and
/// carries no deltas.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFallbackBlock, BetaFallbackBlockFromRaw>))]
public sealed record class BetaFallbackBlock : JsonModel
{
    /// <summary>
    /// The model whose output ends at this point — the model that declined at this
    /// hop. When the declining hop is the requested model, its `model` echoes the
    /// top-level `model` string the caller sent (alias or canonical); when the declining
    /// hop is a fallback model, its `model` is that model's canonical id.
    /// </summary>
    public required BetaFallbackInfo From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFallbackInfo>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The fallback model producing the content that follows this block. Its `model`
    /// is always the canonical id.
    /// </summary>
    public required BetaFallbackInfo To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFallbackInfo>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// What caused the `from` model to hand over at this hop.
    /// </summary>
    public required BetaFallbackRefusalTrigger Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFallbackRefusalTrigger>("trigger");
        }
        init { this._rawData.Set("trigger", value); }
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
        this.From.Validate();
        this.To.Validate();
        this.Trigger.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("fallback")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFallbackBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("fallback");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackBlock(BetaFallbackBlock betaFallbackBlock)
        : base(betaFallbackBlock) { }
#pragma warning restore CS8618

    public BetaFallbackBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("fallback");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackBlockFromRaw.FromRawUnchecked"/>
    public static BetaFallbackBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFallbackBlockFromRaw : IFromRawJson<BetaFallbackBlock>
{
    /// <inheritdoc/>
    public BetaFallbackBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaFallbackBlock.FromRawUnchecked(rawData);
}
