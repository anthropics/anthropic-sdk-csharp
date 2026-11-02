using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Per-project activity data for a given day.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsProjectActivity, AnalyticsProjectActivityFromRaw>)
)]
public sealed record class AnalyticsProjectActivity : JsonModel
{
    /// <summary>
    /// Project creation timestamp in RFC 3339 format. Null if the project was deleted
    /// before attribution was recorded.
    /// </summary>
    public required DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// User who created the project. Null if the project was deleted before attribution
    /// was recorded, or if the creator's account no longer exists.
    /// </summary>
    public required AnalyticsUser? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AnalyticsUser>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// Number of distinct conversations in the project. Null on aggregated rows where
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
    /// Number of distinct users who used the project on the requested day, or, in
    /// date-range mode, over the requested window — recomputed as an exact distinct
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
    /// Number of messages sent in the project on the requested day
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
    /// Tagged project identifier (e.g. `claude_proj_...`)
    /// </summary>
    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// Name of the project
    /// </summary>
    public required string ProjectName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_name");
        }
        init { this._rawData.Set("project_name", value); }
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
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        _ = this.DistinctConversationCount;
        _ = this.DistinctUserCount;
        _ = this.MessageCount;
        _ = this.ProjectID;
        _ = this.ProjectName;
        _ = this.RbacGroupID;
        _ = this.RbacGroupName;
        _ = this.UserID;
    }

    public AnalyticsProjectActivity() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsProjectActivity(AnalyticsProjectActivity analyticsProjectActivity)
        : base(analyticsProjectActivity) { }
#pragma warning restore CS8618

    public AnalyticsProjectActivity(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsProjectActivity(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsProjectActivityFromRaw.FromRawUnchecked"/>
    public static AnalyticsProjectActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsProjectActivityFromRaw : IFromRawJson<AnalyticsProjectActivity>
{
    /// <inheritdoc/>
    public AnalyticsProjectActivity FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsProjectActivity.FromRawUnchecked(rawData);
}
