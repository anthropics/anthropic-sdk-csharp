using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsUsageBucketedResult,
        BetaAnalyticsUsageBucketedResultFromRaw
    >)
)]
public sealed record class BetaAnalyticsUsageBucketedResult : JsonModel
{
    /// <summary>
    /// The number of input tokens for cache creation.
    /// </summary>
    public required Messages::BetaCacheCreation CacheCreation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Messages::BetaCacheCreation>("cache_creation");
        }
        init { this._rawData.Set("cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// Claude Tag (Claude in Slack) spend category: `engaged` (a person addressed
    /// Claude in a channel or thread), `proactive` (Claude responded without being
    /// addressed), `scheduled` (a scheduled routine ran), `monitoring` (Claude watching
    /// a channel it was asked to monitor), or `dm` (direct messages with Claude).
    /// Populated only when `claude_tag_category` is in `group_by[]`; null for usage
    /// that is not Claude Tag. Direct-message usage is billed to the individual
    /// user and is reported under that user's product, not under `claude-tag`. New
    /// categories may be added over time.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsClaudeTagCategory>? ClaudeTagCategory
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsClaudeTagCategory>>(
                "claude_tag_category"
            );
        }
        init { this._rawData.Set("claude_tag_category", value); }
    }

    /// <summary>
    /// Slack user ID (for example `U0123ABCDEF`) of the member the Claude Tag (Claude
    /// in Slack) usage is attributed to, not a claude.ai user ID. Populated only
    /// when `claude_tag_user_id` is in `group_by[]`; null for usage that is not Claude
    /// Tag and for Claude Tag usage that is not attributed to a single user (for
    /// example `monitoring`, and `proactive` usage Claude initiated), so per-user
    /// rows can sum to less than the Claude Tag total. Cannot be combined with `group_by[]=rbac_group_id`
    /// or the `rbac_group_ids[]` filter.
    /// </summary>
    public required string? ClaudeTagUserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("claude_tag_user_id");
        }
        init { this._rawData.Set("claude_tag_user_id", value); }
    }

    /// <summary>
    /// Context-window pricing tier of the usage or cost. Null unless `context_window`
    /// is in `group_by[]`; it can also be null on grouped rows with no context-window
    /// tier, such as code execution.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsContextWindow>? ContextWindow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsContextWindow>>(
                "context_window"
            );
        }
        init { this._rawData.Set("context_window", value); }
    }

    /// <summary>
    /// Inference region of the usage or cost. Null unless `inference_geo` is in
    /// `group_by[]`; it can also be null on grouped rows where the region is not
    /// set (the rows that `inference_geos[]=not_available` matches).
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsUsageBucketedResultInferenceGeo>? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageBucketedResultInferenceGeo>
            >("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// Model that produced the usage or cost, as a model name in the form the `models[]`
    /// filter accepts (for example, `claude-opus-5`). Null unless `model` is in
    /// `group_by[]`; it can also be null on grouped rows whose usage or cost is
    /// not attributed to a specific model, such as code execution.
    /// </summary>
    public required string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The number of output tokens generated.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// Product surface that produced the usage or cost. Null unless product is in
    /// `group_by[]`; it can also be null on grouped rows whose usage cannot be attributed
    /// to a known surface. Values include `chat`, `claude_code`, `cowork`, `office_agent`,
    /// `claude_in_chrome`, `claude_design`, and `claude-tag`. `claude-tag` is Claude
    /// Tag, the Claude product in Slack. Some unattributed usage is reported as "other".
    /// </summary>
    public required string? Product
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product");
        }
        init { this._rawData.Set("product", value); }
    }

    /// <summary>
    /// RBAC group (team) the usage is attributed to, in the public tagged `rbac_group_...`
    /// spelling — the same spelling the activity resources use for this key, so
    /// the same team has one id across resources and it round-trips as an `rbac_group_ids[]`
    /// filter value. Populated only when `rbac_group_id` is in `group_by[]`. Any-membership
    /// semantics: a user in several groups contributes their full usage to each
    /// of those groups' rows, so the named-group rows overlap and their sum can exceed
    /// the org total. A null value is the single unassigned row: users in no group
    /// on that (UTC) day. For the true org total, run the same query without `group_by[]`.
    /// </summary>
    public required string? RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// Number of API requests in this row's scope. For sandbox / code-execution
    /// events, this counts execution spans rather than HTTP requests (these rows
    /// surface with `product: null`).
    /// </summary>
    public required long? Requests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests");
        }
        init { this._rawData.Set("requests", value); }
    }

    /// <summary>
    /// Server-side tool usage metrics.
    /// </summary>
    public required BetaAnalyticsServerToolUse ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsServerToolUse>("server_tool_use");
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <summary>
    /// Slack channel the usage originated from. Populated only when `slack_channel_id`
    /// is in `group_by[]`; null for usage outside Slack (and for rows recorded before
    /// channel attribution was enabled).
    /// </summary>
    public required string? SlackChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slack_channel_id");
        }
        init { this._rawData.Set("slack_channel_id", value); }
    }

    /// <summary>
    /// Inference speed mode of the usage or cost: `fast` or `standard`. Null unless
    /// `speed` is in `group_by[]`.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsUsageBucketedResultSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageBucketedResultSpeed>
            >("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <summary>
    /// The number of uncached input tokens processed.
    /// </summary>
    public required long UncachedInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("uncached_input_tokens");
        }
        init { this._rawData.Set("uncached_input_tokens", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation.Validate();
        _ = this.CacheReadInputTokens;
        this.ClaudeTagCategory?.Validate();
        _ = this.ClaudeTagUserID;
        this.ContextWindow?.Validate();
        this.InferenceGeo?.Validate();
        _ = this.Model;
        _ = this.OutputTokens;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.Requests;
        this.ServerToolUse.Validate();
        _ = this.SlackChannelID;
        this.Speed?.Validate();
        _ = this.UncachedInputTokens;
    }

    public BetaAnalyticsUsageBucketedResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageBucketedResult(
        BetaAnalyticsUsageBucketedResult betaAnalyticsUsageBucketedResult
    )
        : base(betaAnalyticsUsageBucketedResult) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageBucketedResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageBucketedResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageBucketedResultFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageBucketedResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageBucketedResultFromRaw : IFromRawJson<BetaAnalyticsUsageBucketedResult>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageBucketedResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageBucketedResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Inference region of the usage or cost. Null unless `inference_geo` is in `group_by[]`;
/// it can also be null on grouped rows where the region is not set (the rows that
/// `inference_geos[]=not_available` matches).
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUsageBucketedResultInferenceGeoConverter))]
public enum BetaAnalyticsUsageBucketedResultInferenceGeo
{
    Global,
    Us,
}

