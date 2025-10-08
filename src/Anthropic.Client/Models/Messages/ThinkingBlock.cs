using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ThinkingBlock>))]
public sealed record class ThinkingBlock : ModelBase, IFromRaw<ThinkingBlock>
{
    public required string Signature
    {
        get
        {
            if (!this.Properties.TryGetValue("signature", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new ArgumentOutOfRangeException("signature", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new ArgumentNullException("signature")
                );
        }
        set
        {
            this.Properties["signature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Thinking
    {
        get
        {
            if (!this.Properties.TryGetValue("thinking", out JsonElement element))
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
        set
        {
            this.Properties["thinking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Signature;
        _ = this.Thinking;
    }

    public ThinkingBlock()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ThinkingBlock FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
