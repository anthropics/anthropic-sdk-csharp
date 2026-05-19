using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Environments.Work;

/// <summary>
/// Response when listing work items with cursor-based pagination.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaSelfHostedWorkListResponse,
        BetaSelfHostedWorkListResponseFromRaw
    >)
)]
public sealed record class BetaSelfHostedWorkListResponse : JsonModel
{
    /// <summary>
    /// List of work items
    /// </summary>
    public required IReadOnlyList<BetaSelfHostedWork> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaSelfHostedWork>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaSelfHostedWork>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for fetching the next page of results
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

    public BetaSelfHostedWorkListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSelfHostedWorkListResponse(
        BetaSelfHostedWorkListResponse betaSelfHostedWorkListResponse
    )
        : base(betaSelfHostedWorkListResponse) { }
#pragma warning restore CS8618

    public BetaSelfHostedWorkListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSelfHostedWorkListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSelfHostedWorkListResponseFromRaw.FromRawUnchecked"/>
    public static BetaSelfHostedWorkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaSelfHostedWorkListResponseFromRaw : IFromRawJson<BetaSelfHostedWorkListResponse>
{
    /// <inheritdoc/>
    public BetaSelfHostedWorkListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaSelfHostedWorkListResponse.FromRawUnchecked(rawData);
}
