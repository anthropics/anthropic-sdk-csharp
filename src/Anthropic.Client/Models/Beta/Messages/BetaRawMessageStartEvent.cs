using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRawMessageStartEvent>))]
public sealed record class BetaRawMessageStartEvent : ModelBase, IFromRaw<BetaRawMessageStartEvent>
{
    public required BetaMessage Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaMessage>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentNullException("message")
                );
        }
        set
        {
            this.Properties["message"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        this.Message.Validate();
        _ = this.Type;
    }

    public BetaRawMessageStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageStartEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawMessageStartEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaRawMessageStartEvent(BetaMessage message)
        : this()
    {
        this.Message = message;
    }
}
