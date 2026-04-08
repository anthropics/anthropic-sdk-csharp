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
/// Emitted when a session has been deleted. Terminates any active event stream —
/// no further events will be emitted for this session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionDeletedEvent,
        BetaManagedAgentsSessionDeletedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionDeletedEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionDeletedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionDeletedEventType>
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

    public BetaManagedAgentsSessionDeletedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionDeletedEvent(
        BetaManagedAgentsSessionDeletedEvent betaManagedAgentsSessionDeletedEvent
    )
        : base(betaManagedAgentsSessionDeletedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionDeletedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionDeletedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionDeletedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionDeletedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionDeletedEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionDeletedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionDeletedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionDeletedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionDeletedEventTypeConverter))]
public enum BetaManagedAgentsSessionDeletedEventType
{
    SessionDeleted,
}

sealed class BetaManagedAgentsSessionDeletedEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionDeletedEventType>
{
    public override BetaManagedAgentsSessionDeletedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.deleted" => BetaManagedAgentsSessionDeletedEventType.SessionDeleted,
            _ => (BetaManagedAgentsSessionDeletedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionDeletedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionDeletedEventType.SessionDeleted => "session.deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
