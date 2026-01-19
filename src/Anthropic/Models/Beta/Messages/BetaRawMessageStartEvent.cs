using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaRawMessageStartEvent, BetaRawMessageStartEventFromRaw>)
)]
public sealed record class BetaRawMessageStartEvent : JsonModel
{
    public required BetaMessage Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaMessage>("message");
        }
        init { this._rawData.Set("message", value); }
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
        this.Message.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("message_start")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawMessageStartEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("message_start");
    }

    public BetaRawMessageStartEvent(BetaRawMessageStartEvent betaRawMessageStartEvent)
        : base(betaRawMessageStartEvent) { }

    public BetaRawMessageStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawMessageStartEventFromRaw.FromRawUnchecked"/>
    public static BetaRawMessageStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRawMessageStartEvent(BetaMessage message)
        : this()
    {
        this.Message = message;
    }
}

class BetaRawMessageStartEventFromRaw : IFromRawJson<BetaRawMessageStartEvent>
{
    /// <inheritdoc/>
    public BetaRawMessageStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawMessageStartEvent.FromRawUnchecked(rawData);
}
