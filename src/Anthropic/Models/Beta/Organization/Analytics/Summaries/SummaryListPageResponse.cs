using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Summaries;

/// <summary>
/// Response for GET /v1/organizations/analytics/summaries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SummaryListPageResponse, SummaryListPageResponseFromRaw>))]
public sealed record class SummaryListPageResponse : JsonModel
{
    /// <summary>
    /// One entry per day in the requested range, ascending by date.
    /// </summary>
    public required IReadOnlyList<BetaAnalyticsSingleDayActivitySummary> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaAnalyticsSingleDayActivitySummary>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsSingleDayActivitySummary>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results. Currently always
    /// null: the day series is returned in full.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public SummaryListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SummaryListPageResponse(SummaryListPageResponse summaryListPageResponse)
        : base(summaryListPageResponse) { }
#pragma warning restore CS8618

    public SummaryListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SummaryListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SummaryListPageResponseFromRaw.FromRawUnchecked"/>
    public static SummaryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SummaryListPageResponseFromRaw : IFromRawJson<SummaryListPageResponse>
{
    /// <inheritdoc/>
    public SummaryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SummaryListPageResponse.FromRawUnchecked(rawData);
}
