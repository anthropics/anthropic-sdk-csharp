using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Multiagent configuration with three members, each enabled or disabled on its own.
/// On an update, if the agent's stored `multiagent` also has type `multiagent_20261001`,
/// this configuration is merged into the stored one, level by level, instead of replacing
/// it. A key that the update omits keeps its stored value. A key sent as null takes
/// its default, on create as well, so `"workflows": null` enables workflows. An object
/// sent with a `type` other than the stored one replaces the stored object, and
/// the keys that it omits take their defaults. A `predefined_agents` list that is
/// sent replaces the stored list. Every object that is sent needs its `type`, and
/// an enabled `advisor` needs its `model`. Other validation applies to the merged result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagent20261001Params,
        BetaManagedAgentsMultiagent20261001ParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagent20261001Params : JsonModel
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
    /// Whether the session's primary thread can consult an advisor model. Defaults
    /// to disabled.
    /// </summary>
    public BetaManagedAgentsMultiagentAdvisorParams? Advisor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMultiagentAdvisorParams>(
                "advisor"
            );
        }
        init { this._rawData.Set("advisor", value); }
    }

    /// <summary>
    /// Whether the agent can spawn session threads. Defaults to enabled.
    /// </summary>
    public BetaManagedAgentsMultiagentSubagentsParams? Subagents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMultiagentSubagentsParams>(
                "subagents"
            );
        }
        init { this._rawData.Set("subagents", value); }
    }

    /// <summary>
    /// Whether the agent can start workflow runs. Defaults to enabled.
    /// </summary>
    public BetaManagedAgentsMultiagentWorkflowsParams? Workflows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMultiagentWorkflowsParams>(
                "workflows"
            );
        }
        init { this._rawData.Set("workflows", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("multiagent_20261001")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.Advisor?.Validate();
        this.Subagents?.Validate();
        this.Workflows?.Validate();
    }

    public BetaManagedAgentsMultiagent20261001Params()
    {
        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagent20261001Params(
        BetaManagedAgentsMultiagent20261001Params betaManagedAgentsMultiagent20261001Params
    )
        : base(betaManagedAgentsMultiagent20261001Params) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagent20261001Params(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("multiagent_20261001");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagent20261001Params(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagent20261001ParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagent20261001Params FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagent20261001ParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagent20261001Params>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagent20261001Params FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagent20261001Params.FromRawUnchecked(rawData);
}
