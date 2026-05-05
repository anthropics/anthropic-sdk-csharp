using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Threads;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Resolved coordinator topology with full agent definitions for each roster member.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionMultiagentCoordinator,
        BetaManagedAgentsSessionMultiagentCoordinatorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionMultiagentCoordinator : JsonModel
{
    /// <summary>
    /// Full `agent` definitions the coordinator may spawn as session threads.
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsSessionThreadAgent> Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsSessionThreadAgent>
            >("agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionThreadAgent>>(
                "agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionMultiagentCoordinatorType>
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

    public BetaManagedAgentsSessionMultiagentCoordinator() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionMultiagentCoordinator(
        BetaManagedAgentsSessionMultiagentCoordinator betaManagedAgentsSessionMultiagentCoordinator
    )
        : base(betaManagedAgentsSessionMultiagentCoordinator) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionMultiagentCoordinator(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionMultiagentCoordinator(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionMultiagentCoordinatorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionMultiagentCoordinatorFromRaw
    : IFromRawJson<BetaManagedAgentsSessionMultiagentCoordinator>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionMultiagentCoordinator FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionMultiagentCoordinator.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionMultiagentCoordinatorTypeConverter))]
public enum BetaManagedAgentsSessionMultiagentCoordinatorType
{
    Coordinator,
}

sealed class BetaManagedAgentsSessionMultiagentCoordinatorTypeConverter
    : JsonConverter<BetaManagedAgentsSessionMultiagentCoordinatorType>
{
    public override BetaManagedAgentsSessionMultiagentCoordinatorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator,
            _ => (BetaManagedAgentsSessionMultiagentCoordinatorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionMultiagentCoordinatorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionMultiagentCoordinatorType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
