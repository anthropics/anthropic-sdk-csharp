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
/// Low effort. Favors latency over reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortLow, BetaManagedAgentsEffortLowFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortLow : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEffortLowType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsEffortLowType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsEffortLow() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortLow(BetaManagedAgentsEffortLow betaManagedAgentsEffortLow)
        : base(betaManagedAgentsEffortLow) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortLow(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortLow(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortLowFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortLow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEffortLow(ApiEnum<string, BetaManagedAgentsEffortLowType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEffortLowFromRaw : IFromRawJson<BetaManagedAgentsEffortLow>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortLow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortLow.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEffortLowTypeConverter))]
public enum BetaManagedAgentsEffortLowType
{
    Low,
}

sealed class BetaManagedAgentsEffortLowTypeConverter : JsonConverter<BetaManagedAgentsEffortLowType>
{
    public override BetaManagedAgentsEffortLowType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low" => BetaManagedAgentsEffortLowType.Low,
            _ => (BetaManagedAgentsEffortLowType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortLowType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortLowType.Low => "low",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
