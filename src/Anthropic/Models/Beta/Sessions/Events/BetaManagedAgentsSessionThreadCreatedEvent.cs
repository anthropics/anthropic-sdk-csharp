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
/// Emitted when a child thread is created. Written to the parent thread's output
/// stream so clients observing the session see child creation.
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
    /// Timestamp when the thread was created.
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Identifier of the workflow run that created the thread, or `null` for any
    /// other thread.
    /// </summary>
    public required string? WorkflowRunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workflow_run_id");
        }
        init { this._rawData.Set("workflow_run_id", value); }
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
                JsonSerializer.SerializeToElement("session.thread_created")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
    }

    public BetaManagedAgentsSessionThreadCreatedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("session.thread_created");
    }

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

        this.Type = JsonSerializer.SerializeToElement("session.thread_created");
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
