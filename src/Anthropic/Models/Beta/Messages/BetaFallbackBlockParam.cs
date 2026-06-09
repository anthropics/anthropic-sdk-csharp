using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A `fallback` block echoed back from a prior response.
///
/// <para>Accepted in `messages[].content` and never rendered into the prompt, not
/// validated against the request's `fallbacks` chain or top-level `model`, and stripped
/// before the sticky-routing cache key is computed.</para>
///
/// <para>Callers should echo the assistant turn verbatim — block included. The block's
/// position is load-bearing for thinking verification: the thinking runs on either
/// side of a fallback hop carry independently-rooted verification hash chains, and
/// this block is the only record of where one chain ends and the next begins. When
/// thinking runs flank the boundary, omitting the block merges the runs into one
/// contiguous span whose hashes cannot verify (the request is rejected), and moving
/// it into the middle of a single run splits that run's chain and is likewise rejected;
/// between non-thinking blocks the block's placement has no verification effect.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaFallbackBlockParam, BetaFallbackBlockParamFromRaw>))]
public sealed record class BetaFallbackBlockParam : JsonModel
{
    /// <summary>
    /// Identifies one hop of a fallback transition.
    /// </summary>
    public required BetaFallbackInfoParam From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFallbackInfoParam>("from");
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Identifies one hop of a fallback transition.
    /// </summary>
    public required BetaFallbackInfoParam To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaFallbackInfoParam>("to");
        }
        init { this._rawData.Set("to", value); }
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("fallback")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaFallbackBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("fallback");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaFallbackBlockParam(BetaFallbackBlockParam betaFallbackBlockParam)
        : base(betaFallbackBlockParam) { }
#pragma warning restore CS8618

    public BetaFallbackBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("fallback");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaFallbackBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaFallbackBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaFallbackBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaFallbackBlockParamFromRaw : IFromRawJson<BetaFallbackBlockParam>
{
    /// <inheritdoc/>
    public BetaFallbackBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaFallbackBlockParam.FromRawUnchecked(rawData);
}
