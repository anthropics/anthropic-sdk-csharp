using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedMemoryStore,
        BetaManagedAgentsDeletedMemoryStoreFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedMemoryStore : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.MemoryStores.Type>
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

    public BetaManagedAgentsDeletedMemoryStore() { }

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
}

class BetaManagedAgentsDeletedMemoryStoreFromRaw : IFromRawJson<BetaManagedAgentsDeletedMemoryStore>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedMemoryStore FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedMemoryStore.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    MemoryStoreDeleted,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.MemoryStores.Type>
{
    public override global::Anthropic.Models.Beta.MemoryStores.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store_deleted" => global::Anthropic
                .Models
                .Beta
                .MemoryStores
                .Type
                .MemoryStoreDeleted,
            _ => (global::Anthropic.Models.Beta.MemoryStores.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.MemoryStores.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.MemoryStores.Type.MemoryStoreDeleted =>
                    "memory_store_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
