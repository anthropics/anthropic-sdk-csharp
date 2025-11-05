using System.Collections.Frozen;
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
    /// The cumulative number of input tokens read from the cache.
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
    /// The cumulative number of input tokens which were used.
    /// </summary>
    public required long? InputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("input_tokens", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
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
    /// The cumulative number of output tokens which were used.
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
    public required ServerToolUsage? ServerToolUse
    {
        get
        {
            if (!this._properties.TryGetValue("server_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ServerToolUsage?>(
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

    public override void Validate()
    {
        _ = this.CacheCreationInputTokens;
        _ = this.CacheReadInputTokens;
        _ = this.InputTokens;
        _ = this.OutputTokens;
        this.ServerToolUse?.Validate();
    }

    public MessageDeltaUsage() { }

    public MessageDeltaUsage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageDeltaUsage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MessageDeltaUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
