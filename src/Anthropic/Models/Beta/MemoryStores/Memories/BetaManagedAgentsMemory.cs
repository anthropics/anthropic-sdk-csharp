using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

[JsonConverter(typeof(JsonModelConverter<BetaManagedAgentsMemory, BetaManagedAgentsMemoryFromRaw>))]
public sealed record class BetaManagedAgentsMemory : JsonModel
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

    public required string ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content_sha256");
        }
        init { this._rawData.Set("content_sha256", value); }
    }

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

    public required string MemoryStoreID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_store_id");
        }
        init { this._rawData.Set("memory_store_id", value); }
    }

    public required string MemoryVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_version_id");
        }
        init { this._rawData.Set("memory_version_id", value); }
    }

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsMemoryType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsMemoryType>>(
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
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.Content;
    }

    public BetaManagedAgentsMemory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemory(BetaManagedAgentsMemory betaManagedAgentsMemory)
        : base(betaManagedAgentsMemory) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

[JsonConverter(typeof(BetaManagedAgentsMemoryTypeConverter))]
public enum BetaManagedAgentsMemoryType
{
    Memory,
}

sealed class BetaManagedAgentsMemoryTypeConverter : JsonConverter<BetaManagedAgentsMemoryType>
{
    public override BetaManagedAgentsMemoryType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory" => BetaManagedAgentsMemoryType.Memory,
            _ => (BetaManagedAgentsMemoryType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryType.Memory => "memory",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
