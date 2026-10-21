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
/// Indicates the session is recovering from an error state and is rescheduled for execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionStatusRescheduledEvent,
        BetaManagedAgentsSessionStatusRescheduledEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionStatusRescheduledEvent : JsonModel
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
    /// Timestamp of status change.
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
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("session.status_rescheduled")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionStatusRescheduledEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("session.status_rescheduled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionStatusRescheduledEvent(
        BetaManagedAgentsSessionStatusRescheduledEvent betaManagedAgentsSessionStatusRescheduledEvent
    )
        : base(betaManagedAgentsSessionStatusRescheduledEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionStatusRescheduledEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("session.status_rescheduled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionStatusRescheduledEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionStatusRescheduledEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionStatusRescheduledEventFromRaw
    : IFromRawJson<BetaManagedAgentsSessionStatusRescheduledEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionStatusRescheduledEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionStatusRescheduledEvent.FromRawUnchecked(rawData);
}
