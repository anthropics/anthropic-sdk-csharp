using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles.Permissions;

[JsonConverter(
    typeof(JsonModelConverter<
        RbacOrganizationPermissionResource,
        RbacOrganizationPermissionResourceFromRaw
    >)
)]
public sealed record class RbacOrganizationPermissionResource : JsonModel
{
    /// <summary>
    /// UUID of the organization the permission applies to.
    /// </summary>
    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <summary>
    /// Kind of resource the permission applies to.
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
        _ = this.OrganizationID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacOrganizationPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacOrganizationPermissionResource(
        RbacOrganizationPermissionResource rbacOrganizationPermissionResource
    )
        : base(rbacOrganizationPermissionResource) { }
#pragma warning restore CS8618

    public RbacOrganizationPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacOrganizationPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacOrganizationPermissionResourceFromRaw.FromRawUnchecked"/>
    public static RbacOrganizationPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RbacOrganizationPermissionResource(string organizationID)
        : this()
    {
        this.OrganizationID = organizationID;
    }
}

class RbacOrganizationPermissionResourceFromRaw : IFromRawJson<RbacOrganizationPermissionResource>
{
    /// <inheritdoc/>
    public RbacOrganizationPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacOrganizationPermissionResource.FromRawUnchecked(rawData);
}
