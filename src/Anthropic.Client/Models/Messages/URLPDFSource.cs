using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<URLPDFSource>))]
public sealed record class URLPDFSource : ModelBase, IFromRaw<URLPDFSource>
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

    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.URL;
    }

    public URLPDFSource()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    URLPDFSource(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static URLPDFSource FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public URLPDFSource(string url)
        : this()
    {
        this.URL = url;
    }
}
