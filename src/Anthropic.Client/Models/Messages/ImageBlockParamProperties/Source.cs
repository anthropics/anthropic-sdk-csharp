using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.ImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get { return Match(base64Image: (x) => x.Type, urlImage: (x) => x.Type); }
    }

    public Source(Base64ImageSource value)
    {
        Value = value;
    }

    public Source(URLImageSource value)
    {
        Value = value;
    }

    Source(UnknownVariant value)
    {
        Value = value;
    }

    public static Source CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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

    public void Switch(Action<Base64ImageSource> base64Image, Action<URLImageSource> urlImage)
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
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(Func<Base64ImageSource, T> base64Image, Func<URLImageSource, T> urlImage)
    {
        return this.Value switch
        {
            Base64ImageSource value => base64Image(value),
            URLImageSource value => urlImage(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64ImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Source(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'Base64ImageSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "url":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLImageSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Source(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'URLImageSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
