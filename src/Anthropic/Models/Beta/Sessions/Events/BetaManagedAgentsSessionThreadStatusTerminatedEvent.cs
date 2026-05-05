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
/// A session thread has terminated and will accept no further input. Emitted on the
/// thread's own stream and cross-posted to the primary stream for child threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadStatusTerminatedEvent,
        BetaManagedAgentsSessionThreadStatusTerminatedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadStatusTerminatedEvent : JsonModel
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
    /// Public sthr_ ID of the thread that terminated.
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

    public required ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadStatusTerminatedEventType>
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

    public BetaManagedAgentsSessionThreadStatusTerminatedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadStatusTerminatedEvent(
        BetaManagedAgentsSessionThreadStatusTerminatedEvent betaManagedAgentsSessionThreadStatusTerminatedEvent
    )
        : base(betaManagedAgentsSessionThreadStatusTerminatedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadStatusTerminatedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadStatusTerminatedEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadStatusTerminatedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadStatusTerminatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadStatusTerminatedEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionThreadStatusTerminatedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadStatusTerminatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadStatusTerminatedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionThreadStatusTerminatedEventTypeConverter))]
public enum BetaManagedAgentsSessionThreadStatusTerminatedEventType
{
    SessionThreadStatusTerminated,
}

sealed class BetaManagedAgentsSessionThreadStatusTerminatedEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionThreadStatusTerminatedEventType>
{
    public override BetaManagedAgentsSessionThreadStatusTerminatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.thread_status_terminated" =>
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated,
            _ => (BetaManagedAgentsSessionThreadStatusTerminatedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadStatusTerminatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionThreadStatusTerminatedEventType.SessionThreadStatusTerminated =>
                    "session.thread_status_terminated",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
