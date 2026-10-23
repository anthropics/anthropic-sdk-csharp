using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Cost;

[JsonConverter(typeof(JsonModelConverter<CostListPageResponse, CostListPageResponseFromRaw>))]
public sealed record class CostListPageResponse : JsonModel
{
    /// <summary>
    /// Rows for this page, in the order set by `order_by` and `order`: one per combination
    /// of the `group_by[]` dimensions (and per time bucket, when `time_bucket_width`
    /// is set) with usage or cost in the range, or a single row when neither is set.
    /// Rows split out by `cost_type` or `token_type` (cost endpoint only) stay adjacent
    /// and are ranked as one unit.
    /// </summary>
    public required IReadOnlyList<BetaAnalyticsCostItem> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsCostItem>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsCostItem>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// RFC 3339 timestamp of the export this response was served from. Null when
    /// no export yet covers any part of the requested range, in which case `data`
    /// is empty. Data beyond this watermark is incomplete; for stable results, set
    /// `ending_at` to this value or earlier. Data is typically refreshed every 4
    /// hours. Values can be revised as late events arrive and reconciliation runs,
    /// until about 7 days after the end of the calendar month the usage falls in;
    /// for example, values for October 1 can change until about November 7.
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
    }

    public CostListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CostListPageResponse(CostListPageResponse costListPageResponse)
        : base(costListPageResponse) { }
#pragma warning restore CS8618

    public CostListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CostListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CostListPageResponseFromRaw.FromRawUnchecked"/>
    public static CostListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CostListPageResponseFromRaw : IFromRawJson<CostListPageResponse>
{
    /// <inheritdoc/>
    public CostListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CostListPageResponse.FromRawUnchecked(rawData);
}
