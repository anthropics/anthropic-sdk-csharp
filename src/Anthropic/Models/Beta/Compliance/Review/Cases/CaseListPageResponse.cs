using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Compliance.Review.Cases;

/// <summary>
/// A page of review cases.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CaseListPageResponse, CaseListPageResponseFromRaw>))]
public sealed record class CaseListPageResponse : JsonModel
{
    /// <summary>
    /// The cases on this page.
    /// </summary>
    public required IReadOnlyList<BetaComplianceReviewCase> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaComplianceReviewCase>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaComplianceReviewCase>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page. Null on the last page. A page can be short or empty
    /// while this is set.
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

    public CaseListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CaseListPageResponse(CaseListPageResponse caseListPageResponse)
        : base(caseListPageResponse) { }
#pragma warning restore CS8618

    public CaseListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CaseListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CaseListPageResponseFromRaw.FromRawUnchecked"/>
    public static CaseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CaseListPageResponseFromRaw : IFromRawJson<CaseListPageResponse>
{
    /// <inheritdoc/>
    public CaseListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CaseListPageResponse.FromRawUnchecked(rawData);
}
