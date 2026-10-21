using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("mcp_egress_blocked_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_egress_blocked_error");
    }

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

        this.Type = JsonSerializer.SerializeToElement("mcp_egress_blocked_error");
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
}

class BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpEgressBlockedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}
