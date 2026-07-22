using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Medium effort. Balances latency and reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortMedium, BetaManagedAgentsEffortMediumFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortMedium : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEffortMediumType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEffortMediumType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsEffortMedium() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMedium(
        BetaManagedAgentsEffortMedium betaManagedAgentsEffortMedium
    )
        : base(betaManagedAgentsEffortMedium) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortMedium(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortMedium(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortMediumFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortMedium FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMedium(ApiEnum<string, BetaManagedAgentsEffortMediumType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEffortMediumFromRaw : IFromRawJson<BetaManagedAgentsEffortMedium>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortMedium FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortMedium.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEffortMediumTypeConverter))]
public enum BetaManagedAgentsEffortMediumType
{
    Medium,
}

sealed class BetaManagedAgentsEffortMediumTypeConverter
    : JsonConverter<BetaManagedAgentsEffortMediumType>
{
    public override BetaManagedAgentsEffortMediumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "medium" => BetaManagedAgentsEffortMediumType.Medium,
            _ => (BetaManagedAgentsEffortMediumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortMediumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortMediumType.Medium => "medium",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
