using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single connector on a given day, broken out
/// by Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AnalyticsConnectorOfficeMetrics,
        AnalyticsConnectorOfficeMetricsFromRaw
    >)
)]
public sealed record class AnalyticsConnectorOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required AnalyticsConnectorOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorOfficeProductMetrics>("excel");
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required AnalyticsConnectorOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorOfficeProductMetrics>("outlook");
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required AnalyticsConnectorOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorOfficeProductMetrics>(
                "powerpoint"
            );
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single connector on a given day within
    /// one Office product.
    /// </summary>
    public required AnalyticsConnectorOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsConnectorOfficeProductMetrics>("word");
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

    public AnalyticsConnectorOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsConnectorOfficeMetrics(
        AnalyticsConnectorOfficeMetrics analyticsConnectorOfficeMetrics
    )
        : base(analyticsConnectorOfficeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsConnectorOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsConnectorOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsConnectorOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsConnectorOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsConnectorOfficeMetricsFromRaw : IFromRawJson<AnalyticsConnectorOfficeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsConnectorOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsConnectorOfficeMetrics.FromRawUnchecked(rawData);
}
