using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("end_turn")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionEndTurn()
    {
        this.Type = JsonSerializer.SerializeToElement("end_turn");
    }

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

        this.Type = JsonSerializer.SerializeToElement("end_turn");
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
}

class BetaManagedAgentsSessionEndTurnFromRaw : IFromRawJson<BetaManagedAgentsSessionEndTurn>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionEndTurn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionEndTurn.FromRawUnchecked(rawData);
}
