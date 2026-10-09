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
/// A workflow run is running. Emitted when the run starts to execute, and each time
/// it resumes after being idle. A run that starts idle emits `workflow_run.status_idle` first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunStatusRunningEvent,
        BetaManagedAgentsWorkflowRunStatusRunningEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunStatusRunningEvent : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workflow_run.status_running")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
    }

    public BetaManagedAgentsWorkflowRunStatusRunningEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("workflow_run.status_running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunStatusRunningEvent(
        BetaManagedAgentsWorkflowRunStatusRunningEvent betaManagedAgentsWorkflowRunStatusRunningEvent
    )
        : base(betaManagedAgentsWorkflowRunStatusRunningEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunStatusRunningEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workflow_run.status_running");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunStatusRunningEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunStatusRunningEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunStatusRunningEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunStatusRunningEventFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunStatusRunningEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunStatusRunningEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunStatusRunningEvent.FromRawUnchecked(rawData);
}
