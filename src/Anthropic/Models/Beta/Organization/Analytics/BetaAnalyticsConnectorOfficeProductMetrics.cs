using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single connector on a given day within one
/// Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorOfficeProductMetrics,
        BetaAnalyticsConnectorOfficeProductMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorOfficeProductMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Office Agent sessions in which the connector was used.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
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

    public BetaAnalyticsConnectorOfficeProductMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorOfficeProductMetrics(
        BetaAnalyticsConnectorOfficeProductMetrics betaAnalyticsConnectorOfficeProductMetrics
    )
        : base(betaAnalyticsConnectorOfficeProductMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorOfficeProductMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorOfficeProductMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorOfficeProductMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsConnectorOfficeProductMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class BetaAnalyticsConnectorOfficeProductMetricsFromRaw
    : IFromRawJson<BetaAnalyticsConnectorOfficeProductMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorOfficeProductMetrics.FromRawUnchecked(rawData);
}
