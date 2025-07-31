using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using MessageParamProperties = Anthropic.Models.Messages.MessageParamProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageParam>))]
public sealed record class MessageParam : ModelBase, IFromRaw<MessageParam>
{
    public required MessageParamProperties::Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "content",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MessageParamProperties::Content>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("content");
        }
        set { this.Properties["content"] = JsonSerializer.SerializeToElement(value); }
    }

    public required MessageParamProperties::Role Role
    {
        get
        {
            if (!this.Properties.TryGetValue("role", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "role",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<MessageParamProperties::Role>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("role");
        }
        set { this.Properties["role"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Content.Validate();
        this.Role.Validate();
    }

    public MessageParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