sealed class BetaAnalyticsUsageBucketedResultInferenceGeoConverter
    : JsonConverter<BetaAnalyticsUsageBucketedResultInferenceGeo>
{
    public override BetaAnalyticsUsageBucketedResultInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAnalyticsUsageBucketedResultInferenceGeo.Global,
            "us" => BetaAnalyticsUsageBucketedResultInferenceGeo.Us,
            _ => (BetaAnalyticsUsageBucketedResultInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageBucketedResultInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageBucketedResultInferenceGeo.Global => "global",
                BetaAnalyticsUsageBucketedResultInferenceGeo.Us => "us",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Inference speed mode of the usage or cost: `fast` or `standard`. Null unless `speed`
/// is in `group_by[]`.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUsageBucketedResultSpeedConverter))]
public enum BetaAnalyticsUsageBucketedResultSpeed
{
    Fast,
    Standard,
}

sealed class BetaAnalyticsUsageBucketedResultSpeedConverter
    : JsonConverter<BetaAnalyticsUsageBucketedResultSpeed>
{
    public override BetaAnalyticsUsageBucketedResultSpeed Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => BetaAnalyticsUsageBucketedResultSpeed.Fast,
            "standard" => BetaAnalyticsUsageBucketedResultSpeed.Standard,
            _ => (BetaAnalyticsUsageBucketedResultSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageBucketedResultSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageBucketedResultSpeed.Fast => "fast",
                BetaAnalyticsUsageBucketedResultSpeed.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
