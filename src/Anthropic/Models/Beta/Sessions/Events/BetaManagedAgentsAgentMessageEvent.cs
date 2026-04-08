using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// An agent response event in the session conversation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentMessageEvent,
        BetaManagedAgentsAgentMessageEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentMessageEvent : JsonModel
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
    /// Array of text blocks comprising the agent response.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsTextBlock> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsTextBlock>>(
                "content"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsTextBlock>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required ApiEnum<string, BetaManagedAgentsAgentMessageEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentMessageEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentMessageEvent(
        BetaManagedAgentsAgentMessageEvent betaManagedAgentsAgentMessageEvent
    )
        : base(betaManagedAgentsAgentMessageEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentMessageEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentMessageEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentMessageEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentMessageEventFromRaw : IFromRawJson<BetaManagedAgentsAgentMessageEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentMessageEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentMessageEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentMessageEventTypeConverter))]
public enum BetaManagedAgentsAgentMessageEventType
{
    AgentMessage,
}

sealed class BetaManagedAgentsAgentMessageEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentMessageEventType>
{
    public override BetaManagedAgentsAgentMessageEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.message" => BetaManagedAgentsAgentMessageEventType.AgentMessage,
            _ => (BetaManagedAgentsAgentMessageEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentMessageEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentMessageEventType.AgentMessage => "agent.message",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
