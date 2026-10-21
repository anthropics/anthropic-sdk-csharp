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
/// Periodic heartbeat emitted while an outcome evaluation cycle is in progress. Distinguishes
/// 'evaluation is actively running' from 'evaluation is stuck' between the corresponding
/// `span.outcome_evaluation_start` and `span.outcome_evaluation_end` events.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent,
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent : JsonModel
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
    /// 0-indexed revision cycle, matching the corresponding `span.outcome_evaluation_start`.
    /// </summary>
    public required int Iteration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("iteration");
        }
        init { this._rawData.Set("iteration", value); }
    }

    /// <summary>
    /// The `outc_` ID of the outcome being evaluated.
    /// </summary>
    public required string OutcomeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outcome_id");
        }
        init { this._rawData.Set("outcome_id", value); }
    }

    /// <summary>
    /// Timestamp when this heartbeat was emitted.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Iteration;
        _ = this.OutcomeID;
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("span.outcome_evaluation_ongoing")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("span.outcome_evaluation_ongoing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent(
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent betaManagedAgentsSpanOutcomeEvaluationOngoingEvent
    )
        : base(betaManagedAgentsSpanOutcomeEvaluationOngoingEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("span.outcome_evaluation_ongoing");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanOutcomeEvaluationOngoingEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanOutcomeEvaluationOngoingEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent.FromRawUnchecked(rawData);
}
