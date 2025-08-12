using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Beta.Messages;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::BetaBase64PDFSource value) =>
        new SourceVariants::BetaBase64PDFSourceVariant(value);

    public static implicit operator Source(Messages::BetaPlainTextSource value) =>
        new SourceVariants::BetaPlainTextSourceVariant(value);

    public static implicit operator Source(Messages::BetaContentBlockSource value) =>
        new SourceVariants::BetaContentBlockSourceVariant(value);

    public static implicit operator Source(Messages::BetaURLPDFSource value) =>
        new SourceVariants::BetaURLPDFSourceVariant(value);

    public static implicit operator Source(Messages::BetaFileDocumentSource value) =>
        new SourceVariants::BetaFileDocumentSourceVariant(value);

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
            var deserialized = JsonSerializer.Deserialize<Messages::BetaBase64PDFSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::BetaBase64PDFSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaPlainTextSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::BetaPlainTextSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaContentBlockSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::BetaContentBlockSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaURLPDFSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::BetaURLPDFSourceVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaFileDocumentSource>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SourceVariants::BetaFileDocumentSourceVariant(deserialized);
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
            SourceVariants::BetaBase64PDFSourceVariant(var betaBase64PDFSource) =>
                betaBase64PDFSource,
            SourceVariants::BetaPlainTextSourceVariant(var betaPlainTextSource) =>
                betaPlainTextSource,
            SourceVariants::BetaContentBlockSourceVariant(var betaContentBlockSource) =>
                betaContentBlockSource,
            SourceVariants::BetaURLPDFSourceVariant(var betaUrlpdfSource) => betaUrlpdfSource,
            SourceVariants::BetaFileDocumentSourceVariant(var betaFileDocumentSource) =>
                betaFileDocumentSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
