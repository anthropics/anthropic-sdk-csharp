using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(typeof(JsonModelConverter<BetaWorkspaceRateLimit, BetaWorkspaceRateLimitFromRaw>))]
public sealed record class BetaWorkspaceRateLimit : JsonModel
{
    /// <summary>
    /// The kind of rate-limit group this entry represents. `model_group` entries
    /// apply to a family of models (listed in `models`); other values apply to an
    /// API-surface category and have `models` set to `null`.
    /// </summary>
    public required ApiEnum<string, BetaWorkspaceRateLimitGroupType> GroupType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWorkspaceRateLimitGroupType>>(
                "group_type"
            );
        }
        init { this._rawData.Set("group_type", value); }
    }

    /// <summary>
    /// The limiter values overridden for this group in this workspace. Limiter types
    /// without a workspace override are omitted and inherit the organization value.
    /// </summary>
    public required IReadOnlyList<BetaWorkspaceRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaWorkspaceRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaWorkspaceRateLimitValue>>(
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
    /// The `id` of the RateLimit group this override applies to.
    /// </summary>
    public required string RateLimitID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rate_limit_id");
        }
        init { this._rawData.Set("rate_limit_id", value); }
    }

    /// <summary>
    /// Object type. Always `workspace_rate_limit` for workspace rate-limit entries.
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

    /// <summary>
    /// ID of the Workspace this override applies to.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.GroupType.Validate();
        foreach (var item in this.Limits)
        {
            item.Validate();
        }
        _ = this.Models;
        _ = this.RateLimitID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workspace_rate_limit")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public BetaWorkspaceRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimit(BetaWorkspaceRateLimit betaWorkspaceRateLimit)
        : base(betaWorkspaceRateLimit) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitFromRaw : IFromRawJson<BetaWorkspaceRateLimit>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The kind of rate-limit group this entry represents. `model_group` entries apply
/// to a family of models (listed in `models`); other values apply to an API-surface
/// category and have `models` set to `null`.
/// </summary>
[JsonConverter(typeof(BetaWorkspaceRateLimitGroupTypeConverter))]
public enum BetaWorkspaceRateLimitGroupType
{
    Batch,
    Files,
    ModelGroup,
    Skills,
    TokenCount,
    WebSearch,
}

sealed class BetaWorkspaceRateLimitGroupTypeConverter
    : JsonConverter<BetaWorkspaceRateLimitGroupType>
{
    public override BetaWorkspaceRateLimitGroupType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => BetaWorkspaceRateLimitGroupType.Batch,
            "files" => BetaWorkspaceRateLimitGroupType.Files,
            "model_group" => BetaWorkspaceRateLimitGroupType.ModelGroup,
            "skills" => BetaWorkspaceRateLimitGroupType.Skills,
            "token_count" => BetaWorkspaceRateLimitGroupType.TokenCount,
            "web_search" => BetaWorkspaceRateLimitGroupType.WebSearch,
            _ => (BetaWorkspaceRateLimitGroupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkspaceRateLimitGroupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkspaceRateLimitGroupType.Batch => "batch",
                BetaWorkspaceRateLimitGroupType.Files => "files",
                BetaWorkspaceRateLimitGroupType.ModelGroup => "model_group",
                BetaWorkspaceRateLimitGroupType.Skills => "skills",
                BetaWorkspaceRateLimitGroupType.TokenCount => "token_count",
                BetaWorkspaceRateLimitGroupType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
