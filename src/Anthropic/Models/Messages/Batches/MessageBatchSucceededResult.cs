using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.Batches;

[JsonConverter(typeof(Anthropic::ModelConverter<MessageBatchSucceededResult>))]
public sealed record class MessageBatchSucceededResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<MessageBatchSucceededResult>
{
    public required Messages::Message Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Messages::Message>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("message");
        }
        set { this.Properties["message"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
    public MessageBatchSucceededResult(Messages::Message message)
        : this()
    {
        this.Message = message;
    }
}
