using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Resources;

/// <summary>
/// A memory store attached to an agent session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryStoreResource,
        BetaManagedAgentsMemoryStoreResourceFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryStoreResource : JsonModel
{
    /// <summary>
    /// The memory store ID (memstore_...). Must belong to the caller's organization
    /// and workspace.
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

    public required ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryStoreResourceType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Access mode for an attached memory store.
    /// </summary>
    public ApiEnum<string, Access>? Access
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Access>>("access");
        }
        init { this._rawData.Set("access", value); }
    }

    /// <summary>
    /// Description of the memory store, snapshotted at attach time. Rendered into
    /// the agent's system prompt. Empty string when the store has no description.
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
    /// Per-attachment guidance for the agent on how to use this store. Rendered
    /// into the memory section of the system prompt. Max 4096 chars.
    /// </summary>
    public string? Instructions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("instructions");
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <summary>
    /// Filesystem path where the store is mounted in the session container, e.g.
    /// /mnt/memory/user-preferences. Derived from the store's name. Output-only.
    /// </summary>
    public string? MountPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mount_path");
        }
        init { this._rawData.Set("mount_path", value); }
    }

    /// <summary>
    /// Display name of the memory store, snapshotted at attach time. Later edits
    /// to the store's name do not propagate to this resource.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        this.Type.Validate();
        this.Access?.Validate();
        _ = this.Description;
        _ = this.Instructions;
        _ = this.MountPath;
        _ = this.Name;
    }

    public BetaManagedAgentsMemoryStoreResource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreResource(
        BetaManagedAgentsMemoryStoreResource betaManagedAgentsMemoryStoreResource
    )
        : base(betaManagedAgentsMemoryStoreResource) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStoreResource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStoreResource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreResourceFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStoreResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryStoreResourceFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryStoreResource>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStoreResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStoreResource.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryStoreResourceTypeConverter))]
public enum BetaManagedAgentsMemoryStoreResourceType
{
    MemoryStore,
}

sealed class BetaManagedAgentsMemoryStoreResourceTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryStoreResourceType>
{
    public override BetaManagedAgentsMemoryStoreResourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaManagedAgentsMemoryStoreResourceType.MemoryStore,
            _ => (BetaManagedAgentsMemoryStoreResourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryStoreResourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryStoreResourceType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Access mode for an attached memory store.
/// </summary>
[JsonConverter(typeof(AccessConverter))]
public enum Access
{
    ReadWrite,
    ReadOnly,
}

sealed class AccessConverter : JsonConverter<Access>
{
    public override Access Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "read_write" => Access.ReadWrite,
            "read_only" => Access.ReadOnly,
            _ => (Access)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Access value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Access.ReadWrite => "read_write",
                Access.ReadOnly => "read_only",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
