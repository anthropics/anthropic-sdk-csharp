using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Claude.ai activity metrics for a single user on a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsChatMetrics, BetaAnalyticsChatMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsChatMetrics : JsonModel
{
    /// <summary>
    /// Number of MCP connector invocations.
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
    /// Number of distinct artifacts created. Exact in date-range mode: a creation
    /// belongs to exactly one day, so the per-day counts never overlap and their
    /// sum over the window is the exact count of distinct creations in it.
    /// </summary>
    public required long DistinctArtifactsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("distinct_artifacts_created_count");
        }
        init { this._rawData.Set("distinct_artifacts_created_count", value); }
    }

    /// <summary>
    /// Distinct claude.ai connectors this user used. Excludes calls whose connector
    /// could not be identified and all calls from organizations with zero data retention.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
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
    /// Number of distinct conversations the user participated in. Approximate (HLL,
    /// typical error &lt;2%) in date-range mode. Null on aggregated rows where a
    /// distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConversationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_conversation_count");
        }
        init { this._rawData.Set("distinct_conversation_count", value); }
    }

    /// <summary>
    /// Number of distinct files uploaded. Approximate (HLL, typical error &lt;2%)
    /// in date-range mode. Null on aggregated rows where a distinct count cannot
    /// be computed.
    /// </summary>
    public required long? DistinctFilesUploadedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_files_uploaded_count");
        }
        init { this._rawData.Set("distinct_files_uploaded_count", value); }
    }

    /// <summary>
    /// Number of distinct projects created. Exact in date-range mode: a creation
    /// belongs to exactly one day, so the per-day counts never overlap and their
    /// sum over the window is the exact count of distinct creations in it.
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
    /// Number of distinct projects used. Approximate (HLL, typical error &lt;2%)
    /// in date-range mode. Null on aggregated rows where a distinct count cannot
    /// be computed.
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
    /// Number of distinct shared artifacts the user viewed. Approximate (HLL, typical
    /// error &lt;2%) in date-range mode. Null on aggregated rows where a distinct
    /// count cannot be computed.
    /// </summary>
    public required long? DistinctSharedArtifactsViewedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("distinct_shared_artifacts_viewed_count");
        }
        init { this._rawData.Set("distinct_shared_artifacts_viewed_count", value); }
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
    /// Number of times the user opened a shared conversation in a project
    /// </summary>
    public required long SharedConversationsViewedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("shared_conversations_viewed_count");
        }
        init { this._rawData.Set("shared_conversations_viewed_count", value); }
    }

    /// <summary>
    /// Number of messages that used extended thinking
    /// </summary>
    public required long ThinkingMessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("thinking_message_count");
        }
        init { this._rawData.Set("thinking_message_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectorsUsedCount;
        _ = this.DistinctArtifactsCreatedCount;
        _ = this.DistinctConnectorsUsedCount;
        _ = this.DistinctConversationCount;
        _ = this.DistinctFilesUploadedCount;
        _ = this.DistinctProjectsCreatedCount;
        _ = this.DistinctProjectsUsedCount;
        _ = this.DistinctSharedArtifactsViewedCount;
        _ = this.DistinctSkillsUsedCount;
        _ = this.MessageCount;
        _ = this.SharedConversationsViewedCount;
        _ = this.ThinkingMessageCount;
    }

    public BetaAnalyticsChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsChatMetrics(BetaAnalyticsChatMetrics betaAnalyticsChatMetrics)
        : base(betaAnalyticsChatMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsChatMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsChatMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsChatMetricsFromRaw : IFromRawJson<BetaAnalyticsChatMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsChatMetrics.FromRawUnchecked(rawData);
}
