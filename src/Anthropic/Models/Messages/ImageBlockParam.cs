using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ImageBlockParam, ImageBlockParamFromRaw>))]
public sealed record class ImageBlockParam : ModelBase
{
    public required ImageBlockParamSource Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ImageBlockParamSource>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentNullException("source")
                );
        }
        init
        {
            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Source.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"image\""))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ImageBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

    public ImageBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"image\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageBlockParam(ImageBlockParamSource source)
        : this()
    {
        this.Source = source;
    }
}

class ImageBlockParamFromRaw : IFromRaw<ImageBlockParam>
{
    public ImageBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ImageBlockParamSourceConverter))]
public record class ImageBlockParamSource
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(base64Image: (x) => x.Type, urlImage: (x) => x.Type); }
    }

    public ImageBlockParamSource(Base64ImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ImageBlockParamSource(URLImageSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ImageBlockParamSource(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBase64Image([NotNullWhen(true)] out Base64ImageSource? value)
    {
        value = this.Value as Base64ImageSource;
        return value != null;
    }

    public bool TryPickURLImage([NotNullWhen(true)] out URLImageSource? value)
    {
        value = this.Value as URLImageSource;
        return value != null;
    }

    public void Switch(
        System::Action<Base64ImageSource> base64Image,
        System::Action<URLImageSource> urlImage
    )
    {
        switch (this.Value)
        {
            case Base64ImageSource value:
                base64Image(value);
                break;
            case URLImageSource value:
                urlImage(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ImageBlockParamSource"
                );
        }
    }

    public T Match<T>(
        System::Func<Base64ImageSource, T> base64Image,
        System::Func<URLImageSource, T> urlImage
    )
    {
        return this.Value switch
        {
            Base64ImageSource value => base64Image(value),
            URLImageSource value => urlImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ImageBlockParamSource"
            ),
        };
    }

    public static implicit operator ImageBlockParamSource(Base64ImageSource value) => new(value);

    public static implicit operator ImageBlockParamSource(URLImageSource value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ImageBlockParamSource"
            );
        }
    }
}

sealed class ImageBlockParamSourceConverter : JsonConverter<ImageBlockParamSource>
{
    public override ImageBlockParamSource? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "base64":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new ImageBlockParamSource(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageBlockParamSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
