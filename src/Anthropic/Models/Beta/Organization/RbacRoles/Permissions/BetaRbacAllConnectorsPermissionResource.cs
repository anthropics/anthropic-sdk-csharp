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
        BetaRbacAllConnectorsPermissionResource,
        BetaRbacAllConnectorsPermissionResourceFromRaw
    >)
)]
public sealed record class BetaRbacAllConnectorsPermissionResource : JsonModel
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

    public BetaRbacAllConnectorsPermissionResource()
    {
        this.Type = JsonSerializer.SerializeToElement("all_connectors");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacAllConnectorsPermissionResource(
        BetaRbacAllConnectorsPermissionResource betaRbacAllConnectorsPermissionResource
    )
        : base(betaRbacAllConnectorsPermissionResource) { }
#pragma warning restore CS8618

    public BetaRbacAllConnectorsPermissionResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("all_connectors");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacAllConnectorsPermissionResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacAllConnectorsPermissionResourceFromRaw.FromRawUnchecked"/>
    public static BetaRbacAllConnectorsPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacAllConnectorsPermissionResourceFromRaw
    : IFromRawJson<BetaRbacAllConnectorsPermissionResource>
{
    /// <inheritdoc/>
    public BetaRbacAllConnectorsPermissionResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacAllConnectorsPermissionResource.FromRawUnchecked(rawData);
}
