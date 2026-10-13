using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsCostUsersItem, BetaAnalyticsCostUsersItemFromRaw>)
)]
public sealed record class BetaAnalyticsCostUsersItem : JsonModel
{
    /// <summary>
    /// The user this row's usage or cost is attributed to. Always a `user_actor`.
    /// </summary>
    public required BetaAnalyticsUserActor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUserActor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    /// <summary>
    /// Amount (post-discount, pre-credit) in fractional cents (minor units).
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
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
    /// Cost component breakdown; null when returning the combined total.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsCostType>? CostType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsCostType>>(
                "cost_type"
            );
        }
        init { this._rawData.Set("cost_type", value); }
    }

    /// <summary>
    /// Currency code for the cost amount. Currently always `"USD"`.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// End of the row's UTC time bucket (exclusive), as an RFC 3339 timestamp; equal
    /// to `starting_at` plus one `bucket_width`. Null unless `bucket_width` is set.
    /// </summary>
    public required DateTimeOffset? EndingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("ending_at");
        }
        init { this._rawData.Set("ending_at", value); }
    }

    /// <summary>
    /// Inference region of the usage or cost. Null unless `inference_geo` is in
    /// `group_by[]`; it can also be null on grouped rows where the region is not
    /// set (the rows that `inference_geos[]=not_available` matches).
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsCostUsersItemInferenceGeo>
            >("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// List-price amount (pre-discount) in fractional cents.
    /// </summary>
    public required string ListAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("list_amount");
        }
        init { this._rawData.Set("list_amount", value); }
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
    /// Product surface that produced the usage or cost. Null unless product is in
    /// `group_by[]`; it can also be null on grouped rows whose usage cannot be attributed
    /// to a known surface. Values include `chat`, `claude_code`, `cowork`, `office_agent`,
    /// `claude_in_chrome`, `claude_design`, `claude-tag`, and `chat_cowork_unified`.
    /// `claude-tag` is Claude Tag, the Claude product in Slack. `chat_cowork_unified`
    /// is Chat and Cowork unified, Cowork's features inside claude.ai chat: chat
    /// and Cowork usage by a member who has it turned on is reported under this
    /// value instead of `chat` or `cowork`. It is accepted as a filter only on deployments
    /// that offer Chat and Cowork unified. Some unattributed usage is reported as "other".
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
    /// Number of API requests in this row's scope. Null when `group_by` includes
    /// `cost_type` or `token_type` (the count has no per-component attribution; read
    /// it from the ungrouped response). For sandbox / code-execution events, this
    /// counts execution spans rather than HTTP requests (these rows surface with
    /// `product: null`).
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
    public required ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsCostUsersItemSpeed>>(
                "speed"
            );
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <summary>
    /// Start of the row's UTC time bucket (inclusive), as an RFC 3339 timestamp.
    /// Null unless `bucket_width` is set; without `bucket_width`, each row aggregates
    /// the full requested range.
    /// </summary>
    public required DateTimeOffset? StartingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("starting_at");
        }
        init { this._rawData.Set("starting_at", value); }
    }

    /// <summary>
    /// Token type when `cost_type` is `tokens`; null otherwise.
    /// </summary>
    public required ApiEnum<string, BetaAnalyticsTokenType>? TokenType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaAnalyticsTokenType>>(
                "token_type"
            );
        }
        init { this._rawData.Set("token_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Actor.Validate();
        _ = this.Amount;
        this.ClaudeTagCategory?.Validate();
        _ = this.ClaudeTagUserID;
        this.ContextWindow?.Validate();
        this.CostType?.Validate();
        _ = this.Currency;
        _ = this.EndingAt;
        this.InferenceGeo?.Validate();
        _ = this.ListAmount;
        _ = this.Model;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.Requests;
        _ = this.SlackChannelID;
        this.Speed?.Validate();
        _ = this.StartingAt;
        this.TokenType?.Validate();
    }

    public BetaAnalyticsCostUsersItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCostUsersItem(BetaAnalyticsCostUsersItem betaAnalyticsCostUsersItem)
        : base(betaAnalyticsCostUsersItem) { }
#pragma warning restore CS8618

    public BetaAnalyticsCostUsersItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCostUsersItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCostUsersItemFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCostUsersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCostUsersItemFromRaw : IFromRawJson<BetaAnalyticsCostUsersItem>
{
    /// <inheritdoc/>
    public BetaAnalyticsCostUsersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCostUsersItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Inference region of the usage or cost. Null unless `inference_geo` is in `group_by[]`;
/// it can also be null on grouped rows where the region is not set (the rows that
/// `inference_geos[]=not_available` matches).
/// </summary>
[JsonConverter(typeof(BetaAnalyticsCostUsersItemInferenceGeoConverter))]
public enum BetaAnalyticsCostUsersItemInferenceGeo
{
    Global,
    Us,
}

sealed class BetaAnalyticsCostUsersItemInferenceGeoConverter
    : JsonConverter<BetaAnalyticsCostUsersItemInferenceGeo>
{
    public override BetaAnalyticsCostUsersItemInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAnalyticsCostUsersItemInferenceGeo.Global,
            "us" => BetaAnalyticsCostUsersItemInferenceGeo.Us,
            _ => (BetaAnalyticsCostUsersItemInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsCostUsersItemInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsCostUsersItemInferenceGeo.Global => "global",
                BetaAnalyticsCostUsersItemInferenceGeo.Us => "us",
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
[JsonConverter(typeof(BetaAnalyticsCostUsersItemSpeedConverter))]
public enum BetaAnalyticsCostUsersItemSpeed
{
    Fast,
    Standard,
}

sealed class BetaAnalyticsCostUsersItemSpeedConverter
    : JsonConverter<BetaAnalyticsCostUsersItemSpeed>
{
    public override BetaAnalyticsCostUsersItemSpeed Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => BetaAnalyticsCostUsersItemSpeed.Fast,
            "standard" => BetaAnalyticsCostUsersItemSpeed.Standard,
            _ => (BetaAnalyticsCostUsersItemSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsCostUsersItemSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsCostUsersItemSpeed.Fast => "fast",
                BetaAnalyticsCostUsersItemSpeed.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
