using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-connector activity data for a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorActivity,
        BetaAnalyticsConnectorActivityFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorActivity : JsonModel
{
    /// <summary>
    /// Claude.ai activity metrics for a single connector on a given day.
    /// </summary>
    public required BetaAnalyticsConnectorChatMetrics ChatMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorChatMetrics>("chat_metrics");
        }
        init { this._rawData.Set("chat_metrics", value); }
    }

    /// <summary>
    /// Claude Code activity metrics for a single connector on a given day.
    /// </summary>
    public required BetaAnalyticsConnectorClaudeCodeMetrics ClaudeCodeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorClaudeCodeMetrics>(
                "claude_code_metrics"
            );
        }
        init { this._rawData.Set("claude_code_metrics", value); }
    }

    /// <summary>
    /// Name of the connector. Some rows carry an opaque connector id here instead
    /// of a readable name; `connector_display_name` holds the resolved name for those rows.
    /// </summary>
    public required string ConnectorName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connector_name");
        }
        init { this._rawData.Set("connector_name", value); }
    }

    /// <summary>
    /// Cowork activity metrics for a single connector on a given day.
    /// </summary>
    public required BetaAnalyticsConnectorCoworkMetrics CoworkMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorCoworkMetrics>(
                "cowork_metrics"
            );
        }
        init { this._rawData.Set("cowork_metrics", value); }
    }

    /// <summary>
    /// Number of distinct users who used the connector on the requested day, or,
    /// in date-range mode, over the requested window — recomputed as an exact distinct
    /// count over the window's per-member daily rows, never a sum of per-day values.
    /// </summary>
    public required long DistinctUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("distinct_user_count");
        }
        init { this._rawData.Set("distinct_user_count", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day, broken
    /// out by Office product.
    /// </summary>
    public required BetaAnalyticsConnectorOfficeMetrics OfficeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorOfficeMetrics>(
                "office_metrics"
            );
        }
        init { this._rawData.Set("office_metrics", value); }
    }

    /// <summary>
    /// Connector use recorded while members had Chat and Cowork unified (Cowork's
    /// features inside claude.ai chat) turned on, split into chat conversations and
    /// Cowork sessions. A count is null in date-range mode where it cannot be computed.
    /// Omitted from the response on deployments that do not offer Chat and Cowork unified.
    /// </summary>
    public ChatCoworkUnifiedMetrics? ChatCoworkUnifiedMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatCoworkUnifiedMetrics>(
                "chat_cowork_unified_metrics"
            );
        }
        init { this._rawData.Set("chat_cowork_unified_metrics", value); }
    }

    /// <summary>
    /// Human-readable display name for rows whose `connector_name` is an opaque
    /// connector id rather than a readable name, resolved at request time from the
    /// organization's connectors (including connectors that have since been removed).
    /// `connector_name` remains the row's stable key for sorting and pagination,
    /// and `filter[]=connector_name:{value}` also matches these rows by display
    /// name. Display names are not unique, and the same connector's claude.ai usage
    /// can appear under a separate row with a readable `connector_name`. Null when
    /// `connector_name` is already a readable name, when the id cannot be resolved
    /// to one of the organization's connectors, or when display-name resolution
    /// is not enabled for this organization.
    /// </summary>
    public string? ConnectorDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("connector_display_name");
        }
        init { this._rawData.Set("connector_display_name", value); }
    }

    /// <summary>
    /// Number of distinct users whose use of this connector on the requested day
    /// ran on their own individual credential, connected through their own consent
    /// flow. Companion bucket to `managed_auth_distinct_user_count`, which carries
    /// the measurement, attribution, and null rules. Users whose requests used no
    /// stored credential count in neither bucket.
    /// </summary>
    public long? IndividualAuthDistinctUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("individual_auth_distinct_user_count");
        }
        init { this._rawData.Set("individual_auth_distinct_user_count", value); }
    }

    /// <summary>
    /// Number of distinct users whose use of this connector on the requested day
    /// ran on Enterprise Managed Auth (an organization-managed credential provisioned
    /// through the organization's identity provider), read from the token record
    /// each request used. Null, never 0, when managed-auth reporting is not enabled
    /// for the organization, the value cannot be attributed to the row, no credentialed
    /// requests and no managed-token mint events (a managed credential being provisioned
    /// for a user's use of the connector) were observed that day, or the day predates
    /// 2026-07-01, the first day the backing data exists (forward-only data, no
    /// backfill). When credentialed requests or mint events were observed and attributed,
    /// both managed-auth fields populate, reporting 0 for a bucket with no users;
    /// the two counts are independent, not a partition — a user whose requests that
    /// day used both kinds of credential counts in both. Mint events carry user
    /// but not surface attribution, so they count as observed auth activity on `user_id`
    /// and `rbac_group_id` cuts — attributed to the user the credential was provisioned
    /// for — but never on a cut that references `product` (group or filter). Date-range
    /// rollup mode (`starting_date`/`ending_date`) computes both fields exactly
    /// over the window — distinct users with at least one qualifying day — when
    /// the whole window starts on or after 2026-07-01, with the null-versus-0 and
    /// mint-event rules applying with the window in place of the day; a range starting
    /// earlier reports every managed-auth field as null, never a partial-window value.
    /// </summary>
    public long? ManagedAuthDistinctUserCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("managed_auth_distinct_user_count");
        }
        init { this._rawData.Set("managed_auth_distinct_user_count", value); }
    }

    /// <summary>
    /// Product that produced this row's activity: one of `chat`, `claude_code`,
    /// `cowork`, `office_agent`, or `chat_cowork_unified` (Chat and Cowork unified).
    /// These are the canonical Cost &amp; Usage product names; an `office_agent`
    /// row's per-surface breakdown is in its `office_metrics`. On `/plugins` only
    /// `cowork`, `claude_code` and `chat_cowork_unified` occur (the only surfaces
    /// with plugin attribution); on `/artifacts` only `chat`, `claude_code`, `cowork`
    /// and `chat_cowork_unified` occur (the surfaces that create artifacts); `/apps/chat/projects`
    /// does not support the product dimension (a `product` entry in `group_by[]`
    /// or `filter[]` there is rejected). Present only when the request grouped by `product`.
    /// </summary>
    public string? Product
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product");
        }
        init { this._rawData.Set("product", value); }
    }

    /// <summary>
    /// Tagged RBAC group identifier (`rbac_group_...`), matching the spend-limits
    /// API spelling. Present only when the request grouped by `rbac_group_id`.
    /// </summary>
    public string? RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Resolved RBAC group display name, alongside `rbac_group_id` when name resolution
    /// is available. Null if the group has been deleted or its name could not be
    /// resolved; `rbac_group_id` remains the stable key.
    /// </summary>
    public string? RbacGroupName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_name");
        }
        init { this._rawData.Set("rbac_group_name", value); }
    }

    /// <summary>
    /// Number of connector tool calls on the requested day whose trusted read-only
    /// annotation marked them read-only. Call count, not distinct users. Every call
    /// recorded on a classified surface lands in exactly one of `read_call_count`,
    /// `write_call_count`, or `unclassified_call_count`, so the three sum to the
    /// day's classified calls. Classification is forward-only per surface: claude.ai
    /// from 2026-06-01, Claude Code from 2026-05-30, Claude in Office from 2026-05-29,
    /// Cowork from 2026-06-02 (Cowork clients predating annotation forwarding land
    /// in `unclassified_call_count`). Null, never 0, when the value cannot be stated:
    /// the read/write split is not enabled for this organization, or the day predates
    /// 2026-05-29. For a date-range total, sum the per-day values, but treat a window
    /// that extends before 2026-05-29 as null rather than summing only its covered
    /// days — date-range rollup mode (`starting_date`/`ending_date`) applies both
    /// rules server-side.
    /// </summary>
    public long? ReadCallCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("read_call_count");
        }
        init { this._rawData.Set("read_call_count", value); }
    }

    /// <summary>
    /// Number of connector tool calls on the requested day with no trusted read-only
    /// annotation — the annotation is optional in the MCP spec and is discarded
    /// when connector access controls are active, so unclassified calls are common.
    /// This field shows how much of the day's classified activity the read/write
    /// split actually covers. Call count, not distinct users. One of the three call-classification
    /// buckets; see `read_call_count` for the per-surface data-start dates, null
    /// conditions, and date-range guidance.
    /// </summary>
    public long? UnclassifiedCallCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("unclassified_call_count");
        }
        init { this._rawData.Set("unclassified_call_count", value); }
    }

    /// <summary>
    /// Tagged user identifier (e.g. `user_...`). Present only when the request grouped
    /// by `user_id`.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Number of connector tool calls on the requested day whose trusted read-only
    /// annotation marked them not read-only. Call count, not distinct users. One
    /// of the three call-classification buckets; see `read_call_count` for the per-surface
    /// data-start dates, null conditions, and date-range guidance.
    /// </summary>
    public long? WriteCallCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("write_call_count");
        }
        init { this._rawData.Set("write_call_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChatMetrics.Validate();
        this.ClaudeCodeMetrics.Validate();
        _ = this.ConnectorName;
        this.CoworkMetrics.Validate();
        _ = this.DistinctUserCount;
        this.OfficeMetrics.Validate();
        this.ChatCoworkUnifiedMetrics?.Validate();
        _ = this.ConnectorDisplayName;
        _ = this.IndividualAuthDistinctUserCount;
        _ = this.ManagedAuthDistinctUserCount;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        _ = this.ReadCallCount;
        _ = this.UnclassifiedCallCount;
        _ = this.UserID;
        _ = this.WriteCallCount;
    }

    public BetaAnalyticsConnectorActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorActivity(
        BetaAnalyticsConnectorActivity betaAnalyticsConnectorActivity
    )
        : base(betaAnalyticsConnectorActivity) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorActivityFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsConnectorActivityFromRaw : IFromRawJson<BetaAnalyticsConnectorActivity>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorActivity.FromRawUnchecked(rawData);
}

