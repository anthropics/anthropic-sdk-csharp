using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Base64ImageSourceProperties = Anthropic.Models.Messages.Base64ImageSourceProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Base64ImageSource>))]
public sealed record class Base64ImageSource : ModelBase, IFromRaw<Base64ImageSource>
{
    public required string Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "data",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new global::System.ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Base64ImageSourceProperties::MediaType MediaType
    {
        get
        {
            if (!this.Properties.TryGetValue("media_type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "media_type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Base64ImageSourceProperties::MediaType>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("media_type");
        }
        set { this.Properties["media_type"] = JsonSerializer.SerializeToElement(value); }
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
        _ = this.Data;
        this.MediaType.Validate();
    }

    public Base64ImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Base64ImageSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Base64ImageSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
