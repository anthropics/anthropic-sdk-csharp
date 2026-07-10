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
/// An output memory store the dream writes consolidated memories into.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamMemoryStoreOutput, BetaDreamMemoryStoreOutputFromRaw>)
)]
public sealed record class BetaDreamMemoryStoreOutput : JsonModel
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

    public required ApiEnum<string, BetaDreamMemoryStoreOutputType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaDreamMemoryStoreOutputType>>(
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

    public BetaDreamMemoryStoreOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamMemoryStoreOutput(BetaDreamMemoryStoreOutput betaDreamMemoryStoreOutput)
        : base(betaDreamMemoryStoreOutput) { }
#pragma warning restore CS8618

    public BetaDreamMemoryStoreOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
}

class BetaDreamMemoryStoreOutputFromRaw : IFromRawJson<BetaDreamMemoryStoreOutput>
{
    /// <inheritdoc/>
    public BetaDreamMemoryStoreOutput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamMemoryStoreOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaDreamMemoryStoreOutputTypeConverter))]
public enum BetaDreamMemoryStoreOutputType
{
    MemoryStore,
}

sealed class BetaDreamMemoryStoreOutputTypeConverter : JsonConverter<BetaDreamMemoryStoreOutputType>
{
    public override BetaDreamMemoryStoreOutputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaDreamMemoryStoreOutputType.MemoryStore,
            _ => (BetaDreamMemoryStoreOutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamMemoryStoreOutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaDreamMemoryStoreOutputType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
