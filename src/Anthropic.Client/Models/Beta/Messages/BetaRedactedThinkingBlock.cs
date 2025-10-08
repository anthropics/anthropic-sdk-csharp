using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRedactedThinkingBlock>))]
public sealed record class BetaRedactedThinkingBlock
    : ModelBase,
        IFromRaw<BetaRedactedThinkingBlock>
{
    public required string Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
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
        _ = this.Data;
    }

    public BetaRedactedThinkingBlock()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRedactedThinkingBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRedactedThinkingBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaRedactedThinkingBlock(string data)
        : this()
    {
        this.Data = data;
    }
}
