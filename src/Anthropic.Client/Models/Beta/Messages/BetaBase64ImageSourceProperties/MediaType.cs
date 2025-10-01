using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaBase64ImageSourceProperties;

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
        Type typeToConvert,
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
