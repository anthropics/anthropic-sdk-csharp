using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        OrganizationRateLimitTokenCountGroup,
        OrganizationRateLimitTokenCountGroupFromRaw
    >)
)]
public sealed record class OrganizationRateLimitTokenCountGroup : JsonModel
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

    public OrganizationRateLimitTokenCountGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("token_count");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRateLimitTokenCountGroup(
        OrganizationRateLimitTokenCountGroup organizationRateLimitTokenCountGroup
    )
        : base(organizationRateLimitTokenCountGroup) { }
#pragma warning restore CS8618

    public OrganizationRateLimitTokenCountGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("token_count");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRateLimitTokenCountGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRateLimitTokenCountGroupFromRaw.FromRawUnchecked"/>
    public static OrganizationRateLimitTokenCountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OrganizationRateLimitTokenCountGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class OrganizationRateLimitTokenCountGroupFromRaw
    : IFromRawJson<OrganizationRateLimitTokenCountGroup>
{
    /// <inheritdoc/>
    public OrganizationRateLimitTokenCountGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRateLimitTokenCountGroup.FromRawUnchecked(rawData);
}
