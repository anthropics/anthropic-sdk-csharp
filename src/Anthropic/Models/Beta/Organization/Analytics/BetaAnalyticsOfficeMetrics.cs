using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single user on a given day, broken out by
/// Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsOfficeMetrics, BetaAnalyticsOfficeMetricsFromRaw>)
)]
public sealed record class BetaAnalyticsOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsOfficeProductMetrics>("excel");
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsOfficeProductMetrics>("outlook");
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsOfficeProductMetrics>("powerpoint");
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsOfficeProductMetrics>("word");
        }
        init { this._rawData.Set("word", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Excel.Validate();
        this.Outlook.Validate();
        this.Powerpoint.Validate();
        this.Word.Validate();
    }

    public BetaAnalyticsOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsOfficeMetrics(BetaAnalyticsOfficeMetrics betaAnalyticsOfficeMetrics)
        : base(betaAnalyticsOfficeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsOfficeMetricsFromRaw : IFromRawJson<BetaAnalyticsOfficeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsOfficeMetrics.FromRawUnchecked(rawData);
}
