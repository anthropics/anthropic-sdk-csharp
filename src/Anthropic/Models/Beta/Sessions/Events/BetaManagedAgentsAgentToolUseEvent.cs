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
/// Event emitted when the agent invokes a built-in agent tool.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolUseEvent,
        BetaManagedAgentsAgentToolUseEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolUseEvent : JsonModel
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
    /// Name of the agent tool being used.
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
    /// Timestamp when this event was processed.
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

    public required ApiEnum<string, BetaManagedAgentsAgentToolUseEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentToolUseEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The evaluated permission policy for this tool invocation.
    /// </summary>
    public ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>? EvaluatedPermission
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>
            >("evaluated_permission");
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

    /// <summary>
    /// Which resolved permission_policy produced evaluated_permission: always_allow,
    /// always_ask, or auto (with the server's per-invocation judgement). Absent only
    /// when the server refused the call before any policy applied (for example,
    /// the named tool is not enabled in the session); such a refusal has evaluated_permission
    /// deny. An event recorded before this field existed reads as the arm its evaluated_permission
    /// implies (always_allow for allow, always_ask for ask).
    /// </summary>
    public BetaManagedAgentsAgentToolEvaluation? Evaluation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsAgentToolEvaluation>(
                "evaluation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("evaluation", value);
        }
    }

    /// <summary>
    /// When set, this event was cross-posted from a subagent's thread to surface
    /// its permission request on the primary thread's stream. Empty on the thread's
    /// own events. Informational only: the server routes the matching `user.tool_confirmation`
    /// or `user.tool_result` by `tool_use_id`, so clients do not send it back.
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
        _ = this.Input;
        _ = this.Name;
        _ = this.ProcessedAt;
        this.Type.Validate();
        this.EvaluatedPermission?.Validate();
        this.Evaluation?.Validate();
        _ = this.SessionThreadID;
    }

    public BetaManagedAgentsAgentToolUseEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolUseEvent(
        BetaManagedAgentsAgentToolUseEvent betaManagedAgentsAgentToolUseEvent
    )
        : base(betaManagedAgentsAgentToolUseEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolUseEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolUseEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolUseEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolUseEventFromRaw : IFromRawJson<BetaManagedAgentsAgentToolUseEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolUseEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolUseEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsAgentToolUseEventTypeConverter))]
public enum BetaManagedAgentsAgentToolUseEventType
{
    AgentToolUse,
}

sealed class BetaManagedAgentsAgentToolUseEventTypeConverter
    : JsonConverter<BetaManagedAgentsAgentToolUseEventType>
{
    public override BetaManagedAgentsAgentToolUseEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent.tool_use" => BetaManagedAgentsAgentToolUseEventType.AgentToolUse,
            _ => (BetaManagedAgentsAgentToolUseEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolUseEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentToolUseEventType.AgentToolUse => "agent.tool_use",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
