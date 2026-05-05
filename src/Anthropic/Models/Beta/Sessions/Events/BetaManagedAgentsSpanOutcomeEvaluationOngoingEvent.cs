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

    public required ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
            >("type");
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
        this.Type.Validate();
    }

    public BetaManagedAgentsSpanOutcomeEvaluationOngoingEvent() { }

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

[JsonConverter(typeof(BetaManagedAgentsSpanOutcomeEvaluationOngoingEventTypeConverter))]
public enum BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType
{
    SpanOutcomeEvaluationOngoing,
}

sealed class BetaManagedAgentsSpanOutcomeEvaluationOngoingEventTypeConverter
    : JsonConverter<BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType>
{
    public override BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "span.outcome_evaluation_ongoing" =>
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing,
            _ => (BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSpanOutcomeEvaluationOngoingEventType.SpanOutcomeEvaluationOngoing =>
                    "span.outcome_evaluation_ongoing",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
