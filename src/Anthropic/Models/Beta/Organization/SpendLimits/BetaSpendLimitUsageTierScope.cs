using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// Scope of the monthly spend cap Anthropic sets for a Claude Console organization
/// from its usage tier, or a higher cap Anthropic granted the organization. Read-only;
/// its `created_at` and `updated_at` are the organization's creation time, so `amount`
/// can change while `updated_at` stays the same.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaSpendLimitUsageTierScope, BetaSpendLimitUsageTierScopeFromRaw>)
)]
public sealed record class BetaSpendLimitUsageTierScope : JsonModel
{
    /// <summary>
    /// Scope type. Always `usage_tier` for this scope.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("usage_tier")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitUsageTierScope()
    {
        this.Type = JsonSerializer.SerializeToElement("usage_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitUsageTierScope(BetaSpendLimitUsageTierScope betaSpendLimitUsageTierScope)
        : base(betaSpendLimitUsageTierScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitUsageTierScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("usage_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitUsageTierScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitUsageTierScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitUsageTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSpendLimitUsageTierScopeFromRaw : IFromRawJson<BetaSpendLimitUsageTierScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitUsageTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitUsageTierScope.FromRawUnchecked(rawData);
}
