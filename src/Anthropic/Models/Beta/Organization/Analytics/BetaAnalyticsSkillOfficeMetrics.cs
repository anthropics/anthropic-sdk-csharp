using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Office Agent activity metrics for a single skill on a given day, broken out by
/// Office product.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsSkillOfficeMetrics,
        BetaAnalyticsSkillOfficeMetricsFromRaw
    >)
)]
public sealed record class BetaAnalyticsSkillOfficeMetrics : JsonModel
{
    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsSkillOfficeProductMetrics Excel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillOfficeProductMetrics>("excel");
        }
        init { this._rawData.Set("excel", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsSkillOfficeProductMetrics Outlook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillOfficeProductMetrics>("outlook");
        }
        init { this._rawData.Set("outlook", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsSkillOfficeProductMetrics Powerpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillOfficeProductMetrics>(
                "powerpoint"
            );
        }
        init { this._rawData.Set("powerpoint", value); }
    }

    /// <summary>
    /// Office Agent activity metrics for a single skill on a given day within one
    /// Office product.
    /// </summary>
    public required BetaAnalyticsSkillOfficeProductMetrics Word
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsSkillOfficeProductMetrics>("word");
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

    public BetaAnalyticsSkillOfficeMetrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsSkillOfficeMetrics(
        BetaAnalyticsSkillOfficeMetrics betaAnalyticsSkillOfficeMetrics
    )
        : base(betaAnalyticsSkillOfficeMetrics) { }
#pragma warning restore CS8618

    public BetaAnalyticsSkillOfficeMetrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsSkillOfficeMetrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsSkillOfficeMetricsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsSkillOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsSkillOfficeMetricsFromRaw : IFromRawJson<BetaAnalyticsSkillOfficeMetrics>
{
    /// <inheritdoc/>
    public BetaAnalyticsSkillOfficeMetrics FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsSkillOfficeMetrics.FromRawUnchecked(rawData);
}
