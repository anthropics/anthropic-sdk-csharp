using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaOrganizationRateLimitModelGroup,
        BetaOrganizationRateLimitModelGroupFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitModelGroup : JsonModel
{
    /// <summary>
    /// Opaque identifier of the rate-limit group (for example, `rlg_01VPTCmyiu5ZLsWkcxYG2pY8`).
    /// It is the same in every organization and never changes, unlike the entry's
    /// own identifier, which differs per organization.
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
    /// Human-readable name of the model group (for example, `Claude Sonnet 4.x`).
    /// For display only; it may change.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Always `model_group`: a family of models.
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
        _ = this.DisplayName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("model_group")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimitModelGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("model_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitModelGroup(
        BetaOrganizationRateLimitModelGroup betaOrganizationRateLimitModelGroup
    )
        : base(betaOrganizationRateLimitModelGroup) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitModelGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("model_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitModelGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitModelGroupFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitModelGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationRateLimitModelGroupFromRaw : IFromRawJson<BetaOrganizationRateLimitModelGroup>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitModelGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitModelGroup.FromRawUnchecked(rawData);
}
