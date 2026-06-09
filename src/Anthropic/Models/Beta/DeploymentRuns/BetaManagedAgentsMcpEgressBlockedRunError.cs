using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// An MCP server host used by the deployment's agent is blocked by the environment's
/// network policy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpEgressBlockedRunError,
        BetaManagedAgentsMcpEgressBlockedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpEgressBlockedRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpEgressBlockedRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsMcpEgressBlockedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpEgressBlockedRunError(
        BetaManagedAgentsMcpEgressBlockedRunError betaManagedAgentsMcpEgressBlockedRunError
    )
        : base(betaManagedAgentsMcpEgressBlockedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpEgressBlockedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpEgressBlockedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpEgressBlockedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpEgressBlockedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpEgressBlockedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMcpEgressBlockedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpEgressBlockedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpEgressBlockedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMcpEgressBlockedRunErrorTypeConverter))]
public enum BetaManagedAgentsMcpEgressBlockedRunErrorType
{
    McpEgressBlockedError,
}

sealed class BetaManagedAgentsMcpEgressBlockedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsMcpEgressBlockedRunErrorType>
{
    public override BetaManagedAgentsMcpEgressBlockedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_egress_blocked_error" =>
                BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError,
            _ => (BetaManagedAgentsMcpEgressBlockedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpEgressBlockedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpEgressBlockedRunErrorType.McpEgressBlockedError =>
                    "mcp_egress_blocked_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
