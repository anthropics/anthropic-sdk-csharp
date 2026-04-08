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
/// Parameters for confirming or denying a tool execution request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUserToolConfirmationEventParams,
        BetaManagedAgentsUserToolConfirmationEventParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUserToolConfirmationEventParams : JsonModel
{
    /// <summary>
    /// UserToolConfirmationResult enum
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult> Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult>
            >("result");
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

    public required ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Result.Validate();
        _ = this.ToolUseID;
        this.Type.Validate();
        _ = this.DenyMessage;
    }

    public BetaManagedAgentsUserToolConfirmationEventParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUserToolConfirmationEventParams(
        BetaManagedAgentsUserToolConfirmationEventParams betaManagedAgentsUserToolConfirmationEventParams
    )
        : base(betaManagedAgentsUserToolConfirmationEventParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUserToolConfirmationEventParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUserToolConfirmationEventParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUserToolConfirmationEventParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUserToolConfirmationEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsUserToolConfirmationEventParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUserToolConfirmationEventParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUserToolConfirmationEventParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUserToolConfirmationEventParams.FromRawUnchecked(rawData);
}

/// <summary>
/// UserToolConfirmationResult enum
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsUserToolConfirmationEventParamsResultConverter))]
public enum BetaManagedAgentsUserToolConfirmationEventParamsResult
{
    Allow,
    Deny,
}

sealed class BetaManagedAgentsUserToolConfirmationEventParamsResultConverter
    : JsonConverter<BetaManagedAgentsUserToolConfirmationEventParamsResult>
{
    public override BetaManagedAgentsUserToolConfirmationEventParamsResult Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            "deny" => BetaManagedAgentsUserToolConfirmationEventParamsResult.Deny,
            _ => (BetaManagedAgentsUserToolConfirmationEventParamsResult)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserToolConfirmationEventParamsResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow => "allow",
                BetaManagedAgentsUserToolConfirmationEventParamsResult.Deny => "deny",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(BetaManagedAgentsUserToolConfirmationEventParamsTypeConverter))]
public enum BetaManagedAgentsUserToolConfirmationEventParamsType
{
    UserToolConfirmation,
}

sealed class BetaManagedAgentsUserToolConfirmationEventParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUserToolConfirmationEventParamsType>
{
    public override BetaManagedAgentsUserToolConfirmationEventParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user.tool_confirmation" =>
                BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            _ => (BetaManagedAgentsUserToolConfirmationEventParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUserToolConfirmationEventParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation =>
                    "user.tool_confirmation",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
