using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchSucceededResult>))]
public sealed record class MessageBatchSucceededResult
    : ModelBase,
        IFromRaw<MessageBatchSucceededResult>
{
    public required Message Message
    {
        get
        {
            if (!this._properties.TryGetValue("message", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Message>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
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
        this.Message.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"succeeded\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public MessageBatchSucceededResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

    public MessageBatchSucceededResult(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchSucceededResult(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MessageBatchSucceededResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public MessageBatchSucceededResult(Message message)
        : this()
    {
        this.Message = message;
    }
}
