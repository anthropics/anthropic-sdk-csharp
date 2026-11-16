using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles;

[JsonConverter(
    typeof(JsonModelConverter<BetaRbacRoleSourceCustom, BetaRbacRoleSourceCustomFromRaw>)
)]
public sealed record class BetaRbacRoleSourceCustom : JsonModel
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

    public BetaRbacRoleSourceCustom()
    {
        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacRoleSourceCustom(BetaRbacRoleSourceCustom betaRbacRoleSourceCustom)
        : base(betaRbacRoleSourceCustom) { }
#pragma warning restore CS8618

    public BetaRbacRoleSourceCustom(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("custom");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacRoleSourceCustom(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacRoleSourceCustomFromRaw.FromRawUnchecked"/>
    public static BetaRbacRoleSourceCustom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacRoleSourceCustomFromRaw : IFromRawJson<BetaRbacRoleSourceCustom>
{
    /// <inheritdoc/>
    public BetaRbacRoleSourceCustom FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacRoleSourceCustom.FromRawUnchecked(rawData);
}
