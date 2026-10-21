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
/// Configuration for built-in agent tools. Use this to enable or disable groups
/// of tools available to the agent.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401Params,
        BetaManagedAgentsAgentToolset20260401ParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401Params : JsonModel
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
    /// Per-tool configuration overrides.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsAgentToolConfigParams>? Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsAgentToolConfigParams>
            >("configs");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("configs");
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentToolConfigParams>?>(
                "configs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default configuration applied to all tools in this set.
    /// </summary>
    public BetaManagedAgentsAgentToolsetDefaultConfigParams? DefaultConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsAgentToolsetDefaultConfigParams>(
                "default_config"
            );
        }
        init { this._rawData.Set("default_config", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("agent_toolset_20260401")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Configs ?? [])
        {
            item.Validate();
        }
        this.DefaultConfig?.Validate();
    }

    public BetaManagedAgentsAgentToolset20260401Params()
    {
        this.Type = JsonSerializer.SerializeToElement("agent_toolset_20260401");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401Params(
        BetaManagedAgentsAgentToolset20260401Params betaManagedAgentsAgentToolset20260401Params
    )
        : base(betaManagedAgentsAgentToolset20260401Params) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401Params(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent_toolset_20260401");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401Params(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401ParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401Params FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolset20260401ParamsFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401Params>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401Params FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401Params.FromRawUnchecked(rawData);
}
