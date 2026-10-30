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
        RbacConnectorToolPermissionResource,
        RbacConnectorToolPermissionResourceFromRaw
    >)
)]
public sealed record class RbacConnectorToolPermissionResource : JsonModel
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
    /// Published name of the connector tool the permission applies to.
    ///
    /// <para>When the published name contains characters outside `[a-zA-Z0-9_-]`
    /// (or collides with a reserved form), it is server-encoded into a stable `{prefix}_{32-hex}`
    /// form — a shortened readable prefix of the name plus a hash — from which the
    /// published name is not recoverable.</para>
    /// </summary>
    public required string ToolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_name");
        }
        init { this._rawData.Set("tool_name", value); }
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
        _ = this.ToolName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("connector_tool")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacConnectorToolPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("connector_tool");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacConnectorToolPermissionResource(
        RbacConnectorToolPermissionResource rbacConnectorToolPermissionResource
    )
        : base(rbacConnectorToolPermissionResource) { }
#pragma warning restore CS8618

    public RbacConnectorToolPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("connector_tool");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacConnectorToolPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacConnectorToolPermissionResourceFromRaw.FromRawUnchecked"/>
    public static RbacConnectorToolPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacConnectorToolPermissionResourceFromRaw : IFromRawJson<RbacConnectorToolPermissionResource>
{
    /// <inheritdoc/>
    public RbacConnectorToolPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacConnectorToolPermissionResource.FromRawUnchecked(rawData);
}
