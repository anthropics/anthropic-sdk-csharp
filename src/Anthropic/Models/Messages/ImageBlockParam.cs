using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using ImageBlockParamProperties = Anthropic.Models.Messages.ImageBlockParamProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<ImageBlockParam>))]
public sealed record class ImageBlockParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<ImageBlockParam>
{
    public required ImageBlockParamProperties::Source Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<ImageBlockParamProperties::Source>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("source");
        }
        set { this.Properties["source"] = JsonSerializer.SerializeToElement(value); }
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
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["cache_control"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Source.Validate();
        this.CacheControl?.Validate();
    }

    public ImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
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
    public ImageBlockParam(ImageBlockParamProperties::Source source)
        : this()
    {
        this.Source = source;
    }
}
