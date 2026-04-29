using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// A `memory_version` object: one immutable, attributed row in a memory's append-only
/// history. Every non-no-op mutation to a memory produces a new version. Versions
/// belong to the store (not the individual memory) and persist after the memory
/// is deleted. Retrieving a redacted version returns 200 with `content`, `path`,
/// `content_size_bytes`, and `content_sha256` set to `null`; branch on `redacted_at`,
/// not HTTP status.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryVersion,
        BetaManagedAgentsMemoryVersionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryVersion : JsonModel
{
    /// <summary>
    /// Unique identifier for this version (a `memver_...` value).
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
    /// ID of the memory this version snapshots (a `mem_...` value). Remains valid
    /// after the memory is deleted; pass it as `memory_id` to [List memory versions](/en/api/beta/memory_stores/memory_versions/list)
    /// to retrieve the full lineage including the `deleted` row.
    /// </summary>
    public required string MemoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_id");
        }
        init { this._rawData.Set("memory_id", value); }
    }

    /// <summary>
    /// ID of the memory store this version belongs to (a `memstore_...` value).
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
    /// The kind of mutation a `memory_version` records. Every non-no-op mutation
    /// to a memory appends exactly one version row with one of these values.
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

    /// <summary>
    /// The memory's UTF-8 text content as of this version. `null` when `view=basic`,
    /// when `operation` is `deleted`, or when `redacted_at` is set.
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

    /// <summary>
    /// Lowercase hex SHA-256 digest of `content` as of this version (64 characters).
    /// `null` when `redacted_at` is set or `operation` is `deleted`. Populated regardless
    /// of `view` otherwise.
    /// </summary>
    public string? ContentSha256
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_sha256");
        }
        init { this._rawData.Set("content_sha256", value); }
    }

    /// <summary>
    /// Size of `content` in bytes as of this version. `null` when `redacted_at`
    /// is set or `operation` is `deleted`. Populated regardless of `view` otherwise.
    /// </summary>
    public int? ContentSizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("content_size_bytes");
        }
        init { this._rawData.Set("content_size_bytes", value); }
    }

    /// <summary>
    /// Identifies who performed a write or redact operation. Captured at write time
    /// on the `memory_version` row. The API key that created a session is not recorded
    /// on agent writes; attribution answers who made the write, not who is ultimately
    /// responsible. Look up session provenance separately via the [Sessions API](/en/api/sessions-retrieve).
    /// </summary>
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

    /// <summary>
    /// The memory's path at the time of this write. `null` if and only if `redacted_at`
    /// is set.
    /// </summary>
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

    /// <summary>
    /// Identifies who performed a write or redact operation. Captured at write time
    /// on the `memory_version` row. The API key that created a session is not recorded
    /// on agent writes; attribution answers who made the write, not who is ultimately
    /// responsible. Look up session provenance separately via the [Sessions API](/en/api/sessions-retrieve).
    /// </summary>
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
