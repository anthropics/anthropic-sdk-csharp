using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        _ = this.Message;
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

    public BetaManagedAgentsMcpEgressBlockedRunError()
    {
        this.Type = JsonSerializer.SerializeToElement("mcp_egress_blocked_error");
    }

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

        this.Type = JsonSerializer.SerializeToElement("mcp_egress_blocked_error");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsMcpEgressBlockedRunError(string message)
        : this()
    {
        this.Message = message;
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
