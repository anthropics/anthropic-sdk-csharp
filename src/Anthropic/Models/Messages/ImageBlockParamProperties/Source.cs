using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Messages;
using SourceVariants = Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.ImageBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::Base64ImageSource value) =>
        new SourceVariants::Base64ImageSourceVariant(value);

    public static implicit operator Source(Messages::URLImageSource value) =>
        new SourceVariants::URLImageSourceVariant(value);

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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::Base64ImageSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::Base64ImageSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::URLImageSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::URLImageSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SourceVariants::Base64ImageSourceVariant(var base64ImageSource) => base64ImageSource,
            SourceVariants::URLImageSourceVariant(var urlImageSource) => urlImageSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
