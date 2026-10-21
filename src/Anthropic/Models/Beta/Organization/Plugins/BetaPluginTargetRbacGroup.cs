using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(
    typeof(JsonModelConverter<BetaPluginTargetRbacGroup, BetaPluginTargetRbacGroupFromRaw>)
)]
public sealed record class BetaPluginTargetRbacGroup : JsonModel
{
    /// <summary>
    /// The RBAC Group's ID.
    /// </summary>
    public required string RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

    /// <summary>
    /// An RBAC Group.
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
        _ = this.RbacGroupID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rbac_group")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginTargetRbacGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginTargetRbacGroup(BetaPluginTargetRbacGroup betaPluginTargetRbacGroup)
        : base(betaPluginTargetRbacGroup) { }
#pragma warning restore CS8618

    public BetaPluginTargetRbacGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginTargetRbacGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginTargetRbacGroupFromRaw.FromRawUnchecked"/>
    public static BetaPluginTargetRbacGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPluginTargetRbacGroup(string rbacGroupID)
        : this()
    {
        this.RbacGroupID = rbacGroupID;
    }
}

class BetaPluginTargetRbacGroupFromRaw : IFromRawJson<BetaPluginTargetRbacGroup>
{
    /// <inheritdoc/>
    public BetaPluginTargetRbacGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginTargetRbacGroup.FromRawUnchecked(rawData);
}
