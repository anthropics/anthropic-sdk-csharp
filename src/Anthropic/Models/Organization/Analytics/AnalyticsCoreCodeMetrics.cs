using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Core Claude Code activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsCoreCodeMetrics, AnalyticsCoreCodeMetricsFromRaw>)
)]
public sealed record class AnalyticsCoreCodeMetrics : JsonModel
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
    public required AnalyticsLinesOfCode LinesOfCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsLinesOfCode>("lines_of_code");
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

    public AnalyticsCoreCodeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsCoreCodeMetrics(AnalyticsCoreCodeMetrics analyticsCoreCodeMetrics)
        : base(analyticsCoreCodeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsCoreCodeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsCoreCodeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsCoreCodeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsCoreCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsCoreCodeMetricsFromRaw : IFromRawJson<AnalyticsCoreCodeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsCoreCodeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsCoreCodeMetrics.FromRawUnchecked(rawData);
}
