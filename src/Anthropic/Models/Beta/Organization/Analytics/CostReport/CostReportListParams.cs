using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics.CostReport;

/// <summary>
/// Get cost in USD over time across a date range.
///
/// <para>Returns cost bucketed by minute, hour, or day, optionally broken down by
/// product, model, context window, inference region, speed, cost type, or token type.
/// Available to organizations on a Claude Enterprise plan. Requires an API key with
/// the `read:analytics` scope.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CostReportListParams : ParamsBase
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
    /// Time bucket granularity.
    /// </summary>
    public ApiEnum<string, BucketWidth>? BucketWidth
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, BucketWidth>>(
                "bucket_width"
            );
        }
        init
        {
            if (value == null)
            {
                this._rawQueryData.Remove("bucket_width");
                return;
            }

            this._rawQueryData.Set("bucket_width", value);
        }
    }

    /// <summary>
    /// Filter to Claude Tag (Claude in Slack) usage in specific spend categories.
    /// Usage with no category never matches. `dm` usage is reported under the user's
    /// product rather than `claude-tag`, so combining this filter with `products[]=claude-tag`
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
    /// End of range, exclusive. When omitted, defaults to the earlier of now and
    /// `starting_at` + 31 days. The range may span at most 31 days.
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
    /// Dimensions to break each time bucket out by. Defaults to no grouping (one
    /// total per bucket). Each bucket reports at most its top 100 groups; a group
    /// beyond that cap has no row in that bucket (there is no remainder row), so
    /// grouped buckets are not exhaustive when a dimension has more than 100 distinct values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, GroupBy>>? GroupBy
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, GroupBy>>>(
                "group_by"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, GroupBy>>?>(
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
    /// Maximum number of time buckets per page. Defaults and caps vary by `bucket_width`
    /// (`1d`: default 7, max 31; `1h`: default 24, max 168; `1m`: default 60, max 256).
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init { this._rawQueryData.Set("limit", value); }
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
    /// Product surfaces to include. Defaults to all products. Use `group_by[]=product`
    /// to break out per-product values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, BetaAnalyticsProductFilter>>? Products
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaAnalyticsProductFilter>>
            >("products");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, BetaAnalyticsProductFilter>>?>(
                "products",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    public IReadOnlyList<ApiEnum<string, Speed>>? Speeds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<ApiEnum<string, Speed>>>(
                "speeds"
            );
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, Speed>>?>(
                "speeds",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to specific users by tagged user ID.
    /// </summary>
    public IReadOnlyList<string>? UserIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("user_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "user_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CostReportListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostReportListParams(CostReportListParams costReportListParams)
        : base(costReportListParams) { }
#pragma warning restore CS8618

    public CostReportListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostReportListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CostReportListParams FromRawUnchecked(
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

    public virtual bool Equals(CostReportListParams? other)
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
        var queryString = this.QueryString(options);
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/organizations/analytics/cost_report"
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
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

/// <summary>
/// Time bucket granularity.
/// </summary>
[JsonConverter(typeof(BucketWidthConverter))]
public enum BucketWidth
{
    Day,
    Hour,
    Minute,
}

sealed class BucketWidthConverter : JsonConverter<BucketWidth>
{
    public override BucketWidth Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1d" => BucketWidth.Day,
            "1h" => BucketWidth.Hour,
            "1m" => BucketWidth.Minute,
            _ => (BucketWidth)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BucketWidth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BucketWidth.Day => "1d",
                BucketWidth.Hour => "1h",
                BucketWidth.Minute => "1m",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GroupByConverter))]
public enum GroupBy
{
    ClaudeTagCategory,
    ClaudeTagUserID,
    ContextWindow,
    CostType,
    InferenceGeo,
    Model,
    Product,
    RbacGroupID,
    SlackChannelID,
    Speed,
    TokenType,
}

sealed class GroupByConverter : JsonConverter<GroupBy>
{
    public override GroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "claude_tag_category" => GroupBy.ClaudeTagCategory,
            "claude_tag_user_id" => GroupBy.ClaudeTagUserID,
            "context_window" => GroupBy.ContextWindow,
            "cost_type" => GroupBy.CostType,
            "inference_geo" => GroupBy.InferenceGeo,
            "model" => GroupBy.Model,
            "product" => GroupBy.Product,
            "rbac_group_id" => GroupBy.RbacGroupID,
            "slack_channel_id" => GroupBy.SlackChannelID,
            "speed" => GroupBy.Speed,
            "token_type" => GroupBy.TokenType,
            _ => (GroupBy)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, GroupBy value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GroupBy.ClaudeTagCategory => "claude_tag_category",
                GroupBy.ClaudeTagUserID => "claude_tag_user_id",
                GroupBy.ContextWindow => "context_window",
                GroupBy.CostType => "cost_type",
                GroupBy.InferenceGeo => "inference_geo",
                GroupBy.Model => "model",
                GroupBy.Product => "product",
                GroupBy.RbacGroupID => "rbac_group_id",
                GroupBy.SlackChannelID => "slack_channel_id",
                GroupBy.Speed => "speed",
                GroupBy.TokenType => "token_type",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(SpeedConverter))]
public enum Speed
{
    Fast,
    Standard,
}

sealed class SpeedConverter : JsonConverter<Speed>
{
    public override Speed Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => Speed.Fast,
            "standard" => Speed.Standard,
            _ => (Speed)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Speed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Speed.Fast => "fast",
                Speed.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
