using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<SpendLimitRbacGroupScope, SpendLimitRbacGroupScopeFromRaw>)
)]
public sealed record class SpendLimitRbacGroupScope : JsonModel
{
    public required string RbacGroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rbac_group_id");
        }
        init { this._rawData.Set("rbac_group_id", value); }
    }

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

    public SpendLimitRbacGroupScope()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitRbacGroupScope(SpendLimitRbacGroupScope spendLimitRbacGroupScope)
        : base(spendLimitRbacGroupScope) { }
#pragma warning restore CS8618

    public SpendLimitRbacGroupScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitRbacGroupScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitRbacGroupScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitRbacGroupScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitRbacGroupScope(string rbacGroupID)
        : this()
    {
        this.RbacGroupID = rbacGroupID;
    }
}

class SpendLimitRbacGroupScopeFromRaw : IFromRawJson<SpendLimitRbacGroupScope>
{
    /// <inheritdoc/>
    public SpendLimitRbacGroupScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitRbacGroupScope.FromRawUnchecked(rawData);
}
