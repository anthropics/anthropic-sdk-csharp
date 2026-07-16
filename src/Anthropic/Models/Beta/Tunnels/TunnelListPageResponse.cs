using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Tunnels;

/// <summary>
/// A paginated list of tunnels.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TunnelListPageResponse, TunnelListPageResponseFromRaw>))]
public sealed record class TunnelListPageResponse : JsonModel
{
    /// <summary>
    /// List of tunnels, ordered by created_at descending.
    /// </summary>
    public required IReadOnlyList<BetaTunnel> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaTunnel>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTunnel>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination cursor for the next page, or null if no more results.
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

    public TunnelListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TunnelListPageResponse(TunnelListPageResponse tunnelListPageResponse)
        : base(tunnelListPageResponse) { }
#pragma warning restore CS8618

    public TunnelListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TunnelListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TunnelListPageResponseFromRaw.FromRawUnchecked"/>
    public static TunnelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TunnelListPageResponseFromRaw : IFromRawJson<TunnelListPageResponse>
{
    /// <inheritdoc/>
    public TunnelListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TunnelListPageResponse.FromRawUnchecked(rawData);
}
