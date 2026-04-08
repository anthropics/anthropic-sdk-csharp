using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The agent completed its turn naturally and is ready for the next user message.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionEndTurn,
        BetaManagedAgentsSessionEndTurnFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionEndTurn : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsSessionEndTurnType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionEndTurnType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionEndTurn() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionEndTurn(
        BetaManagedAgentsSessionEndTurn betaManagedAgentsSessionEndTurn
    )
        : base(betaManagedAgentsSessionEndTurn) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionEndTurn(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionEndTurn(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionEndTurnFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionEndTurn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionEndTurn(
        ApiEnum<string, BetaManagedAgentsSessionEndTurnType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsSessionEndTurnFromRaw : IFromRawJson<BetaManagedAgentsSessionEndTurn>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionEndTurn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionEndTurn.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionEndTurnTypeConverter))]
public enum BetaManagedAgentsSessionEndTurnType
{
    EndTurn,
}

sealed class BetaManagedAgentsSessionEndTurnTypeConverter
    : JsonConverter<BetaManagedAgentsSessionEndTurnType>
{
    public override BetaManagedAgentsSessionEndTurnType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "end_turn" => BetaManagedAgentsSessionEndTurnType.EndTurn,
            _ => (BetaManagedAgentsSessionEndTurnType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionEndTurnType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionEndTurnType.EndTurn => "end_turn",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
