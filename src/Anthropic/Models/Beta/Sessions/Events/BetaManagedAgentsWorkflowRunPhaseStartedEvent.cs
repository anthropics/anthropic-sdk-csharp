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
/// A workflow run's plan entered a phase.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunPhaseStartedEvent,
        BetaManagedAgentsWorkflowRunPhaseStartedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunPhaseStartedEvent : JsonModel
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
    /// Timestamp when this event was processed.
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
    /// Identifier of the run. The same value is on all of the run's `workflow_run.*` events.
    /// </summary>
    public required string WorkflowRunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflow_run_id");
        }
        init { this._rawData.Set("workflow_run_id", value); }
    }

    /// <summary>
    /// Identifier of the phase, as in `phases` on the run's `workflow_run.created` event.
    /// </summary>
    public required string WorkflowRunPhaseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workflow_run_phase_id");
        }
        init { this._rawData.Set("workflow_run_phase_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workflow_run.phase_started")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
        _ = this.WorkflowRunPhaseID;
    }

    public BetaManagedAgentsWorkflowRunPhaseStartedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("workflow_run.phase_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunPhaseStartedEvent(
        BetaManagedAgentsWorkflowRunPhaseStartedEvent betaManagedAgentsWorkflowRunPhaseStartedEvent
    )
        : base(betaManagedAgentsWorkflowRunPhaseStartedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunPhaseStartedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workflow_run.phase_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunPhaseStartedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunPhaseStartedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunPhaseStartedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunPhaseStartedEventFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunPhaseStartedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunPhaseStartedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunPhaseStartedEvent.FromRawUnchecked(rawData);
}
