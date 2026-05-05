using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// A coordinator topology: the session's primary thread orchestrates work by spawning
/// session threads, each running an agent drawn from the `agents` roster.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMultiagentParams,
        BetaManagedAgentsMultiagentParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMultiagentParams : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsMultiagentParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
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

    public BetaManagedAgentsMultiagentParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMultiagentParams(
        BetaManagedAgentsMultiagentParams betaManagedAgentsMultiagentParams
    )
        : base(betaManagedAgentsMultiagentParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMultiagentParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMultiagentParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMultiagentParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMultiagentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMultiagentParamsFromRaw : IFromRawJson<BetaManagedAgentsMultiagentParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMultiagentParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMultiagentParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMultiagentParamsTypeConverter))]
public enum BetaManagedAgentsMultiagentParamsType
{
    Coordinator,
}

sealed class BetaManagedAgentsMultiagentParamsTypeConverter
    : JsonConverter<BetaManagedAgentsMultiagentParamsType>
{
    public override BetaManagedAgentsMultiagentParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coordinator" => BetaManagedAgentsMultiagentParamsType.Coordinator,
            _ => (BetaManagedAgentsMultiagentParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMultiagentParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMultiagentParamsType.Coordinator => "coordinator",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
