using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Cumulative token usage for the dream across every pipeline stage.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamUsage, BetaDreamUsageFromRaw>))]
public sealed record class BetaDreamUsage : JsonModel
{
    /// <summary>
    /// Total tokens used to create prompt-cache entries (sum of all TTL tiers).
    /// </summary>
    public required int CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// Total tokens read from prompt cache.
    /// </summary>
    public required int CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// Total uncached input tokens consumed across every pipeline stage.
    /// </summary>
    public required int InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Total output tokens generated across every pipeline stage.
    /// </summary>
    public required int OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
    }

    public BetaDreamUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamUsage(BetaDreamUsage betaDreamUsage)
        : base(betaDreamUsage) { }
#pragma warning restore CS8618

    public BetaDreamUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamUsageFromRaw.FromRawUnchecked"/>
    public static BetaDreamUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDreamUsageFromRaw : IFromRawJson<BetaDreamUsage>
{
    /// <inheritdoc/>
    public BetaDreamUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDreamUsage.FromRawUnchecked(rawData);
}
