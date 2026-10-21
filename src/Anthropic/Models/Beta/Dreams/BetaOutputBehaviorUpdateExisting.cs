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
/// Write the result into the input memory store instead of a new memory store.
///
/// <para>The credential must be allowed to write memory stores, or the request returns
/// a 403 error. While another `update_existing` dream on the same memory store hasn't
/// fully stopped, the request returns a 409 error.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaOutputBehaviorUpdateExisting,
        BetaOutputBehaviorUpdateExistingFromRaw
    >)
)]
public sealed record class BetaOutputBehaviorUpdateExisting : JsonModel
{
    /// <summary>
    /// The ID of the memory store for the dream to write its result to (`memstore_...`).
    /// It must be the memory store in the `memory_store` entry of `inputs`.
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

    public required ApiEnum<string, BetaOutputBehaviorUpdateExistingType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaOutputBehaviorUpdateExistingType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryStoreID;
        this.Type.Validate();
    }

    public BetaOutputBehaviorUpdateExisting() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOutputBehaviorUpdateExisting(
        BetaOutputBehaviorUpdateExisting betaOutputBehaviorUpdateExisting
    )
        : base(betaOutputBehaviorUpdateExisting) { }
#pragma warning restore CS8618

    public BetaOutputBehaviorUpdateExisting(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOutputBehaviorUpdateExisting(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOutputBehaviorUpdateExistingFromRaw.FromRawUnchecked"/>
    public static BetaOutputBehaviorUpdateExisting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOutputBehaviorUpdateExistingFromRaw : IFromRawJson<BetaOutputBehaviorUpdateExisting>
{
    /// <inheritdoc/>
    public BetaOutputBehaviorUpdateExisting FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOutputBehaviorUpdateExisting.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaOutputBehaviorUpdateExistingTypeConverter))]
public enum BetaOutputBehaviorUpdateExistingType
{
    UpdateExisting,
}

sealed class BetaOutputBehaviorUpdateExistingTypeConverter
    : JsonConverter<BetaOutputBehaviorUpdateExistingType>
{
    public override BetaOutputBehaviorUpdateExistingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "update_existing" => BetaOutputBehaviorUpdateExistingType.UpdateExisting,
            _ => (BetaOutputBehaviorUpdateExistingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOutputBehaviorUpdateExistingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOutputBehaviorUpdateExistingType.UpdateExisting => "update_existing",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
