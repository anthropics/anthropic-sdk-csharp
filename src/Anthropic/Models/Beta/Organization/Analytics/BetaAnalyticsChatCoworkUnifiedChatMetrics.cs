using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Chat activity recorded while members had Chat and Cowork unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsChatCoworkUnifiedChatMetrics,
        BetaAnalyticsChatCoworkUnifiedChatMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsChatCoworkUnifiedChatMetrics : JsonModel
{
    /// <summary>
    /// Same measure as `chat_metrics.connectors_used_count`, for activity recorded
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
    /// Same measure as `chat_metrics.distinct_artifacts_created_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Exact in date-range
    /// mode: a creation belongs to exactly one day, so the per-day counts never
    /// overlap and their sum over the window is the exact count of distinct creations
    /// in it.
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
    /// Same measure as `chat_metrics.distinct_connectors_used_count`, for activity
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
    /// Same measure as `chat_metrics.distinct_conversation_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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
    /// Same measure as `chat_metrics.distinct_files_uploaded_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. It counts uploaded
    /// files as well as files Claude created and images returned by Claude's tools,
    /// such as screenshots. Approximate (HLL, typical error &lt;2%) in date-range
    /// mode. Null on aggregated rows where a distinct count cannot be computed.
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
    /// Same measure as `chat_metrics.distinct_projects_created_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Exact in date-range
    /// mode: a creation belongs to exactly one day, so the per-day counts never
    /// overlap and their sum over the window is the exact count of distinct creations
    /// in it.
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
    /// Same measure as `chat_metrics.distinct_projects_used_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on. Approximate
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
    /// Always null: shared-artifact views are not currently measured.
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
    /// Same measure as `chat_metrics.distinct_skills_used_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on. Approximate (HLL, typical
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
    /// Same measure as `chat_metrics.message_count`, for activity recorded while
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
    /// Same measure as `chat_metrics.shared_conversations_viewed_count`, for activity
    /// recorded while members had Chat and Cowork unified turned on.
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
    /// Same measure as `chat_metrics.thinking_message_count`, for activity recorded
    /// while members had Chat and Cowork unified turned on.
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

    public BetaAnalyticsChatCoworkUnifiedChatMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsChatCoworkUnifiedChatMetrics(
        BetaAnalyticsChatCoworkUnifiedChatMetrics betaAnalyticsChatCoworkUnifiedChatMetrics
    )
        : base(betaAnalyticsChatCoworkUnifiedChatMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsChatCoworkUnifiedChatMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsChatCoworkUnifiedChatMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsChatCoworkUnifiedChatMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsChatCoworkUnifiedChatMetricsFromRaw
    : IFromRawJson<BetaAnalyticsChatCoworkUnifiedChatMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsChatCoworkUnifiedChatMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsChatCoworkUnifiedChatMetrics.FromRawUnchecked(rawData);
}
