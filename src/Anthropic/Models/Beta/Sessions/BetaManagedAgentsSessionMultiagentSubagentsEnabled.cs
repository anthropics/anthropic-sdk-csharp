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
/// The agent can spawn session threads.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionMultiagentSubagentsEnabled,
        BetaManagedAgentsSessionMultiagentSubagentsEnabledFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionMultiagentSubagentsEnabled : JsonModel
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
    /// Full `agent` definitions of the predefined agents, which are saved agents
    /// that this agent can spawn as session threads.
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

    public BetaManagedAgentsSessionMultiagentSubagentsEnabled()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionMultiagentSubagentsEnabled(
        BetaManagedAgentsSessionMultiagentSubagentsEnabled betaManagedAgentsSessionMultiagentSubagentsEnabled
    )
        : base(betaManagedAgentsSessionMultiagentSubagentsEnabled) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionMultiagentSubagentsEnabled(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionMultiagentSubagentsEnabled(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionMultiagentSubagentsEnabledFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionMultiagentSubagentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionMultiagentSubagentsEnabledFromRaw
    : IFromRawJson<BetaManagedAgentsSessionMultiagentSubagentsEnabled>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionMultiagentSubagentsEnabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionMultiagentSubagentsEnabled.FromRawUnchecked(rawData);
}
