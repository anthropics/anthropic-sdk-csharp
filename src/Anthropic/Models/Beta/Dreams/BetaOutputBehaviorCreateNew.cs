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
/// The default destination: the job creates a new output memory store as a clone
/// of the memory_store input and writes the consolidated memories into it. The input
/// store is never mutated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaOutputBehaviorCreateNew, BetaOutputBehaviorCreateNewFromRaw>)
)]
public sealed record class BetaOutputBehaviorCreateNew : JsonModel
{
    public required ApiEnum<string, BetaOutputBehaviorCreateNewType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaOutputBehaviorCreateNewType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaOutputBehaviorCreateNew() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOutputBehaviorCreateNew(BetaOutputBehaviorCreateNew betaOutputBehaviorCreateNew)
        : base(betaOutputBehaviorCreateNew) { }
#pragma warning restore CS8618

    public BetaOutputBehaviorCreateNew(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOutputBehaviorCreateNew(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOutputBehaviorCreateNewFromRaw.FromRawUnchecked"/>
    public static BetaOutputBehaviorCreateNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOutputBehaviorCreateNew(ApiEnum<string, BetaOutputBehaviorCreateNewType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaOutputBehaviorCreateNewFromRaw : IFromRawJson<BetaOutputBehaviorCreateNew>
{
    /// <inheritdoc/>
    public BetaOutputBehaviorCreateNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOutputBehaviorCreateNew.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaOutputBehaviorCreateNewTypeConverter))]
public enum BetaOutputBehaviorCreateNewType
{
    CreateNew,
}

sealed class BetaOutputBehaviorCreateNewTypeConverter
    : JsonConverter<BetaOutputBehaviorCreateNewType>
{
    public override BetaOutputBehaviorCreateNewType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "create_new" => BetaOutputBehaviorCreateNewType.CreateNew,
            _ => (BetaOutputBehaviorCreateNewType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOutputBehaviorCreateNewType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOutputBehaviorCreateNewType.CreateNew => "create_new",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
