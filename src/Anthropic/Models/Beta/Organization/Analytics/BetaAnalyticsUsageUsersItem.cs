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
    typeof(JsonModelConverter<BetaAnalyticsUsageUsersItem, BetaAnalyticsUsageUsersItemFromRaw>)
)]
public sealed record class BetaAnalyticsUsageUsersItem : JsonModel
{
    /// <summary>
    /// The user this row's usage or cost is attributed to. Always a `user_actor`.
    /// </summary>
    public required BetaAnalyticsUsageUsersItemActor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUsageUsersItemActor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

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
    /// that is not Claude Tag. New categories may be added over time.
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
    public required ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageUsersItemInferenceGeo>
            >("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// Model that produced the usage or cost, as a model name in the form the `models[]`
    /// filter accepts (for example, `claude-opus-5-5`). Null unless `model` is in
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
    /// `claude_in_chrome`, `claude_design`, `claude-tag`, and `chat_cowork_unified`.
    /// `claude-tag` is Claude Tag, the Claude product in Slack. `chat_cowork_unified`
    /// is Chat and Cowork unified, Cowork's features inside claude.ai chat: chat
    /// and Cowork usage by a member who has it turned on is reported under this
    /// value instead of `chat` or `cowork`. It is accepted as a filter only where
    /// Chat and Cowork unified is available. Some unattributed usage is reported
    /// as "other".
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
    /// is in `group_by[]`; null for usage outside Slack, for some Claude Tag usage
    /// that has no channel recorded, and for usage recorded before channel attribution
    /// was enabled.
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
    public required ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaAnalyticsUsageUsersItemSpeed>
            >("speed");
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
    /// Total token count across all token types. This is the value the default `order_by`
    /// (`total_tokens`) sorts on.
    /// </summary>
    public required long TotalTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tokens");
        }
        init { this._rawData.Set("total_tokens", value); }
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
        this.Actor.Validate();
        this.CacheCreation.Validate();
        _ = this.CacheReadInputTokens;
        this.ClaudeTagCategory?.Validate();
        _ = this.ClaudeTagUserID;
        this.ContextWindow?.Validate();
        _ = this.EndingAt;
        this.InferenceGeo?.Validate();
        _ = this.Model;
        _ = this.OutputTokens;
        _ = this.Product;
        _ = this.RbacGroupID;
        _ = this.Requests;
        this.ServerToolUse.Validate();
        _ = this.SlackChannelID;
        this.Speed?.Validate();
        _ = this.StartingAt;
        _ = this.TotalTokens;
        _ = this.UncachedInputTokens;
    }

    public BetaAnalyticsUsageUsersItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageUsersItem(BetaAnalyticsUsageUsersItem betaAnalyticsUsageUsersItem)
        : base(betaAnalyticsUsageUsersItem) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageUsersItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageUsersItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageUsersItemFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageUsersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageUsersItemFromRaw : IFromRawJson<BetaAnalyticsUsageUsersItem>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageUsersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageUsersItem.FromRawUnchecked(rawData);
}

/// <summary>
/// The user this row's usage or cost is attributed to. Always a `user_actor`.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUsageUsersItemActorConverter))]
public record class BetaAnalyticsUsageUsersItemActor : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, BetaAnalyticsUsageUsersItemActorType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaAnalyticsUserActor _ => BetaAnalyticsUsageUsersItemActorType.UserActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaAnalyticsUsageUsersItemActorType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaAnalyticsUsageUsersItemActor(
        BetaAnalyticsUserActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsUsageUsersItemActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaAnalyticsUser(out var value)) {
    ///     // `value` is of type `BetaAnalyticsUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaAnalyticsUser([NotNullWhen(true)] out BetaAnalyticsUserActor? value)
    {
        value = this.Value as BetaAnalyticsUserActor;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaAnalyticsUserActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<BetaAnalyticsUserActor> betaAnalyticsUser)
    {
        switch (this.Value)
        {
            case BetaAnalyticsUserActor value:
                betaAnalyticsUser(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaAnalyticsUsageUsersItemActor"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaAnalyticsUserActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<BetaAnalyticsUserActor, T> betaAnalyticsUser)
    {
        return this.Value switch
        {
            BetaAnalyticsUserActor value => betaAnalyticsUser(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaAnalyticsUsageUsersItemActor"
            ),
        };
    }

    public static implicit operator BetaAnalyticsUsageUsersItemActor(
        BetaAnalyticsUserActor value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaAnalyticsUsageUsersItemActor"
            );
        }
        this.Switch((betaAnalyticsUser) => betaAnalyticsUser.Validate());
    }

    public virtual bool Equals(BetaAnalyticsUsageUsersItemActor? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaAnalyticsUserActor _ => 0,
            _ => -1,
        };
    }
}

sealed class BetaAnalyticsUsageUsersItemActorConverter
    : JsonConverter<BetaAnalyticsUsageUsersItemActor>
{
    public override BetaAnalyticsUsageUsersItemActor? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAnalyticsUserActor>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaAnalyticsUsageUsersItemActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageUsersItemActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaAnalyticsUsageUsersItemActorTypeConverter))]
public enum BetaAnalyticsUsageUsersItemActorType
{
    UserActor,
}

sealed class BetaAnalyticsUsageUsersItemActorTypeConverter
    : JsonConverter<BetaAnalyticsUsageUsersItemActorType>
{
    public override BetaAnalyticsUsageUsersItemActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => BetaAnalyticsUsageUsersItemActorType.UserActor,
            _ => (BetaAnalyticsUsageUsersItemActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageUsersItemActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageUsersItemActorType.UserActor => "user_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Inference region of the usage or cost. Null unless `inference_geo` is in `group_by[]`;
/// it can also be null on grouped rows where the region is not set (the rows that
/// `inference_geos[]=not_available` matches).
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUsageUsersItemInferenceGeoConverter))]
public enum BetaAnalyticsUsageUsersItemInferenceGeo
{
    Global,
    Us,
}

sealed class BetaAnalyticsUsageUsersItemInferenceGeoConverter
    : JsonConverter<BetaAnalyticsUsageUsersItemInferenceGeo>
{
    public override BetaAnalyticsUsageUsersItemInferenceGeo Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "global" => BetaAnalyticsUsageUsersItemInferenceGeo.Global,
            "us" => BetaAnalyticsUsageUsersItemInferenceGeo.Us,
            _ => (BetaAnalyticsUsageUsersItemInferenceGeo)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageUsersItemInferenceGeo value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageUsersItemInferenceGeo.Global => "global",
                BetaAnalyticsUsageUsersItemInferenceGeo.Us => "us",
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
[JsonConverter(typeof(BetaAnalyticsUsageUsersItemSpeedConverter))]
public enum BetaAnalyticsUsageUsersItemSpeed
{
    Fast,
    Standard,
}

sealed class BetaAnalyticsUsageUsersItemSpeedConverter
    : JsonConverter<BetaAnalyticsUsageUsersItemSpeed>
{
    public override BetaAnalyticsUsageUsersItemSpeed Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fast" => BetaAnalyticsUsageUsersItemSpeed.Fast,
            "standard" => BetaAnalyticsUsageUsersItemSpeed.Standard,
            _ => (BetaAnalyticsUsageUsersItemSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUsageUsersItemSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUsageUsersItemSpeed.Fast => "fast",
                BetaAnalyticsUsageUsersItemSpeed.Standard => "standard",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
