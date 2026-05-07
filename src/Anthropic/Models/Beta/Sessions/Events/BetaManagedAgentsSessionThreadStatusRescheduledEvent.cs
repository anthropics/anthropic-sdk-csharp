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
/// A session thread hit a transient error and is retrying automatically. Emitted
/// on the thread's own stream and cross-posted to the primary stream for child threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadStatusRescheduledEvent,
        BetaManagedAgentsSessionThreadStatusRescheduledEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadStatusRescheduledEvent : JsonModel
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
    /// Name of the agent the thread runs.
    /// </summary>
    public required string AgentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agent_name");
        }
        init { this._rawData.Set("agent_name", value); }
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

    /// <summary>
    /// Public sthr_ ID of the thread that is retrying.
    /// </summary>
    public required string SessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_thread_id");
        }
        init { this._rawData.Set("session_thread_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionThreadStatusRescheduledEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadStatusRescheduledEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentName;
        _ = this.ProcessedAt;
        _ = this.SessionThreadID;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionThreadStatusRescheduledEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadStatusRescheduledEvent(
        BetaManagedAgentsSessionThreadStatusRescheduledEvent betaManagedAgentsSessionThreadStatusRescheduledEvent
    )
        : base(betaManagedAgentsSessionThreadStatusRescheduledEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadStatusRescheduledEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadStatusRescheduledEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadStatusRescheduledEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadStatusRescheduledEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionThreadStatusRescheduledEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadStatusRescheduledEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionThreadStatusRescheduledEventTypeConverter))]
public enum BetaManagedAgentsSessionThreadStatusRescheduledEventType
{
    SessionThreadStatusRescheduled,
}

sealed class BetaManagedAgentsSessionThreadStatusRescheduledEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionThreadStatusRescheduledEventType>
{
    public override BetaManagedAgentsSessionThreadStatusRescheduledEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.thread_status_rescheduled" =>
                BetaManagedAgentsSessionThreadStatusRescheduledEventType.SessionThreadStatusRescheduled,
            _ => (BetaManagedAgentsSessionThreadStatusRescheduledEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadStatusRescheduledEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionThreadStatusRescheduledEventType.SessionThreadStatusRescheduled =>
                    "session.thread_status_rescheduled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
