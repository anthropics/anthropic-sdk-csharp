using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// The memory store that holds a dream's result, as an entry in `outputs`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamMemoryStoreOutput, BetaDreamMemoryStoreOutputFromRaw>)
)]
public sealed record class BetaDreamMemoryStoreOutput : JsonModel
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

    public BetaDreamMemoryStoreOutput()
    {
        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamMemoryStoreOutput(BetaDreamMemoryStoreOutput betaDreamMemoryStoreOutput)
        : base(betaDreamMemoryStoreOutput) { }
#pragma warning restore CS8618

    public BetaDreamMemoryStoreOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("memory_store");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamMemoryStoreOutput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamMemoryStoreOutputFromRaw.FromRawUnchecked"/>
    public static BetaDreamMemoryStoreOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamMemoryStoreOutput(string memoryStoreID)
        : this()
    {
        this.MemoryStoreID = memoryStoreID;
    }
}

class BetaDreamMemoryStoreOutputFromRaw : IFromRawJson<BetaDreamMemoryStoreOutput>
{
    /// <inheritdoc/>
    public BetaDreamMemoryStoreOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamMemoryStoreOutput.FromRawUnchecked(rawData);
}
