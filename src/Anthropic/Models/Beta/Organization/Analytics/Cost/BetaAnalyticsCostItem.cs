using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsCostItem, BetaAnalyticsCostItemFromRaw>))]
public sealed record class BetaAnalyticsCostItem : JsonModel
{
    /// <summary>
    /// Cost for this row.
    /// </summary>
    public required BetaAnalyticsCostMetrics Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsCostMetrics>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

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
    /// The dimension values this row's cost is broken out by.
    /// </summary>
    public required BetaAnalyticsCostGroup Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaAnalyticsCostGroup>("group");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cost.Validate();
        _ = this.EndingAt;
        this.Group.Validate();
        _ = this.StartingAt;
    }

    public BetaAnalyticsCostItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCostItem(BetaAnalyticsCostItem betaAnalyticsCostItem)
        : base(betaAnalyticsCostItem) { }
#pragma warning restore CS8618

    public BetaAnalyticsCostItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCostItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCostItemFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCostItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCostItemFromRaw : IFromRawJson<BetaAnalyticsCostItem>
{
    /// <inheritdoc/>
    public BetaAnalyticsCostItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCostItem.FromRawUnchecked(rawData);
}
