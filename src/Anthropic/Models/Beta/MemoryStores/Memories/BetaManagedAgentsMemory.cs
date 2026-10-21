using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// A text document at a path inside a memory store.
///
/// <para>`content` is `null` when the response uses `view=basic`. `content_size_bytes`
/// and `content_sha256` are always set, so you can detect changes without fetching
/// the content. To retrieve, update, or delete a memory, pass its ID, which stays
/// the same when its path changes.</para>
///
/// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#view-and-edit-memories)
/// to learn more about working with memories.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaManagedAgentsMemory, BetaManagedAgentsMemoryFromRaw>))]
public sealed record class BetaManagedAgentsMemory : JsonModel
{
    /// <summary>
    /// The unique ID of the memory (`mem_...`). It stays the same when the memory's
    /// path changes.
    ///
    /// <para>To retrieve, update, or delete the memory, pass this ID.</para>
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
    /// Lowercase hex SHA-256 digest of the UTF-8 `content` bytes (64 characters).
    /// The server applies no normalization, so clients can compute the same hash
    /// locally for staleness checks and as the value for a `content_sha256` precondition
    /// on update. Always populated, regardless of `view`.
    /// </summary>
    public required string ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content_sha256");
        }
        init { this._rawData.Set("content_sha256", value); }
    }

    /// <summary>
    /// The size of the memory's `content` in UTF-8 bytes. It is set regardless of `view`.
    /// </summary>
    public required int ContentSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("content_size_bytes");
        }
        init { this._rawData.Set("content_size_bytes", value); }
    }

    /// <summary>
    /// When this memory was created, in RFC 3339 format.
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
    /// ID of the memory store this memory belongs to (a `memstore_...` value).
    /// </summary>
    public required string MemoryStoreID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_store_id");
        }
        init { this._rawData.Set("memory_store_id", value); }
    }

    /// <summary>
    /// The ID of the memory version that holds the memory's current content (`memver_...`).
    ///
    /// <para>Memory versions don't have a flag that marks the latest one. Compare
    /// their IDs with this field instead.</para>
    ///
    /// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#audit-memory-changes)
    /// to learn more about memory versions.</para>
    /// </summary>
    public required string MemoryVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_version_id");
        }
        init { this._rawData.Set("memory_version_id", value); }
    }

    /// <summary>
    /// Hierarchical path of the memory within the store, e.g. `/projects/foo/notes.md`.
    /// Always starts with `/`. Paths are case-sensitive and unique within a store.
    /// Maximum 1,024 bytes.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
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
    /// When the memory was last changed, in RFC 3339.
    ///
    /// <para>To find out who made the change, look at `created_by` on the memory
    /// version that `memory_version_id` references.</para>
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

    /// <summary>
    /// The memory's UTF-8 text content, or `null` when the response uses `view=basic`.
    ///
    /// <para>The maximum size is 100 kB (102,400 bytes).</para>
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ContentSha256;
        _ = this.ContentSizeBytes;
        _ = this.CreatedAt;
        _ = this.MemoryStoreID;
        _ = this.MemoryVersionID;
        _ = this.Path;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.Content;
    }

    public BetaManagedAgentsMemory()
    {
        this.Type = JsonSerializer.SerializeToElement("memory");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemory(BetaManagedAgentsMemory betaManagedAgentsMemory)
        : base(betaManagedAgentsMemory) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryFromRaw : IFromRawJson<BetaManagedAgentsMemory>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemory.FromRawUnchecked(rawData);
}
