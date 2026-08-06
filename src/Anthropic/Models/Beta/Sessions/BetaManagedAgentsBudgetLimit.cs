using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

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
    /// A monetary amount in a specific currency.
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

    public required ApiEnum<string, BetaManagedAgentsBudgetLimitType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsBudgetLimitType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MaxListCost.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsBudgetLimit() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsBudgetLimit(BetaManagedAgentsBudgetLimit betaManagedAgentsBudgetLimit)
        : base(betaManagedAgentsBudgetLimit) { }
#pragma warning restore CS8618

    public BetaManagedAgentsBudgetLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
}

class BetaManagedAgentsBudgetLimitFromRaw : IFromRawJson<BetaManagedAgentsBudgetLimit>
{
    /// <inheritdoc/>
    public BetaManagedAgentsBudgetLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsBudgetLimit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsBudgetLimitTypeConverter))]
public enum BetaManagedAgentsBudgetLimitType
{
    Limit,
}

sealed class BetaManagedAgentsBudgetLimitTypeConverter
    : JsonConverter<BetaManagedAgentsBudgetLimitType>
{
    public override BetaManagedAgentsBudgetLimitType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "limit" => BetaManagedAgentsBudgetLimitType.Limit,
            _ => (BetaManagedAgentsBudgetLimitType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsBudgetLimitType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsBudgetLimitType.Limit => "limit",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
