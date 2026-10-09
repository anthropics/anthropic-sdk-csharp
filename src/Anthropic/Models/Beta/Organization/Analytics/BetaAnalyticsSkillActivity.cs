using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-skill activity data for a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsSkillActivity, BetaAnalyticsSkillActivityFromRaw>)
)]
public sealed record class BetaAnalyticsSkillActivity : JsonModel
{
    /// <summary>
    /// Claude.ai activity metrics for a single skill on a given day.
    /// </summary>
    public required BetaAnalyticsSkillChatMetrics ChatMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillChatMetrics>("chat_metrics");
        }
        init { this._rawData.Set("chat_metrics", value); }
    }

    /// <summary>
    /// Claude Code activity metrics for a single skill on a given day.
    /// </summary>
    public required BetaAnalyticsSkillClaudeCodeMetrics ClaudeCodeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillClaudeCodeMetrics>(
                "claude_code_metrics"
            );
        }
        init { this._rawData.Set("claude_code_metrics", value); }
    }

    /// <summary>
    /// Cowork activity metrics for a single skill on a given day.
    /// </summary>
    public required BetaAnalyticsSkillCoworkMetrics CoworkMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillCoworkMetrics>("cowork_metrics");
        }
        init { this._rawData.Set("cowork_metrics", value); }
    }

    /// <summary>
    /// Number of distinct users who used the skill on the requested day, or, in
    /// date-range mode, over the requested window — recomputed as an exact distinct
    /// count over the window's per-member daily rows, never a sum of per-day values.
    /// A skill counts as used only when it is explicitly activated — the model (or
    /// the user, via the skill's slash command) invokes it, reading its instructions
    /// into context as part of that activation. Skills that are merely installed
    /// or listed as available, or whose content reaches the context without an activation
    /// (preloaded, hook-injected, or read as a plain file), are not counted.
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
    /// Office Agent activity metrics for a single skill on a given day, broken out
    /// by Office product.
    /// </summary>
    public required BetaAnalyticsSkillOfficeMetrics OfficeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillOfficeMetrics>("office_metrics");
        }
        init { this._rawData.Set("office_metrics", value); }
    }

    /// <summary>
    /// Name of the skill
    /// </summary>
    public required string SkillName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("skill_name");
        }
        init { this._rawData.Set("skill_name", value); }
    }

    /// <summary>
    /// List-price (rate-card) value of the member requests attributed to this skill,
    /// as a decimal string in the minor unit of `currency` (cents for USD), from
    /// Claude Code, Cowork, and Office Agent request-level attribution — the value
    /// of requests that involved the skill, not the skill's incremental cost. Unlike
    /// `estimated_overage_spend` this reflects usage value regardless of how it was
    /// funded — seat-covered usage counts — but it is undiscounted and does not tie
    /// to billed spend or the organization's spend reporting. claude.ai chat usage
    /// carries no request-level attribution and contributes nothing: the field is
    /// null on `chat` product rows and on `office_agent` product cuts dated before
    /// 2026-06-18 (the Office Agent attribution data-start), and on ungrouped rows
    /// it covers the Claude Code + Cowork + Office Agent share only (null when no
    /// attributable usage exists). Also null under the same conditions as `estimated_overage_spend`
    /// (spend reporting not enabled for this organization, `office_agent` product
    /// cuts before the 2026-06-18 data-start). "0" means attributable usage existed
    /// but none was attributed to this skill. Addable across days: date-range rollup
    /// mode returns the window's sum. On `group_by[]` and `filter[]` shapes both
    /// amounts can total below the ungrouped value for the same skill over the same
    /// date or range: spend attributed to a member–skill pair with no counted usage
    /// on that day is excluded from those cuts.
    /// </summary>
    public string? AttributedListPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("attributed_list_price");
        }
        init { this._rawData.Set("attributed_list_price", value); }
    }

    /// <summary>
    /// Skill use recorded while members had Chat and Cowork unified (Cowork's features
    /// inside claude.ai chat) turned on, split into chat conversations and Cowork
    /// sessions. A count is null in date-range mode where it cannot be computed.
    /// Omitted from the response on deployments that do not offer Chat and Cowork unified.
    /// </summary>
    public BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics? ChatCoworkUnifiedMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics>(
                "chat_cowork_unified_metrics"
            );
        }
        init { this._rawData.Set("chat_cowork_unified_metrics", value); }
    }

    /// <summary>
    /// Currency for this row's monetary fields (`estimated_overage_spend` and `attributed_list_price`),
    /// as an uppercase ISO-4217 code. Always "USD" when either amount is populated;
    /// null whenever both amounts are null.
    /// </summary>
    public string? Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// Distinct accounts that enabled this skill on the requested day (claude.ai
    /// only — the skill analog of plugin `install_count`). The count is org-wide:
    /// null when enable reporting is not enabled for this organization, or when the
    /// request scopes to `user_id` / `rbac_group_id` / `product` via `group_by[]`
    /// or `filter[]` (an org-wide count would be misleading on per-cut rows). A
    /// distinct count, not an event count: summing across days double-counts members
    /// who enable the skill on more than one day, so it is also null in date-range
    /// rollup mode (`starting_date`/`ending_date`).
    /// </summary>
    public long? EnableCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("enable_count");
        }
        init { this._rawData.Set("enable_count", value); }
    }

    /// <summary>
    /// Estimated overage spend attributed to this skill, as a decimal string in
    /// the minor unit of `currency` (cents for USD; "1250" is $12.50, fractional
    /// cents possible) — an allocation of each member's daily post-discount, pre-credit
    /// metered overage spend (the same cost basis as the organization's spend reporting
    /// and the Cost &amp; Usage API, so per-skill figures are directly comparable;
    /// spend with no skill attribution — including any member-day without skill
    /// invocations — is not represented, so skill rows sum to at most those totals)
    /// across the skills the member used. Overage only: usage covered by included
    /// seat allowances bills nothing and allocates $0 here — see `attributed_list_price`
    /// for the funding-independent usage-value companion. Claude Code, Cowork, and
    /// Office Agent spend use request-level skill attribution; claude.ai chat spend
    /// is approximated proportionally to skill-invoking messages. An estimate, not
    /// a billing number — and the cost of the requests/messages that involved the
    /// skill, not the skill's incremental cost (the same request would still have
    /// cost something without the skill active). "0" means no overage spend was
    /// attributed; null when spend reporting is not enabled for this organization,
    /// on `office_agent` product cuts dated before 2026-06-18 (the Office Agent attribution
    /// data-start). Addable across days: date-range rollup mode (`starting_date`/`ending_date`)
    /// returns the window's sum. With `group_by[]=user_id` each row carries the
    /// user's own attributed spend. On `group_by[]` and `filter[]` shapes both amounts
    /// can total below the ungrouped value for the same skill over the same date
    /// or range: spend attributed to a member–skill pair with no counted usage on
    /// that day is excluded from those cuts.
    /// </summary>
    public string? EstimatedOverageSpend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("estimated_overage_spend");
        }
        init { this._rawData.Set("estimated_overage_spend", value); }
    }

    /// <summary>
    /// Total number of times this skill was invoked on the requested day (the skill
    /// analog of plugin `invocation_count`). Unlike `distinct_user_count` — which
    /// answers '# of users' — this is the true '# of uses'. A skill counts as used
    /// only when it is explicitly activated — the model (or the user, via the skill's
    /// slash command) invokes it, reading its instructions into context as part of
    /// that activation. Skills that are merely installed or listed as available,
    /// or whose content reaches the context without an activation (preloaded, hook-injected,
    /// or read as a plain file), are not counted. Null when invocation reporting
    /// is not enabled for this organization. Sum across a date range for total uses
    /// in the window — date-range rollup mode (`starting_date`/`ending_date`) returns
    /// this sum directly.
    /// </summary>
    public long? InvocationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("invocation_count");
        }
        init { this._rawData.Set("invocation_count", value); }
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
    /// Skill share status (claude.ai only): one of `private`, `organization`, or
    /// `public`. Null for skills used only in Claude Code or Office (no per-skill
    /// share-status concept) and when share-status reporting is not yet available
    /// for the organization. Filterable via `filter[]=share_status:{value}`.
    /// </summary>
    public ApiEnum<string, ShareStatus>? ShareStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ShareStatus>>("share_status");
        }
        init { this._rawData.Set("share_status", value); }
    }

    /// <summary>
    /// Human-readable display name for rows whose `skill_name` is an opaque skill
    /// id (user/organization skill types and plugin-delivered skills, whose user-defined
    /// names usage reports generally withhold). Organization-shared skills and skills
    /// delivered by the organization's own plugins (its plugin marketplaces and its
    /// library) resolve; plugin skill names are shown without their 'plugin:' prefix.
    /// The literal 'unknown' bucket row gets a fixed 'Unknown skill' label. For a
    /// member's own skill (private or personal-plugin) it is null, except when the
    /// skill's owner used it from Claude Code or Cowork in the requested period:
    /// then it shows the name that client reported at the time. Apart from that,
    /// the names of members' own skills are not disclosed to analytics-key holders.
    /// Also null for Anthropic-provided plugin skills (not resolved), for an organization
    /// skill or plugin whose name can no longer be found (for example, one since
    /// deleted), when `skill_name` is already a display name, or when display-name
    /// resolution is not enabled for this organization.
    /// </summary>
    public string? SkillDisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("skill_display_name");
        }
        init { this._rawData.Set("skill_display_name", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChatMetrics.Validate();
        this.ClaudeCodeMetrics.Validate();
        this.CoworkMetrics.Validate();
        _ = this.DistinctUserCount;
        this.OfficeMetrics.Validate();
        _ = this.SkillName;
        _ = this.AttributedListPrice;
        this.ChatCoworkUnifiedMetrics?.Validate();
        _ = this.Currency;
        _ = this.EnableCount;
        _ = this.EstimatedOverageSpend;
        _ = this.InvocationCount;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        this.ShareStatus?.Validate();
        _ = this.SkillDisplayName;
        _ = this.UserID;
    }

    public BetaAnalyticsSkillActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillActivity(BetaAnalyticsSkillActivity betaAnalyticsSkillActivity)
        : base(betaAnalyticsSkillActivity) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillActivityFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsSkillActivityFromRaw : IFromRawJson<BetaAnalyticsSkillActivity>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillActivity.FromRawUnchecked(rawData);
}

