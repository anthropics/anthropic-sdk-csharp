using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A plugin's use in Cowork sessions recorded while members had Chat and Cowork unified
/// turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsPluginChatCoworkUnifiedMetrics,
        AnalyticsPluginChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class AnalyticsPluginChatCoworkUnifiedMetrics : JsonModel
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

    public AnalyticsPluginChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsPluginChatCoworkUnifiedMetrics(
        AnalyticsPluginChatCoworkUnifiedMetrics analyticsPluginChatCoworkUnifiedMetrics
    )
        : base(analyticsPluginChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public AnalyticsPluginChatCoworkUnifiedMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsPluginChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsPluginChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsPluginChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsPluginChatCoworkUnifiedMetrics(long? distinctSessionPluginUsedCount)
        : this()
    {
        this.DistinctSessionPluginUsedCount = distinctSessionPluginUsedCount;
    }
}

class AnalyticsPluginChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<AnalyticsPluginChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public AnalyticsPluginChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsPluginChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}
