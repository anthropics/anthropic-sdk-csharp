using System;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaBase64ImageSourceProperties;

[JsonConverter(typeof(EnumConverter<MediaType, string>))]
public sealed record class MediaType(string value) : IEnum<MediaType, string>
{
    public static readonly MediaType ImageJPEG = new("image/jpeg");

    public static readonly MediaType ImagePNG = new("image/png");

    public static readonly MediaType ImageGIF = new("image/gif");

    public static readonly MediaType ImageWebP = new("image/webp");

    readonly string _value = value;

    public enum Value
    {
        ImageJPEG,
        ImagePNG,
        ImageGIF,
        ImageWebP,
    }

    public Value Known() =>
        _value switch
        {
            "image/jpeg" => Value.ImageJPEG,
            "image/png" => Value.ImagePNG,
            "image/gif" => Value.ImageGIF,
            "image/webp" => Value.ImageWebP,
            _ => throw new ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static MediaType FromRaw(string value)
    {
        return new(value);
    }
}
