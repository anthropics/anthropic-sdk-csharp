using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaRbacConnectorToolPermissionResource,
        BetaRbacConnectorToolPermissionResourceFromRaw
    >)
)]
public sealed record class BetaRbacConnectorToolPermissionResource : JsonModel
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

    public BetaRbacConnectorToolPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("connector_tool");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacConnectorToolPermissionResource(
        BetaRbacConnectorToolPermissionResource betaRbacConnectorToolPermissionResource
    )
        : base(betaRbacConnectorToolPermissionResource) { }
#pragma warning restore CS8618

    public BetaRbacConnectorToolPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("connector_tool");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacConnectorToolPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacConnectorToolPermissionResourceFromRaw.FromRawUnchecked"/>
    public static BetaRbacConnectorToolPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacConnectorToolPermissionResourceFromRaw
    : IFromRawJson<BetaRbacConnectorToolPermissionResource>
{
    /// <inheritdoc/>
    public BetaRbacConnectorToolPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacConnectorToolPermissionResource.FromRawUnchecked(rawData);
}
