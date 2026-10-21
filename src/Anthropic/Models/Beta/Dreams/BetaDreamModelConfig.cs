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
/// The model that runs a dream, from the request that created it.
///
/// <para>The dream uses this model for all of its work. The response always gives
/// the model as an object, even if the request gave only a model ID.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamModelConfig, BetaDreamModelConfigFromRaw>))]
public sealed record class BetaDreamModelConfig : JsonModel
{
    /// <summary>
    /// The ID of the model that runs the dream, as given in the request that created it.
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
    /// How fast the model generates output for the dream. Always `standard`.
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
                this._rawData.Remove("speed");
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
/// How fast the model generates output for the dream. Always `standard`.
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
