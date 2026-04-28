using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    /// Unique identifier for the memory store (a `memstore_...` tagged ID). Use this
    /// when attaching the store to a session, or in the `{memory_store_id}` path
    /// parameter of subsequent calls.
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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
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

    public required ApiEnum<string, BetaManagedAgentsMemoryStoreType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsMemoryStoreType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Free-text description of what the store contains, up to 1024 characters. Included
    /// in the agent's system prompt when the store is attached, so word it to be
    /// useful to the agent. Empty string when unset.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Arbitrary key-value tags for your own bookkeeping (such as the end user a
    /// store belongs to). Up to 16 pairs; keys 1–64 characters; values up to 512
    /// characters. Returned on retrieve/list but not filterable.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.ArchivedAt;
        _ = this.Description;
        _ = this.Metadata;
    }

    public BetaManagedAgentsMemoryStore() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStore(BetaManagedAgentsMemoryStore betaManagedAgentsMemoryStore)
        : base(betaManagedAgentsMemoryStore) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStore(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(BetaManagedAgentsMemoryStoreTypeConverter))]
public enum BetaManagedAgentsMemoryStoreType
{
    MemoryStore,
}

sealed class BetaManagedAgentsMemoryStoreTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryStoreType>
{
    public override BetaManagedAgentsMemoryStoreType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaManagedAgentsMemoryStoreType.MemoryStore,
            _ => (BetaManagedAgentsMemoryStoreType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryStoreType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryStoreType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
