using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawMessageStartEvent>))]
public sealed record class RawMessageStartEvent : ModelBase, IFromRaw<RawMessageStartEvent>
{
    public required Message Message
    {
        get
        {
            if (!this._properties.TryGetValue("message", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Message>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentNullException("message")
                );
        }
        init
        {
            this._properties["message"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        this.Message.Validate();
        _ = this.Type;
    }

    public RawMessageStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

    public RawMessageStartEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageStartEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RawMessageStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public RawMessageStartEvent(Message message)
        : this()
    {
        this.Message = message;
    }
}
