using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RawMessageStopEvent, RawMessageStopEventFromRaw>))]
public sealed record class RawMessageStopEvent : JsonModel
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

    public RawMessageStopEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("message_stop");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RawMessageStopEvent(RawMessageStopEvent rawMessageStopEvent)
        : base(rawMessageStopEvent) { }
#pragma warning restore CS8618

    public RawMessageStopEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("message_stop");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageStopEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RawMessageStopEventFromRaw.FromRawUnchecked"/>
    public static RawMessageStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RawMessageStopEventFromRaw : IFromRawJson<RawMessageStopEvent>
{
    /// <inheritdoc/>
    public RawMessageStopEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RawMessageStopEvent.FromRawUnchecked(rawData);
}
