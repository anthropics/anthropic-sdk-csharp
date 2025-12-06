using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaUsage, BetaUsageFromRaw>))]
public sealed record class BetaUsage : ModelBase
{
    /// <summary>
    /// Breakdown of cached tokens by TTL
    /// </summary>
    public required BetaCacheCreation? CacheCreation
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheCreation>(this.RawData, "cache_creation");
        }
        init { ModelBase.Set(this._rawData, "cache_creation", value); }
    }

    /// <summary>
    /// The number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            return ModelBase.GetNullableStruct<long>(this.RawData, "cache_creation_input_tokens");
        }
        init { ModelBase.Set(this._rawData, "cache_creation_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "cache_read_input_tokens"); }
        init { ModelBase.Set(this._rawData, "cache_read_input_tokens", value); }
    }

    /// <summary>
    /// The number of input tokens which were used.
    /// </summary>
    public required long InputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "input_tokens"); }
        init { ModelBase.Set(this._rawData, "input_tokens", value); }
    }

    /// <summary>
    /// The number of output tokens which were used.
    /// </summary>
    public required long OutputTokens
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "output_tokens"); }
        init { ModelBase.Set(this._rawData, "output_tokens", value); }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            return ModelBase.GetNullableClass<BetaServerToolUsage>(this.RawData, "server_tool_use");
        }
        init { ModelBase.Set(this._rawData, "server_tool_use", value); }
    }

    /// <summary>
    /// If the request used the priority, standard, or batch tier.
    /// </summary>
    public required ApiEnum<string, BetaUsageServiceTier>? ServiceTier
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, BetaUsageServiceTier>>(
                this.RawData,
                "service_tier"
            );
        }
        init { ModelBase.Set(this._rawData, "service_tier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheCreation?.Validate();
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
        this.ServiceTier?.Validate();
    }

    public BetaUsage() { }

    public BetaUsage(BetaUsage betaUsage)
        : base(betaUsage) { }

    public BetaUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaUsageFromRaw.FromRawUnchecked"/>
    public static BetaUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaUsageFromRaw : IFromRaw<BetaUsage>
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
