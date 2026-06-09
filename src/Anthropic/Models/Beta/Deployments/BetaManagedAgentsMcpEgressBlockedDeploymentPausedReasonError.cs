using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// An MCP server host used by the deployment's agent is blocked by the environment's
/// network policy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError,
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError betaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType
{
    McpEgressBlockedError,
}

sealed class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mcp_egress_blocked_error" =>
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError,
            _ => (BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorType.McpEgressBlockedError =>
                    "mcp_egress_blocked_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
