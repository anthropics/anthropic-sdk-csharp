using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The agent is idle waiting on one or more blocking user-input events (tool confirmation,
/// custom tool result, etc.). Resolving all of them transitions the session back
/// to running.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRequiresAction,
        BetaManagedAgentsSessionRequiresActionFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRequiresAction : JsonModel
{
    /// <summary>
    /// The ids of events the agent is blocked on. Resolving fewer than all re-emits
    /// `session.status_idle` with the remainder.
    /// </summary>
    public required IReadOnlyList<string> EventIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("event_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "event_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionRequiresActionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionRequiresActionType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventIds;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionRequiresAction() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRequiresAction(
        BetaManagedAgentsSessionRequiresAction betaManagedAgentsSessionRequiresAction
    )
        : base(betaManagedAgentsSessionRequiresAction) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRequiresAction(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRequiresAction(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRequiresActionFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRequiresAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionRequiresActionFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRequiresAction>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRequiresAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRequiresAction.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionRequiresActionTypeConverter))]
public enum BetaManagedAgentsSessionRequiresActionType
{
    RequiresAction,
}

sealed class BetaManagedAgentsSessionRequiresActionTypeConverter
    : JsonConverter<BetaManagedAgentsSessionRequiresActionType>
{
    public override BetaManagedAgentsSessionRequiresActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "requires_action" => BetaManagedAgentsSessionRequiresActionType.RequiresAction,
            _ => (BetaManagedAgentsSessionRequiresActionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionRequiresActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionRequiresActionType.RequiresAction => "requires_action",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
