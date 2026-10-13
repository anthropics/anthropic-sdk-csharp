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
/// A workflow run's plan left a phase, or the run's end closed it. Emitted once for
/// every `workflow_run.phase_started` event, before the run's `workflow_run.status_ended`
/// event. The event does not say whether the plan finished the phase's work, or why
/// it left.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunPhaseEndedEvent,
        BetaManagedAgentsWorkflowRunPhaseEndedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunPhaseEndedEvent : JsonModel
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
    /// Identifier of the `workflow_run.phase_started` event that opened the phase.
    /// </summary>
    public required string PhaseStartedID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phase_started_id");
        }
        init { this._rawData.Set("phase_started_id", value); }
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
        _ = this.PhaseStartedID;
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workflow_run.phase_ended")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
        _ = this.WorkflowRunPhaseID;
    }

    public BetaManagedAgentsWorkflowRunPhaseEndedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("workflow_run.phase_ended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunPhaseEndedEvent(
        BetaManagedAgentsWorkflowRunPhaseEndedEvent betaManagedAgentsWorkflowRunPhaseEndedEvent
    )
        : base(betaManagedAgentsWorkflowRunPhaseEndedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunPhaseEndedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workflow_run.phase_ended");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunPhaseEndedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunPhaseEndedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunPhaseEndedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunPhaseEndedEventFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunPhaseEndedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunPhaseEndedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunPhaseEndedEvent.FromRawUnchecked(rawData);
}
