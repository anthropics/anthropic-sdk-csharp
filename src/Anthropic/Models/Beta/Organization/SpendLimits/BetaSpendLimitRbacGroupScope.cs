using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaSpendLimitRbacGroupScope, BetaSpendLimitRbacGroupScopeFromRaw>)
)]
public sealed record class BetaSpendLimitRbacGroupScope : JsonModel
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

    public BetaSpendLimitRbacGroupScope()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitRbacGroupScope(BetaSpendLimitRbacGroupScope betaSpendLimitRbacGroupScope)
        : base(betaSpendLimitRbacGroupScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitRbacGroupScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitRbacGroupScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitRbacGroupScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitRbacGroupScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSpendLimitRbacGroupScope(string rbacGroupID)
        : this()
    {
        this.RbacGroupID = rbacGroupID;
    }
}

class BetaSpendLimitRbacGroupScopeFromRaw : IFromRawJson<BetaSpendLimitRbacGroupScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitRbacGroupScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitRbacGroupScope.FromRawUnchecked(rawData);
}
