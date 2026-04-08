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
/// A tool confirmation event that approves or denies a pending tool execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserToolConfirmationEvent,
        BetaManagedAgentsUserToolConfirmationEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserToolConfirmationEvent : JsonModel
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
    /// UserToolConfirmationResult enum
    /// </summary>
    public required ApiEnum<string, Result> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Result>>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// The id of the `agent.tool_use` or `agent.mcp_tool_use` event this result
    /// corresponds to, which can be found in the last `session.status_idle` [event's](https://platform.claude.com/docs/en/api/beta/sessions/events/list#beta_managed_agents_session_requires_action.event_ids)
    /// `stop_reason.event_ids` field.
    /// </summary>
    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional message providing context for a 'deny' decision. Only allowed when
    /// result is 'deny'.
    /// </summary>
    public string? DenyMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("deny_message");
        }
        init { this._rawData.Set("deny_message", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public System::DateTimeOffset? ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Result.Validate();
        _ = this.ToolUseID;
        this.Type.Validate();
        _ = this.DenyMessage;
        _ = this.ProcessedAt;
    }

    public BetaManagedAgentsUserToolConfirmationEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserToolConfirmationEvent(
        BetaManagedAgentsUserToolConfirmationEvent betaManagedAgentsUserToolConfirmationEvent
    )
        : base(betaManagedAgentsUserToolConfirmationEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserToolConfirmationEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserToolConfirmationEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserToolConfirmationEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserToolConfirmationEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserToolConfirmationEventFromRaw
    : IFromRawJson<BetaManagedAgentsUserToolConfirmationEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserToolConfirmationEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserToolConfirmationEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// UserToolConfirmationResult enum
/// </summary>
[JsonConverter(typeof(ResultConverter))]
public enum Result
{
    Allow,
    Deny,
}

sealed class ResultConverter : JsonConverter<Result>
{
    public override Result Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => Result.Allow,
            "deny" => Result.Deny,
            _ => (Result)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Result.Allow => "allow",
                Result.Deny => "deny",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserToolConfirmationEventTypeConverter))]
public enum BetaManagedAgentsUserToolConfirmationEventType
{
    UserToolConfirmation,
}

sealed class BetaManagedAgentsUserToolConfirmationEventTypeConverter
    : JsonConverter<BetaManagedAgentsUserToolConfirmationEventType>
{
    public override BetaManagedAgentsUserToolConfirmationEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.tool_confirmation" =>
                BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            _ => (BetaManagedAgentsUserToolConfirmationEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserToolConfirmationEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation =>
                    "user.tool_confirmation",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
