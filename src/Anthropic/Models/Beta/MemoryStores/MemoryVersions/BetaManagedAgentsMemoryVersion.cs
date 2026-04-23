using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryVersion,
        BetaManagedAgentsMemoryVersionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryVersion : JsonModel
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

    public required string MemoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_id");
        }
        init { this._rawData.Set("memory_id", value); }
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

    /// <summary>
    /// MemoryVersionOperation enum
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsMemoryVersionOperation> Operation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryVersionOperation>
            >("operation");
        }
        init { this._rawData.Set("operation", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsMemoryVersionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryVersionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
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

    public string? ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_sha256");
        }
        init { this._rawData.Set("content_sha256", value); }
    }

    public int? ContentSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("content_size_bytes");
        }
        init { this._rawData.Set("content_size_bytes", value); }
    }

    public BetaManagedAgentsActor? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsActor>("created_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_by", value);
        }
    }

    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? RedactedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("redacted_at");
        }
        init { this._rawData.Set("redacted_at", value); }
    }

    public BetaManagedAgentsActor? RedactedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsActor>("redacted_by");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("redacted_by", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.MemoryID;
        _ = this.MemoryStoreID;
        this.Operation.Validate();
        this.Type.Validate();
        _ = this.Content;
        _ = this.ContentSha256;
        _ = this.ContentSizeBytes;
        this.CreatedBy?.Validate();
        _ = this.Path;
        _ = this.RedactedAt;
        this.RedactedBy?.Validate();
    }

    public BetaManagedAgentsMemoryVersion() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryVersion(
        BetaManagedAgentsMemoryVersion betaManagedAgentsMemoryVersion
    )
        : base(betaManagedAgentsMemoryVersion) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryVersion(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryVersion(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryVersionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryVersion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryVersionFromRaw : IFromRawJson<BetaManagedAgentsMemoryVersion>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryVersion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryVersion.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryVersionTypeConverter))]
public enum BetaManagedAgentsMemoryVersionType
{
    MemoryVersion,
}

sealed class BetaManagedAgentsMemoryVersionTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryVersionType>
{
    public override BetaManagedAgentsMemoryVersionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_version" => BetaManagedAgentsMemoryVersionType.MemoryVersion,
            _ => (BetaManagedAgentsMemoryVersionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryVersionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryVersionType.MemoryVersion => "memory_version",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
