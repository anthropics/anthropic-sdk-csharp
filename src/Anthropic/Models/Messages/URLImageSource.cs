using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<URLImageSource>))]
public sealed record class URLImageSource
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<URLImageSource>
{
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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "url",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("url");
        }
        set { this.Properties["url"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.URL;
    }

    public URLImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"url\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    URLImageSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static URLImageSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public URLImageSource(string url)
        : this()
    {
        this.URL = url;
    }
}
