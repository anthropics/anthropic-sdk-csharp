using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Notices;

/// <summary>
/// A page of review notices.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NoticeListPageResponse, NoticeListPageResponseFromRaw>))]
public sealed record class NoticeListPageResponse : JsonModel
{
    /// <summary>
    /// The notices on this page.
    /// </summary>
    public required IReadOnlyList<BetaComplianceReviewNotice> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaComplianceReviewNotice>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaComplianceReviewNotice>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page. Null on the last page.
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

    public NoticeListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoticeListPageResponse(NoticeListPageResponse noticeListPageResponse)
        : base(noticeListPageResponse) { }
#pragma warning restore CS8618

    public NoticeListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoticeListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoticeListPageResponseFromRaw.FromRawUnchecked"/>
    public static NoticeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NoticeListPageResponseFromRaw : IFromRawJson<NoticeListPageResponse>
{
    /// <inheritdoc/>
    public NoticeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NoticeListPageResponse.FromRawUnchecked(rawData);
}
