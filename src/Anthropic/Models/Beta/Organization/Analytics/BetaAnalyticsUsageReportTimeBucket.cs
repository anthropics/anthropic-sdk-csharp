using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsUsageReportTimeBucket,
        BetaAnalyticsUsageReportTimeBucketFromRaw
    >)
)]
public sealed record class BetaAnalyticsUsageReportTimeBucket : JsonModel
{
    /// <summary>
    /// End of the time bucket (exclusive) in RFC 3339 format.
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
    /// Rows for this time bucket. Empty when the bucket has no data; otherwise a
    /// single combined row when `group_by[]` is omitted, or one row per group (subject
    /// to the per-bucket group cap described on the `group_by[]` parameter).
    /// </summary>
    public required IReadOnlyList<BetaAnalyticsUsageBucketedResult> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsUsageBucketedResult>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsUsageBucketedResult>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start of the time bucket (inclusive) in RFC 3339 format.
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
        _ = this.EndingAt;
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        _ = this.StartingAt;
    }

    public BetaAnalyticsUsageReportTimeBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsUsageReportTimeBucket(
        BetaAnalyticsUsageReportTimeBucket betaAnalyticsUsageReportTimeBucket
    )
        : base(betaAnalyticsUsageReportTimeBucket) { }
#pragma warning restore CS8618

    public BetaAnalyticsUsageReportTimeBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsUsageReportTimeBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsUsageReportTimeBucketFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsUsageReportTimeBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsUsageReportTimeBucketFromRaw : IFromRawJson<BetaAnalyticsUsageReportTimeBucket>
{
    /// <inheritdoc/>
    public BetaAnalyticsUsageReportTimeBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsUsageReportTimeBucket.FromRawUnchecked(rawData);
}
