using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Design activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsDesignMetrics, BetaAnalyticsDesignMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsDesignMetrics : JsonModel
{
    /// <summary>
    /// Number of distinct Claude Design projects created. Exact in date-range mode:
    /// a creation belongs to exactly one day, so the per-day counts never overlap
    /// and their sum over the window is the exact count of distinct creations in it.
    /// </summary>
    public required long DistinctProjectsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("distinct_projects_created_count");
        }
        init { this._rawData.Set("distinct_projects_created_count", value); }
    }

    /// <summary>
    /// Number of distinct Claude Design projects the user worked in. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctProjectsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_projects_used_count");
        }
        init { this._rawData.Set("distinct_projects_used_count", value); }
    }

    /// <summary>
    /// Number of distinct Claude Design sessions. Approximate (HLL, typical error
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
    /// Number of messages sent in Claude Design sessions
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctProjectsCreatedCount;
        _ = this.DistinctProjectsUsedCount;
        _ = this.DistinctSessionCount;
        _ = this.MessageCount;
    }

    public BetaAnalyticsDesignMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsDesignMetrics(BetaAnalyticsDesignMetrics betaAnalyticsDesignMetrics)
        : base(betaAnalyticsDesignMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsDesignMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsDesignMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsDesignMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsDesignMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsDesignMetricsFromRaw : IFromRawJson<BetaAnalyticsDesignMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsDesignMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsDesignMetrics.FromRawUnchecked(rawData);
}
