using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Opens a preview of a buffered event. Carries the previewed event's type and id
/// only. Followed by zero or more event_delta events with the same event id, normally
/// concluded by the buffered event carrying that id. If the producing model request
/// ends without that event (an error or interrupt mid-stream), its terminal span.model_request_end
/// closes the preview. Only sent on stream connections that opt in via event_deltas;
/// never appears in event history.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsStartEvent, BetaManagedAgentsStartEventFromRaw>)
)]
public sealed record class BetaManagedAgentsStartEvent : JsonModel
{
    /// <summary>
    /// The previewed event's type and id. The event type determines which delta
    /// types the preview's event_delta events carry: agent.message events stream
    /// content_delta fragments; agent.thinking previews are start-only — no deltas
    /// follow, and the buffered agent.thinking with the same id concludes them.
    /// </summary>
    public required BetaManagedAgentsStartEventPreview Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsStartEventPreview>("event");
        }
        init { this._rawData.Set("event", value); }
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
        this.Event.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("event_start")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsStartEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("event_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStartEvent(BetaManagedAgentsStartEvent betaManagedAgentsStartEvent)
        : base(betaManagedAgentsStartEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("event_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStartEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsStartEvent(BetaManagedAgentsStartEventPreview event_)
        : this()
    {
        this.Event = event_;
    }
}

class BetaManagedAgentsStartEventFromRaw : IFromRawJson<BetaManagedAgentsStartEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStartEvent.FromRawUnchecked(rawData);
}
