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
/// The agent can start workflow runs.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentWorkflowsEnabled,
        BetaManagedAgentsMultiagentWorkflowsEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentWorkflowsEnabled : JsonModel
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
    /// Predefined agents, which are saved agents that a run's plan can use, each
    /// resolved to a specific version.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsAgentReference> PredefinedAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsAgentReference>>(
                "predefined_agents"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentReference>>(
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

    public BetaManagedAgentsMultiagentWorkflowsEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentWorkflowsEnabled(
        BetaManagedAgentsMultiagentWorkflowsEnabled betaManagedAgentsMultiagentWorkflowsEnabled
    )
        : base(betaManagedAgentsMultiagentWorkflowsEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentWorkflowsEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentWorkflowsEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentWorkflowsEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentWorkflowsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentWorkflowsEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentWorkflowsEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentWorkflowsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentWorkflowsEnabled.FromRawUnchecked(rawData);
}
