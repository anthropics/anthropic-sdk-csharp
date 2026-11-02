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
        RbacAllConnectorsPermissionResource,
        RbacAllConnectorsPermissionResourceFromRaw
    >)
)]
public sealed record class RbacAllConnectorsPermissionResource : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("all_connectors")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacAllConnectorsPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("all_connectors");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacAllConnectorsPermissionResource(
        RbacAllConnectorsPermissionResource rbacAllConnectorsPermissionResource
    )
        : base(rbacAllConnectorsPermissionResource) { }
#pragma warning restore CS8618

    public RbacAllConnectorsPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all_connectors");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacAllConnectorsPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacAllConnectorsPermissionResourceFromRaw.FromRawUnchecked"/>
    public static RbacAllConnectorsPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacAllConnectorsPermissionResourceFromRaw : IFromRawJson<RbacAllConnectorsPermissionResource>
{
    /// <inheritdoc/>
    public RbacAllConnectorsPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacAllConnectorsPermissionResource.FromRawUnchecked(rawData);
}
