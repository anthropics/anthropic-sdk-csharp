using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Emitted when an UpdateSession request changed at least one field. Carries only
/// the fields that changed; absent fields were not part of the update. The new configuration
/// applies from the next turn.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionUpdatedEvent,
        BetaManagedAgentsSessionUpdatedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionUpdatedEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionUpdatedEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Resolved `agent` definition for a `session`. Snapshot of the `agent` at `session`
    /// creation time.
    /// </summary>
    public BetaManagedAgentsSessionAgent? Agent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsSessionAgent>("agent");
        }
        init { this._rawData.Set("agent", value); }
    }

    /// <summary>
    /// The session's full metadata bag after the update. Present when the update
    /// set non-empty metadata; absent when metadata was unchanged or cleared to empty.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The session's new title. Present only when the update changed it.
    /// </summary>
    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProcessedAt;
        this.Type.Validate();
        this.Agent?.Validate();
        _ = this.Metadata;
        _ = this.Title;
    }

    public BetaManagedAgentsSessionUpdatedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionUpdatedEvent(
        BetaManagedAgentsSessionUpdatedEvent betaManagedAgentsSessionUpdatedEvent
    )
        : base(betaManagedAgentsSessionUpdatedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionUpdatedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionUpdatedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionUpdatedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionUpdatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionUpdatedEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionUpdatedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionUpdatedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionUpdatedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionUpdatedEventTypeConverter))]
public enum BetaManagedAgentsSessionUpdatedEventType
{
    SessionUpdated,
}

sealed class BetaManagedAgentsSessionUpdatedEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionUpdatedEventType>
{
    public override BetaManagedAgentsSessionUpdatedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.updated" => BetaManagedAgentsSessionUpdatedEventType.SessionUpdated,
            _ => (BetaManagedAgentsSessionUpdatedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionUpdatedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionUpdatedEventType.SessionUpdated => "session.updated",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
