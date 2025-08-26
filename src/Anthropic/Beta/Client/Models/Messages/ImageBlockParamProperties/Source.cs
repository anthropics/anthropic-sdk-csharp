using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Beta.Client.Models.Messages.ImageBlockParamProperties.SourceVariants;

namespace Anthropic.Beta.Client.Models.Messages.ImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64ImageSource value) =>
        new SourceVariants::Base64ImageSource(value);

    public static implicit operator Source(URLImageSource value) =>
        new SourceVariants::URLImageSource(value);

    public bool TryPickBase64Image([NotNullWhen(true)] out Base64ImageSource? value)
    {
        value = (this as SourceVariants::Base64ImageSource)?.Value;
        return value != null;
    }

    public bool TryPickURLImage([NotNullWhen(true)] out URLImageSource? value)
    {
        value = (this as SourceVariants::URLImageSource)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SourceVariants::Base64ImageSource> base64Image,
        Action<SourceVariants::URLImageSource> urlImage
    )
    {
        switch (this)
        {
            case SourceVariants::Base64ImageSource inner:
                base64Image(inner);
                break;
            case SourceVariants::URLImageSource inner:
                urlImage(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SourceVariants::Base64ImageSource, T> base64Image,
        Func<SourceVariants::URLImageSource, T> urlImage
    )
    {
        return this switch
        {
            SourceVariants::Base64ImageSource inner => base64Image(inner),
            SourceVariants::URLImageSource inner => urlImage(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json, options);
                    if (deserialized != null)
                    {
                        return new SourceVariants::Base64ImageSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "url":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLImageSource>(json, options);
                    if (deserialized != null)
                    {
                        return new SourceVariants::URLImageSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SourceVariants::Base64ImageSource(var base64Image) => base64Image,
            SourceVariants::URLImageSource(var urlImage) => urlImage,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
