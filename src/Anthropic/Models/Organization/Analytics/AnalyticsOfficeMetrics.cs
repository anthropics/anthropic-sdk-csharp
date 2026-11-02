using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single user on a given day, broken out by
/// Office product.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnalyticsOfficeMetrics, AnalyticsOfficeMetricsFromRaw>))]
public sealed record class AnalyticsOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsOfficeProductMetrics>("excel");
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsOfficeProductMetrics>("outlook");
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsOfficeProductMetrics>("powerpoint");
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single user on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsOfficeProductMetrics>("word");
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

    public AnalyticsOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsOfficeMetrics(AnalyticsOfficeMetrics analyticsOfficeMetrics)
        : base(analyticsOfficeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsOfficeMetricsFromRaw : IFromRawJson<AnalyticsOfficeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsOfficeMetrics.FromRawUnchecked(rawData);
}
