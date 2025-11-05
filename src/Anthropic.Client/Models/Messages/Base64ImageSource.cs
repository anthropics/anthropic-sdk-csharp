using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<Base64ImageSource>))]
public sealed record class Base64ImageSource : ModelBase, IFromRaw<Base64ImageSource>
{
    public required string Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new System::ArgumentNullException("data")
                );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, MediaType> MediaType
    {
        get
        {
            if (!this._properties.TryGetValue("media_type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'media_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "media_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MediaType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["media_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Data;
        this.MediaType.Validate();
        _ = this.Type;
    }

    public Base64ImageSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

    public Base64ImageSource(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"base64\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Base64ImageSource(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Base64ImageSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(MediaTypeConverter))]
public enum MediaType
{
    ImageJPEG,
    ImagePNG,
    ImageGIF,
    ImageWebP,
}

sealed class MediaTypeConverter : JsonConverter<MediaType>
{
    public override MediaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image/jpeg" => MediaType.ImageJPEG,
            "image/png" => MediaType.ImagePNG,
            "image/gif" => MediaType.ImageGIF,
            "image/webp" => MediaType.ImageWebP,
            _ => (MediaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MediaType.ImageJPEG => "image/jpeg",
                MediaType.ImagePNG => "image/png",
                MediaType.ImageGIF => "image/gif",
                MediaType.ImageWebP => "image/webp",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