/// <summary>
/// Connector use recorded while members had Chat and Cowork unified (Cowork's features
/// inside claude.ai chat) turned on, split into chat conversations and Cowork sessions.
/// A count is null in date-range mode where it cannot be computed. Omitted from
/// the response on deployments that do not offer Chat and Cowork unified.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ChatCoworkUnifiedMetrics, ChatCoworkUnifiedMetricsFromRaw>)
)]
public sealed record class ChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A connector's use in chat conversations recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required Chat Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Chat>("chat");
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A connector's use in Cowork sessions recorded while members had Chat and
    /// Cowork unified turned on.
    /// </summary>
    public required ChatCoworkUnifiedMetricsSessions Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ChatCoworkUnifiedMetricsSessions>("sessions");
        }
        init { this._rawData.Set("sessions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Chat.Validate();
        this.Sessions.Validate();
    }

    public ChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCoworkUnifiedMetrics(ChatCoworkUnifiedMetrics chatCoworkUnifiedMetrics)
        : base(chatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public ChatCoworkUnifiedMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCoworkUnifiedMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static ChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatCoworkUnifiedMetricsFromRaw : IFromRawJson<ChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public ChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// A connector's use in chat conversations recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Chat, ChatFromRaw>))]
public sealed record class Chat : JsonModel
{
    /// <summary>
    /// Same measure as `chat_metrics.distinct_conversation_connector_used_count`,
    /// for activity recorded while members had Chat and Cowork unified turned on.
    /// Approximate (HLL, typical error &lt;2%) in date-range mode. Null on aggregated
    /// rows where a distinct count cannot be computed.
    /// </summary>
    public required long? DistinctConversationConnectorUsedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "distinct_conversation_connector_used_count"
            );
        }
        init { this._rawData.Set("distinct_conversation_connector_used_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DistinctConversationConnectorUsedCount;
    }

    public Chat() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Chat(Chat chat)
        : base(chat) { }
#pragma warning restore CS8618

    public Chat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Chat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatFromRaw.FromRawUnchecked"/>
    public static Chat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Chat(long? distinctConversationConnectorUsedCount)
        : this()
    {
        this.DistinctConversationConnectorUsedCount = distinctConversationConnectorUsedCount;
    }
}

class ChatFromRaw : IFromRawJson<Chat>
{
    /// <inheritdoc/>
    public Chat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chat.FromRawUnchecked(rawData);
}

/// <summary>
/// A connector's use in Cowork sessions recorded while members had Chat and Cowork
/// unified turned on.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatCoworkUnifiedMetricsSessions,
        ChatCoworkUnifiedMetricsSessionsFromRaw
    >)
)]
public sealed record class ChatCoworkUnifiedMetricsSessions : JsonModel
{
    /// <summary>
    /// Same measure as `cowork_metrics.distinct_session_connector_used_count`, for
    /// activity recorded while members had Chat and Cowork unified turned on. Approximate
    /// (HLL, typical error &lt;2%) in date-range mode. Null on aggregated rows where
    /// a distinct count cannot be computed.
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

    public ChatCoworkUnifiedMetricsSessions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatCoworkUnifiedMetricsSessions(
        ChatCoworkUnifiedMetricsSessions chatCoworkUnifiedMetricsSessions
    )
        : base(chatCoworkUnifiedMetricsSessions) { }
#pragma warning restore CS8618

    public ChatCoworkUnifiedMetricsSessions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatCoworkUnifiedMetricsSessions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatCoworkUnifiedMetricsSessionsFromRaw.FromRawUnchecked"/>
    public static ChatCoworkUnifiedMetricsSessions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChatCoworkUnifiedMetricsSessions(long? distinctSessionConnectorUsedCount)
        : this()
    {
        this.DistinctSessionConnectorUsedCount = distinctSessionConnectorUsedCount;
    }
}

class ChatCoworkUnifiedMetricsSessionsFromRaw : IFromRawJson<ChatCoworkUnifiedMetricsSessions>
{
    /// <inheritdoc/>
    public ChatCoworkUnifiedMetricsSessions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatCoworkUnifiedMetricsSessions.FromRawUnchecked(rawData);
}
