using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages.Batches;

[JsonConverter(typeof(ModelConverter<MessageBatchErroredResult>))]
public sealed record class MessageBatchErroredResult
    : ModelBase,
        IFromRaw<MessageBatchErroredResult>
{
    public required ErrorResponse Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new ArgumentOutOfRangeException("error", "Missing required argument");

            return JsonSerializer.Deserialize<ErrorResponse>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("error");
        }
        set
        {
            this.Properties["error"] = JsonSerializer.SerializeToElement(
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
        this.Error.Validate();
    }

    public MessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageBatchErroredResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchErroredResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageBatchErroredResult(ErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}
