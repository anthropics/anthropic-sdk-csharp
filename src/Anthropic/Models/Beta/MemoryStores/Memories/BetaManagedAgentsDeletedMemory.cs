using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// The confirmation that [Delete a Memory](https://platform.claude.com/docs/en/api/beta/memory_stores/memories/delete) returns.
///
/// <para>Deleting a memory doesn't delete its versions. [List Memory Versions](https://platform.claude.com/docs/en/api/beta/memory_stores/memory_versions/list)
/// returns them while they are retained: each version is kept for at least the version
/// retention period after it was written, unless the store itself is deleted.</para>
///
/// <para>See the [memory guide](https://platform.claude.com/docs/en/managed-agents/memory#audit-memory-changes)
/// to learn more about how long versions are kept.</para>
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeletedMemory()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_deleted");
    }

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

        this.Type = JsonSerializer.SerializeToElement("memory_deleted");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedMemory(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeletedMemoryFromRaw : IFromRawJson<BetaManagedAgentsDeletedMemory>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedMemory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedMemory.FromRawUnchecked(rawData);
}
