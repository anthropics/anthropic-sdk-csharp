using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// A workflow run was created. A workflow run is background work that the session's
/// agent starts. Emitted once per run, before the run's other `workflow_run.*` events.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunCreatedEvent,
        BetaManagedAgentsWorkflowRunCreatedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunCreatedEvent : JsonModel
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
    /// Description that the agent gave the run, passed on as written, or `null` if
    /// it gave none.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Name that the agent gave the run, passed on as written, or a name that the
    /// server assigned.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The phases that the run's plan declares, in the plan's order. Can be empty.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsWorkflowRunPhase> Phases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsWorkflowRunPhase>
            >("phases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsWorkflowRunPhase>>(
                "phases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.Description;
        _ = this.Name;
        foreach (var item in this.Phases)
        {
            item.Validate();
        }
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workflow_run.created")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
    }

    public BetaManagedAgentsWorkflowRunCreatedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("workflow_run.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunCreatedEvent(
        BetaManagedAgentsWorkflowRunCreatedEvent betaManagedAgentsWorkflowRunCreatedEvent
    )
        : base(betaManagedAgentsWorkflowRunCreatedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunCreatedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workflow_run.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunCreatedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunCreatedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunCreatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunCreatedEventFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunCreatedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunCreatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunCreatedEvent.FromRawUnchecked(rawData);
}
