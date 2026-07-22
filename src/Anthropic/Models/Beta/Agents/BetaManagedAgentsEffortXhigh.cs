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
/// Extra-high effort. Not all models accept this level.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsEffortXhigh, BetaManagedAgentsEffortXhighFromRaw>)
)]
public sealed record class BetaManagedAgentsEffortXhigh : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsEffortXhighType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsEffortXhighType>>(
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

    public BetaManagedAgentsEffortXhigh() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEffortXhigh(BetaManagedAgentsEffortXhigh betaManagedAgentsEffortXhigh)
        : base(betaManagedAgentsEffortXhigh) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEffortXhigh(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEffortXhigh(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEffortXhighFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEffortXhigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsEffortXhigh(ApiEnum<string, BetaManagedAgentsEffortXhighType> type)
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsEffortXhighFromRaw : IFromRawJson<BetaManagedAgentsEffortXhigh>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEffortXhigh FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEffortXhigh.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsEffortXhighTypeConverter))]
public enum BetaManagedAgentsEffortXhighType
{
    Xhigh,
}

sealed class BetaManagedAgentsEffortXhighTypeConverter
    : JsonConverter<BetaManagedAgentsEffortXhighType>
{
    public override BetaManagedAgentsEffortXhighType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "xhigh" => BetaManagedAgentsEffortXhighType.Xhigh,
            _ => (BetaManagedAgentsEffortXhighType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEffortXhighType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEffortXhighType.Xhigh => "xhigh",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
