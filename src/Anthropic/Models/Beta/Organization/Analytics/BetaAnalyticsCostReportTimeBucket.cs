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
        BetaAnalyticsCostReportTimeBucket,
        BetaAnalyticsCostReportTimeBucketFromRaw
    >)
)]
public sealed record class BetaAnalyticsCostReportTimeBucket : JsonModel
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
    public required IReadOnlyList<BetaAnalyticsCostBucketedResult> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsCostBucketedResult>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsCostBucketedResult>>(
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

    public BetaAnalyticsCostReportTimeBucket() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsCostReportTimeBucket(
        BetaAnalyticsCostReportTimeBucket betaAnalyticsCostReportTimeBucket
    )
        : base(betaAnalyticsCostReportTimeBucket) { }
#pragma warning restore CS8618

    public BetaAnalyticsCostReportTimeBucket(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsCostReportTimeBucket(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsCostReportTimeBucketFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsCostReportTimeBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsCostReportTimeBucketFromRaw : IFromRawJson<BetaAnalyticsCostReportTimeBucket>
{
    /// <inheritdoc/>
    public BetaAnalyticsCostReportTimeBucket FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsCostReportTimeBucket.FromRawUnchecked(rawData);
}
