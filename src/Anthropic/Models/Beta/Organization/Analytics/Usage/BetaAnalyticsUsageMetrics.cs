using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Organization.Analytics.Usage;

/// <summary>
/// The token usage of one row.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsUsageMetrics, BetaAnalyticsUsageMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsUsageMetrics : JsonModel
{
    /// <summary>
    /// The number of input tokens for cache creation.
    /// </summary>
    public required BetaCacheCreation CacheCreation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCacheCreation>("cache_creation");
        }
        init { this._rawData.Set("cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens generated.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// Number of API requests in this row's scope. For sandbox / code-execution
    /// events, this counts execution spans rather than HTTP requests (these rows
    /// surface with `product: null`).
    /// </summary>
    public required long? Requests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests");
        }
        init { this._rawData.Set("requests", value); }
    }

    /// <summary>
    /// Server-side tool usage metrics.
    /// </summary>
    public required BetaAnalyticsServerToolUse ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsServerToolUse>("server_tool_use");
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <summary>
    /// Total token count across all token types. This is the value the default `order_by`
    /// (`total_tokens`) sorts on.
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tokens");
        }
        init { this._rawData.Set("total_tokens", value); }
    }

    /// <summary>
    /// The number of uncached input tokens processed.
    /// </summary>
    public required long UncachedInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("uncached_input_tokens");
        }
        init { this._rawData.Set("uncached_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation.Validate();
        _ = this.CacheReadInputTokens;
        _ = this.OutputTokens;
        _ = this.Requests;
        this.ServerToolUse.Validate();
        _ = this.TotalTokens;
        _ = this.UncachedInputTokens;
    }

    public BetaAnalyticsUsageMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageMetrics(BetaAnalyticsUsageMetrics betaAnalyticsUsageMetrics)
        : base(betaAnalyticsUsageMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageMetricsFromRaw : IFromRawJson<BetaAnalyticsUsageMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageMetrics.FromRawUnchecked(rawData);
}
