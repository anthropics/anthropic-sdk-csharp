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
        get { return JsonModel.GetNotNullClass<BetaMessage>(this.RawData, "message"); }
        init { JsonModel.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Message.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"message_start\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawMessageStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

    public BetaRawMessageStartEvent(BetaRawMessageStartEvent betaRawMessageStartEvent)
        : base(betaRawMessageStartEvent) { }

    public BetaRawMessageStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
