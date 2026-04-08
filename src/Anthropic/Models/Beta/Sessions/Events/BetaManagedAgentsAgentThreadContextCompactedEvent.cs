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
/// Indicates that context compaction (summarization) occurred during the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentThreadContextCompactedEvent,
        BetaManagedAgentsAgentThreadContextCompactedEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentThreadContextCompactedEvent : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsAgentThreadContextCompactedEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentThreadContextCompactedEventType>
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

    public BetaManagedAgentsAgentThreadContextCompactedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentThreadContextCompactedEvent(
        BetaManagedAgentsAgentThreadContextCompactedEvent betaManagedAgentsAgentThreadContextCompactedEvent
    )
        : base(betaManagedAgentsAgentThreadContextCompactedEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentThreadContextCompactedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentThreadContextCompactedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentThreadContextCompactedEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentThreadContextCompactedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentThreadContextCompactedEventFromRaw
    : IFromRawJson<BetaManagedAgentsAgentThreadContextCompactedEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentThreadContextCompactedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentThreadContextCompactedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentThreadContextCompactedEventTypeConverter))]
public enum BetaManagedAgentsAgentThreadContextCompactedEventType
{
    AgentThreadContextCompacted,
}

sealed class BetaManagedAgentsAgentThreadContextCompactedEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentThreadContextCompactedEventType>
{
    public override BetaManagedAgentsAgentThreadContextCompactedEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.thread_context_compacted" =>
                BetaManagedAgentsAgentThreadContextCompactedEventType.AgentThreadContextCompacted,
            _ => (BetaManagedAgentsAgentThreadContextCompactedEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentThreadContextCompactedEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentThreadContextCompactedEventType.AgentThreadContextCompacted =>
                    "agent.thread_context_compacted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
