using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Cowork activity metrics for a single connector on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorCoworkMetrics,
        BetaAnalyticsConnectorCoworkMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorCoworkMetrics : JsonModel
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

    public BetaAnalyticsConnectorCoworkMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorCoworkMetrics(
        BetaAnalyticsConnectorCoworkMetrics betaAnalyticsConnectorCoworkMetrics
    )
        : base(betaAnalyticsConnectorCoworkMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorCoworkMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorCoworkMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorCoworkMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsConnectorCoworkMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class BetaAnalyticsConnectorCoworkMetricsFromRaw : IFromRawJson<BetaAnalyticsConnectorCoworkMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorCoworkMetrics.FromRawUnchecked(rawData);
}
