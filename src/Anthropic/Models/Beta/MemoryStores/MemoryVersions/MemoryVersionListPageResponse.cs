using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// Response payload for [List memory versions](/en/api/beta/memory_stores/memory_versions/list).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MemoryVersionListPageResponse, MemoryVersionListPageResponseFromRaw>)
)]
public sealed record class MemoryVersionListPageResponse : JsonModel
{
    /// <summary>
    /// One page of `memory_version` objects, ordered by `created_at` descending (newest
    /// first), with `id` as tiebreak.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsMemoryVersion>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsMemoryVersion>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsMemoryVersion>?>(
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

    public MemoryVersionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryVersionListPageResponse(
        MemoryVersionListPageResponse memoryVersionListPageResponse
    )
        : base(memoryVersionListPageResponse) { }
#pragma warning restore CS8618

    public MemoryVersionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryVersionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryVersionListPageResponseFromRaw.FromRawUnchecked"/>
    public static MemoryVersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryVersionListPageResponseFromRaw : IFromRawJson<MemoryVersionListPageResponse>
{
    /// <inheritdoc/>
    public MemoryVersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryVersionListPageResponse.FromRawUnchecked(rawData);
}
