using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved coordinator topology with a concrete agent roster.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsMultiagent, BetaManagedAgentsMultiagentFromRaw>)
)]
public sealed record class BetaManagedAgentsMultiagent : JsonModel
{
    /// <summary>
    /// Agents the coordinator may spawn as session threads, each resolved to a specific version.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsAgentReference> Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaManagedAgentsAgentReference>>(
                "agents"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsAgentReference>>(
                "agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsMultiagentType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsMultiagentType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agents)
        {
            item.Validate();
        }
        this.Type.Validate();
    }

    public BetaManagedAgentsMultiagent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagent(BetaManagedAgentsMultiagent betaManagedAgentsMultiagent)
        : base(betaManagedAgentsMultiagent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentFromRaw : IFromRawJson<BetaManagedAgentsMultiagent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentTypeConverter))]
public enum BetaManagedAgentsMultiagentType
{
    Coordinator,
}

sealed class BetaManagedAgentsMultiagentTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentType>
{
    public override BetaManagedAgentsMultiagentType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentType.Coordinator,
            _ => (BetaManagedAgentsMultiagentType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
