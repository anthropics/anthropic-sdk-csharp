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
/// A workflow run met an error, or an error kept a run from being created. A run
/// that ends with a `result.type` of `error` emits this event before its `workflow_run.status_ended`,
/// with the same `error`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunErrorEvent,
        BetaManagedAgentsWorkflowRunErrorEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunErrorEvent : JsonModel
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
    /// Why the run did not finish, or was not created.
    /// </summary>
    public required BetaManagedAgentsWorkflowRunError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsWorkflowRunError>("error");
        }
        init { this._rawData.Set("error", value); }
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
    /// Identifier of the run that met the error, or `null` when the error kept a
    /// run from being created.
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
        this.Error.Validate();
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workflow_run.error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkflowRunID;
    }

    public BetaManagedAgentsWorkflowRunErrorEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("workflow_run.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunErrorEvent(
        BetaManagedAgentsWorkflowRunErrorEvent betaManagedAgentsWorkflowRunErrorEvent
    )
        : base(betaManagedAgentsWorkflowRunErrorEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workflow_run.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunErrorEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunErrorEventFromRaw
    : IFromRawJson<BetaManagedAgentsWorkflowRunErrorEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunErrorEvent.FromRawUnchecked(rawData);
}
