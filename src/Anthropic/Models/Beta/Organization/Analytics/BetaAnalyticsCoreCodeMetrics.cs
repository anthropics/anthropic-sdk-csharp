using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Core Claude Code activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsCoreCodeMetrics, BetaAnalyticsCoreCodeMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsCoreCodeMetrics : JsonModel
{
    /// <summary>
    /// Number of artifacts created in Claude Code sessions: an artifact counts once,
    /// on the day a session first saves it. Counted from 2026-08-17; 0 on earlier
    /// days. Exact in date-range mode: a creation belongs to exactly one day, so
    /// the per-day counts never overlap and their sum over the window is the exact
    /// count of distinct creations in it.
    /// </summary>
    public required long ArtifactsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("artifacts_created_count");
        }
        init { this._rawData.Set("artifacts_created_count", value); }
    }

    /// <summary>
    /// Number of commits made via Claude Code
    /// </summary>
    public required long CommitCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("commit_count");
        }
        init { this._rawData.Set("commit_count", value); }
    }

    /// <summary>
    /// Number of distinct Claude Code sessions. On aggregated rows and in date-range
    /// mode: summed per-day distinct counts. A session essentially never spans a
    /// UTC day, so the sum is in practice the true distinct count.
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
    /// Lines of code added and removed via Claude Code.
    /// </summary>
    public required BetaAnalyticsLinesOfCode LinesOfCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsLinesOfCode>("lines_of_code");
        }
        init { this._rawData.Set("lines_of_code", value); }
    }

    /// <summary>
    /// Number of pull requests created via Claude Code
    /// </summary>
    public required long PullRequestCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pull_request_count");
        }
        init { this._rawData.Set("pull_request_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArtifactsCreatedCount;
        _ = this.CommitCount;
        _ = this.DistinctSessionCount;
        this.LinesOfCode.Validate();
        _ = this.PullRequestCount;
    }

    public BetaAnalyticsCoreCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCoreCodeMetrics(BetaAnalyticsCoreCodeMetrics betaAnalyticsCoreCodeMetrics)
        : base(betaAnalyticsCoreCodeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsCoreCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCoreCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCoreCodeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCoreCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCoreCodeMetricsFromRaw : IFromRawJson<BetaAnalyticsCoreCodeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsCoreCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCoreCodeMetrics.FromRawUnchecked(rawData);
}
