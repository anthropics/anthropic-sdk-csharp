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
/// The agent can spawn session threads. Each thread runs a predefined agent, which
/// is a saved agent in `predefined_agents`, or an inline agent, which the agent
/// defines when it spawns the thread and which is not saved. If `inline_agents` is
/// disabled, `predefined_agents` must name at least one agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentSubagentsEnabledParams,
        BetaManagedAgentsMultiagentSubagentsEnabledParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSubagentsEnabledParams : JsonModel
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
    /// Whether the agent can define inline agents when it spawns session threads.
    /// Defaults to enabled.
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
    /// Predefined agents that this agent can spawn as session threads. At most 20.
    /// Defaults to null. Null and an empty list both mean no predefined agents.
    /// This list is separate from `workflows.predefined_agents`, and an agent in
    /// one list is not added to the other.
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

    public BetaManagedAgentsMultiagentSubagentsEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSubagentsEnabledParams(
        BetaManagedAgentsMultiagentSubagentsEnabledParams betaManagedAgentsMultiagentSubagentsEnabledParams
    )
        : base(betaManagedAgentsMultiagentSubagentsEnabledParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSubagentsEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSubagentsEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSubagentsEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSubagentsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentSubagentsEnabledParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSubagentsEnabledParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSubagentsEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSubagentsEnabledParams.FromRawUnchecked(rawData);
}
