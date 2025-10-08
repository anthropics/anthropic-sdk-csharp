using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object Value { get; private init; }

    public string? Data
    {
        get
        {
            return Match<string?>(
                betaBase64PDF: (x) => x.Data,
                betaPlainText: (x) => x.Data,
                betaContentBlock: (_) => null,
                betaURLPDF: (_) => null,
                betaFileDocument: (_) => null
            );
        }
    }

    public JsonElement? MediaType
    {
        get
        {
            return Match<JsonElement?>(
                betaBase64PDF: (x) => x.MediaType,
                betaPlainText: (x) => x.MediaType,
                betaContentBlock: (_) => null,
                betaURLPDF: (_) => null,
                betaFileDocument: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaBase64PDF: (x) => x.Type,
                betaPlainText: (x) => x.Type,
                betaContentBlock: (x) => x.Type,
                betaURLPDF: (x) => x.Type,
                betaFileDocument: (x) => x.Type
            );
        }
    }

    public Source(BetaBase64PDFSource value)
    {
        Value = value;
    }

    public Source(BetaPlainTextSource value)
    {
        Value = value;
    }

    public Source(BetaContentBlockSource value)
    {
        Value = value;
    }

    public Source(BetaURLPDFSource value)
    {
        Value = value;
    }

    public Source(BetaFileDocumentSource value)
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

    public bool TryPickBetaBase64PDF([NotNullWhen(true)] out BetaBase64PDFSource? value)
    {
        value = this.Value as BetaBase64PDFSource;
        return value != null;
    }

    public bool TryPickBetaPlainText([NotNullWhen(true)] out BetaPlainTextSource? value)
    {
        value = this.Value as BetaPlainTextSource;
        return value != null;
    }

    public bool TryPickBetaContentBlock([NotNullWhen(true)] out BetaContentBlockSource? value)
    {
        value = this.Value as BetaContentBlockSource;
        return value != null;
    }

    public bool TryPickBetaURLPDF([NotNullWhen(true)] out BetaURLPDFSource? value)
    {
        value = this.Value as BetaURLPDFSource;
        return value != null;
    }

    public bool TryPickBetaFileDocument([NotNullWhen(true)] out BetaFileDocumentSource? value)
    {
        value = this.Value as BetaFileDocumentSource;
        return value != null;
    }

    public void Switch(
        Action<BetaBase64PDFSource> betaBase64PDF,
        Action<BetaPlainTextSource> betaPlainText,
        Action<BetaContentBlockSource> betaContentBlock,
        Action<BetaURLPDFSource> betaURLPDF,
        Action<BetaFileDocumentSource> betaFileDocument
    )
    {
        switch (this.Value)
        {
            case BetaBase64PDFSource value:
                betaBase64PDF(value);
                break;
            case BetaPlainTextSource value:
                betaPlainText(value);
                break;
            case BetaContentBlockSource value:
                betaContentBlock(value);
                break;
            case BetaURLPDFSource value:
                betaURLPDF(value);
                break;
            case BetaFileDocumentSource value:
                betaFileDocument(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        Func<BetaBase64PDFSource, T> betaBase64PDF,
        Func<BetaPlainTextSource, T> betaPlainText,
        Func<BetaContentBlockSource, T> betaContentBlock,
        Func<BetaURLPDFSource, T> betaURLPDF,
        Func<BetaFileDocumentSource, T> betaFileDocument
    )
    {
        return this.Value switch
        {
            BetaBase64PDFSource value => betaBase64PDF(value),
            BetaPlainTextSource value => betaPlainText(value),
            BetaContentBlockSource value => betaContentBlock(value),
            BetaURLPDFSource value => betaURLPDF(value),
            BetaFileDocumentSource value => betaFileDocument(value),
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaBase64PDFSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "text":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaPlainTextSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaContentBlockSource'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaURLPDFSource>(json, options);
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
                            "Data does not match union variant 'BetaURLPDFSource'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "file":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileDocumentSource>(
                        json,
                        options
                    );
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
                            "Data does not match union variant 'BetaFileDocumentSource'",
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
