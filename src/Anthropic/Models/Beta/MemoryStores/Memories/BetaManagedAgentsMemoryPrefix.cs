using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// A directory marker that [List Memories](https://platform.claude.com/docs/en/api/beta/memory_stores/memories/list)
/// returns instead of the memories below the requested `depth`.
///
/// <para>It stands for one or more memories whose paths start with `path`. It isn't
/// a stored object and doesn't have an ID. Each marker counts toward the page `limit`.</para>
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Path;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory_prefix")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMemoryPrefix()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_prefix");
    }

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

        this.Type = JsonSerializer.SerializeToElement("memory_prefix");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryPrefix(string path)
        : this()
    {
        this.Path = path;
    }
}

class BetaManagedAgentsMemoryPrefixFromRaw : IFromRawJson<BetaManagedAgentsMemoryPrefix>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryPrefix FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryPrefix.FromRawUnchecked(rawData);
}
