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
        BetaOrganizationRateLimitTokenCountGroup,
        BetaOrganizationRateLimitTokenCountGroupFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitTokenCountGroup : JsonModel
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
    /// Always `token_count`: the Token Count API.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("token_count")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimitTokenCountGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("token_count");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitTokenCountGroup(
        BetaOrganizationRateLimitTokenCountGroup betaOrganizationRateLimitTokenCountGroup
    )
        : base(betaOrganizationRateLimitTokenCountGroup) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitTokenCountGroup(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("token_count");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitTokenCountGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitTokenCountGroupFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitTokenCountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOrganizationRateLimitTokenCountGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaOrganizationRateLimitTokenCountGroupFromRaw
    : IFromRawJson<BetaOrganizationRateLimitTokenCountGroup>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitTokenCountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitTokenCountGroup.FromRawUnchecked(rawData);
}
