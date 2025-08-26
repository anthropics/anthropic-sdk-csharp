using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchSucceededResult>))]
public sealed record class MessageBatchSucceededResult
    : ModelBase,
        IFromRaw<MessageBatchSucceededResult>
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

    public MessageBatchSucceededResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchSucceededResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchSucceededResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageBatchSucceededResult(Message message)
        : this()
    {
        this.Message = message;
    }
}
