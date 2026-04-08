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
/// Event emitted when the agent invokes a tool provided by an MCP server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentMcpToolUseEvent,
        BetaManagedAgentsAgentMcpToolUseEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentMcpToolUseEvent : JsonModel
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
    /// Name of the MCP server providing the tool.
    /// </summary>
    public required string McpServerName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_name");
        }
        init { this._rawData.Set("mcp_server_name", value); }
    }

    /// <summary>
    /// Name of the MCP tool being used.
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

    public required ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// AgentEvaluatedPermission enum
    /// </summary>
    public ApiEnum<string, EvaluatedPermission>? EvaluatedPermission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EvaluatedPermission>>(
                "evaluated_permission"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("evaluated_permission", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        _ = this.McpServerName;
        _ = this.Name;
        _ = this.ProcessedAt;
        this.Type.Validate();
        this.EvaluatedPermission?.Validate();
    }

    public BetaManagedAgentsAgentMcpToolUseEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentMcpToolUseEvent(
        BetaManagedAgentsAgentMcpToolUseEvent betaManagedAgentsAgentMcpToolUseEvent
    )
        : base(betaManagedAgentsAgentMcpToolUseEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentMcpToolUseEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentMcpToolUseEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentMcpToolUseEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentMcpToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentMcpToolUseEventFromRaw
    : IFromRawJson<BetaManagedAgentsAgentMcpToolUseEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentMcpToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentMcpToolUseEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentMcpToolUseEventTypeConverter))]
public enum BetaManagedAgentsAgentMcpToolUseEventType
{
    AgentMcpToolUse,
}

sealed class BetaManagedAgentsAgentMcpToolUseEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentMcpToolUseEventType>
{
    public override BetaManagedAgentsAgentMcpToolUseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.mcp_tool_use" => BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            _ => (BetaManagedAgentsAgentMcpToolUseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentMcpToolUseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse => "agent.mcp_tool_use",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// AgentEvaluatedPermission enum
/// </summary>
[JsonConverter(typeof(EvaluatedPermissionConverter))]
public enum EvaluatedPermission
{
    Allow,
    Ask,
    Deny,
}

sealed class EvaluatedPermissionConverter : JsonConverter<EvaluatedPermission>
{
    public override EvaluatedPermission Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => EvaluatedPermission.Allow,
            "ask" => EvaluatedPermission.Ask,
            "deny" => EvaluatedPermission.Deny,
            _ => (EvaluatedPermission)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EvaluatedPermission value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EvaluatedPermission.Allow => "allow",
                EvaluatedPermission.Ask => "ask",
                EvaluatedPermission.Deny => "deny",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
