using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    public required ApiEnum<string, BetaManagedAgentsAgentToolset20260401ParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentToolset20260401ParamsType>
            >("type");
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
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentToolConfigParams>?>(
                "configs",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Default configuration for all tools in a toolset.
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
        this.Type.Validate();
        foreach (var item in this.Configs ?? [])
        {
            item.Validate();
        }
        this.DefaultConfig?.Validate();
    }

    public BetaManagedAgentsAgentToolset20260401Params() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401Params(
        ApiEnum<string, BetaManagedAgentsAgentToolset20260401ParamsType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(typeof(BetaManagedAgentsAgentToolset20260401ParamsTypeConverter))]
public enum BetaManagedAgentsAgentToolset20260401ParamsType
{
    AgentToolset20260401,
}

sealed class BetaManagedAgentsAgentToolset20260401ParamsTypeConverter
    : JsonConverter<BetaManagedAgentsAgentToolset20260401ParamsType>
{
    public override BetaManagedAgentsAgentToolset20260401ParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_toolset_20260401" =>
                BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
            _ => (BetaManagedAgentsAgentToolset20260401ParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolset20260401ParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401 =>
                    "agent_toolset_20260401",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
