using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single connector on a given day, broken out
/// by Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsConnectorOfficeMetrics,
        BetaAnalyticsConnectorOfficeMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsConnectorOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required BetaAnalyticsConnectorOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorOfficeProductMetrics>(
                "excel"
            );
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required BetaAnalyticsConnectorOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorOfficeProductMetrics>(
                "outlook"
            );
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required BetaAnalyticsConnectorOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorOfficeProductMetrics>(
                "powerpoint"
            );
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required BetaAnalyticsConnectorOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsConnectorOfficeProductMetrics>(
                "word"
            );
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

    public BetaAnalyticsConnectorOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsConnectorOfficeMetrics(
        BetaAnalyticsConnectorOfficeMetrics betaAnalyticsConnectorOfficeMetrics
    )
        : base(betaAnalyticsConnectorOfficeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsConnectorOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsConnectorOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsConnectorOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsConnectorOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsConnectorOfficeMetricsFromRaw : IFromRawJson<BetaAnalyticsConnectorOfficeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsConnectorOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsConnectorOfficeMetrics.FromRawUnchecked(rawData);
}
