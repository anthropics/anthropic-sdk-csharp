using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles;

[JsonConverter(
    typeof(JsonModelConverter<BetaRbacRoleSourceBuiltIn, BetaRbacRoleSourceBuiltInFromRaw>)
)]
public sealed record class BetaRbacRoleSourceBuiltIn : JsonModel
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

    public BetaRbacRoleSourceBuiltIn()
    {
        this.Type = JsonSerializer.SerializeToElement("built_in");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacRoleSourceBuiltIn(BetaRbacRoleSourceBuiltIn betaRbacRoleSourceBuiltIn)
        : base(betaRbacRoleSourceBuiltIn) { }
#pragma warning restore CS8618

    public BetaRbacRoleSourceBuiltIn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("built_in");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacRoleSourceBuiltIn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacRoleSourceBuiltInFromRaw.FromRawUnchecked"/>
    public static BetaRbacRoleSourceBuiltIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacRoleSourceBuiltInFromRaw : IFromRawJson<BetaRbacRoleSourceBuiltIn>
{
    /// <inheritdoc/>
    public BetaRbacRoleSourceBuiltIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacRoleSourceBuiltIn.FromRawUnchecked(rawData);
}