/// <summary>
/// Skill use recorded while members had Chat and Cowork unified (Cowork's features
/// inside claude.ai chat) turned on, split into chat conversations and Cowork sessions.
/// A count is null in date-range mode where it cannot be computed. Omitted from
/// the response on deployments that do not offer Chat and Cowork unified.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics,
        BetaAnalyticsSkillActivityChatCoworkUnifiedMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics : JsonModel
{
    /// <summary>
    /// A skill's use in chat conversations recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required BetaAnalyticsSkillChatCoworkUnifiedChatMetrics Chat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillChatCoworkUnifiedChatMetrics>(
                "chat"
            );
        }
        init { this._rawData.Set("chat", value); }
    }

    /// <summary>
    /// A skill's use in Cowork sessions recorded while members had Chat and Cowork
    /// unified turned on.
    /// </summary>
    public required BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics Sessions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillChatCoworkUnifiedSessionsMetrics>(
                "sessions"
            );
        }
        init { this._rawData.Set("sessions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Chat.Validate();
        this.Sessions.Validate();
    }

    public BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics(
        BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics betaAnalyticsSkillActivityChatCoworkUnifiedMetrics
    )
        : base(betaAnalyticsSkillActivityChatCoworkUnifiedMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillActivityChatCoworkUnifiedMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsSkillActivityChatCoworkUnifiedMetricsFromRaw
    : IFromRawJson<BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillActivityChatCoworkUnifiedMetrics.FromRawUnchecked(rawData);
}

/// <summary>
/// Skill share status (claude.ai only): one of `private`, `organization`, or `public`.
/// Null for skills used only in Claude Code or Office (no per-skill share-status
/// concept) and when share-status reporting is not yet available for the organization.
/// Filterable via `filter[]=share_status:{value}`.
/// </summary>
[JsonConverter(typeof(ShareStatusConverter))]
public enum ShareStatus
{
    Organization,
    Private,
    Public,
}

sealed class ShareStatusConverter : JsonConverter<ShareStatus>
{
    public override ShareStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => ShareStatus.Organization,
            "private" => ShareStatus.Private,
            "public" => ShareStatus.Public,
            _ => (ShareStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShareStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ShareStatus.Organization => "organization",
                ShareStatus.Private => "private",
                ShareStatus.Public => "public",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
