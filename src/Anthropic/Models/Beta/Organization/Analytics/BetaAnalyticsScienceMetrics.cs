using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude Science activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsScienceMetrics, BetaAnalyticsScienceMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsScienceMetrics : JsonModel
{
    /// <summary>
    /// Number of delegations (handoffs to a specialized agent) in Claude Science sessions
    /// </summary>
    public required long DelegationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("delegation_count");
        }
        init { this._rawData.Set("delegation_count", value); }
    }

    /// <summary>
    /// Number of distinct Claude Science sessions. Approximate (HLL, typical error
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
    /// Number of messages sent in Claude Science sessions
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
    /// Number of remote compute jobs launched from Claude Science sessions
    /// </summary>
    public required long RemoteComputeJobCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("remote_compute_job_count");
        }
        init { this._rawData.Set("remote_compute_job_count", value); }
    }

    /// <summary>
    /// Total number of skill invocations in Claude Science sessions
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
        _ = this.DelegationCount;
        _ = this.DistinctSessionCount;
        _ = this.MessageCount;
        _ = this.RemoteComputeJobCount;
        _ = this.SkillsUsedCount;
    }

    public BetaAnalyticsScienceMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsScienceMetrics(BetaAnalyticsScienceMetrics betaAnalyticsScienceMetrics)
        : base(betaAnalyticsScienceMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsScienceMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsScienceMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsScienceMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsScienceMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsScienceMetricsFromRaw : IFromRawJson<BetaAnalyticsScienceMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsScienceMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsScienceMetrics.FromRawUnchecked(rawData);
}
