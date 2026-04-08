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
/// Event emitted when the agent calls a custom tool. The session goes idle until
/// the client sends a `user.custom_tool_result` event with the result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentCustomToolUseEvent,
        BetaManagedAgentsAgentCustomToolUseEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentCustomToolUseEvent : JsonModel
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
    /// Input parameters for the tool call.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("input");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Name of the custom tool being called.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Events.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Events.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        _ = this.Name;
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentCustomToolUseEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentCustomToolUseEvent(
        BetaManagedAgentsAgentCustomToolUseEvent betaManagedAgentsAgentCustomToolUseEvent
    )
        : base(betaManagedAgentsAgentCustomToolUseEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentCustomToolUseEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentCustomToolUseEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentCustomToolUseEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentCustomToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentCustomToolUseEventFromRaw
    : IFromRawJson<BetaManagedAgentsAgentCustomToolUseEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentCustomToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentCustomToolUseEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AgentCustomToolUse,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Events.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Events.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.custom_tool_use" => global::Anthropic
                .Models
                .Beta
                .Sessions
                .Events
                .Type
                .AgentCustomToolUse,
            _ => (global::Anthropic.Models.Beta.Sessions.Events.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Events.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Events.Type.AgentCustomToolUse =>
                    "agent.custom_tool_use",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
