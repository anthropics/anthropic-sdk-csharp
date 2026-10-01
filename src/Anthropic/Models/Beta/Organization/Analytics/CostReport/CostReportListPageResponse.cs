using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.CostReport;

[JsonConverter(
    typeof(JsonModelConverter<CostReportListPageResponse, CostReportListPageResponseFromRaw>)
)]
public sealed record class CostReportListPageResponse : JsonModel
{
    /// <summary>
    /// Time buckets for this page, oldest first: one per `bucket_width` interval,
    /// including intervals with no data (their `results` list is empty). A page holds
    /// at most `limit` buckets.
    /// </summary>
    public required IReadOnlyList<BetaAnalyticsCostReportTimeBucket> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaAnalyticsCostReportTimeBucket>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsCostReportTimeBucket>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// RFC 3339 timestamp of the export this response was served from. Null when
    /// no export yet covers any part of the requested range, in which case every
    /// bucket's `results` list is empty. Buckets beyond this watermark are incomplete;
    /// for stable results, set `ending_at` to this value or earlier. Data is typically
    /// refreshed every 4 hours but not final until about 30 days after the usage
    /// date (late-arriving events, reconciliation adjustments).
    /// </summary>
    public required DateTimeOffset? DataRefreshedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("data_refreshed_at");
        }
        init { this._rawData.Set("data_refreshed_at", value); }
    }

    /// <summary>
    /// Whether another page is available. When true, pass `next_page` as the `page`
    /// parameter to fetch it.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null when `has_more` is false. Pass it
    /// as the `page` parameter, keeping the other parameters unchanged. A cursor
    /// can expire after the underlying data refreshes; the request then returns
    /// HTTP 410 and pagination must restart from the first page.
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

    /// <summary>
    /// ID of the Organization.
    /// </summary>
    public required string OrganizationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("organization_id");
        }
        init { this._rawData.Set("organization_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.DataRefreshedAt;
        _ = this.HasMore;
        _ = this.NextPage;
        _ = this.OrganizationID;
    }

    public CostReportListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostReportListPageResponse(CostReportListPageResponse costReportListPageResponse)
        : base(costReportListPageResponse) { }
#pragma warning restore CS8618

    public CostReportListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostReportListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostReportListPageResponseFromRaw.FromRawUnchecked"/>
    public static CostReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CostReportListPageResponseFromRaw : IFromRawJson<CostReportListPageResponse>
{
    /// <inheritdoc/>
    public CostReportListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CostReportListPageResponse.FromRawUnchecked(rawData);
}
