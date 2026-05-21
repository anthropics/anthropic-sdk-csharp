using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaThinkingDelta, BetaThinkingDeltaFromRaw>))]
public sealed record class BetaThinkingDelta : JsonModel
{
    /// <summary>
    /// Per-frame increment of a coarse, running estimate of the tokens this thinking
    /// block has produced so far. Present whenever the `thinking-token-count-2026-05-13`
    /// beta is set; `null` unless `thinking.display` resolves to `"omitted"` and
    /// a count is due this frame. Sum the increments across `thinking_delta` frames
    /// on this block for a progress indicator. Each increment is a non-negative multiple
    /// of a fixed quantum and the cadence is rate-limited, so this is a deliberately
    /// lossy display hint, not a billable count; `usage.output_tokens` remains authoritative.
    /// </summary>
    public required long? EstimatedTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("estimated_tokens");
        }
        init { this._rawData.Set("estimated_tokens", value); }
    }

    public required string Thinking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("thinking");
        }
        init { this._rawData.Set("thinking", value); }
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
        _ = this.EstimatedTokens;
        _ = this.Thinking;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thinking_delta")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("thinking_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaThinkingDelta(BetaThinkingDelta betaThinkingDelta)
        : base(betaThinkingDelta) { }
#pragma warning restore CS8618

    public BetaThinkingDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thinking_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaThinkingDeltaFromRaw.FromRawUnchecked"/>
    public static BetaThinkingDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaThinkingDeltaFromRaw : IFromRawJson<BetaThinkingDelta>
{
    /// <inheritdoc/>
    public BetaThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaThinkingDelta.FromRawUnchecked(rawData);
}
