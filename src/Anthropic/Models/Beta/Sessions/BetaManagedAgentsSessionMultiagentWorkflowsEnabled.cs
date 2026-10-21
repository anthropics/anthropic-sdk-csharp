using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// The agent can start workflow runs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionMultiagentWorkflowsEnabled,
        BetaManagedAgentsSessionMultiagentWorkflowsEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionMultiagentWorkflowsEnabled : JsonModel
{
    /// <summary>
    /// Whether a run's plan can define inline agents, which are not saved.
    /// </summary>
    public required BetaManagedAgentsMultiagentInlineAgents InlineAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMultiagentInlineAgents>(
                "inline_agents"
            );
        }
        init { this._rawData.Set("inline_agents", value); }
    }

    /// <summary>
    /// Full `agent` definitions of the predefined agents, which are saved agents
    /// that a run's plan can use.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSessionThreadAgent> PredefinedAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSessionThreadAgent>
            >("predefined_agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionThreadAgent>>(
                "predefined_agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this.InlineAgents.Validate();
        foreach (var item in this.PredefinedAgents)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionMultiagentWorkflowsEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionMultiagentWorkflowsEnabled(
        BetaManagedAgentsSessionMultiagentWorkflowsEnabled betaManagedAgentsSessionMultiagentWorkflowsEnabled
    )
        : base(betaManagedAgentsSessionMultiagentWorkflowsEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionMultiagentWorkflowsEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionMultiagentWorkflowsEnabled(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionMultiagentWorkflowsEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionMultiagentWorkflowsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionMultiagentWorkflowsEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsSessionMultiagentWorkflowsEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionMultiagentWorkflowsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionMultiagentWorkflowsEnabled.FromRawUnchecked(rawData);
}
