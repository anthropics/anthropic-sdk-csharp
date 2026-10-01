using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.SpendLimits.Effective;

[JsonConverter(
    typeof(JsonModelConverter<EffectiveListPageResponse, EffectiveListPageResponseFromRaw>)
)]
public sealed record class EffectiveListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaSpendSummary> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaSpendSummary>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSpendSummary>>(
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

    public EffectiveListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EffectiveListPageResponse(EffectiveListPageResponse effectiveListPageResponse)
        : base(effectiveListPageResponse) { }
#pragma warning restore CS8618

    public EffectiveListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EffectiveListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EffectiveListPageResponseFromRaw.FromRawUnchecked"/>
    public static EffectiveListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EffectiveListPageResponseFromRaw : IFromRawJson<EffectiveListPageResponse>
{
    /// <inheritdoc/>
    public EffectiveListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EffectiveListPageResponse.FromRawUnchecked(rawData);
}
