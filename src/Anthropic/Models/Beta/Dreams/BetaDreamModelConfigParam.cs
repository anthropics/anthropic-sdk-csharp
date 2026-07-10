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
/// Model identifier and configuration applied to every pipeline stage.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamModelConfigParam, BetaDreamModelConfigParamFromRaw>)
)]
public sealed record class BetaDreamModelConfigParam : JsonModel
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
    public ApiEnum<string, BetaDreamModelConfigParamSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaDreamModelConfigParamSpeed>>(
                "speed"
            );
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Speed?.Validate();
    }

    public BetaDreamModelConfigParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamModelConfigParam(BetaDreamModelConfigParam betaDreamModelConfigParam)
        : base(betaDreamModelConfigParam) { }
#pragma warning restore CS8618

    public BetaDreamModelConfigParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamModelConfigParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamModelConfigParamFromRaw.FromRawUnchecked"/>
    public static BetaDreamModelConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamModelConfigParam(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDreamModelConfigParamFromRaw : IFromRawJson<BetaDreamModelConfigParam>
{
    /// <inheritdoc/>
    public BetaDreamModelConfigParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamModelConfigParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Inference speed mode. `fast` provides significantly faster output token generation
/// at premium pricing. Not all models support `fast`; invalid combinations are rejected
/// at create time.
/// </summary>
[JsonConverter(typeof(BetaDreamModelConfigParamSpeedConverter))]
public enum BetaDreamModelConfigParamSpeed
{
    Standard,
    Fast,
}

sealed class BetaDreamModelConfigParamSpeedConverter : JsonConverter<BetaDreamModelConfigParamSpeed>
{
    public override BetaDreamModelConfigParamSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaDreamModelConfigParamSpeed.Standard,
            "fast" => BetaDreamModelConfigParamSpeed.Fast,
            _ => (BetaDreamModelConfigParamSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaDreamModelConfigParamSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaDreamModelConfigParamSpeed.Standard => "standard",
                BetaDreamModelConfigParamSpeed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
