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
        RbacConnectorScopePermissionResource,
        RbacConnectorScopePermissionResourceFromRaw
    >)
)]
public sealed record class RbacConnectorScopePermissionResource : JsonModel
{
    /// <summary>
    /// ID of the connector the permission applies to.
    /// </summary>
    public required string ConnectorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("connector_id");
        }
        init { this._rawData.Set("connector_id", value); }
    }

    /// <summary>
    /// OAuth scope the permission names — the role may receive this scope when tokens
    /// are minted for the connector.
    ///
    /// <para>Subject to the same encoding rule as `tool_name`: a scope containing
    /// characters outside `[a-zA-Z0-9_-]` (or colliding with a reserved form) appears
    /// server-encoded in a stable `{prefix}_{32-hex}` form. OAuth scopes routinely
    /// contain `:` and `/`, so most appear encoded.</para>
    /// </summary>
    public required string Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scope");
        }
        init { this._rawData.Set("scope", value); }
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
        _ = this.ConnectorID;
        _ = this.Scope;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("connector_scope"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacConnectorScopePermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("connector_scope");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacConnectorScopePermissionResource(
        RbacConnectorScopePermissionResource rbacConnectorScopePermissionResource
    )
        : base(rbacConnectorScopePermissionResource) { }
#pragma warning restore CS8618

    public RbacConnectorScopePermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("connector_scope");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacConnectorScopePermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacConnectorScopePermissionResourceFromRaw.FromRawUnchecked"/>
    public static RbacConnectorScopePermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacConnectorScopePermissionResourceFromRaw
    : IFromRawJson<RbacConnectorScopePermissionResource>
{
    /// <inheritdoc/>
    public RbacConnectorScopePermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacConnectorScopePermissionResource.FromRawUnchecked(rawData);
}
