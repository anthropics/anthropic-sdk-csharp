using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingDelta>))]
public sealed record class BetaThinkingDelta : ModelBase, IFromRaw<BetaThinkingDelta>
{
    public required string Thinking
    {
        get
        {
            if (!this._properties.TryGetValue("thinking", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'thinking' cannot be null",
                    new ArgumentOutOfRangeException("thinking", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'thinking' cannot be null",
                    new ArgumentNullException("thinking")
                );
        }
        init
        {
            this._properties["thinking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        _ = this.Thinking;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaThinkingDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

    public BetaThinkingDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaThinkingDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaThinkingDelta(string thinking)
        : this()
    {
        this.Thinking = thinking;
    }
}
