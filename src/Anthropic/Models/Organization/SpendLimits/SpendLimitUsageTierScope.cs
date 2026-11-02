using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

/// <summary>
/// Scope of the monthly spend cap Anthropic sets for a Claude Console organization
/// from its usage tier, or a higher cap Anthropic granted the organization. Read-only;
/// its `created_at` and `updated_at` are the organization's creation time, so `amount`
/// can change while `updated_at` stays the same.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SpendLimitUsageTierScope, SpendLimitUsageTierScopeFromRaw>)
)]
public sealed record class SpendLimitUsageTierScope : JsonModel
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

    public SpendLimitUsageTierScope()
    {
        this.Type = JsonSerializer.SerializeToElement("usage_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitUsageTierScope(SpendLimitUsageTierScope spendLimitUsageTierScope)
        : base(spendLimitUsageTierScope) { }
#pragma warning restore CS8618

    public SpendLimitUsageTierScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("usage_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitUsageTierScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitUsageTierScopeFromRaw.FromRawUnchecked"/>
    public static SpendLimitUsageTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendLimitUsageTierScopeFromRaw : IFromRawJson<SpendLimitUsageTierScope>
{
    /// <inheritdoc/>
    public SpendLimitUsageTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitUsageTierScope.FromRawUnchecked(rawData);
}
