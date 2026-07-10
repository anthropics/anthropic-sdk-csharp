using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// An input memory store the dream reads from. The dream never mutates this store.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamMemoryStoreInput, BetaDreamMemoryStoreInputFromRaw>)
)]
public sealed record class BetaDreamMemoryStoreInput : JsonModel
{
    public required string MemoryStoreID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("memory_store_id");
        }
        init { this._rawData.Set("memory_store_id", value); }
    }

    public required ApiEnum<string, BetaDreamMemoryStoreInputType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaDreamMemoryStoreInputType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        this.Type.Validate();
    }

    public BetaDreamMemoryStoreInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamMemoryStoreInput(BetaDreamMemoryStoreInput betaDreamMemoryStoreInput)
        : base(betaDreamMemoryStoreInput) { }
#pragma warning restore CS8618

    public BetaDreamMemoryStoreInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
}

class BetaDreamMemoryStoreInputFromRaw : IFromRawJson<BetaDreamMemoryStoreInput>
{
    /// <inheritdoc/>
    public BetaDreamMemoryStoreInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamMemoryStoreInput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaDreamMemoryStoreInputTypeConverter))]
public enum BetaDreamMemoryStoreInputType
{
    MemoryStore,
}

sealed class BetaDreamMemoryStoreInputTypeConverter : JsonConverter<BetaDreamMemoryStoreInputType>
{
    public override BetaDreamMemoryStoreInputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaDreamMemoryStoreInputType.MemoryStore,
            _ => (BetaDreamMemoryStoreInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamMemoryStoreInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaDreamMemoryStoreInputType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
