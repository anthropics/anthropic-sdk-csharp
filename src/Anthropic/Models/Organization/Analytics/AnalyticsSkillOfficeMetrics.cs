using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single skill on a given day, broken out by
/// Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsSkillOfficeMetrics, AnalyticsSkillOfficeMetricsFromRaw>)
)]
public sealed record class AnalyticsSkillOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsSkillOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillOfficeProductMetrics>("excel");
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsSkillOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillOfficeProductMetrics>("outlook");
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsSkillOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillOfficeProductMetrics>("powerpoint");
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required AnalyticsSkillOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AnalyticsSkillOfficeProductMetrics>("word");
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

    public AnalyticsSkillOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsSkillOfficeMetrics(AnalyticsSkillOfficeMetrics analyticsSkillOfficeMetrics)
        : base(analyticsSkillOfficeMetrics) { }
#pragma warning restore CS8618

    public AnalyticsSkillOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsSkillOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsSkillOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static AnalyticsSkillOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsSkillOfficeMetricsFromRaw : IFromRawJson<AnalyticsSkillOfficeMetrics>
{
    /// <inheritdoc/>
    public AnalyticsSkillOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsSkillOfficeMetrics.FromRawUnchecked(rawData);
}
