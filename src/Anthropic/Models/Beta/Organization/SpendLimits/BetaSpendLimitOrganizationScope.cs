using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaSpendLimitOrganizationScope,
        BetaSpendLimitOrganizationScopeFromRaw
    >)
)]
public sealed record class BetaSpendLimitOrganizationScope : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitOrganizationScope()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitOrganizationScope(
        BetaSpendLimitOrganizationScope betaSpendLimitOrganizationScope
    )
        : base(betaSpendLimitOrganizationScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitOrganizationScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitOrganizationScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitOrganizationScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitOrganizationScopeFromRaw : IFromRawJson<BetaSpendLimitOrganizationScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitOrganizationScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitOrganizationScope.FromRawUnchecked(rawData);
}
