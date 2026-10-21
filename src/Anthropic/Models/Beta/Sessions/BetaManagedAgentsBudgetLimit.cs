using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// A hard spend ceiling. The session stops issuing new model requests once the tracked
/// list cost reaches `max_list_cost`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsBudgetLimit, BetaManagedAgentsBudgetLimitFromRaw>)
)]
public sealed record class BetaManagedAgentsBudgetLimit : JsonModel
{
    /// <summary>
    /// Maximum list cost the session may accrue. List price is used regardless of
    /// any negotiated discount, so the cap fires at or before the actual charge.
    /// </summary>
    public required BetaMonetaryAmount MaxListCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaMonetaryAmount>("max_list_cost");
        }
        init { this._rawData.Set("max_list_cost", value); }
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
        this.MaxListCost.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("limit")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsBudgetLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBudgetLimit(BetaManagedAgentsBudgetLimit betaManagedAgentsBudgetLimit)
        : base(betaManagedAgentsBudgetLimit) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBudgetLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsBudgetLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsBudgetLimitFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsBudgetLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsBudgetLimit(BetaMonetaryAmount maxListCost)
        : this()
    {
        this.MaxListCost = maxListCost;
    }
}

class BetaManagedAgentsBudgetLimitFromRaw : IFromRawJson<BetaManagedAgentsBudgetLimit>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBudgetLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBudgetLimit.FromRawUnchecked(rawData);
}
