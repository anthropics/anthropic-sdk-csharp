using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

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
            if (!this.Properties.TryGetValue("cache_creation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheCreation?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_creation"] = JsonSerializer.SerializeToElement(
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
                !this.Properties.TryGetValue("cache_creation_input_tokens", out JsonElement element)
            )
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cache_creation_input_tokens"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("cache_read_input_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cache_read_input_tokens"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["input_tokens"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("output_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'output_tokens' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "output_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["output_tokens"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("server_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaServerToolUsage?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["server_tool_use"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If the request used the priority, standard, or batch tier.
    /// </summary>
    public required ApiEnum<string, ServiceTierModel>? ServiceTier
    {
        get
        {
            if (!this.Properties.TryGetValue("service_tier", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, ServiceTierModel>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["service_tier"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaUsage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// If the request used the priority, standard, or batch tier.
/// </summary>
[JsonConverter(typeof(ServiceTierModelConverter))]
public enum ServiceTierModel
{
    Standard,
    Priority,
    Batch,
}

sealed class ServiceTierModelConverter : JsonConverter<ServiceTierModel>
{
    public override ServiceTierModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "standard" => ServiceTierModel.Standard,
            "priority" => ServiceTierModel.Priority,
            "batch" => ServiceTierModel.Batch,
            _ => (ServiceTierModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServiceTierModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServiceTierModel.Standard => "standard",
                ServiceTierModel.Priority => "priority",
                ServiceTierModel.Batch => "batch",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
