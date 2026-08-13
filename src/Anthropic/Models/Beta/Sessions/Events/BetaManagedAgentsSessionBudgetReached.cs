using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    public required ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionBudgetReached() { }

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

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionBudgetReached(
        ApiEnum<string, BetaManagedAgentsSessionBudgetReachedType> type
    )
        : this()
    {
        this.Type = type;
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

[JsonConverter(typeof(BetaManagedAgentsSessionBudgetReachedTypeConverter))]
public enum BetaManagedAgentsSessionBudgetReachedType
{
    BudgetReached,
}

sealed class BetaManagedAgentsSessionBudgetReachedTypeConverter
    : JsonConverter<BetaManagedAgentsSessionBudgetReachedType>
{
    public override BetaManagedAgentsSessionBudgetReachedType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "budget_reached" => BetaManagedAgentsSessionBudgetReachedType.BudgetReached,
            _ => (BetaManagedAgentsSessionBudgetReachedType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionBudgetReachedType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionBudgetReachedType.BudgetReached => "budget_reached",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
