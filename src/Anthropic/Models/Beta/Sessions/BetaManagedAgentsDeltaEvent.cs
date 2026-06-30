using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// An incremental update to an event that is still being streamed. Deltas are best-effort
/// and may stop early; when the buffered event with id == event_id is produced it
/// carries the complete content. A model request that ends early (an error or interrupt)
/// produces no buffered event — its terminal span.model_request_end closes the preview.
/// Only sent on stream connections that opt in via event_deltas; never appears in
/// event history.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsDeltaEvent, BetaManagedAgentsDeltaEventFromRaw>)
)]
public sealed record class BetaManagedAgentsDeltaEvent : JsonModel
{
    /// <summary>
    /// One fragment of the previewed event. The delta type is named for the previewed
    /// event's field it streams into: agent.message events stream content_delta fragments,
    /// each a partial element of the content array.
    /// </summary>
    public required BetaManagedAgentsDeltaContent Delta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsDeltaContent>("delta");
        }
        init { this._rawData.Set("delta", value); }
    }

    /// <summary>
    /// The id of the event being previewed. Matches event.id on the corresponding
    /// event_start and the buffered event that reconciles the preview.
    /// </summary>
    public required string EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_id");
        }
        init { this._rawData.Set("event_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsDeltaEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsDeltaEventType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Delta.Validate();
        _ = this.EventID;
        this.Type.Validate();
    }

    public BetaManagedAgentsDeltaEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeltaEvent(BetaManagedAgentsDeltaEvent betaManagedAgentsDeltaEvent)
        : base(betaManagedAgentsDeltaEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeltaEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeltaEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeltaEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeltaEventFromRaw : IFromRawJson<BetaManagedAgentsDeltaEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeltaEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeltaEventTypeConverter))]
public enum BetaManagedAgentsDeltaEventType
{
    EventDelta,
}

sealed class BetaManagedAgentsDeltaEventTypeConverter
    : JsonConverter<BetaManagedAgentsDeltaEventType>
{
    public override BetaManagedAgentsDeltaEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "event_delta" => BetaManagedAgentsDeltaEventType.EventDelta,
            _ => (BetaManagedAgentsDeltaEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeltaEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeltaEventType.EventDelta => "event_delta",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
