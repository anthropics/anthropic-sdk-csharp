using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single connector on a given day within one
/// Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorOfficeProductMetrics,
        AnalyticsConnectorOfficeProductMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorOfficeProductMetrics : JsonModel
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

    public AnalyticsConnectorOfficeProductMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorOfficeProductMetrics(
        AnalyticsConnectorOfficeProductMetrics analyticsConnectorOfficeProductMetrics
    )
        : base(analyticsConnectorOfficeProductMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorOfficeProductMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorOfficeProductMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorOfficeProductMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AnalyticsConnectorOfficeProductMetrics(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class AnalyticsConnectorOfficeProductMetricsFromRaw
    : IFromRawJson<AnalyticsConnectorOfficeProductMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorOfficeProductMetrics.FromRawUnchecked(rawData);
}
