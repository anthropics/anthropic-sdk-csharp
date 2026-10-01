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
        OrganizationRateLimitSkillsGroup,
        OrganizationRateLimitSkillsGroupFromRaw
    >)
)]
public sealed record class OrganizationRateLimitSkillsGroup : JsonModel
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
    /// Always `skills`: the Skills API.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("skills")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationRateLimitSkillsGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("skills");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRateLimitSkillsGroup(
        OrganizationRateLimitSkillsGroup organizationRateLimitSkillsGroup
    )
        : base(organizationRateLimitSkillsGroup) { }
#pragma warning restore CS8618

    public OrganizationRateLimitSkillsGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skills");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRateLimitSkillsGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRateLimitSkillsGroupFromRaw.FromRawUnchecked"/>
    public static OrganizationRateLimitSkillsGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OrganizationRateLimitSkillsGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class OrganizationRateLimitSkillsGroupFromRaw : IFromRawJson<OrganizationRateLimitSkillsGroup>
{
    /// <inheritdoc/>
    public OrganizationRateLimitSkillsGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRateLimitSkillsGroup.FromRawUnchecked(rawData);
}
