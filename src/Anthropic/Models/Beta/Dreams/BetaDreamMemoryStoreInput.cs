using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// The memory store that a dream reads, given as an entry in `inputs`.
///
/// <para>With `output_behavior` set to `update_existing`, the dream writes its result
/// into this memory store. Otherwise the dream doesn't change it.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamMemoryStoreInput, BetaDreamMemoryStoreInputFromRaw>)
)]
public sealed record class BetaDreamMemoryStoreInput : JsonModel
{
    /// <summary>
    /// The ID of the memory store for the dream to read (`memstore_...`).
    ///
    /// <para>The memory store must be in the same workspace as the dream and must
    /// not be archived.</para>
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
        _ = this.MemoryStoreID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("memory_store")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDreamMemoryStoreInput()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamMemoryStoreInput(BetaDreamMemoryStoreInput betaDreamMemoryStoreInput)
        : base(betaDreamMemoryStoreInput) { }
#pragma warning restore CS8618

    public BetaDreamMemoryStoreInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamMemoryStoreInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamMemoryStoreInputFromRaw.FromRawUnchecked"/>
    public static BetaDreamMemoryStoreInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamMemoryStoreInput(string memoryStoreID)
        : this()
    {
        this.MemoryStoreID = memoryStoreID;
    }
}

class BetaDreamMemoryStoreInputFromRaw : IFromRawJson<BetaDreamMemoryStoreInput>
{
    /// <inheritdoc/>
    public BetaDreamMemoryStoreInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamMemoryStoreInput.FromRawUnchecked(rawData);
}
