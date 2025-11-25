using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<CacheCreation>))]
public sealed record class CacheCreation : ModelBase, IFromRaw<CacheCreation>
{
    /// <summary>
    /// The number of input tokens used to create the 1 hour cache entry.
    /// </summary>
    public required long Ephemeral1hInputTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("ephemeral_1h_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'ephemeral_1h_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "ephemeral_1h_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["ephemeral_1h_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of input tokens used to create the 5 minute cache entry.
    /// </summary>
    public required long Ephemeral5mInputTokens
    {
        get
        {
            if (!this._rawData.TryGetValue("ephemeral_5m_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'ephemeral_5m_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "ephemeral_5m_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["ephemeral_5m_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Ephemeral1hInputTokens;
        _ = this.Ephemeral5mInputTokens;
    }

    public CacheCreation() { }

    public CacheCreation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CacheCreation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static CacheCreation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
