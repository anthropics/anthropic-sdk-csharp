using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Response payload for [List memories](/en/api/beta/memory_stores/memories/list).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MemoryListPageResponse, MemoryListPageResponseFromRaw>))]
public sealed record class MemoryListPageResponse : JsonModel
{
    /// <summary>
    /// One page of results. Each item is either a `memory` object or, when `depth`
    /// was set, a `memory_prefix` rollup marker. Items appear in the requested `order_by`/`order`.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsMemoryListItem>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsMemoryListItem>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsMemoryListItem>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page (a `page_...` value), or `null` if there are
    /// no more results. Pass as `page` on the next request.
    /// </summary>
    public string? NextPage
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public MemoryListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryListPageResponse(MemoryListPageResponse memoryListPageResponse)
        : base(memoryListPageResponse) { }
#pragma warning restore CS8618

    public MemoryListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryListPageResponseFromRaw.FromRawUnchecked"/>
    public static MemoryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryListPageResponseFromRaw : IFromRawJson<MemoryListPageResponse>
{
    /// <inheritdoc/>
    public MemoryListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryListPageResponse.FromRawUnchecked(rawData);
}
