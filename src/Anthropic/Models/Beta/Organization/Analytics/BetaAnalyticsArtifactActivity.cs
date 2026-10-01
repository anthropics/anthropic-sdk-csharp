using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Artifact-creation activity for one (`artifact_type`, `is_shared`) bucket on a
/// given day.
///
/// <para>Artifacts form a small finite cube — the canonical MIME type (8 values incl.
/// `other`) crossed with shared-vs-private — so the response is the full set of non-empty
/// buckets, not a ranked/paginated list. Claude Code and Cowork artifacts report
/// under `text/html` and are counted from 2026-08-17 onward; earlier days contain
/// claude.ai chat artifacts only. With `group_by[]=product` / `user_id` / `rbac_group_id`
/// each row is further split by the flat group keys and counts are scoped to that cut.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsArtifactActivity, BetaAnalyticsArtifactActivityFromRaw>)
)]
public sealed record class BetaAnalyticsArtifactActivity : JsonModel
{
    /// <summary>
    /// Canonical artifact MIME type (e.g. `text/markdown`, `application/vnd.ant.react`,
    /// `image/svg+xml`), or `other`. Claude Code and Cowork artifacts report as `text/html`.
    /// </summary>
    public required string ArtifactType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("artifact_type");
        }
        init { this._rawData.Set("artifact_type", value); }
    }

    /// <summary>
    /// Number of artifacts created in this bucket on the requested day
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
    /// Number of distinct users who created artifacts in this bucket on the requested day
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
    /// Whether the artifacts in this bucket have ever been shared (a Claude Code
    /// / Cowork artifact is shared once anyone beyond its creator may open it: named
    /// members, the whole organization, or anyone with the link).
    /// </summary>
    public required bool IsShared
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_shared");
        }
        init { this._rawData.Set("is_shared", value); }
    }

    /// <summary>
    /// Number of those artifacts that have been published (for Claude Code / Cowork
    /// artifacts: open to anyone with the link); never exceeds `artifacts_created_count`
    /// </summary>
    public required long PublishedArtifactsCreatedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("published_artifacts_created_count");
        }
        init { this._rawData.Set("published_artifacts_created_count", value); }
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
        _ = this.ArtifactType;
        _ = this.ArtifactsCreatedCount;
        _ = this.DistinctUserCount;
        _ = this.IsShared;
        _ = this.PublishedArtifactsCreatedCount;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        _ = this.UserID;
    }

    public BetaAnalyticsArtifactActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsArtifactActivity(
        BetaAnalyticsArtifactActivity betaAnalyticsArtifactActivity
    )
        : base(betaAnalyticsArtifactActivity) { }
#pragma warning restore CS8618

    public BetaAnalyticsArtifactActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsArtifactActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsArtifactActivityFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsArtifactActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsArtifactActivityFromRaw : IFromRawJson<BetaAnalyticsArtifactActivity>
{
    /// <inheritdoc/>
    public BetaAnalyticsArtifactActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsArtifactActivity.FromRawUnchecked(rawData);
}
