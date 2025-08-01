using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.Batches;

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
                throw new global::System.ArgumentOutOfRangeException(
                    "error",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ErrorResponse>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("error");
        }
        set { this.Properties["error"] = JsonSerializer.SerializeToElement(value); }
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

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
