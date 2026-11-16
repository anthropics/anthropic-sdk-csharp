using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles;

[JsonConverter(typeof(JsonModelConverter<RbacRoleSourceCustom, RbacRoleSourceCustomFromRaw>))]
public sealed record class RbacRoleSourceCustom : JsonModel
{
    /// <summary>
    /// The organization's administrators can change and delete the RBAC Role.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("custom")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacRoleSourceCustom()
    {
        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRoleSourceCustom(RbacRoleSourceCustom rbacRoleSourceCustom)
        : base(rbacRoleSourceCustom) { }
#pragma warning restore CS8618

    public RbacRoleSourceCustom(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRoleSourceCustom(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRoleSourceCustomFromRaw.FromRawUnchecked"/>
    public static RbacRoleSourceCustom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRoleSourceCustomFromRaw : IFromRawJson<RbacRoleSourceCustom>
{
    /// <inheritdoc/>
    public RbacRoleSourceCustom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacRoleSourceCustom.FromRawUnchecked(rawData);
}
