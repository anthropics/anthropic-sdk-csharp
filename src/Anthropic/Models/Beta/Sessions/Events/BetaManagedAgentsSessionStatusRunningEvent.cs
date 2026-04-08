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
/// Indicates the session is actively running and the agent is working.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionStatusRunningEvent,
        BetaManagedAgentsSessionStatusRunningEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionStatusRunningEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionStatusRunningEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionStatusRunningEventType>
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

    public BetaManagedAgentsSessionStatusRunningEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionStatusRunningEvent(
        BetaManagedAgentsSessionStatusRunningEvent betaManagedAgentsSessionStatusRunningEvent
    )
        : base(betaManagedAgentsSessionStatusRunningEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionStatusRunningEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionStatusRunningEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionStatusRunningEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionStatusRunningEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionStatusRunningEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionStatusRunningEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionStatusRunningEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionStatusRunningEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionStatusRunningEventTypeConverter))]
public enum BetaManagedAgentsSessionStatusRunningEventType
{
    SessionStatusRunning,
}

sealed class BetaManagedAgentsSessionStatusRunningEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionStatusRunningEventType>
{
    public override BetaManagedAgentsSessionStatusRunningEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.status_running" =>
                BetaManagedAgentsSessionStatusRunningEventType.SessionStatusRunning,
            _ => (BetaManagedAgentsSessionStatusRunningEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionStatusRunningEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionStatusRunningEventType.SessionStatusRunning =>
                    "session.status_running",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
