using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchCanceledResult>))]
public sealed record class MessageBatchCanceledResult
    : ModelBase,
        IFromRaw<MessageBatchCanceledResult>
{
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

    public override void Validate() { }

    public MessageBatchCanceledResult()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchCanceledResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchCanceledResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
