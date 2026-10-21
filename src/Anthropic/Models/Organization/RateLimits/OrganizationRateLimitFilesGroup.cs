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
        OrganizationRateLimitFilesGroup,
        OrganizationRateLimitFilesGroupFromRaw
    >)
)]
public sealed record class OrganizationRateLimitFilesGroup : JsonModel
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
    /// Always `files`: the Files API.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("files")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationRateLimitFilesGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("files");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRateLimitFilesGroup(
        OrganizationRateLimitFilesGroup organizationRateLimitFilesGroup
    )
        : base(organizationRateLimitFilesGroup) { }
#pragma warning restore CS8618

    public OrganizationRateLimitFilesGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("files");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRateLimitFilesGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRateLimitFilesGroupFromRaw.FromRawUnchecked"/>
    public static OrganizationRateLimitFilesGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OrganizationRateLimitFilesGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class OrganizationRateLimitFilesGroupFromRaw : IFromRawJson<OrganizationRateLimitFilesGroup>
{
    /// <inheritdoc/>
    public OrganizationRateLimitFilesGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRateLimitFilesGroup.FromRawUnchecked(rawData);
}
