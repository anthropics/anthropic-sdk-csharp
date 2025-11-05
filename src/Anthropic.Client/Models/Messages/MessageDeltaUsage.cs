using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageDeltaUsage>))]
public sealed record class MessageDeltaUsage : ModelBase, IFromRaw<MessageDeltaUsage>
{
    /// <summary>
    /// The cumulative number of input tokens used to create the cache entry.
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
    /// The cumulative number of input tokens read from the cache.
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
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get
        {
            if (!this.Properties.TryGetValue("input_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
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
    /// The cumulative number of output tokens which were used.
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
    public required ServerToolUsage? ServerToolUse
    {
        get
        {
            if (!this.Properties.TryGetValue("server_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ServerToolUsage?>(
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

    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public MessageDeltaUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageDeltaUsage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageDeltaUsage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
