using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Per-plugin install + invocation activity for a given day.
///
/// <para>With `group_by[]=user_id` / `rbac_group_id` / `product` (`cowork` / `claude_code`
/// only on this endpoint) each row is one (plugin, user), (plugin, group), or (plugin,
/// product) cut: the flat `user_id` / `rbac_group_id` / `product` keys carry the
/// cut and the counts are scoped to it.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsPluginActivity, BetaAnalyticsPluginActivityFromRaw>)
)]
public sealed record class BetaAnalyticsPluginActivity : JsonModel
{
    /// <summary>
    /// Claude Code activity metrics for a single plugin on a given day.
    /// </summary>
    public required BetaAnalyticsPluginClaudeCodeMetrics ClaudeCodeMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsPluginClaudeCodeMetrics>(
                "claude_code_metrics"
            );
        }
        init { this._rawData.Set("claude_code_metrics", value); }
    }

    /// <summary>
    /// Cowork activity metrics for a single plugin on a given day.
    /// </summary>
    public required BetaAnalyticsPluginCoworkMetrics CoworkMetrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsPluginCoworkMetrics>(
                "cowork_metrics"
            );
        }
        init { this._rawData.Set("cowork_metrics", value); }
    }

    /// <summary>
    /// Number of distinct users with recorded install or invocation activity for
    /// the plugin on the requested day (install-only users count), or, in date-range
    /// mode, over the requested window — recomputed as an exact distinct count over
    /// the window's per-member daily rows, never a sum of per-day values.
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
    /// Number of distinct users who installed the plugin on the requested day, or,
    /// in date-range mode, over the requested window — recomputed as an exact distinct
    /// count over the window's per-member daily rows, never a sum of per-day values.
    /// </summary>
    public required long? InstallCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("install_count");
        }
        init { this._rawData.Set("install_count", value); }
    }

    /// <summary>
    /// Number of plugin invocations on the requested day
    /// </summary>
    public required long InvocationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("invocation_count");
        }
        init { this._rawData.Set("invocation_count", value); }
    }

    /// <summary>
    /// Name of the plugin
    /// </summary>
    public required string PluginName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_name");
        }
        init { this._rawData.Set("plugin_name", value); }
    }

    /// <summary>
    /// Stable plugin identifier when available (e.g. `serena@claude-plugins-official`).
    /// Null for third-party Claude Code plugins (redacted at the source) and Cowork
    /// slash commands that carry only a hashed id.
    /// </summary>
    public string? PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    /// <summary>
    /// Product that produced this row's activity: one of `chat`, `claude_code`,
    /// `cowork`, or `office_agent` (the canonical Cost &amp; Usage product naming;
    /// an `office_agent` row's per-surface breakdown is in its `office_metrics`).
    /// On `/plugins` only `cowork` and `claude_code` occur (the only surfaces with
    /// plugin attribution); on `/artifacts` only `chat`, `claude_code`, and `cowork`
    /// occur (the surfaces that create artifacts); `/apps/chat/projects` does not
    /// support the product dimension (a `product` entry in `group_by[]` or `filter[]`
    /// there is rejected). Present only when the request grouped by `product`.
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
        this.ClaudeCodeMetrics.Validate();
        this.CoworkMetrics.Validate();
        _ = this.DistinctUserCount;
        _ = this.InstallCount;
        _ = this.InvocationCount;
        _ = this.PluginName;
        _ = this.PluginID;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        _ = this.UserID;
    }

    public BetaAnalyticsPluginActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsPluginActivity(BetaAnalyticsPluginActivity betaAnalyticsPluginActivity)
        : base(betaAnalyticsPluginActivity) { }
#pragma warning restore CS8618

    public BetaAnalyticsPluginActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsPluginActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsPluginActivityFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsPluginActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsPluginActivityFromRaw : IFromRawJson<BetaAnalyticsPluginActivity>
{
    /// <inheritdoc/>
    public BetaAnalyticsPluginActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsPluginActivity.FromRawUnchecked(rawData);
}
