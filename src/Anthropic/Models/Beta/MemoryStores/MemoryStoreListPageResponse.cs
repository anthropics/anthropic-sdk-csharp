using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.MemoryStores;

/// <summary>
/// A page of `memory_store` results, ordered by `created_at` descending (newest first).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<MemoryStoreListPageResponse, MemoryStoreListPageResponseFromRaw>)
)]
public sealed record class MemoryStoreListPageResponse : JsonModel
{
    /// <summary>
    /// Memory stores on this page, newest first. Empty when there are no stores matching
    /// the filters.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsMemoryStore>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsMemoryStore>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsMemoryStore>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page (a `page_...` value). Pass as `page` on the
    /// next request. `null` when there are no more results.
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

    public MemoryStoreListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemoryStoreListPageResponse(MemoryStoreListPageResponse memoryStoreListPageResponse)
        : base(memoryStoreListPageResponse) { }
#pragma warning restore CS8618

    public MemoryStoreListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemoryStoreListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemoryStoreListPageResponseFromRaw.FromRawUnchecked"/>
    public static MemoryStoreListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemoryStoreListPageResponseFromRaw : IFromRawJson<MemoryStoreListPageResponse>
{
    /// <inheritdoc/>
    public MemoryStoreListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemoryStoreListPageResponse.FromRawUnchecked(rawData);
}
