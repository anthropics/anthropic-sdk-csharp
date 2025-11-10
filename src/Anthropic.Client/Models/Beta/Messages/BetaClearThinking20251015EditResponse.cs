using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaClearThinking20251015EditResponse>))]
public sealed record class BetaClearThinking20251015EditResponse
    : ModelBase,
        IFromRaw<BetaClearThinking20251015EditResponse>
{
    /// <summary>
    /// Number of input tokens cleared by this edit.
    /// </summary>
    public required long ClearedInputTokens
    {
        get
        {
            if (!this._properties.TryGetValue("cleared_input_tokens", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cleared_input_tokens' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cleared_input_tokens",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cleared_input_tokens"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of thinking turns that were cleared.
    /// </summary>
    public required long ClearedThinkingTurns
    {
        get
        {
            if (!this._properties.TryGetValue("cleared_thinking_turns", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cleared_thinking_turns' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cleared_thinking_turns",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cleared_thinking_turns"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of context management edit applied.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ClearedInputTokens;
        _ = this.ClearedThinkingTurns;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClearThinking20251015EditResponse()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

    public BetaClearThinking20251015EditResponse(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"clear_thinking_20251015\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearThinking20251015EditResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaClearThinking20251015EditResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
