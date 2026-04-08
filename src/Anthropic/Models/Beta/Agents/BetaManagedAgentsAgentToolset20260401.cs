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

    public required ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsAgentToolset20260401Type>
            >("type");
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
        this.Type.Validate();
    }

    public BetaManagedAgentsAgentToolset20260401() { }

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

[JsonConverter(typeof(BetaManagedAgentsAgentToolset20260401TypeConverter))]
public enum BetaManagedAgentsAgentToolset20260401Type
{
    AgentToolset20260401,
}

sealed class BetaManagedAgentsAgentToolset20260401TypeConverter
    : JsonConverter<BetaManagedAgentsAgentToolset20260401Type>
{
    public override BetaManagedAgentsAgentToolset20260401Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_toolset_20260401" =>
                BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401,
            _ => (BetaManagedAgentsAgentToolset20260401Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentToolset20260401Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentToolset20260401Type.AgentToolset20260401 =>
                    "agent_toolset_20260401",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
