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
/// Indicates the agent is making forward progress via extended thinking. A progress
/// signal, not a content carrier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentThinkingEvent,
        BetaManagedAgentsAgentThinkingEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentThinkingEvent : JsonModel
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
    /// Timestamp when this thinking was produced.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("agent.thinking")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentThinkingEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("agent.thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentThinkingEvent(
        BetaManagedAgentsAgentThinkingEvent betaManagedAgentsAgentThinkingEvent
    )
        : base(betaManagedAgentsAgentThinkingEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentThinkingEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent.thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentThinkingEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentThinkingEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentThinkingEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentThinkingEventFromRaw : IFromRawJson<BetaManagedAgentsAgentThinkingEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentThinkingEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentThinkingEvent.FromRawUnchecked(rawData);
}
