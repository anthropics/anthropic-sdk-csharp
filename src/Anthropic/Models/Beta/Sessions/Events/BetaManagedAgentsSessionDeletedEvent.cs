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
    /// Timestamp when the session was deleted.
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
        _ = this.ProcessedAt;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("session.deleted"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionDeletedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("session.deleted");
    }

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

        this.Type = JsonSerializer.SerializeToElement("session.deleted");
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
