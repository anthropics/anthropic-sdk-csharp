using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<SpendLimitListPageResponse, SpendLimitListPageResponseFromRaw>)
)]
public sealed record class SpendLimitListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaSpendLimit> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaSpendLimit>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSpendLimit>>(
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

    public SpendLimitListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitListPageResponse(SpendLimitListPageResponse spendLimitListPageResponse)
        : base(spendLimitListPageResponse) { }
#pragma warning restore CS8618

    public SpendLimitListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitListPageResponseFromRaw.FromRawUnchecked"/>
    public static SpendLimitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SpendLimitListPageResponseFromRaw : IFromRawJson<SpendLimitListPageResponse>
{
    /// <inheritdoc/>
    public SpendLimitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitListPageResponse.FromRawUnchecked(rawData);
}
