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
/// Emitted when an outcome evaluation cycle completes. Carries the verdict and aggregate
/// token usage. A verdict of `needs_revision` means another evaluation cycle follows;
/// `satisfied`, `max_iterations_reached`, `failed`, or `interrupted` are terminal
/// — no further evaluation cycles follow.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent,
        BetaManagedAgentsSpanOutcomeEvaluationEndEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanOutcomeEvaluationEndEvent : JsonModel
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
    /// Human-readable explanation of the verdict. For `needs_revision`, describes
    /// which criteria failed and why.
    /// </summary>
    public required string Explanation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("explanation");
        }
        init { this._rawData.Set("explanation", value); }
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
    /// The id of the corresponding `span.outcome_evaluation_start` event.
    /// </summary>
    public required string OutcomeEvaluationStartID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("outcome_evaluation_start_id");
        }
        init { this._rawData.Set("outcome_evaluation_start_id", value); }
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

    /// <summary>
    /// Evaluation verdict. 'satisfied': criteria met, session goes idle. 'needs_revision':
    /// criteria not met, another revision cycle follows. 'max_iterations_reached':
    /// evaluation budget exhausted with criteria still unmet — one final acknowledgment
    /// turn follows before the session goes idle, but no further evaluation runs.
    /// 'failed': grader determined the rubric does not apply to the deliverables.
    /// 'interrupted': user sent an interrupt while evaluation was in progress.
    /// </summary>
    public required string Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationEndEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationEndEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Token usage for a single model request.
    /// </summary>
    public required BetaManagedAgentsSpanModelUsage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSpanModelUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Explanation;
        _ = this.Iteration;
        _ = this.OutcomeEvaluationStartID;
        _ = this.OutcomeID;
        _ = this.ProcessedAt;
        _ = this.Result;
        this.Type.Validate();
        this.Usage.Validate();
    }

    public BetaManagedAgentsSpanOutcomeEvaluationEndEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanOutcomeEvaluationEndEvent(
        BetaManagedAgentsSpanOutcomeEvaluationEndEvent betaManagedAgentsSpanOutcomeEvaluationEndEvent
    )
        : base(betaManagedAgentsSpanOutcomeEvaluationEndEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanOutcomeEvaluationEndEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanOutcomeEvaluationEndEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanOutcomeEvaluationEndEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanOutcomeEvaluationEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanOutcomeEvaluationEndEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanOutcomeEvaluationEndEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanOutcomeEvaluationEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanOutcomeEvaluationEndEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSpanOutcomeEvaluationEndEventTypeConverter))]
public enum BetaManagedAgentsSpanOutcomeEvaluationEndEventType
{
    SpanOutcomeEvaluationEnd,
}

sealed class BetaManagedAgentsSpanOutcomeEvaluationEndEventTypeConverter
    : JsonConverter<BetaManagedAgentsSpanOutcomeEvaluationEndEventType>
{
    public override BetaManagedAgentsSpanOutcomeEvaluationEndEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "span.outcome_evaluation_end" =>
                BetaManagedAgentsSpanOutcomeEvaluationEndEventType.SpanOutcomeEvaluationEnd,
            _ => (BetaManagedAgentsSpanOutcomeEvaluationEndEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSpanOutcomeEvaluationEndEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSpanOutcomeEvaluationEndEventType.SpanOutcomeEvaluationEnd =>
                    "span.outcome_evaluation_end",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
