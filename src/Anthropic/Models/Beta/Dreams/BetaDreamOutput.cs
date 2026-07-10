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
[JsonConverter(typeof(JsonModelConverter<BetaDreamOutput, BetaDreamOutputFromRaw>))]
public sealed record class BetaDreamOutput : JsonModel
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

    public required ApiEnum<string, BetaDreamOutputType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaDreamOutputType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        this.Type.Validate();
    }

    public BetaDreamOutput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamOutput(BetaDreamOutput betaDreamOutput)
        : base(betaDreamOutput) { }
#pragma warning restore CS8618

    public BetaDreamOutput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
}

class BetaDreamOutputFromRaw : IFromRawJson<BetaDreamOutput>
{
    /// <inheritdoc/>
    public BetaDreamOutput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDreamOutput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaDreamOutputTypeConverter))]
public enum BetaDreamOutputType
{
    MemoryStore,
}

sealed class BetaDreamOutputTypeConverter : JsonConverter<BetaDreamOutputType>
{
    public override BetaDreamOutputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_store" => BetaDreamOutputType.MemoryStore,
            _ => (BetaDreamOutputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamOutputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaDreamOutputType.MemoryStore => "memory_store",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
