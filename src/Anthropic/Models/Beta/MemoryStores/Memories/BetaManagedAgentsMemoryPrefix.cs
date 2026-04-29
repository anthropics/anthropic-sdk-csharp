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
/// A rolled-up directory marker returned by [List memories](/en/api/beta/memory_stores/memories/list)
/// when `depth` is set. Indicates that one or more memories exist deeper than the
/// requested depth under this prefix. This is a list-time rollup, not a stored resource;
/// it has no ID and no lifecycle. Each prefix counts toward the page `limit` and
/// interleaves with `memory` items in path order.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsMemoryPrefix, BetaManagedAgentsMemoryPrefixFromRaw>)
)]
public sealed record class BetaManagedAgentsMemoryPrefix : JsonModel
{
    /// <summary>
    /// The rolled-up path prefix, including a trailing `/` (e.g. `/projects/foo/`).
    /// Pass this value as `path_prefix` on a subsequent list call to drill into the directory.
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

    public required ApiEnum<string, BetaManagedAgentsMemoryPrefixType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryPrefixType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Path;
        this.Type.Validate();
    }

    public BetaManagedAgentsMemoryPrefix() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryPrefix(
        BetaManagedAgentsMemoryPrefix betaManagedAgentsMemoryPrefix
    )
        : base(betaManagedAgentsMemoryPrefix) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryPrefix(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryPrefix(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryPrefixFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryPrefix FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMemoryPrefixFromRaw : IFromRawJson<BetaManagedAgentsMemoryPrefix>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryPrefix FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryPrefix.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryPrefixTypeConverter))]
public enum BetaManagedAgentsMemoryPrefixType
{
    MemoryPrefix,
}

sealed class BetaManagedAgentsMemoryPrefixTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryPrefixType>
{
    public override BetaManagedAgentsMemoryPrefixType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_prefix" => BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
            _ => (BetaManagedAgentsMemoryPrefixType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryPrefixType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryPrefixType.MemoryPrefix => "memory_prefix",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
