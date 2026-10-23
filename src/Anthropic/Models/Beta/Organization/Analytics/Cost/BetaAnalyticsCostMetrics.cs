using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

/// <summary>
/// The cost of one row.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsCostMetrics, BetaAnalyticsCostMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsCostMetrics : JsonModel
{
    /// <summary>
    /// Amount (post-discount, pre-credit) in fractional cents (minor units).
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
    /// Currency code for the cost amount. Currently always `"USD"`.
    /// </summary>
    public required string Currency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("currency");
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// List-price amount (pre-discount) in fractional cents.
    /// </summary>
    public required string ListAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("list_amount");
        }
        init { this._rawData.Set("list_amount", value); }
    }

    /// <summary>
    /// Number of API requests in this row's scope. Null when `group_by` includes
    /// `cost_type` or `token_type` (the count has no per-component attribution; read
    /// it from the ungrouped response). For sandbox / code-execution events, this
    /// counts execution spans rather than HTTP requests (these rows surface with
    /// `product: null`).
    /// </summary>
    public required long? Requests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("requests");
        }
        init { this._rawData.Set("requests", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
        _ = this.ListAmount;
        _ = this.Requests;
    }

    public BetaAnalyticsCostMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCostMetrics(BetaAnalyticsCostMetrics betaAnalyticsCostMetrics)
        : base(betaAnalyticsCostMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsCostMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCostMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCostMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCostMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCostMetricsFromRaw : IFromRawJson<BetaAnalyticsCostMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsCostMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCostMetrics.FromRawUnchecked(rawData);
}
