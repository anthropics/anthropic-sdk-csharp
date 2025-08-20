using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.ImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64ImageSource value) =>
        new Base64ImageSourceVariant(value);

    public static implicit operator Source(URLImageSource value) =>
        new URLImageSourceVariant(value);

    public bool TryPickBase64ImageSourceVariant([NotNullWhen(true)] out Base64ImageSource? value)
    {
        value = (this as Base64ImageSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickURLImageSourceVariant([NotNullWhen(true)] out URLImageSource? value)
    {
        value = (this as URLImageSourceVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<Base64ImageSourceVariant> base64ImageSource,
        Action<URLImageSourceVariant> urlImageSource
    )
    {
        switch (this)
        {
            case Base64ImageSourceVariant inner:
                base64ImageSource(inner);
                break;
            case URLImageSourceVariant inner:
                urlImageSource(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<Base64ImageSourceVariant, T> base64ImageSource,
        Func<URLImageSourceVariant, T> urlImageSource
    )
    {
        return this switch
        {
            Base64ImageSourceVariant inner => base64ImageSource(inner),
            URLImageSourceVariant inner => urlImageSource(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                        return new Base64ImageSourceVariant(deserialized);
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
                        return new URLImageSourceVariant(deserialized);
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
            Base64ImageSourceVariant(var base64ImageSource) => base64ImageSource,
            URLImageSourceVariant(var urlImageSource) => urlImageSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
