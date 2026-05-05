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
/// Resolved coordinator topology with a concrete agent roster.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentCoordinator,
        BetaManagedAgentsMultiagentCoordinatorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentCoordinator : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
            >("type");
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

    public BetaManagedAgentsMultiagentCoordinator() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentCoordinator(
        BetaManagedAgentsMultiagentCoordinator betaManagedAgentsMultiagentCoordinator
    )
        : base(betaManagedAgentsMultiagentCoordinator) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentCoordinator(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentCoordinator(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentCoordinatorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentCoordinatorFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentCoordinator>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentCoordinator.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentCoordinatorTypeConverter))]
public enum BetaManagedAgentsMultiagentCoordinatorType
{
    Coordinator,
}

sealed class BetaManagedAgentsMultiagentCoordinatorTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentCoordinatorType>
{
    public override BetaManagedAgentsMultiagentCoordinatorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
            _ => (BetaManagedAgentsMultiagentCoordinatorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentCoordinatorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentCoordinatorType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
