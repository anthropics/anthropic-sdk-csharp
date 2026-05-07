using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// A coordinator topology: the session's primary thread orchestrates work by spawning
/// session threads, each running an agent drawn from the `agents` roster.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentCoordinatorParams,
        BetaManagedAgentsMultiagentCoordinatorParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentCoordinatorParams : JsonModel
{
    /// <summary>
    /// Agents the coordinator may spawn as session threads. 1–20 entries. Each entry
    /// is an agent ID string, a versioned `{"type":"agent","id","version"}` reference,
    /// or `{"type":"self"}` to allow recursive self-invocation. Entries must reference
    /// distinct agents (after resolving `self` and string forms); at most one `self`.
    /// Referenced agents must exist, must not be archived, and must not themselves
    /// have `multiagent` set (depth limit 1).
    /// </summary>
    public required IReadOnlyList<BetaManagedAgentsMultiagentRosterEntryParams> Agents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaManagedAgentsMultiagentRosterEntryParams>
            >("agents");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaManagedAgentsMultiagentRosterEntryParams>>(
                "agents",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType>
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

    public BetaManagedAgentsMultiagentCoordinatorParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentCoordinatorParams(
        BetaManagedAgentsMultiagentCoordinatorParams betaManagedAgentsMultiagentCoordinatorParams
    )
        : base(betaManagedAgentsMultiagentCoordinatorParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentCoordinatorParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentCoordinatorParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentCoordinatorParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentCoordinatorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentCoordinatorParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMultiagentCoordinatorParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentCoordinatorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentCoordinatorParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentCoordinatorParamsTypeConverter))]
public enum BetaManagedAgentsMultiagentCoordinatorParamsType
{
    Coordinator,
}

sealed class BetaManagedAgentsMultiagentCoordinatorParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentCoordinatorParamsType>
{
    public override BetaManagedAgentsMultiagentCoordinatorParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
            _ => (BetaManagedAgentsMultiagentCoordinatorParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentCoordinatorParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
