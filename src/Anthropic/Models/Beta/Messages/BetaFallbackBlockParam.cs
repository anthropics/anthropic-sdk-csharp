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
/// <para>Accepted in `messages[].content` and not rendered into the prompt; not
/// validated against the request's `fallbacks` chain or top-level `model`.</para>
///
/// <para>Echo the assistant turn back verbatim, including this block in its original
/// position. The block marks the boundary between content produced before and after
/// a fallback hop, and the server relies on that boundary to validate the turn:
/// when thinking runs flank the boundary, omitting the block merges them into one
/// span the server cannot validate (the request is rejected), and moving it into
/// the middle of a single run is likewise rejected; between non-thinking blocks
/// the block's placement has no validation effect.</para>
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

    /// <summary>
    /// The response block's `trigger`, echoed verbatim. Accepted and ignored by
    /// the server; any object or `null` is allowed.
    /// </summary>
    public JsonElement? Trigger
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("trigger");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trigger", value);
        }
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
        _ = this.Trigger;
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
