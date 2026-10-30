using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A connector's use in Cowork sessions recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorChatCoworkUnifiedSessionsMetrics,
        AnalyticsConnectorChatCoworkUnifiedSessionsMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorChatCoworkUnifiedSessionsMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_connector_used_count`, for
    /// activity recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSessionConnectorUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_connector_used_count");
        }
        init { this._rawData.Set("distinct_session_connector_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctSessionConnectorUsedCount;
    }

    public AnalyticsConnectorChatCoworkUnifiedSessionsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorChatCoworkUnifiedSessionsMetrics(
        AnalyticsConnectorChatCoworkUnifiedSessionsMetrics analyticsConnectorChatCoworkUnifiedSessionsMetrics
    )
        : base(analyticsConnectorChatCoworkUnifiedSessionsMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorChatCoworkUnifiedSessionsMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorChatCoworkUnifiedSessionsMetrics(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorChatCoworkUnifiedSessionsMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorChatCoworkUnifiedSessionsMetrics(
        long? distinctSessionConnectorUsedCount
    )
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class AnalyticsConnectorChatCoworkUnifiedSessionsMetricsFromRaw
    : IFromRawJson<AnalyticsConnectorChatCoworkUnifiedSessionsMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorChatCoworkUnifiedSessionsMetrics.FromRawUnchecked(rawData);
}
