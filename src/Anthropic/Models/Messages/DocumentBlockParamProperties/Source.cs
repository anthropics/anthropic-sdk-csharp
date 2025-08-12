using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Messages;
using SourceVariants = Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::Base64PDFSource value) =>
        new SourceVariants::Base64PDFSourceVariant(value);

    public static implicit operator Source(Messages::PlainTextSource value) =>
        new SourceVariants::PlainTextSourceVariant(value);

    public static implicit operator Source(Messages::ContentBlockSource value) =>
        new SourceVariants::ContentBlockSourceVariant(value);

    public static implicit operator Source(Messages::URLPDFSource value) =>
        new SourceVariants::URLPDFSourceVariant(value);

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
            var deserialized = JsonSerializer.Deserialize<Messages::Base64PDFSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::Base64PDFSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::PlainTextSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::PlainTextSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::ContentBlockSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::ContentBlockSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::URLPDFSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::URLPDFSourceVariant(deserialized);
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
            SourceVariants::Base64PDFSourceVariant(var base64PDFSource) => base64PDFSource,
            SourceVariants::PlainTextSourceVariant(var plainTextSource) => plainTextSource,
            SourceVariants::ContentBlockSourceVariant(var contentBlockSource) => contentBlockSource,
            SourceVariants::URLPDFSourceVariant(var urlpdfSource) => urlpdfSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
