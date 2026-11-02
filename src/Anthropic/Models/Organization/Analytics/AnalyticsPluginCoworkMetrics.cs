using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Cowork activity metrics for a single plugin on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsPluginCoworkMetrics, AnalyticsPluginCoworkMetricsFromRaw>)
)]
public sealed record class AnalyticsPluginCoworkMetrics : JsonModel
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

    public AnalyticsPluginCoworkMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsPluginCoworkMetrics(AnalyticsPluginCoworkMetrics analyticsPluginCoworkMetrics)
        : base(analyticsPluginCoworkMetrics) { }
#pragma warning restore CS8618

    public AnalyticsPluginCoworkMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsPluginCoworkMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsPluginCoworkMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsPluginCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsPluginCoworkMetrics(long? distinctSessionPluginUsedCount)
        : this()
    {
        this.DistinctSessionPluginUsedCount = distinctSessionPluginUsedCount;
    }
}

class AnalyticsPluginCoworkMetricsFromRaw : IFromRawJson<AnalyticsPluginCoworkMetrics>
{
    /// <inheritdoc/>
    public AnalyticsPluginCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsPluginCoworkMetrics.FromRawUnchecked(rawData);
}
