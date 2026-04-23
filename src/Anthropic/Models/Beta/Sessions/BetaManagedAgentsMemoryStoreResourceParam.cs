using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Parameters for attaching a memory store to an agent session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryStoreResourceParam,
        BetaManagedAgentsMemoryStoreResourceParamFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryStoreResourceParam : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryStoreResourceParamType>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        this.Type.Validate();
        this.Access?.Validate();
        _ = this.Instructions;
    }

    public BetaManagedAgentsMemoryStoreResourceParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryStoreResourceParam(
        BetaManagedAgentsMemoryStoreResourceParam betaManagedAgentsMemoryStoreResourceParam
    )
        : base(betaManagedAgentsMemoryStoreResourceParam) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryStoreResourceParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryStoreResourceParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryStoreResourceParamFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryStoreResourceParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryStoreResourceParamFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryStoreResourceParam>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryStoreResourceParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryStoreResourceParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryStoreResourceParamTypeConverter))]
public enum BetaManagedAgentsMemoryStoreResourceParamType
{
    MemoryStore,
}

sealed class BetaManagedAgentsMemoryStoreResourceParamTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryStoreResourceParamType>
{
    public override BetaManagedAgentsMemoryStoreResourceParamType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore,
            _ => (BetaManagedAgentsMemoryStoreResourceParamType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryStoreResourceParamType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryStoreResourceParamType.MemoryStore => "memory_store",
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
