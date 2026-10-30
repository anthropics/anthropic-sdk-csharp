using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Cowork activity metrics for a single connector on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorCoworkMetrics,
        AnalyticsConnectorCoworkMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorCoworkMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Cowork sessions in which the connector was used. Approximate
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

    public AnalyticsConnectorCoworkMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorCoworkMetrics(
        AnalyticsConnectorCoworkMetrics analyticsConnectorCoworkMetrics
    )
        : base(analyticsConnectorCoworkMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorCoworkMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorCoworkMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorCoworkMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorCoworkMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class AnalyticsConnectorCoworkMetricsFromRaw : IFromRawJson<AnalyticsConnectorCoworkMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorCoworkMetrics.FromRawUnchecked(rawData);
}
