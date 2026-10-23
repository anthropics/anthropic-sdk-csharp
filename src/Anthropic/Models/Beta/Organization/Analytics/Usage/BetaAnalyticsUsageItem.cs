using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Usage;

[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsUsageItem, BetaAnalyticsUsageItemFromRaw>))]
public sealed record class BetaAnalyticsUsageItem : JsonModel
{
    /// <summary>
    /// End of the period this row covers (exclusive), as an RFC 3339 UTC timestamp:
    /// the end of the row's time bucket when a time-bucket width is set; otherwise
    /// the requested `ending_at` (or, when omitted, the earlier of now and `starting_at`
    /// plus 31 days) rounded down to the hour, because without a time bucket the
    /// report covers whole hours.
    /// </summary>
    public required DateTimeOffset EndingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("ending_at");
        }
        init { this._rawData.Set("ending_at", value); }
    }

    /// <summary>
    /// The dimension values this row's usage is broken out by.
    /// </summary>
    public required BetaAnalyticsUsageGroup Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUsageGroup>("group");
        }
        init { this._rawData.Set("group", value); }
    }

    /// <summary>
    /// Start of the period this row covers (inclusive), as an RFC 3339 UTC timestamp:
    /// the start of the row's time bucket when a time-bucket width is set, otherwise
    /// the requested `starting_at` rounded down to the hour.
    /// </summary>
    public required DateTimeOffset StartingAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("starting_at");
        }
        init { this._rawData.Set("starting_at", value); }
    }

    /// <summary>
    /// Token usage for this row.
    /// </summary>
    public required BetaAnalyticsUsageMetrics Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsUsageMetrics>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndingAt;
        this.Group.Validate();
        _ = this.StartingAt;
        this.Usage.Validate();
    }

    public BetaAnalyticsUsageItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageItem(BetaAnalyticsUsageItem betaAnalyticsUsageItem)
        : base(betaAnalyticsUsageItem) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageItemFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageItemFromRaw : IFromRawJson<BetaAnalyticsUsageItem>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageItem.FromRawUnchecked(rawData);
}
