using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// An entry in a dream's `outputs` that references the memory store holding its result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamOutput, BetaDreamOutputFromRaw>))]
public sealed record class BetaDreamOutput : JsonModel
{
    /// <summary>
    /// The ID of the memory store that the dream writes its result to (`memstore_...`).
    ///
    /// <para>With `output_behavior` set to `create_new`, this is a new memory store.
    /// With `update_existing`, it is the input memory store.</para>
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

    public BetaDreamOutput()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamOutput(BetaDreamOutput betaDreamOutput)
        : base(betaDreamOutput) { }
#pragma warning restore CS8618

    public BetaDreamOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamOutputFromRaw.FromRawUnchecked"/>
    public static BetaDreamOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamOutput(string memoryStoreID)
        : this()
    {
        this.MemoryStoreID = memoryStoreID;
    }
}

class BetaDreamOutputFromRaw : IFromRawJson<BetaDreamOutput>
{
    /// <inheritdoc/>
    public BetaDreamOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDreamOutput.FromRawUnchecked(rawData);
}
