using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

[JsonConverter(
    typeof(JsonModelConverter<
        IncreaseRequestListPageResponse,
        IncreaseRequestListPageResponseFromRaw
    >)
)]
public sealed record class IncreaseRequestListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaSpendLimitIncreaseRequest> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaSpendLimitIncreaseRequest>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSpendLimitIncreaseRequest>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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

    public IncreaseRequestListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IncreaseRequestListPageResponse(
        IncreaseRequestListPageResponse increaseRequestListPageResponse
    )
        : base(increaseRequestListPageResponse) { }
#pragma warning restore CS8618

    public IncreaseRequestListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IncreaseRequestListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IncreaseRequestListPageResponseFromRaw.FromRawUnchecked"/>
    public static IncreaseRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IncreaseRequestListPageResponseFromRaw : IFromRawJson<IncreaseRequestListPageResponse>
{
    /// <inheritdoc/>
    public IncreaseRequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IncreaseRequestListPageResponse.FromRawUnchecked(rawData);
}
