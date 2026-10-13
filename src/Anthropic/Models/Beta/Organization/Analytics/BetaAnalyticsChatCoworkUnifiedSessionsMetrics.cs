using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Cowork session activity recorded while members had Chat and Cowork unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsChatCoworkUnifiedSessionsMetrics,
        BetaAnalyticsChatCoworkUnifiedSessionsMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsChatCoworkUnifiedSessionsMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.action_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
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
    /// Same measure as `cowork_metrics.artifacts_created_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Exact in date-range mode:
    /// a creation belongs to exactly one day, so the per-day counts never overlap
    /// and their sum over the window is the exact count of distinct creations in it.
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
    /// Same measure as `cowork_metrics.connectors_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
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
    /// Same measure as `cowork_metrics.dispatch_turn_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
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
    /// Same measure as `cowork_metrics.distinct_connectors_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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
    /// Same measure as `cowork_metrics.distinct_plugins_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctPluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_plugins_used_count");
        }
        init { this._rawData.Set("distinct_plugins_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
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
    /// Same measure as `cowork_metrics.distinct_skills_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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
    /// Same measure as `cowork_metrics.edit_tool_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long? EditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("edit_tool_count");
        }
        init { this._rawData.Set("edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.file_edit_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long? FileEditCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("file_edit_count");
        }
        init { this._rawData.Set("file_edit_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.message_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
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
    /// Same measure as `cowork_metrics.multi_edit_tool_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Claude no longer has
    /// a multi-edit tool, so expect 0 when not null; each edit is now a separate
    /// Edit tool call, counted in `edit_tool_count` and `file_edit_count`.
    /// </summary>
    public required long? MultiEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("multi_edit_tool_count");
        }
        init { this._rawData.Set("multi_edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.notebook_edit_tool_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long? NotebookEditToolCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("notebook_edit_tool_count");
        }
        init { this._rawData.Set("notebook_edit_tool_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.plugins_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
    /// </summary>
    public required long? PluginsUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("plugins_used_count");
        }
        init { this._rawData.Set("plugins_used_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.sessions_with_file_edits_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
    /// </summary>
    public required long? SessionsWithFileEditsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sessions_with_file_edits_count");
        }
        init { this._rawData.Set("sessions_with_file_edits_count", value); }
    }

    /// <summary>
    /// Same measure as `cowork_metrics.skills_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
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
    /// Same measure as `cowork_metrics.write_tool_count`, for activity recorded while
    /// members had Chat and Cowork unified turned on.
    /// </summary>
    public required long? WriteToolCount
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
        _ = this.DistinctPluginsUsedCount;
        _ = this.DistinctSessionCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.EditToolCount;
        _ = this.FileEditCount;
        _ = this.MessageCount;
        _ = this.MultiEditToolCount;
        _ = this.NotebookEditToolCount;
        _ = this.PluginsUsedCount;
        _ = this.SessionsWithFileEditsCount;
        _ = this.SkillsUsedCount;
        _ = this.WriteToolCount;
    }

    public BetaAnalyticsChatCoworkUnifiedSessionsMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsChatCoworkUnifiedSessionsMetrics(
        BetaAnalyticsChatCoworkUnifiedSessionsMetrics betaAnalyticsChatCoworkUnifiedSessionsMetrics
    )
        : base(betaAnalyticsChatCoworkUnifiedSessionsMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsChatCoworkUnifiedSessionsMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsChatCoworkUnifiedSessionsMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsChatCoworkUnifiedSessionsMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsChatCoworkUnifiedSessionsMetricsFromRaw
    : IFromRawJson<BetaAnalyticsChatCoworkUnifiedSessionsMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsChatCoworkUnifiedSessionsMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsChatCoworkUnifiedSessionsMetrics.FromRawUnchecked(rawData);
}
