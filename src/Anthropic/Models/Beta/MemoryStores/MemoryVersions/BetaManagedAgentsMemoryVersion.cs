using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// One entry in a memory's history, recording a single change and who made it.
///
/// <para>Every change to a memory adds one version. Only redaction can change a version
/// after that. Versions belong to the memory store and stay after the memory is
/// deleted. Each version is retained for at least the version retention period after
/// it was written, unless the store itself is deleted.</para>
///
/// <para>Retrieving a redacted version succeeds, with `content`, `path`, `content_size_bytes`,
/// and `content_sha256` set to `null`. Check `redacted_at` to find out whether a
/// version was redacted.</para>
///
/// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#audit-memory-changes)
/// to learn more about memory versions.</para>
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
    /// When this version was written, in RFC 3339 format.
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
    /// The ID of the memory that this version belongs to (`mem_...`).
    ///
    /// <para>The ID stays valid after the memory is deleted. Pass it as `memory_id`
    /// to [List Memory Versions](https://platform.claude.com/docs/en/api/beta/memory_stores/memory_versions/list)
    /// to get the memory's retained versions, including its `deleted` version while
    /// the lineage is retained.</para>
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
    /// The kind of mutation this version records: `created`, `modified`, or `deleted`.
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
    /// Who made this change to the memory, or `null` if the author wasn't recorded.
    ///
    /// <para>Redacting the version doesn't change this field. A `session_actor` here
    /// is an agent that wrote through the store's mounted filesystem at `/mnt/memory/`.
    /// The version doesn't record the API key that created that session. So the author
    /// in `created_by` is who made the change, not who is ultimately responsible
    /// for it.</para>
    ///
    /// <para>You can [retrieve the session](https://platform.claude.com/docs/en/api/beta/sessions/retrieve)
    /// to learn more about where the change came from.</para>
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
                this._rawData.Remove("created_by");
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
    /// When the version was redacted, in RFC 3339, or `null` if it hasn't been.
    ///
    /// <para>When set, `content`, `path`, `content_size_bytes`, and `content_sha256`
    /// are `null`.</para>
    ///
    /// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#redact-a-version)
    /// to learn more about redaction.</para>
    /// </summary>
    public DateTimeOffset? RedactedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("redacted_at");
        }
        init { this._rawData.Set("redacted_at", value); }
    }

    /// <summary>
    /// Who redacted this version, or `null` if it has not been redacted. In practice
    /// always an `api_actor`, `user_actor`, or `service_account_actor` (agents do
    /// not have a redact capability).
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
                this._rawData.Remove("redacted_by");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory_version")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Content;
        _ = this.ContentSha256;
        _ = this.ContentSizeBytes;
        this.CreatedBy?.Validate();
        _ = this.Path;
        _ = this.RedactedAt;
        this.RedactedBy?.Validate();
    }

    public BetaManagedAgentsMemoryVersion()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_version");
    }

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

        this.Type = JsonSerializer.SerializeToElement("memory_version");
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
