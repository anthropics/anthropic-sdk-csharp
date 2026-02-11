using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaUsage, BetaUsageFromRaw>))]
public sealed record class BetaUsage : JsonModel
{
    /// <summary>
    /// Breakdown of cached tokens by TTL
    /// </summary>
    public required BetaCacheCreation? CacheCreation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheCreation>("cache_creation");
        }
        init { this._rawData.Set("cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_creation_input_tokens");
        }
        init { this._rawData.Set("cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("cache_read_input_tokens");
        }
        init { this._rawData.Set("cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The geographic region where inference was performed for this request.
    /// </summary>
    public required string? InferenceGeo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("inference_geo");
        }
        init { this._rawData.Set("inference_geo", value); }
    }

    /// <summary>
    /// The number of input tokens which were used.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("input_tokens");
        }
        init { this._rawData.Set("input_tokens", value); }
    }

    /// <summary>
    /// Per-iteration token usage breakdown.
    ///
    /// <para>Each entry represents one sampling iteration, with its own input/output
    /// token counts and cache statistics. This allows you to: - Determine which
    /// iterations exceeded long context thresholds (>=200k tokens) - Calculate the
    /// true context window size from the last iteration - Understand token accumulation
    /// across server-side tool use loops</para>
    /// </summary>
    public required IReadOnlyList<BetaIterationsUsageItems>? Iterations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaIterationsUsageItems>>(
                "iterations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaIterationsUsageItems>?>(
                "iterations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("output_tokens");
        }
        init { this._rawData.Set("output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaServerToolUsage>("server_tool_use");
        }
        init { this._rawData.Set("server_tool_use", value); }
    }

    /// <summary>
    /// If the request used the priority, standard, or batch tier.
    /// </summary>
    public required ApiEnum<string, BetaUsageServiceTier>? ServiceTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaUsageServiceTier>>(
                "service_tier"
            );
        }
        init { this._rawData.Set("service_tier", value); }
    }

    /// <summary>
    /// The inference speed mode used for this request.
    /// </summary>
    public required ApiEnum<string, BetaUsageSpeed>? Speed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BetaUsageSpeed>>("speed");
        }
        init { this._rawData.Set("speed", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation?.Validate();
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InferenceGeo;
        _ = this.InputTokens;
        foreach (var item in this.Iterations ?? [])
        {
            item.Validate();
        }
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
        this.ServiceTier?.Validate();
        this.Speed?.Validate();
    }

    public BetaUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaUsage(BetaUsage betaUsage)
        : base(betaUsage) { }
#pragma warning restore CS8618

    public BetaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUsageFromRaw.FromRawUnchecked"/>
    public static BetaUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUsageFromRaw : IFromRawJson<BetaUsage>
{
    /// <inheritdoc/>
    public BetaUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaUsage.FromRawUnchecked(rawData);
}

/// <summary>
/// If the request used the priority, standard, or batch tier.
/// </summary>
[JsonConverter(typeof(BetaUsageServiceTierConverter))]
public enum BetaUsageServiceTier
{
    Standard,
    Priority,
    Batch,
}

sealed class BetaUsageServiceTierConverter : JsonConverter<BetaUsageServiceTier>
{
    public override BetaUsageServiceTier Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaUsageServiceTier.Standard,
            "priority" => BetaUsageServiceTier.Priority,
            "batch" => BetaUsageServiceTier.Batch,
            _ => (BetaUsageServiceTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUsageServiceTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUsageServiceTier.Standard => "standard",
                BetaUsageServiceTier.Priority => "priority",
                BetaUsageServiceTier.Batch => "batch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The inference speed mode used for this request.
/// </summary>
[JsonConverter(typeof(BetaUsageSpeedConverter))]
public enum BetaUsageSpeed
{
    Standard,
    Fast,
}

sealed class BetaUsageSpeedConverter : JsonConverter<BetaUsageSpeed>
{
    public override BetaUsageSpeed Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => BetaUsageSpeed.Standard,
            "fast" => BetaUsageSpeed.Fast,
            _ => (BetaUsageSpeed)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaUsageSpeed value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaUsageSpeed.Standard => "standard",
                BetaUsageSpeed.Fast => "fast",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
