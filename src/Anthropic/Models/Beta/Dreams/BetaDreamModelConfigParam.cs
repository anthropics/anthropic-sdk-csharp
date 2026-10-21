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
/// The object form of `model` in a request to create a dream.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaDreamModelConfigParam, BetaDreamModelConfigParamFromRaw>)
)]
public sealed record class BetaDreamModelConfigParam : JsonModel
{
    /// <summary>
    /// The ID of the model to run the dream with.
    ///
    /// <para>The ID can be 1 to 256 characters long.</para>
    ///
    /// <para>The [limits table in the Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#limits)
    /// lists the supported models.</para>
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
    /// How fast the model generates output for the dream. Defaults to `standard`.
    ///
    /// <para>Dreams accept only `standard`.</para>
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
/// How fast the model generates output for the dream. Defaults to `standard`.
///
/// <para>Dreams accept only `standard`.</para>
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
