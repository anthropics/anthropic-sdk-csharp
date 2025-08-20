using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64PDFSource value) =>
        new BetaBase64PDFSourceVariant(value);

    public static implicit operator Source(BetaPlainTextSource value) =>
        new BetaPlainTextSourceVariant(value);

    public static implicit operator Source(BetaContentBlockSource value) =>
        new BetaContentBlockSourceVariant(value);

    public static implicit operator Source(BetaURLPDFSource value) =>
        new BetaURLPDFSourceVariant(value);

    public static implicit operator Source(BetaFileDocumentSource value) =>
        new BetaFileDocumentSourceVariant(value);

    public bool TryPickBetaBase64PDFSourceVariant(
        [NotNullWhen(true)] out BetaBase64PDFSource? value
    )
    {
        value = (this as BetaBase64PDFSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaPlainTextSourceVariant(
        [NotNullWhen(true)] out BetaPlainTextSource? value
    )
    {
        value = (this as BetaPlainTextSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaContentBlockSourceVariant(
        [NotNullWhen(true)] out BetaContentBlockSource? value
    )
    {
        value = (this as BetaContentBlockSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaURLPDFSourceVariant([NotNullWhen(true)] out BetaURLPDFSource? value)
    {
        value = (this as BetaURLPDFSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaFileDocumentSourceVariant(
        [NotNullWhen(true)] out BetaFileDocumentSource? value
    )
    {
        value = (this as BetaFileDocumentSourceVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaBase64PDFSourceVariant> betaBase64PDFSource,
        Action<BetaPlainTextSourceVariant> betaPlainTextSource,
        Action<BetaContentBlockSourceVariant> betaContentBlockSource,
        Action<BetaURLPDFSourceVariant> betaUrlpdfSource,
        Action<BetaFileDocumentSourceVariant> betaFileDocumentSource
    )
    {
        switch (this)
        {
            case BetaBase64PDFSourceVariant inner:
                betaBase64PDFSource(inner);
                break;
            case BetaPlainTextSourceVariant inner:
                betaPlainTextSource(inner);
                break;
            case BetaContentBlockSourceVariant inner:
                betaContentBlockSource(inner);
                break;
            case BetaURLPDFSourceVariant inner:
                betaUrlpdfSource(inner);
                break;
            case BetaFileDocumentSourceVariant inner:
                betaFileDocumentSource(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaBase64PDFSourceVariant, T> betaBase64PDFSource,
        Func<BetaPlainTextSourceVariant, T> betaPlainTextSource,
        Func<BetaContentBlockSourceVariant, T> betaContentBlockSource,
        Func<BetaURLPDFSourceVariant, T> betaUrlpdfSource,
        Func<BetaFileDocumentSourceVariant, T> betaFileDocumentSource
    )
    {
        return this switch
        {
            BetaBase64PDFSourceVariant inner => betaBase64PDFSource(inner),
            BetaPlainTextSourceVariant inner => betaPlainTextSource(inner),
            BetaContentBlockSourceVariant inner => betaContentBlockSource(inner),
            BetaURLPDFSourceVariant inner => betaUrlpdfSource(inner),
            BetaFileDocumentSourceVariant inner => betaFileDocumentSource(inner),
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaBase64PDFSourceVariant(deserialized);
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
                        return new BetaPlainTextSourceVariant(deserialized);
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
                        return new BetaContentBlockSourceVariant(deserialized);
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
                        return new BetaURLPDFSourceVariant(deserialized);
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
                        return new BetaFileDocumentSourceVariant(deserialized);
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
            BetaBase64PDFSourceVariant(var betaBase64PDFSource) => betaBase64PDFSource,
            BetaPlainTextSourceVariant(var betaPlainTextSource) => betaPlainTextSource,
            BetaContentBlockSourceVariant(var betaContentBlockSource) => betaContentBlockSource,
            BetaURLPDFSourceVariant(var betaUrlpdfSource) => betaUrlpdfSource,
            BetaFileDocumentSourceVariant(var betaFileDocumentSource) => betaFileDocumentSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
