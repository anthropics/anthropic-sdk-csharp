using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaRawMessageStopEvent, BetaRawMessageStopEventFromRaw>))]
public sealed record class BetaRawMessageStopEvent : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("message_stop")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawMessageStopEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("message_stop");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRawMessageStopEvent(BetaRawMessageStopEvent betaRawMessageStopEvent)
        : base(betaRawMessageStopEvent) { }
#pragma warning restore CS8618

    public BetaRawMessageStopEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_stop");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageStopEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawMessageStopEventFromRaw.FromRawUnchecked"/>
    public static BetaRawMessageStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRawMessageStopEventFromRaw : IFromRawJson<BetaRawMessageStopEvent>
{
    /// <inheritdoc/>
    public BetaRawMessageStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawMessageStopEvent.FromRawUnchecked(rawData);
}
