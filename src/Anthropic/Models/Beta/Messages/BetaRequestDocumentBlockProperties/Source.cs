using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64PDFSource value) =>
        new SourceVariants::BetaBase64PDFSource(value);

    public static implicit operator Source(BetaPlainTextSource value) =>
        new SourceVariants::BetaPlainTextSource(value);

    public static implicit operator Source(BetaContentBlockSource value) =>
        new SourceVariants::BetaContentBlockSource(value);

    public static implicit operator Source(BetaURLPDFSource value) =>
        new SourceVariants::BetaURLPDFSource(value);

    public static implicit operator Source(BetaFileDocumentSource value) =>
        new SourceVariants::BetaFileDocumentSource(value);

    public bool TryPickBetaBase64PDF([NotNullWhen(true)] out BetaBase64PDFSource? value)
    {
        value = (this as SourceVariants::BetaBase64PDFSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaPlainText([NotNullWhen(true)] out BetaPlainTextSource? value)
    {
        value = (this as SourceVariants::BetaPlainTextSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaContentBlock([NotNullWhen(true)] out BetaContentBlockSource? value)
    {
        value = (this as SourceVariants::BetaContentBlockSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaURLPDF([NotNullWhen(true)] out BetaURLPDFSource? value)
    {
        value = (this as SourceVariants::BetaURLPDFSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaFileDocument([NotNullWhen(true)] out BetaFileDocumentSource? value)
    {
        value = (this as SourceVariants::BetaFileDocumentSource)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SourceVariants::BetaBase64PDFSource> betaBase64PDF,
        Action<SourceVariants::BetaPlainTextSource> betaPlainText,
        Action<SourceVariants::BetaContentBlockSource> betaContentBlock,
        Action<SourceVariants::BetaURLPDFSource> betaURLPDF,
        Action<SourceVariants::BetaFileDocumentSource> betaFileDocument
    )
    {
        switch (this)
        {
            case SourceVariants::BetaBase64PDFSource inner:
                betaBase64PDF(inner);
                break;
            case SourceVariants::BetaPlainTextSource inner:
                betaPlainText(inner);
                break;
            case SourceVariants::BetaContentBlockSource inner:
                betaContentBlock(inner);
                break;
            case SourceVariants::BetaURLPDFSource inner:
                betaURLPDF(inner);
                break;
            case SourceVariants::BetaFileDocumentSource inner:
                betaFileDocument(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SourceVariants::BetaBase64PDFSource, T> betaBase64PDF,
        Func<SourceVariants::BetaPlainTextSource, T> betaPlainText,
        Func<SourceVariants::BetaContentBlockSource, T> betaContentBlock,
        Func<SourceVariants::BetaURLPDFSource, T> betaURLPDF,
        Func<SourceVariants::BetaFileDocumentSource, T> betaFileDocument
    )
    {
        return this switch
        {
            SourceVariants::BetaBase64PDFSource inner => betaBase64PDF(inner),
            SourceVariants::BetaPlainTextSource inner => betaPlainText(inner),
            SourceVariants::BetaContentBlockSource inner => betaContentBlock(inner),
            SourceVariants::BetaURLPDFSource inner => betaURLPDF(inner),
            SourceVariants::BetaFileDocumentSource inner => betaFileDocument(inner),
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaBase64PDFSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "text":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaPlainTextSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaContentBlockSource(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BetaURLPDFSource>(json, options);
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaURLPDFSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "file":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileDocumentSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaFileDocumentSource(deserialized);
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
            SourceVariants::BetaBase64PDFSource(var betaBase64PDF) => betaBase64PDF,
            SourceVariants::BetaPlainTextSource(var betaPlainText) => betaPlainText,
            SourceVariants::BetaContentBlockSource(var betaContentBlock) => betaContentBlock,
            SourceVariants::BetaURLPDFSource(var betaURLPDF) => betaURLPDF,
            SourceVariants::BetaFileDocumentSource(var betaFileDocument) => betaFileDocument,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
