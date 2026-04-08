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
/// The turn ended because the retry budget was exhausted (`max_iterations` hit or
/// an error escalated to `retry_status: 'exhausted'`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionRetriesExhausted,
        BetaManagedAgentsSessionRetriesExhaustedFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionRetriesExhausted : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionRetriesExhausted() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRetriesExhausted(
        BetaManagedAgentsSessionRetriesExhausted betaManagedAgentsSessionRetriesExhausted
    )
        : base(betaManagedAgentsSessionRetriesExhausted) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionRetriesExhausted(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionRetriesExhausted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionRetriesExhaustedFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionRetriesExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSessionRetriesExhausted(
        ApiEnum<string, BetaManagedAgentsSessionRetriesExhaustedType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsSessionRetriesExhaustedFromRaw
    : IFromRawJson<BetaManagedAgentsSessionRetriesExhausted>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionRetriesExhausted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionRetriesExhausted.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsSessionRetriesExhaustedTypeConverter))]
public enum BetaManagedAgentsSessionRetriesExhaustedType
{
    RetriesExhausted,
}

sealed class BetaManagedAgentsSessionRetriesExhaustedTypeConverter
    : JsonConverter<BetaManagedAgentsSessionRetriesExhaustedType>
{
    public override BetaManagedAgentsSessionRetriesExhaustedType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "retries_exhausted" => BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted,
            _ => (BetaManagedAgentsSessionRetriesExhaustedType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionRetriesExhaustedType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionRetriesExhaustedType.RetriesExhausted =>
                    "retries_exhausted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
