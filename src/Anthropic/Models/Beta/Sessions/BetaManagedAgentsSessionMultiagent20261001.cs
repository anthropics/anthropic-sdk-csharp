using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved multiagent configuration with three members, as copied to the `session`
/// at creation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionMultiagent20261001,
        BetaManagedAgentsSessionMultiagent20261001FromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionMultiagent20261001 : JsonModel
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
    public required BetaManagedAgentsSessionMultiagentSubagents Subagents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionMultiagentSubagents>(
                "subagents"
            );
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
    public required BetaManagedAgentsSessionMultiagentWorkflows Workflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsSessionMultiagentWorkflows>(
                "workflows"
            );
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

    public BetaManagedAgentsSessionMultiagent20261001()
    {
        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionMultiagent20261001(
        BetaManagedAgentsSessionMultiagent20261001 betaManagedAgentsSessionMultiagent20261001
    )
        : base(betaManagedAgentsSessionMultiagent20261001) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionMultiagent20261001(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionMultiagent20261001(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionMultiagent20261001FromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionMultiagent20261001 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionMultiagent20261001FromRaw
    : IFromRawJson<BetaManagedAgentsSessionMultiagent20261001>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionMultiagent20261001 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionMultiagent20261001.FromRawUnchecked(rawData);
}
