using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaUsage>))]
public sealed record class BetaUsage : ModelBase, IFromRaw<BetaUsage>
{
    /// <summary>
    /// Breakdown of cached tokens by TTL
    /// </summary>
    public required BetaCacheCreation? CacheCreation
    {
        get
        {
            if (!this._properties.TryGetValue("cache_creation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheCreation?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_creation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens used to create the cache entry.
    /// </summary>
    public required long? CacheCreationInputTokens
    {
        get
        {
            if (
                !this._properties.TryGetValue(
                    "cache_creation_input_tokens",
                    out JsonElement element
                )
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cache_creation_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens read from the cache.
    /// </summary>
    public required long? CacheReadInputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("cache_read_input_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cache_read_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens which were used.
    /// </summary>
    public required long InputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("output_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'output_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "output_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["output_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of server tool requests.
    /// </summary>
    public required BetaServerToolUsage? ServerToolUse
    {
        get
        {
            if (!this._properties.TryGetValue("server_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaServerToolUsage?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["server_tool_use"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the request used the priority, standard, or batch tier.
    /// </summary>
    public required ApiEnum<string, BetaUsageServiceTier>? ServiceTier
    {
        get
        {
            if (!this._properties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, BetaUsageServiceTier>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["service_tier"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public BetaUsage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUsage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
