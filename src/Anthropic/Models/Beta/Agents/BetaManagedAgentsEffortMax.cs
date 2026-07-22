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
/// Maximum effort. Favors reasoning depth over latency.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortMax, BetaManagedAgentsEffortMaxFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortMax : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEffortMaxType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsEffortMaxType>>(
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

    public BetaManagedAgentsEffortMax() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMax(BetaManagedAgentsEffortMax betaManagedAgentsEffortMax)
        : base(betaManagedAgentsEffortMax) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortMax(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortMax(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortMaxFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortMax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEffortMax(ApiEnum<string, BetaManagedAgentsEffortMaxType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEffortMaxFromRaw : IFromRawJson<BetaManagedAgentsEffortMax>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortMax FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortMax.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEffortMaxTypeConverter))]
public enum BetaManagedAgentsEffortMaxType
{
    Max,
}

sealed class BetaManagedAgentsEffortMaxTypeConverter : JsonConverter<BetaManagedAgentsEffortMaxType>
{
    public override BetaManagedAgentsEffortMaxType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "max" => BetaManagedAgentsEffortMaxType.Max,
            _ => (BetaManagedAgentsEffortMaxType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortMaxType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortMaxType.Max => "max",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
