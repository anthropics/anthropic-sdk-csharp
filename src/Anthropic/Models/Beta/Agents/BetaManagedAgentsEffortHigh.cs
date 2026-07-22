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
/// High effort. Favors reasoning depth.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortHigh, BetaManagedAgentsEffortHighFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortHigh : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEffortHighType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsEffortHighType>>(
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

    public BetaManagedAgentsEffortHigh() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortHigh(BetaManagedAgentsEffortHigh betaManagedAgentsEffortHigh)
        : base(betaManagedAgentsEffortHigh) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortHigh(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortHigh(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortHighFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortHigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEffortHigh(ApiEnum<string, BetaManagedAgentsEffortHighType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEffortHighFromRaw : IFromRawJson<BetaManagedAgentsEffortHigh>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortHigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortHigh.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEffortHighTypeConverter))]
public enum BetaManagedAgentsEffortHighType
{
    High,
}

sealed class BetaManagedAgentsEffortHighTypeConverter
    : JsonConverter<BetaManagedAgentsEffortHighType>
{
    public override BetaManagedAgentsEffortHighType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "high" => BetaManagedAgentsEffortHighType.High,
            _ => (BetaManagedAgentsEffortHighType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortHighType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortHighType.High => "high",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
