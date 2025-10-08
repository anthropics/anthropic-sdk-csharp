using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.ImageBlockParamProperties;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ImageBlockParam>))]
public sealed record class ImageBlockParam : ModelBase, IFromRaw<ImageBlockParam>
{
    public required Source Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentNullException("source")
                );
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Source.Validate();
        this.CacheControl?.Validate();
    }

    public ImageBlockParam()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ImageBlockParam FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ImageBlockParam(Source source)
        : this()
    {
        this.Source = source;
    }
}
