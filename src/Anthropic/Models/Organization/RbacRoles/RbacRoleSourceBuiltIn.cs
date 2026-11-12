using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles;

[JsonConverter(typeof(JsonModelConverter<RbacRoleSourceBuiltIn, RbacRoleSourceBuiltInFromRaw>))]
public sealed record class RbacRoleSourceBuiltIn : JsonModel
{
    /// <summary>
    /// Anthropic provisions the RBAC Role, and the organization's administrators
    /// cannot change or delete it.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("built_in")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RbacRoleSourceBuiltIn()
    {
        this.Type = JsonSerializer.SerializeToElement("built_in");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRoleSourceBuiltIn(RbacRoleSourceBuiltIn rbacRoleSourceBuiltIn)
        : base(rbacRoleSourceBuiltIn) { }
#pragma warning restore CS8618

    public RbacRoleSourceBuiltIn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("built_in");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRoleSourceBuiltIn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRoleSourceBuiltInFromRaw.FromRawUnchecked"/>
    public static RbacRoleSourceBuiltIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRoleSourceBuiltInFromRaw : IFromRawJson<RbacRoleSourceBuiltIn>
{
    /// <inheritdoc/>
    public RbacRoleSourceBuiltIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacRoleSourceBuiltIn.FromRawUnchecked(rawData);
}
