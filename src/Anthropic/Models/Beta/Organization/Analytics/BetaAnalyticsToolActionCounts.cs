using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Accepted/rejected counts for a single Claude Code tool type.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsToolActionCounts, BetaAnalyticsToolActionCountsFromRaw>)
)]
public sealed record class BetaAnalyticsToolActionCounts : JsonModel
{
    /// <summary>
    /// Number of tool proposals accepted
    /// </summary>
    public required long AcceptedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("accepted_count");
        }
        init { this._rawData.Set("accepted_count", value); }
    }

    /// <summary>
    /// Number of tool proposals rejected
    /// </summary>
    public required long RejectedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("rejected_count");
        }
        init { this._rawData.Set("rejected_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedCount;
        _ = this.RejectedCount;
    }

    public BetaAnalyticsToolActionCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsToolActionCounts(
        BetaAnalyticsToolActionCounts betaAnalyticsToolActionCounts
    )
        : base(betaAnalyticsToolActionCounts) { }
#pragma warning restore CS8618

    public BetaAnalyticsToolActionCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsToolActionCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsToolActionCountsFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsToolActionCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsToolActionCountsFromRaw : IFromRawJson<BetaAnalyticsToolActionCounts>
{
    /// <inheritdoc/>
    public BetaAnalyticsToolActionCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsToolActionCounts.FromRawUnchecked(rawData);
}
