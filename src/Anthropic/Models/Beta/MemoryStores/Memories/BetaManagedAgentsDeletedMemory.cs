using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// Tombstone returned by [Delete a memory](/en/api/beta/memory_stores/memories/delete).
/// The memory's version history persists and remains listable via [List memory versions](/en/api/beta/memory_stores/memory_versions/list)
/// until the store itself is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedMemory,
        BetaManagedAgentsDeletedMemoryFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedMemory : JsonModel
{
    /// <summary>
    /// ID of the deleted memory (a `mem_...` value).
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

    public required ApiEnum<string, BetaManagedAgentsDeletedMemoryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeletedMemoryType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaManagedAgentsDeletedMemory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedMemory(
        BetaManagedAgentsDeletedMemory betaManagedAgentsDeletedMemory
    )
        : base(betaManagedAgentsDeletedMemory) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedMemory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedMemory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedMemoryFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedMemory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeletedMemoryFromRaw : IFromRawJson<BetaManagedAgentsDeletedMemory>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedMemory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedMemory.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeletedMemoryTypeConverter))]
public enum BetaManagedAgentsDeletedMemoryType
{
    MemoryDeleted,
}

sealed class BetaManagedAgentsDeletedMemoryTypeConverter
    : JsonConverter<BetaManagedAgentsDeletedMemoryType>
{
    public override BetaManagedAgentsDeletedMemoryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_deleted" => BetaManagedAgentsDeletedMemoryType.MemoryDeleted,
            _ => (BetaManagedAgentsDeletedMemoryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeletedMemoryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeletedMemoryType.MemoryDeleted => "memory_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
