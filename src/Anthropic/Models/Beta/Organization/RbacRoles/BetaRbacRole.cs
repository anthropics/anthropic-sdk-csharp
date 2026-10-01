using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles;

[JsonConverter(typeof(JsonModelConverter<BetaRbacRole, BetaRbacRoleFromRaw>))]
public sealed record class BetaRbacRole : JsonModel
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
    /// Name of the RBAC Role.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rbac_role")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaRbacRole()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacRole(BetaRbacRole betaRbacRole)
        : base(betaRbacRole) { }
#pragma warning restore CS8618

    public BetaRbacRole(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_role");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacRole(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacRoleFromRaw.FromRawUnchecked"/>
    public static BetaRbacRole FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacRoleFromRaw : IFromRawJson<BetaRbacRole>
{
    /// <inheritdoc/>
    public BetaRbacRole FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaRbacRole.FromRawUnchecked(rawData);
}
