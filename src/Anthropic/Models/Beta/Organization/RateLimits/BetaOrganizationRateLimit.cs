using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaOrganizationRateLimit, BetaOrganizationRateLimitFromRaw>)
)]
public sealed record class BetaOrganizationRateLimit : JsonModel
{
    /// <summary>
    /// Stable identifier for this rate-limit group within the organization.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The kind of rate-limit group this entry represents. `model_group` entries
    /// apply to a family of models (listed in `models`); other values apply to an
    /// API-surface category and have `models` set to `null`.
    /// </summary>
    public required ApiEnum<string, BetaOrganizationRateLimitGroupType> GroupType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaOrganizationRateLimitGroupType>
            >("group_type");
        }
        init { this._rawData.Set("group_type", value); }
    }

    /// <summary>
    /// The limiter values that apply to this group.
    /// </summary>
    public required IReadOnlyList<BetaOrganizationRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaOrganizationRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaOrganizationRateLimitValue>>(
                "limits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Model names this entry's limits apply to, including aliases. `null` when `group_type`
    /// is not `"model_group"`.
    /// </summary>
    public required IReadOnlyList<string>? Models
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("models");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "models",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Object type. Always `rate_limit` for organization rate-limit entries.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.GroupType.Validate();
        foreach (var item in this.Limits)
        {
            item.Validate();
        }
        _ = this.Models;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rate_limit")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimit(BetaOrganizationRateLimit betaOrganizationRateLimit)
        : base(betaOrganizationRateLimit) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationRateLimitFromRaw : IFromRawJson<BetaOrganizationRateLimit>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The kind of rate-limit group this entry represents. `model_group` entries apply
/// to a family of models (listed in `models`); other values apply to an API-surface
/// category and have `models` set to `null`.
/// </summary>
[JsonConverter(typeof(BetaOrganizationRateLimitGroupTypeConverter))]
public enum BetaOrganizationRateLimitGroupType
{
    Batch,
    Files,
    ModelGroup,
    Skills,
    TokenCount,
    WebSearch,
}

sealed class BetaOrganizationRateLimitGroupTypeConverter
    : JsonConverter<BetaOrganizationRateLimitGroupType>
{
    public override BetaOrganizationRateLimitGroupType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => BetaOrganizationRateLimitGroupType.Batch,
            "files" => BetaOrganizationRateLimitGroupType.Files,
            "model_group" => BetaOrganizationRateLimitGroupType.ModelGroup,
            "skills" => BetaOrganizationRateLimitGroupType.Skills,
            "token_count" => BetaOrganizationRateLimitGroupType.TokenCount,
            "web_search" => BetaOrganizationRateLimitGroupType.WebSearch,
            _ => (BetaOrganizationRateLimitGroupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOrganizationRateLimitGroupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOrganizationRateLimitGroupType.Batch => "batch",
                BetaOrganizationRateLimitGroupType.Files => "files",
                BetaOrganizationRateLimitGroupType.ModelGroup => "model_group",
                BetaOrganizationRateLimitGroupType.Skills => "skills",
                BetaOrganizationRateLimitGroupType.TokenCount => "token_count",
                BetaOrganizationRateLimitGroupType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
