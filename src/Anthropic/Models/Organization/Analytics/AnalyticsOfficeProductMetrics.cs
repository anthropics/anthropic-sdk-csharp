using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single user on a given day within one Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsOfficeProductMetrics, AnalyticsOfficeProductMetricsFromRaw>)
)]
public sealed record class AnalyticsOfficeProductMetrics : JsonModel
{
    /// <summary>
    /// Number of MCP connector invocations
    /// </summary>
    public required long ConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("connectors_used_count");
        }
        init { this._rawData.Set("connectors_used_count", value); }
    }

    /// <summary>
    /// Number of distinct MCP connectors used. Approximate (HLL, typical error &lt;2%)
    /// in date-range mode. Null on aggregated rows where a distinct count cannot
    /// be computed.
    /// </summary>
    public required long? DistinctConnectorsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_connectors_used_count");
        }
        init { this._rawData.Set("distinct_connectors_used_count", value); }
    }

    /// <summary>
    /// Number of distinct Office Agent sessions. Approximate (HLL, typical error
    /// &lt;2%) in date-range mode. Null on aggregated rows where a distinct count
    /// cannot be computed.
    /// </summary>
    public required long? DistinctSessionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_session_count");
        }
        init { this._rawData.Set("distinct_session_count", value); }
    }

    /// <summary>
    /// Number of distinct skills used. Approximate (HLL, typical error &lt;2%) in
    /// date-range mode. Null on aggregated rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctSkillsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_skills_used_count");
        }
        init { this._rawData.Set("distinct_skills_used_count", value); }
    }

    /// <summary>
    /// Number of messages sent
    /// </summary>
    public required long MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("message_count");
        }
        init { this._rawData.Set("message_count", value); }
    }

    /// <summary>
    /// Number of skill invocations
    /// </summary>
    public required long SkillsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skills_used_count");
        }
        init { this._rawData.Set("skills_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectorsUsedCount;
        _ = this.DistinctConnectorsUsedCount;
        _ = this.DistinctSessionCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.MessageCount;
        _ = this.SkillsUsedCount;
    }

    public AnalyticsOfficeProductMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsOfficeProductMetrics(
        AnalyticsOfficeProductMetrics analyticsOfficeProductMetrics
    )
        : base(analyticsOfficeProductMetrics) { }
#pragma warning restore CS8618

    public AnalyticsOfficeProductMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsOfficeProductMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsOfficeProductMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsOfficeProductMetricsFromRaw : IFromRawJson<AnalyticsOfficeProductMetrics>
{
    /// <inheritdoc/>
    public AnalyticsOfficeProductMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsOfficeProductMetrics.FromRawUnchecked(rawData);
}
