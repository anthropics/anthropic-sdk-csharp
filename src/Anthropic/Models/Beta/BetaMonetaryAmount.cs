using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta;

/// <summary>
/// A monetary amount in a specific currency.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaMonetaryAmount, BetaMonetaryAmountFromRaw>))]
public sealed record class BetaMonetaryAmount : JsonModel
{
    /// <summary>
    /// Amount in minor units of the currency, as an integer decimal string with no
    /// leading zeros: "2500" is $25.00 and "50" is fifty cents. A string rather than
    /// a number so no float rounding is ever applied.
    /// </summary>
    public required string Amount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("amount");
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Uppercase ISO-4217 currency code. `USD` is the only currency currently supported;
    /// the accepted set is closed and grows only when a new currency is priced.
    /// </summary>
    public required ApiEnum<string, BetaCurrency> Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaCurrency>>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Currency.Validate();
    }

    public BetaMonetaryAmount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMonetaryAmount(BetaMonetaryAmount betaMonetaryAmount)
        : base(betaMonetaryAmount) { }
#pragma warning restore CS8618

    public BetaMonetaryAmount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMonetaryAmount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMonetaryAmountFromRaw.FromRawUnchecked"/>
    public static BetaMonetaryAmount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaMonetaryAmountFromRaw : IFromRawJson<BetaMonetaryAmount>
{
    /// <inheritdoc/>
    public BetaMonetaryAmount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaMonetaryAmount.FromRawUnchecked(rawData);
}
