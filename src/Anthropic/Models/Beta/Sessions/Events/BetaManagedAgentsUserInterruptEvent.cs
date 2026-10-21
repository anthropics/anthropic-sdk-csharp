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
/// An interrupt event that pauses agent execution and returns control to the user.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserInterruptEvent,
        BetaManagedAgentsUserInterruptEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserInterruptEvent : JsonModel
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp when the interrupt was processed.
    /// </summary>
    public DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <summary>
    /// If absent, interrupts every non-archived thread in a multiagent session (or
    /// the primary alone in a single-agent session). If present, interrupts only
    /// the named thread.
    /// </summary>
    public string? SessionThreadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("session_thread_id");
        }
        init { this._rawData.Set("session_thread_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user.interrupt")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ProcessedAt;
        _ = this.SessionThreadID;
    }

    public BetaManagedAgentsUserInterruptEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("user.interrupt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEvent(
        BetaManagedAgentsUserInterruptEvent betaManagedAgentsUserInterruptEvent
    )
        : base(betaManagedAgentsUserInterruptEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserInterruptEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user.interrupt");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserInterruptEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserInterruptEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserInterruptEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUserInterruptEvent(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsUserInterruptEventFromRaw : IFromRawJson<BetaManagedAgentsUserInterruptEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserInterruptEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserInterruptEvent.FromRawUnchecked(rawData);
}
