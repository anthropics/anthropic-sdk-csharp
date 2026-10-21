using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// Timestamp of the status transition.
    /// </summary>
    public required DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("processed_at");
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
        _ = this.ID;
        _ = this.AgentName;
        _ = this.ProcessedAt;
        _ = this.SessionThreadID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session.thread_status_terminated")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionThreadStatusTerminatedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("session.thread_status_terminated");
    }

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

        this.Type = JsonSerializer.SerializeToElement("session.thread_status_terminated");
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
