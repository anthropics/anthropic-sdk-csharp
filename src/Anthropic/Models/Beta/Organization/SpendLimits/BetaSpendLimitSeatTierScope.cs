using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaSpendLimitSeatTierScope, BetaSpendLimitSeatTierScopeFromRaw>)
)]
public sealed record class BetaSpendLimitSeatTierScope : JsonModel
{
    public required string SeatTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("seat_tier");
        }
        init { this._rawData.Set("seat_tier", value); }
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
        _ = this.SeatTier;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("seat_tier")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaSpendLimitSeatTierScope()
    {
        this.Type = JsonSerializer.SerializeToElement("seat_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSpendLimitSeatTierScope(BetaSpendLimitSeatTierScope betaSpendLimitSeatTierScope)
        : base(betaSpendLimitSeatTierScope) { }
#pragma warning restore CS8618

    public BetaSpendLimitSeatTierScope(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("seat_tier");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSpendLimitSeatTierScope(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSpendLimitSeatTierScopeFromRaw.FromRawUnchecked"/>
    public static BetaSpendLimitSeatTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSpendLimitSeatTierScope(string seatTier)
        : this()
    {
        this.SeatTier = seatTier;
    }
}

class BetaSpendLimitSeatTierScopeFromRaw : IFromRawJson<BetaSpendLimitSeatTierScope>
{
    /// <inheritdoc/>
    public BetaSpendLimitSeatTierScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSpendLimitSeatTierScope.FromRawUnchecked(rawData);
}
