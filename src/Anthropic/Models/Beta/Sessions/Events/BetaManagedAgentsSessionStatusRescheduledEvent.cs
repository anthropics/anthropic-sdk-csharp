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
/// Indicates the session is recovering from an error state and is rescheduled for execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionStatusRescheduledEvent,
        BetaManagedAgentsSessionStatusRescheduledEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionStatusRescheduledEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionStatusRescheduledEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionStatusRescheduledEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionStatusRescheduledEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionStatusRescheduledEvent(
        BetaManagedAgentsSessionStatusRescheduledEvent betaManagedAgentsSessionStatusRescheduledEvent
    )
        : base(betaManagedAgentsSessionStatusRescheduledEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionStatusRescheduledEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionStatusRescheduledEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionStatusRescheduledEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionStatusRescheduledEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionStatusRescheduledEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionStatusRescheduledEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionStatusRescheduledEventTypeConverter))]
public enum BetaManagedAgentsSessionStatusRescheduledEventType
{
    SessionStatusRescheduled,
}

sealed class BetaManagedAgentsSessionStatusRescheduledEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionStatusRescheduledEventType>
{
    public override BetaManagedAgentsSessionStatusRescheduledEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.status_rescheduled" =>
                BetaManagedAgentsSessionStatusRescheduledEventType.SessionStatusRescheduled,
            _ => (BetaManagedAgentsSessionStatusRescheduledEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionStatusRescheduledEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionStatusRescheduledEventType.SessionStatusRescheduled =>
                    "session.status_rescheduled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
