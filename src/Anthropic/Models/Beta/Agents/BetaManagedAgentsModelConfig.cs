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
/// Model identifier and configuration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsModelConfig, BetaManagedAgentsModelConfigFromRaw>)
)]
public sealed record class BetaManagedAgentsModelConfig : JsonModel
{
    /// <summary>
    /// The model that will power your agent.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
    /// for additional details and options.
    /// </summary>
    public required ApiEnum<string, BetaManagedAgentsModel> ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsModel>>("id");
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
        this.ID.Raw();
        this.Speed?.Validate();
    }

    public BetaManagedAgentsModelConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfig(BetaManagedAgentsModelConfig betaManagedAgentsModelConfig)
        : base(betaManagedAgentsModelConfig) { }
#pragma warning restore CS8618

    public BetaManagedAgentsModelConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsModelConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsModelConfigFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfig(ApiEnum<string, BetaManagedAgentsModel> id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsModelConfigFromRaw : IFromRawJson<BetaManagedAgentsModelConfig>
{
    /// <inheritdoc/>
    public BetaManagedAgentsModelConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsModelConfig.FromRawUnchecked(rawData);
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
