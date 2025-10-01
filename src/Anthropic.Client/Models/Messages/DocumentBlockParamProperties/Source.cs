using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using SourceVariants = Anthropic.Client.Models.Messages.DocumentBlockParamProperties.SourceVariants;

namespace Anthropic.Client.Models.Messages.DocumentBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64PDFSource value) =>
        new SourceVariants::Base64PDFSource(value);

    public static implicit operator Source(PlainTextSource value) =>
        new SourceVariants::PlainTextSource(value);

    public static implicit operator Source(ContentBlockSource value) =>
        new SourceVariants::ContentBlockSource(value);

    public static implicit operator Source(URLPDFSource value) =>
        new SourceVariants::URLPDFSource(value);

    public bool TryPickBase64PDF([NotNullWhen(true)] out Base64PDFSource? value)
    {
        value = (this as SourceVariants::Base64PDFSource)?.Value;
        return value != null;
    }

    public bool TryPickPlainText([NotNullWhen(true)] out PlainTextSource? value)
    {
        value = (this as SourceVariants::PlainTextSource)?.Value;
        return value != null;
    }

    public bool TryPickContentBlock([NotNullWhen(true)] out ContentBlockSource? value)
    {
        value = (this as SourceVariants::ContentBlockSource)?.Value;
        return value != null;
    }

    public bool TryPickURLPDF([NotNullWhen(true)] out URLPDFSource? value)
    {
        value = (this as SourceVariants::URLPDFSource)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SourceVariants::Base64PDFSource> base64PDF,
        Action<SourceVariants::PlainTextSource> plainText,
        Action<SourceVariants::ContentBlockSource> contentBlock,
        Action<SourceVariants::URLPDFSource> urlPDF
    )
    {
        switch (this)
        {
            case SourceVariants::Base64PDFSource inner:
                base64PDF(inner);
                break;
            case SourceVariants::PlainTextSource inner:
                plainText(inner);
                break;
            case SourceVariants::ContentBlockSource inner:
                contentBlock(inner);
                break;
            case SourceVariants::URLPDFSource inner:
                urlPDF(inner);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        Func<SourceVariants::Base64PDFSource, T> base64PDF,
        Func<SourceVariants::PlainTextSource, T> plainText,
        Func<SourceVariants::ContentBlockSource, T> contentBlock,
        Func<SourceVariants::URLPDFSource, T> urlPDF
    )
    {
        return this switch
        {
            SourceVariants::Base64PDFSource inner => base64PDF(inner),
            SourceVariants::PlainTextSource inner => plainText(inner),
            SourceVariants::ContentBlockSource inner => contentBlock(inner),
            SourceVariants::URLPDFSource inner => urlPDF(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64PDFSource>(json, options);
                    if (deserialized != null)
                    {
                        return new SourceVariants::Base64PDFSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::Base64PDFSource",
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
                        return new SourceVariants::PlainTextSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::PlainTextSource",
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
                        return new SourceVariants::ContentBlockSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::ContentBlockSource",
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
                        return new SourceVariants::URLPDFSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::URLPDFSource",
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
        object variant = value switch
        {
            SourceVariants::Base64PDFSource(var base64PDF) => base64PDF,
            SourceVariants::PlainTextSource(var plainText) => plainText,
            SourceVariants::ContentBlockSource(var contentBlock) => contentBlock,
            SourceVariants::URLPDFSource(var urlPDF) => urlPDF,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
