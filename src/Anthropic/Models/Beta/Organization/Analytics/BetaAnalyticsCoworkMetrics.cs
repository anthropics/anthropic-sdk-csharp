using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Cowork activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsCoworkMetrics, BetaAnalyticsCoworkMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsCoworkMetrics : JsonModel
{
    /// <summary>
    /// Number of tool actions completed in Cowork sessions
    /// </summary>
    public required long ActionCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("action_count");
        }
        init { this._rawData.Set("action_count", value); }
    }

    /// <summary>
    /// Number of artifacts created in Cowork sessions: an artifact counts once, on
    /// the day a session first saves it. Counted from 2026-08-17; 0 on earlier days.
    /// Exact in date-range mode: a creation belongs to exactly one day, so the per-day
    /// counts never overlap and their sum over the window is the exact count of
    /// distinct creations in it.
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
    /// Total number of connector invocations in Cowork sessions
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
    /// Number of Dispatch (background agent) turns completed
    /// </summary>
    public required long DispatchTurnCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("dispatch_turn_count");
        }
        init { this._rawData.Set("dispatch_turn_count", value); }
    }

    /// <summary>
    /// Number of distinct connectors used in Cowork sessions. Approximate (HLL,
    /// typical error &lt;2%) in date-range mode. Null on aggregated rows where a
    /// distinct count cannot be computed.
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
    /// Number of distinct Cowork sessions. Approximate (HLL, typical error &lt;2%)
    /// in date-range mode. Null on aggregated rows where a distinct count cannot
    /// be computed.
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
    /// Number of distinct skills used in Cowork sessions. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
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
    /// Number of messages sent in Cowork sessions
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
    /// Total number of skill invocations in Cowork sessions
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

    /// <summary>
    /// Number of distinct plugins used in Cowork sessions. Null while Cowork plugin-use
    /// metrics are not enabled for this organization. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
    /// </summary>
    public long? DistinctPluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_plugins_used_count");
        }
        init { this._rawData.Set("distinct_plugins_used_count", value); }
    }

    /// <summary>
    /// Number of successful Edit tool calls in Cowork sessions. Null while the file-edit
    /// metrics are not enabled for this organization.
    /// </summary>
    public long? EditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("edit_tool_count");
        }
        init { this._rawData.Set("edit_tool_count", value); }
    }

    /// <summary>
    /// Number of successful file-edit tool calls (Edit, MultiEdit, Write, NotebookEdit)
    /// in Cowork sessions. Null, never 0, while the file-edit metrics are not enabled
    /// for this organization.
    /// </summary>
    public long? FileEditCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_edit_count");
        }
        init { this._rawData.Set("file_edit_count", value); }
    }

    /// <summary>
    /// Number of successful MultiEdit tool calls in Cowork sessions. Null while the
    /// file-edit metrics are not enabled for this organization.
    /// </summary>
    public long? MultiEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("multi_edit_tool_count");
        }
        init { this._rawData.Set("multi_edit_tool_count", value); }
    }

    /// <summary>
    /// Number of successful NotebookEdit tool calls in Cowork sessions. Null while
    /// the file-edit metrics are not enabled for this organization.
    /// </summary>
    public long? NotebookEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("notebook_edit_tool_count");
        }
        init { this._rawData.Set("notebook_edit_tool_count", value); }
    }

    /// <summary>
    /// Total number of plugin invocations in Cowork sessions. Null while Cowork plugin-use
    /// metrics are not enabled for this organization.
    /// </summary>
    public long? PluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plugins_used_count");
        }
        init { this._rawData.Set("plugins_used_count", value); }
    }

    /// <summary>
    /// Number of distinct Cowork sessions with at least one successful file-edit
    /// tool call. Null while the file-edit metrics are not enabled for this organization.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
    /// </summary>
    public long? SessionsWithFileEditsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sessions_with_file_edits_count");
        }
        init { this._rawData.Set("sessions_with_file_edits_count", value); }
    }

    /// <summary>
    /// Number of successful Write tool calls in Cowork sessions. Null while the
    /// file-edit metrics are not enabled for this organization.
    /// </summary>
    public long? WriteToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("write_tool_count");
        }
        init { this._rawData.Set("write_tool_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ActionCount;
        _ = this.ArtifactsCreatedCount;
        _ = this.ConnectorsUsedCount;
        _ = this.DispatchTurnCount;
        _ = this.DistinctConnectorsUsedCount;
        _ = this.DistinctSessionCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.MessageCount;
        _ = this.SkillsUsedCount;
        _ = this.DistinctPluginsUsedCount;
        _ = this.EditToolCount;
        _ = this.FileEditCount;
        _ = this.MultiEditToolCount;
        _ = this.NotebookEditToolCount;
        _ = this.PluginsUsedCount;
        _ = this.SessionsWithFileEditsCount;
        _ = this.WriteToolCount;
    }

    public BetaAnalyticsCoworkMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCoworkMetrics(BetaAnalyticsCoworkMetrics betaAnalyticsCoworkMetrics)
        : base(betaAnalyticsCoworkMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsCoworkMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCoworkMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCoworkMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCoworkMetricsFromRaw : IFromRawJson<BetaAnalyticsCoworkMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsCoworkMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCoworkMetrics.FromRawUnchecked(rawData);
}
