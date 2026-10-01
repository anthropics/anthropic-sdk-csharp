using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Cowork activity metrics for a single plugin on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsPluginCoworkMetrics,
        BetaAnalyticsPluginCoworkMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsPluginCoworkMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Cowork sessions in which the plugin was invoked. Null
    /// on aggregated rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSessionPluginUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_plugin_used_count");
        }
        init { this._rawData.Set("distinct_session_plugin_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctSessionPluginUsedCount;
    }

    public BetaAnalyticsPluginCoworkMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsPluginCoworkMetrics(
        BetaAnalyticsPluginCoworkMetrics betaAnalyticsPluginCoworkMetrics
    )
        : base(betaAnalyticsPluginCoworkMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsPluginCoworkMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsPluginCoworkMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsPluginCoworkMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsPluginCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsPluginCoworkMetrics(long? distinctSessionPluginUsedCount)
        : this()
    {
        this.DistinctSessionPluginUsedCount = distinctSessionPluginUsedCount;
    }
}

class BetaAnalyticsPluginCoworkMetricsFromRaw : IFromRawJson<BetaAnalyticsPluginCoworkMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsPluginCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsPluginCoworkMetrics.FromRawUnchecked(rawData);
}
