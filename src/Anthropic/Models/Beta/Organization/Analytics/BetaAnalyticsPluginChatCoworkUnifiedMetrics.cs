using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A plugin's use in Cowork sessions recorded while members had Chat and Cowork unified
/// turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsPluginChatCoworkUnifiedMetrics,
        BetaAnalyticsPluginChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsPluginChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_plugin_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Null on aggregated
    /// rows where a distinct count cannot be computed.
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

    public BetaAnalyticsPluginChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsPluginChatCoworkUnifiedMetrics(
        BetaAnalyticsPluginChatCoworkUnifiedMetrics betaAnalyticsPluginChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsPluginChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsPluginChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsPluginChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsPluginChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsPluginChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsPluginChatCoworkUnifiedMetrics(long? distinctSessionPluginUsedCount)
        : this()
    {
        this.DistinctSessionPluginUsedCount = distinctSessionPluginUsedCount;
    }
}

class BetaAnalyticsPluginChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsPluginChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsPluginChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsPluginChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
