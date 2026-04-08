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
/// Emitted when a model request is initiated by the agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSpanModelRequestStartEvent,
        BetaManagedAgentsSpanModelRequestStartEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSpanModelRequestStartEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSpanModelRequestStartEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSpanModelRequestStartEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsSpanModelRequestStartEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSpanModelRequestStartEvent(
        BetaManagedAgentsSpanModelRequestStartEvent betaManagedAgentsSpanModelRequestStartEvent
    )
        : base(betaManagedAgentsSpanModelRequestStartEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSpanModelRequestStartEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSpanModelRequestStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSpanModelRequestStartEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSpanModelRequestStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSpanModelRequestStartEventFromRaw
    : IFromRawJson<BetaManagedAgentsSpanModelRequestStartEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSpanModelRequestStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSpanModelRequestStartEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSpanModelRequestStartEventTypeConverter))]
public enum BetaManagedAgentsSpanModelRequestStartEventType
{
    SpanModelRequestStart,
}

sealed class BetaManagedAgentsSpanModelRequestStartEventTypeConverter
    : JsonConverter<BetaManagedAgentsSpanModelRequestStartEventType>
{
    public override BetaManagedAgentsSpanModelRequestStartEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "span.model_request_start" =>
                BetaManagedAgentsSpanModelRequestStartEventType.SpanModelRequestStart,
            _ => (BetaManagedAgentsSpanModelRequestStartEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSpanModelRequestStartEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSpanModelRequestStartEventType.SpanModelRequestStart =>
                    "span.model_request_start",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
