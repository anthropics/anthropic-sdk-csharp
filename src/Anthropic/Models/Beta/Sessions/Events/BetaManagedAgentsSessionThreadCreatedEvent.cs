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
/// Emitted when a subagent is spawned as a new thread. Written to the parent thread's
/// output stream so clients observing the session see child creation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionThreadCreatedEvent,
        BetaManagedAgentsSessionThreadCreatedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionThreadCreatedEvent : JsonModel
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
    /// Name of the callable agent the thread runs.
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
    /// Public `sthr_` ID of the newly created thread.
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

    public required ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionThreadCreatedEventType>
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

    public BetaManagedAgentsSessionThreadCreatedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionThreadCreatedEvent(
        BetaManagedAgentsSessionThreadCreatedEvent betaManagedAgentsSessionThreadCreatedEvent
    )
        : base(betaManagedAgentsSessionThreadCreatedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionThreadCreatedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionThreadCreatedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionThreadCreatedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionThreadCreatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionThreadCreatedEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionThreadCreatedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionThreadCreatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionThreadCreatedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionThreadCreatedEventTypeConverter))]
public enum BetaManagedAgentsSessionThreadCreatedEventType
{
    SessionThreadCreated,
}

sealed class BetaManagedAgentsSessionThreadCreatedEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionThreadCreatedEventType>
{
    public override BetaManagedAgentsSessionThreadCreatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.thread_created" =>
                BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated,
            _ => (BetaManagedAgentsSessionThreadCreatedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionThreadCreatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionThreadCreatedEventType.SessionThreadCreated =>
                    "session.thread_created",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
