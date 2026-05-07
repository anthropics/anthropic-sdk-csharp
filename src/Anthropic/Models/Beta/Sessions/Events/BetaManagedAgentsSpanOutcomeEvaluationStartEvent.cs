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
/// Emitted when an outcome evaluation cycle begins.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent,
        BetaManagedAgentsSpanOutcomeEvaluationStartEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanOutcomeEvaluationStartEvent : JsonModel
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
    /// 0-indexed revision cycle. 0 is the first evaluation; 1 is the re-evaluation
    /// after the first revision; etc.
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

    public required ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
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

    public BetaManagedAgentsSpanOutcomeEvaluationStartEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanOutcomeEvaluationStartEvent(
        BetaManagedAgentsSpanOutcomeEvaluationStartEvent betaManagedAgentsSpanOutcomeEvaluationStartEvent
    )
        : base(betaManagedAgentsSpanOutcomeEvaluationStartEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanOutcomeEvaluationStartEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanOutcomeEvaluationStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanOutcomeEvaluationStartEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanOutcomeEvaluationStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanOutcomeEvaluationStartEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanOutcomeEvaluationStartEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanOutcomeEvaluationStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanOutcomeEvaluationStartEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSpanOutcomeEvaluationStartEventTypeConverter))]
public enum BetaManagedAgentsSpanOutcomeEvaluationStartEventType
{
    SpanOutcomeEvaluationStart,
}

sealed class BetaManagedAgentsSpanOutcomeEvaluationStartEventTypeConverter
    : JsonConverter<BetaManagedAgentsSpanOutcomeEvaluationStartEventType>
{
    public override BetaManagedAgentsSpanOutcomeEvaluationStartEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "span.outcome_evaluation_start" =>
                BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart,
            _ => (BetaManagedAgentsSpanOutcomeEvaluationStartEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSpanOutcomeEvaluationStartEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSpanOutcomeEvaluationStartEventType.SpanOutcomeEvaluationStart =>
                    "span.outcome_evaluation_start",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
