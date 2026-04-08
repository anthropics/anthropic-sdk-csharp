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

    public required ApiEnum<string, BetaManagedAgentsAgentThinkingEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentThinkingEventType>
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

    public BetaManagedAgentsAgentThinkingEvent() { }

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

[JsonConverter(typeof(BetaManagedAgentsAgentThinkingEventTypeConverter))]
public enum BetaManagedAgentsAgentThinkingEventType
{
    AgentThinking,
}

sealed class BetaManagedAgentsAgentThinkingEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentThinkingEventType>
{
    public override BetaManagedAgentsAgentThinkingEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.thinking" => BetaManagedAgentsAgentThinkingEventType.AgentThinking,
            _ => (BetaManagedAgentsAgentThinkingEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentThinkingEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentThinkingEventType.AgentThinking => "agent.thinking",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
