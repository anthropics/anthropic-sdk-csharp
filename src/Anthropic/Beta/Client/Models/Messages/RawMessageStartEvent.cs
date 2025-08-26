using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawMessageStartEvent>))]
public sealed record class RawMessageStartEvent : ModelBase, IFromRaw<RawMessageStartEvent>
{
    public required Message Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                throw new ArgumentOutOfRangeException("message", "Missing required argument");

            return JsonSerializer.Deserialize<Message>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("message");
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
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

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
    }

    public RawMessageStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawMessageStartEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawMessageStartEvent FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public RawMessageStartEvent(Message message)
        : this()
    {
        this.Message = message;
    }
}
