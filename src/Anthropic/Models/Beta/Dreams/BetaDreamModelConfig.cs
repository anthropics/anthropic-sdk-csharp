using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Model identifier and configuration applied to every pipeline stage. Same wire
/// shape as the Agents API ModelConfig.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamModelConfig, BetaDreamModelConfigFromRaw>))]
public sealed record class BetaDreamModelConfig : JsonModel
{
    /// <summary>
    /// Model identifier, e.g. "claude-opus-4-7". 1-256 characters.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Inference speed mode. `fast` provides significantly faster output token generation
    /// at premium pricing. Not all models support `fast`; invalid combinations are
    /// rejected at create time.
    /// </summary>
    public ApiEnum<string, Speed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Speed>>("speed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Speed?.Validate();
    }

    public BetaDreamModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamModelConfig(BetaDreamModelConfig betaDreamModelConfig)
        : base(betaDreamModelConfig) { }
#pragma warning restore CS8618

    public BetaDreamModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamModelConfigFromRaw.FromRawUnchecked"/>
    public static BetaDreamModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamModelConfig(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDreamModelConfigFromRaw : IFromRawJson<BetaDreamModelConfig>
{
    /// <inheritdoc/>
    public BetaDreamModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamModelConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Inference speed mode. `fast` provides significantly faster output token generation
/// at premium pricing. Not all models support `fast`; invalid combinations are rejected
/// at create time.
/// </summary>
[JsonConverter(typeof(SpeedConverter))]
public enum Speed
{
    Standard,
    Fast,
}

sealed class SpeedConverter : JsonConverter<Speed>
{
    public override Speed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => Speed.Standard,
            "fast" => Speed.Fast,
            _ => (Speed)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Speed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Speed.Standard => "standard",
                Speed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
