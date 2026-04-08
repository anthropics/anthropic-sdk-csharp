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
/// Indicates the session has terminated, either due to an error or completion.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionStatusTerminatedEvent,
        BetaManagedAgentsSessionStatusTerminatedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionStatusTerminatedEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionStatusTerminatedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionStatusTerminatedEventType>
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

    public BetaManagedAgentsSessionStatusTerminatedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionStatusTerminatedEvent(
        BetaManagedAgentsSessionStatusTerminatedEvent betaManagedAgentsSessionStatusTerminatedEvent
    )
        : base(betaManagedAgentsSessionStatusTerminatedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionStatusTerminatedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionStatusTerminatedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionStatusTerminatedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionStatusTerminatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionStatusTerminatedEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionStatusTerminatedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionStatusTerminatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionStatusTerminatedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionStatusTerminatedEventTypeConverter))]
public enum BetaManagedAgentsSessionStatusTerminatedEventType
{
    SessionStatusTerminated,
}

sealed class BetaManagedAgentsSessionStatusTerminatedEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionStatusTerminatedEventType>
{
    public override BetaManagedAgentsSessionStatusTerminatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.status_terminated" =>
                BetaManagedAgentsSessionStatusTerminatedEventType.SessionStatusTerminated,
            _ => (BetaManagedAgentsSessionStatusTerminatedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionStatusTerminatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionStatusTerminatedEventType.SessionStatusTerminated =>
                    "session.status_terminated",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
