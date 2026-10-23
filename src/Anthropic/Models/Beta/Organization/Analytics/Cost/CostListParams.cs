using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Analytics;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

/// <summary>
/// Get cost in USD across a date range, broken out by dimension.
///
/// <para>Returns one row per combination of the requested `group_by[]` dimensions
/// (and time bucket, when `time_bucket_width` is set) that has cost in the range,
/// ranked by spend or ordered by time bucket; every combination is returned across
/// pages. With no `group_by[]` and no `time_bucket_width`, a single row aggregates
/// the whole range. Includes all cost, whether or not it is attributable to a seat
/// user. Requires an API key with the `read:analytics` scope, or an Admin API key.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CostListParams : ParamsBase
{
    /// <summary>
    /// Start of range, inclusive. RFC 3339 tz-aware. Must be within the last 365
    /// days and no earlier than 2026-01-01T00:00:00Z.
    /// </summary>
    public required DateTimeOffset StartingAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<DateTimeOffset>("starting_at");
        }
        init { this._rawQueryData.Set("starting_at", value); }
    }

    /// <summary>
    /// Filter to usage attributed to specific identities, by tagged ID: a `user_...`,
    /// `svac_...` (service account), or `apikey_...` ID. An `apikey_` entry matches
    /// only usage attributed to the key itself, not usage on that key attributed
    /// to a user or service account (use `api_key_ids[]` for every request a key
    /// authenticated). Federated identities have no tagged ID; select them with
    /// `actor_types[]`. Use `group_by[]=actor` to break out per-identity values.
    /// </summary>
    public IReadOnlyList<string>? ActorIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("actor_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "actor_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage attributed to specific kinds of identity. Use `group_by[]=actor_type`
    /// to break out per-kind values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsActorType>>? ActorTypes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsActorType>>
            >("actor_types");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsActorType>>?>(
                "actor_types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage incurred by sessions of specific Claude Managed Agents agents.
    /// Use `group_by[]=agent_id` to break out per-agent values. Claude Developer
    /// Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? AgentIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("agent_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "agent_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage authenticated by specific API keys, by tagged API key ID (`apikey_...`),
    /// whichever identity the usage is attributed to. Include an empty entry (`api_key_ids[]=`)
    /// to also match usage that no API key authenticated. Use `group_by[]=api_key_id`
    /// to break out per-key values; usage without a key has a null `api_key_id`.
    /// Claude Developer Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? ApiKeyIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("api_key_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "api_key_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to Claude Tag (Claude in Slack) usage in specific spend categories.
    /// Usage with no category never matches. `dm` usage is reported under the user's
    /// product rather than `claude_tag`, so combining this filter with `products[]=claude_tag`
    /// excludes it. Use `group_by[]=claude_tag_category` to break out per-category values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>? ClaudeTagCategories
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>
            >("claude_tag_categories");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, BetaAnalyticsClaudeTagCategory>
            >?>(
                "claude_tag_categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to Claude Tag (Claude in Slack) usage attributed to specific Slack
    /// users, by Slack user ID (for example `U0123ABCDEF`), not claude.ai user ID.
    /// Usage that is not Claude Tag, and Claude Tag usage not attributed to a single
    /// user, never matches. Use `group_by[]=claude_tag_user_id` to break out per-user values.
    /// </summary>
    public IReadOnlyList<string>? ClaudeTagUserIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "claude_tag_user_ids"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "claude_tag_user_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to specific context-window pricing tiers. Use `group_by[]=context_window`
    /// to break out per-tier values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsContextWindow>>? ContextWindows
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsContextWindow>>
            >("context_windows");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsContextWindow>>?>(
                "context_windows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage incurred by Claude Managed Agents sessions that specific deployments
    /// started. Use `group_by[]=deployment_id` to break out per-deployment values.
    /// Claude Developer Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? DeploymentIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("deployment_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "deployment_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// End of range, exclusive. Required when `time_bucket_width` is set. Without
    /// `time_bucket_width`, defaults to the earlier of now and `starting_at` + 31
    /// days. The range may span at most 31 days.
    /// </summary>
    public DateTimeOffset? EndingAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("ending_at");
        }
        init { this._rawQueryData.Set("ending_at", value); }
    }

    /// <summary>
    /// Filter to usage incurred by Claude Managed Agents sessions that ran in specific
    /// environments. Use `group_by[]=environment_id` to break out per-environment
    /// values. Claude Developer Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? EnvironmentIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("environment_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "environment_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// If true, omit rows whose `actor` is a `user_actor` with `deleted: true`.
    /// Requires `group_by[]=actor`. Rows for other actor types, and rows whose `actor`
    /// is null, are always kept. A page may contain fewer than `limit` rows; use
    /// `has_more` and `next_page` to paginate as usual.
    /// </summary>
    public bool? ExcludeDeletedUsers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("exclude_deleted_users");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("exclude_deleted_users");
                return;
            }

            this._rawQueryData.Set("exclude_deleted_users", value);
        }
    }

    /// <summary>
    /// Dimensions to break cost out by (at most 5, not counting `cost_type` and `token_type`):
    /// one row per combination of their values with cost in the range (and per time
    /// bucket, when `time_bucket_width` is set), every combination returned across
    /// pages rather than a capped top set. `cost_type` and `token_type` do not count
    /// toward `limit`: `cost_type` returns one row per cost component (tokens, web
    /// search, code execution, and `session_usage`, Claude Managed Agents session
    /// time); `token_type` returns one row per token type, each with `cost_type:
    /// "tokens"`; combining both returns the per-token-type rows plus the web-search,
    /// code-execution and session-usage rows. When omitted, a single row aggregates
    /// the whole range.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsCostGroupBy>>? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsCostGroupBy>>
            >("group_by");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsCostGroupBy>>?>(
                "group_by",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to specific inference regions. `not_available` matches rows where the
    /// region is unset. Use `group_by[]=inference_geo` to break out per-region values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsInferenceGeoFilter>>? InferenceGeos
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsInferenceGeoFilter>>
            >("inference_geos");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, BetaAnalyticsInferenceGeoFilter>
            >?>("inference_geos", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Number of rows per page (1-1000, default 20). `cost_type`/`token_type` fan-out
    /// rows (cost endpoint only) do not count toward this limit, so `data` can exceed it.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("limit");
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Models to include. Defaults to all models. Use `group_by[]=model` to break
    /// out per-model values.
    /// </summary>
    public IReadOnlyList<string>? Models
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("models");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "models",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Sort direction of the `order_by` metric, or of the time buckets when `order_by`
    /// is `time` and `time_bucket_width` is set. Defaults to `desc`.
    /// </summary>
    public ApiEnum<string, BetaAnalyticsUsageCostSortOrder>? Order
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageCostSortOrder>
            >("order");
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("order");
                return;
            }

            this._rawQueryData.Set("order", value);
        }
    }

    /// <summary>
    /// Row order. A metric ranks rows by that metric in the `order` direction. `time`
    /// orders rows by time bucket in the `order` direction (newest first by default)
    /// and, within a bucket, by `amount`, highest first. `time` takes effect only
    /// with `time_bucket_width`; without it, `time` is the same as `amount`. Defaults
    /// to `amount`.
    /// </summary>
    public ApiEnum<string, BetaAnalyticsCostOrderBy>? OrderBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, BetaAnalyticsCostOrderBy>>(
                "order_by"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("order_by");
                return;
            }

            this._rawQueryData.Set("order_by", value);
        }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `next_page` field.
    /// </summary>
    public string? Page
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page");
        }
        init { this._rawQueryData.Set("page", value); }
    }

    /// <summary>
    /// Product surfaces to include. Defaults to all products.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsUsageCostProductFilter>>? Products
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsUsageCostProductFilter>>
            >("products");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<
                ApiEnum<string, BetaAnalyticsUsageCostProductFilter>
            >?>("products", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Filter to usage attributed to specific RBAC groups. Accepts tagged RBAC group
    /// IDs (`rbac_group_...`) or bare group UUIDs. A row matches when the user belonged
    /// to any of the listed groups on the (UTC) day the usage occurred; usage with
    /// no group attribution never matches.
    /// </summary>
    public IReadOnlyList<string>? RbacGroupIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("rbac_group_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "rbac_group_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to specific service tiers. Use `group_by[]=service_tier` to break out
    /// per-tier values. Claude Developer Platform organizations only; matches nothing
    /// for a Claude Enterprise organization.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsServiceTier>>? ServiceTiers
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsServiceTier>>
            >("service_tiers");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsServiceTier>>?>(
                "service_tiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage incurred by specific Claude Managed Agents sessions, by tagged
    /// session ID (`sesn_...`). Use `group_by[]=session_id` to break out per-session
    /// values. Claude Developer Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? SessionIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("session_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "session_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage originating from specific Slack channels. Use `group_by[]=slack_channel_id`
    /// to break out per-channel values.
    /// </summary>
    public IReadOnlyList<string>? SlackChannelIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "slack_channel_ids"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "slack_channel_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to fast or standard inference mode. Use `group_by[]=speed` to break
    /// out per-mode values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsSpeed>>? Speeds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsSpeed>>
            >("speeds");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsSpeed>>?>(
                "speeds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Time-bucket granularity. When set, rows are returned per time bucket (one
    /// per bucket and dimension combination with usage) and each row's `starting_at`
    /// and `ending_at` are that bucket's bounds; the time bucket counts toward `limit`.
    /// `ending_at` is required when `time_bucket_width` is set, and with `time_bucket_width="1m"`
    /// the range may span at most 24 hours. When omitted, each row aggregates the
    /// requested range with `starting_at` and `ending_at` each rounded down to the hour.
    /// </summary>
    public ApiEnum<string, BetaAnalyticsTimeBucketWidth>? TimeBucketWidth
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsTimeBucketWidth>
            >("time_bucket_width");
        }
        init { this._rawQueryData.Set("time_bucket_width", value); }
    }

    /// <summary>
    /// Filter to usage attributed to specific user profiles, by tagged user profile
    /// ID (`uprof_...`). Use `group_by[]=user_profile_id` to break out per-profile
    /// values. Claude Developer Platform organizations only.
    /// </summary>
    public IReadOnlyList<string>? UserProfileIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("user_profile_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "user_profile_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to usage in specific workspaces, by tagged workspace ID (`wrkspc_...`).
    /// Use `group_by[]=workspace_id` to break out per-workspace values. Claude Developer
    /// Platform organizations only; matches nothing for a Claude Enterprise organization.
    /// </summary>
    public IReadOnlyList<string>? WorkspaceIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("workspace_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "workspace_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// This endpoint is in beta: requests must send `analytics-usage-cost-2026-08-24`
    /// in this header.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                this._rawHeaderData.Remove("anthropic-beta");
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CostListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostListParams(CostListParams costListParams)
        : base(costListParams) { }
#pragma warning restore CS8618

    public CostListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CostListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CostListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/cost"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override string Route => "/v1/organizations/analytics/cost";

    internal override IReadOnlyList<string> QueryParams =>
        [
            "actor_ids",
            "actor_types",
            "agent_ids",
            "api_key_ids",
            "claude_tag_categories",
            "claude_tag_user_ids",
            "context_windows",
            "deployment_ids",
            "ending_at",
            "environment_ids",
            "exclude_deleted_users",
            "group_by",
            "inference_geos",
            "limit",
            "models",
            "order",
            "order_by",
            "page",
            "products",
            "rbac_group_ids",
            "service_tiers",
            "session_ids",
            "slack_channel_ids",
            "speeds",
            "starting_at",
            "time_bucket_width",
            "user_profile_ids",
            "workspace_ids",
        ];

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        CostService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
