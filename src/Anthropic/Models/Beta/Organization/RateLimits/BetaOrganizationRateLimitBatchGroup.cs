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
        BetaOrganizationRateLimitBatchGroup,
        BetaOrganizationRateLimitBatchGroupFromRaw
    >)
)]
public sealed record class BetaOrganizationRateLimitBatchGroup : JsonModel
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
    /// Always `batch`: the Message Batches API.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("batch")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationRateLimitBatchGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("batch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationRateLimitBatchGroup(
        BetaOrganizationRateLimitBatchGroup betaOrganizationRateLimitBatchGroup
    )
        : base(betaOrganizationRateLimitBatchGroup) { }
#pragma warning restore CS8618

    public BetaOrganizationRateLimitBatchGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("batch");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationRateLimitBatchGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitBatchGroupFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimitBatchGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOrganizationRateLimitBatchGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaOrganizationRateLimitBatchGroupFromRaw : IFromRawJson<BetaOrganizationRateLimitBatchGroup>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimitBatchGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimitBatchGroup.FromRawUnchecked(rawData);
}
