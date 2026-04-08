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
/// Emitted when a model request completes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanModelRequestEndEvent,
        BetaManagedAgentsSpanModelRequestEndEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanModelRequestEndEvent : JsonModel
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
    /// Whether the model request resulted in an error.
    /// </summary>
    public required bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    /// <summary>
    /// The id of the corresponding `span.model_request_start` event.
    /// </summary>
    public required string ModelRequestStartID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model_request_start_id");
        }
        init { this._rawData.Set("model_request_start_id", value); }
    }

    /// <summary>
    /// Token usage for a single model request.
    /// </summary>
    public required BetaManagedAgentsSpanModelUsage ModelUsage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSpanModelUsage>("model_usage");
        }
        init { this._rawData.Set("model_usage", value); }
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

    public required ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSpanModelRequestEndEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IsError;
        _ = this.ModelRequestStartID;
        this.ModelUsage.Validate();
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsSpanModelRequestEndEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanModelRequestEndEvent(
        BetaManagedAgentsSpanModelRequestEndEvent betaManagedAgentsSpanModelRequestEndEvent
    )
        : base(betaManagedAgentsSpanModelRequestEndEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanModelRequestEndEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanModelRequestEndEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanModelRequestEndEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanModelRequestEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanModelRequestEndEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanModelRequestEndEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanModelRequestEndEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanModelRequestEndEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSpanModelRequestEndEventTypeConverter))]
public enum BetaManagedAgentsSpanModelRequestEndEventType
{
    SpanModelRequestEnd,
}

sealed class BetaManagedAgentsSpanModelRequestEndEventTypeConverter
    : JsonConverter<BetaManagedAgentsSpanModelRequestEndEventType>
{
    public override BetaManagedAgentsSpanModelRequestEndEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "span.model_request_end" =>
                BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd,
            _ => (BetaManagedAgentsSpanModelRequestEndEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSpanModelRequestEndEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSpanModelRequestEndEventType.SpanModelRequestEnd =>
                    "span.model_request_end",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
