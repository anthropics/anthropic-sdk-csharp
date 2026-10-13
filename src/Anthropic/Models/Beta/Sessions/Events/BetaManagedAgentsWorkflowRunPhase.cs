using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// A phase that a workflow run's plan declares.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkflowRunPhase,
        BetaManagedAgentsWorkflowRunPhaseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkflowRunPhase : JsonModel
{
    /// <summary>
    /// Unique identifier for the phase.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Description that the agent gave the phase, passed on as written, or `null`
    /// if it gave none.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Name that the agent gave the phase, passed on as written.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
    }

    public BetaManagedAgentsWorkflowRunPhase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkflowRunPhase(
        BetaManagedAgentsWorkflowRunPhase betaManagedAgentsWorkflowRunPhase
    )
        : base(betaManagedAgentsWorkflowRunPhase) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkflowRunPhase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkflowRunPhase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkflowRunPhaseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkflowRunPhase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkflowRunPhaseFromRaw : IFromRawJson<BetaManagedAgentsWorkflowRunPhase>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkflowRunPhase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkflowRunPhase.FromRawUnchecked(rawData);
}
