using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Accepted/rejected counts for a single Claude Code tool type.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AnalyticsToolActionCounts, AnalyticsToolActionCountsFromRaw>)
)]
public sealed record class AnalyticsToolActionCounts : JsonModel
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

    public AnalyticsToolActionCounts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsToolActionCounts(AnalyticsToolActionCounts analyticsToolActionCounts)
        : base(analyticsToolActionCounts) { }
#pragma warning restore CS8618

    public AnalyticsToolActionCounts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsToolActionCounts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsToolActionCountsFromRaw.FromRawUnchecked"/>
    public static AnalyticsToolActionCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsToolActionCountsFromRaw : IFromRawJson<AnalyticsToolActionCounts>
{
    /// <inheritdoc/>
    public AnalyticsToolActionCounts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsToolActionCounts.FromRawUnchecked(rawData);
}
