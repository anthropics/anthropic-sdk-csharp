using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Resolved multiagent configuration with three members, each enabled or disabled
/// on its own.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagent20261001,
        BetaManagedAgentsMultiagent20261001FromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagent20261001 : JsonModel
{
    /// <summary>
    /// Whether the session's primary thread can consult an advisor model.
    /// </summary>
    public required BetaManagedAgentsMultiagentAdvisor Advisor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMultiagentAdvisor>("advisor");
        }
        init { this._rawData.Set("advisor", value); }
    }

    /// <summary>
    /// Whether the agent can spawn session threads.
    /// </summary>
    public required BetaManagedAgentsMultiagentSubagents Subagents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMultiagentSubagents>("subagents");
        }
        init { this._rawData.Set("subagents", value); }
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

    /// <summary>
    /// Whether the agent can start workflow runs.
    /// </summary>
    public required BetaManagedAgentsMultiagentWorkflows Workflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMultiagentWorkflows>("workflows");
        }
        init { this._rawData.Set("workflows", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Advisor.Validate();
        this.Subagents.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("multiagent_20261001")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Workflows.Validate();
    }

    public BetaManagedAgentsMultiagent20261001()
    {
        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagent20261001(
        BetaManagedAgentsMultiagent20261001 betaManagedAgentsMultiagent20261001
    )
        : base(betaManagedAgentsMultiagent20261001) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagent20261001(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagent20261001(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagent20261001FromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagent20261001 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagent20261001FromRaw : IFromRawJson<BetaManagedAgentsMultiagent20261001>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagent20261001 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagent20261001.FromRawUnchecked(rawData);
}
