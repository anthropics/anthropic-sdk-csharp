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
/// An object that defines additional configuration control over model use
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsModelConfigParams,
        BetaManagedAgentsModelConfigParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsModelConfigParams : JsonModel
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
    public ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaManagedAgentsModelConfigParamsSpeed>
            >("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ID.Raw();
        this.Speed?.Validate();
    }

    public BetaManagedAgentsModelConfigParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfigParams(
        BetaManagedAgentsModelConfigParams betaManagedAgentsModelConfigParams
    )
        : base(betaManagedAgentsModelConfigParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsModelConfigParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsModelConfigParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsModelConfigParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsModelConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsModelConfigParams(ApiEnum<string, BetaManagedAgentsModel> id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsModelConfigParamsFromRaw : IFromRawJson<BetaManagedAgentsModelConfigParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsModelConfigParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsModelConfigParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Inference speed mode. `fast` provides significantly faster output token generation
/// at premium pricing. Not all models support `fast`; invalid combinations are rejected
/// at create time.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsModelConfigParamsSpeedConverter))]
public enum BetaManagedAgentsModelConfigParamsSpeed
{
    Standard,
    Fast,
}

sealed class BetaManagedAgentsModelConfigParamsSpeedConverter
    : JsonConverter<BetaManagedAgentsModelConfigParamsSpeed>
{
    public override BetaManagedAgentsModelConfigParamsSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaManagedAgentsModelConfigParamsSpeed.Standard,
            "fast" => BetaManagedAgentsModelConfigParamsSpeed.Fast,
            _ => (BetaManagedAgentsModelConfigParamsSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsModelConfigParamsSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsModelConfigParamsSpeed.Standard => "standard",
                BetaManagedAgentsModelConfigParamsSpeed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
