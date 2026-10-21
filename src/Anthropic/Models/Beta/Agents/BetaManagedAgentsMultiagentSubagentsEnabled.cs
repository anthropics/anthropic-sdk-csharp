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
/// The agent can spawn session threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentSubagentsEnabled,
        BetaManagedAgentsMultiagentSubagentsEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentSubagentsEnabled : JsonModel
{
    /// <summary>
    /// Whether the agent can define inline agents, which are not saved, when it spawns
    /// session threads.
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
    /// Predefined agents, which are saved agents that this agent can spawn as session
    /// threads, each resolved to a specific version.
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

    public BetaManagedAgentsMultiagentSubagentsEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentSubagentsEnabled(
        BetaManagedAgentsMultiagentSubagentsEnabled betaManagedAgentsMultiagentSubagentsEnabled
    )
        : base(betaManagedAgentsMultiagentSubagentsEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentSubagentsEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentSubagentsEnabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentSubagentsEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentSubagentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentSubagentsEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentSubagentsEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentSubagentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentSubagentsEnabled.FromRawUnchecked(rawData);
}
