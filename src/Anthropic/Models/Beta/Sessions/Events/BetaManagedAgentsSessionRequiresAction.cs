using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        _ = this.EventIds;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("requires_action"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionRequiresAction()
    {
        this.Type = JsonSerializer.SerializeToElement("requires_action");
    }

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

        this.Type = JsonSerializer.SerializeToElement("requires_action");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRequiresAction(IReadOnlyList<string> eventIds)
        : this()
    {
        this.EventIds = eventIds;
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
