using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores;

/// <summary>
/// A `memory_store`: a named container for agent memories, scoped to a workspace.
/// Attach a store to a session via `resources[]` to mount it as a directory the agent
/// can read and write.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsMemoryStore, BetaManagedAgentsMemoryStoreFromRaw>)
)]
public sealed record class BetaManagedAgentsMemoryStore : JsonModel
{
    /// <summary>
    /// The unique ID of the memory store (`memstore_...`). Use it to attach the store
    /// to a session.
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

    /// <summary>
    /// When the memory store was archived, in RFC 3339, or `null` if it hasn't been.
    ///
    /// <para>Archiving can't be undone. An archived store can't be attached to new
    /// sessions. You can't create or update its memories or update the store. You
    /// can still read and delete its memories, redact their versions, and delete
    /// the store.</para>
    ///
    /// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#archive-a-store)
    /// to learn more about archiving.</para>
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// When the memory store was created, in RFC 3339.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Free-text description of what the store contains, up to 1,024 characters.
    /// Included in the agent's system prompt when the store is attached, so word
    /// it to be useful to the agent. Empty string when unset.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Key-value pairs for your own use, such as the end user that the store belongs to.
    ///
    /// <para>A store has at most 16 pairs. Keys are 1 to 64 characters long and values
    /// at most 512 characters. You can't filter lists by metadata.</para>
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name for the store. 1–255 characters. The store's mount-path
    /// slug under `/mnt/memory/` is derived from this name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    /// <summary>
    /// When the memory store was last changed, in RFC 3339.
    ///
    /// <para>Changing its `name`, `description`, or `metadata` updates it. Archiving
    /// the store does too. Changes to the store's memories don't.</para>
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory_store")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaManagedAgentsMemoryStore()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStore(BetaManagedAgentsMemoryStore betaManagedAgentsMemoryStore)
        : base(betaManagedAgentsMemoryStore) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStore(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryStoreFromRaw : IFromRawJson<BetaManagedAgentsMemoryStore>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStore.FromRawUnchecked(rawData);
}
