using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The agent stopped because the session's tracked list cost reached its budget,
/// or because its usage includes a model with no list price (which the budget cannot
/// measure). Raise the budget to continue — or, if raising is rejected because a
/// model has no list price, remove the budget.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionBudgetReached,
        BetaManagedAgentsSessionBudgetReachedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionBudgetReached : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("budget_reached")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsSessionBudgetReached()
    {
        this.Type = JsonSerializer.SerializeToElement("budget_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionBudgetReached(
        BetaManagedAgentsSessionBudgetReached betaManagedAgentsSessionBudgetReached
    )
        : base(betaManagedAgentsSessionBudgetReached) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionBudgetReached(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("budget_reached");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionBudgetReached(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionBudgetReachedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionBudgetReached FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionBudgetReachedFromRaw
    : IFromRawJson<BetaManagedAgentsSessionBudgetReached>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionBudgetReached FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionBudgetReached.FromRawUnchecked(rawData);
}
