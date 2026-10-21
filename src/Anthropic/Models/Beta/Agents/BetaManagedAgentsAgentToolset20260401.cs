using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Agents;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401,
        BetaManagedAgentsAgentToolset20260401FromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401 : JsonModel
{
    public required IReadOnlyList<BetaManagedAgentsAgentToolConfig> Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsAgentToolConfig>>(
                "configs"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentToolConfig>>(
                "configs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Resolved default configuration for agent tools.
    /// </summary>
    public required BetaManagedAgentsAgentToolsetDefaultConfig DefaultConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsAgentToolsetDefaultConfig>(
                "default_config"
            );
        }
        init { this._rawData.Set("default_config", value); }
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
        foreach (var item in this.Configs)
        {
            item.Validate();
        }
        this.DefaultConfig.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("agent_toolset_20260401")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsAgentToolset20260401()
    {
        this.Type = JsonSerializer.SerializeToElement("agent_toolset_20260401");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401(
        BetaManagedAgentsAgentToolset20260401 betaManagedAgentsAgentToolset20260401
    )
        : base(betaManagedAgentsAgentToolset20260401) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("agent_toolset_20260401");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401FromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolset20260401FromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401.FromRawUnchecked(rawData);
}
