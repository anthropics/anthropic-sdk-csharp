using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The agent can start workflow runs. Each run follows a plan, a program that the
/// agent writes. A plan can use predefined agents, which are the saved agents in
/// `predefined_agents`, and inline agents, which it defines itself and which are
/// not saved. If `inline_agents` is disabled, `predefined_agents` must name at least
/// one agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentWorkflowsEnabledParams,
        BetaManagedAgentsMultiagentWorkflowsEnabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentWorkflowsEnabledParams : JsonModel
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

    /// <summary>
    /// Whether a run's plan can define inline agents. Defaults to enabled.
    /// </summary>
    public BetaManagedAgentsMultiagentInlineAgentsParams? InlineAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMultiagentInlineAgentsParams>(
                "inline_agents"
            );
        }
        init { this._rawData.Set("inline_agents", value); }
    }

    /// <summary>
    /// Predefined agents that a run's plan can use. At most 20. Defaults to null.
    /// Null and an empty list both mean no predefined agents. This list is separate
    /// from `subagents.predefined_agents`, and an agent in one list is not added
    /// to the other.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsMultiagentPredefinedAgentParams>? PredefinedAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsMultiagentPredefinedAgentParams>
            >("predefined_agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsMultiagentPredefinedAgentParams>?>(
                "predefined_agents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.InlineAgents?.Validate();
        foreach (var item in this.PredefinedAgents ?? [])
        {
            item.Validate();
        }
    }

    public BetaManagedAgentsMultiagentWorkflowsEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentWorkflowsEnabledParams(
        BetaManagedAgentsMultiagentWorkflowsEnabledParams betaManagedAgentsMultiagentWorkflowsEnabledParams
    )
        : base(betaManagedAgentsMultiagentWorkflowsEnabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentWorkflowsEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentWorkflowsEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentWorkflowsEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentWorkflowsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentWorkflowsEnabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentWorkflowsEnabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentWorkflowsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentWorkflowsEnabledParams.FromRawUnchecked(rawData);
}
