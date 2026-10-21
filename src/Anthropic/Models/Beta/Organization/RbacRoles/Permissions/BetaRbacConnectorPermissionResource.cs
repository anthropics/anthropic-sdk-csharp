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
        BetaRbacConnectorPermissionResource,
        BetaRbacConnectorPermissionResourceFromRaw
    >)
)]
public sealed record class BetaRbacConnectorPermissionResource : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("connector")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRbacConnectorPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("connector");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacConnectorPermissionResource(
        BetaRbacConnectorPermissionResource betaRbacConnectorPermissionResource
    )
        : base(betaRbacConnectorPermissionResource) { }
#pragma warning restore CS8618

    public BetaRbacConnectorPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("connector");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacConnectorPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacConnectorPermissionResourceFromRaw.FromRawUnchecked"/>
    public static BetaRbacConnectorPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRbacConnectorPermissionResource(string connectorID)
        : this()
    {
        this.ConnectorID = connectorID;
    }
}

class BetaRbacConnectorPermissionResourceFromRaw : IFromRawJson<BetaRbacConnectorPermissionResource>
{
    /// <inheritdoc/>
    public BetaRbacConnectorPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacConnectorPermissionResource.FromRawUnchecked(rawData);
}
