using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.DocumentBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object Value { get; private init; }

    public string? Data
    {
        get
        {
            return Match<string?>(
                base64PDF: (x) => x.Data,
                plainText: (x) => x.Data,
                contentBlock: (_) => null,
                urlPDF: (_) => null
            );
        }
    }

    public JsonElement? MediaType
    {
        get
        {
            return Match<JsonElement?>(
                base64PDF: (x) => x.MediaType,
                plainText: (x) => x.MediaType,
                contentBlock: (_) => null,
                urlPDF: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                base64PDF: (x) => x.Type,
                plainText: (x) => x.Type,
                contentBlock: (x) => x.Type,
                urlPDF: (x) => x.Type
            );
        }
    }

    public Source(Base64PDFSource value)
    {
        Value = value;
    }

    public Source(PlainTextSource value)
    {
        Value = value;
    }

    public Source(ContentBlockSource value)
    {
        Value = value;
    }

    public Source(URLPDFSource value)
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

    public bool TryPickBase64PDF([NotNullWhen(true)] out Base64PDFSource? value)
    {
        value = this.Value as Base64PDFSource;
        return value != null;
    }

    public bool TryPickPlainText([NotNullWhen(true)] out PlainTextSource? value)
    {
        value = this.Value as PlainTextSource;
        return value != null;
    }

    public bool TryPickContentBlock([NotNullWhen(true)] out ContentBlockSource? value)
    {
        value = this.Value as ContentBlockSource;
        return value != null;
    }

    public bool TryPickURLPDF([NotNullWhen(true)] out URLPDFSource? value)
    {
        value = this.Value as URLPDFSource;
        return value != null;
    }

    public void Switch(
        Action<Base64PDFSource> base64PDF,
        Action<PlainTextSource> plainText,
        Action<ContentBlockSource> contentBlock,
        Action<URLPDFSource> urlPDF
    )
    {
        switch (this.Value)
        {
            case Base64PDFSource value:
                base64PDF(value);
                break;
            case PlainTextSource value:
                plainText(value);
                break;
            case ContentBlockSource value:
                contentBlock(value);
                break;
            case URLPDFSource value:
                urlPDF(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        Func<Base64PDFSource, T> base64PDF,
        Func<PlainTextSource, T> plainText,
        Func<ContentBlockSource, T> contentBlock,
        Func<URLPDFSource, T> urlPDF
    )
    {
        return this.Value switch
        {
            Base64PDFSource value => base64PDF(value),
            PlainTextSource value => plainText(value),
            ContentBlockSource value => contentBlock(value),
            URLPDFSource value => urlPDF(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                    var deserialized = JsonSerializer.Deserialize<Base64PDFSource>(json, options);
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
                            "Data does not match union variant 'Base64PDFSource'",
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
                    var deserialized = JsonSerializer.Deserialize<PlainTextSource>(json, options);
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
                            "Data does not match union variant 'PlainTextSource'",
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
                    var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
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
                            "Data does not match union variant 'ContentBlockSource'",
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
                    var deserialized = JsonSerializer.Deserialize<URLPDFSource>(json, options);
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
                            "Data does not match union variant 'URLPDFSource'",
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
