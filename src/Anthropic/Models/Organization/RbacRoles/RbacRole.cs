using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles;

[JsonConverter(typeof(JsonModelConverter<RbacRole, RbacRoleFromRaw>))]
public sealed record class RbacRole : JsonModel
{
    /// <summary>
    /// ID of the RBAC Role.
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
    /// RFC 3339 datetime string indicating when the RBAC Role was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Name of the RBAC Role. For a role created by Anthropic, this is Anthropic's
    /// name for the access that the role grants. Anthropic may change this name,
    /// so to keep a lasting reference to a role, store its `id`.
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
    /// Object type.
    ///
    /// <para>For RBAC Roles, this is always `"rbac_role"`.</para>
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
    /// RFC 3339 datetime string indicating when the RBAC Role was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rbac_role")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public RbacRole()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRole(RbacRole rbacRole)
        : base(rbacRole) { }
#pragma warning restore CS8618

    public RbacRole(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRole(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRoleFromRaw.FromRawUnchecked"/>
    public static RbacRole FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRoleFromRaw : IFromRawJson<RbacRole>
{
    /// <inheritdoc/>
    public RbacRole FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RbacRole.FromRawUnchecked(rawData);
}
