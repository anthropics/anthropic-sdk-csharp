using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores;

/// <summary>
/// Confirmation that a `memory_store` was deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedMemoryStore,
        BetaManagedAgentsDeletedMemoryStoreFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedMemoryStore : JsonModel
{
    /// <summary>
    /// ID of the deleted memory store (a `memstore_...` identifier). The store and
    /// all its memories and versions are no longer retrievable.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("memory_store_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeletedMemoryStore()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedMemoryStore(
        BetaManagedAgentsDeletedMemoryStore betaManagedAgentsDeletedMemoryStore
    )
        : base(betaManagedAgentsDeletedMemoryStore) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedMemoryStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedMemoryStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedMemoryStoreFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedMemoryStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedMemoryStore(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeletedMemoryStoreFromRaw : IFromRawJson<BetaManagedAgentsDeletedMemoryStore>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedMemoryStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedMemoryStore.FromRawUnchecked(rawData);
}
