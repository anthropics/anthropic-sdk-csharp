using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64PDFSource value) =>
        new Base64PDFSourceVariant(value);

    public static implicit operator Source(PlainTextSource value) =>
        new PlainTextSourceVariant(value);

    public static implicit operator Source(ContentBlockSource value) =>
        new ContentBlockSourceVariant(value);

    public static implicit operator Source(URLPDFSource value) => new URLPDFSourceVariant(value);

    public bool TryPickBase64PDFSourceVariant([NotNullWhen(true)] out Base64PDFSource? value)
    {
        value = (this as Base64PDFSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickPlainTextSourceVariant([NotNullWhen(true)] out PlainTextSource? value)
    {
        value = (this as PlainTextSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickContentBlockSourceVariant([NotNullWhen(true)] out ContentBlockSource? value)
    {
        value = (this as ContentBlockSourceVariant)?.Value;
        return value != null;
    }

    public bool TryPickURLPDFSourceVariant([NotNullWhen(true)] out URLPDFSource? value)
    {
        value = (this as URLPDFSourceVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<Base64PDFSourceVariant> base64PDFSource,
        Action<PlainTextSourceVariant> plainTextSource,
        Action<ContentBlockSourceVariant> contentBlockSource,
        Action<URLPDFSourceVariant> urlpdfSource
    )
    {
        switch (this)
        {
            case Base64PDFSourceVariant inner:
                base64PDFSource(inner);
                break;
            case PlainTextSourceVariant inner:
                plainTextSource(inner);
                break;
            case ContentBlockSourceVariant inner:
                contentBlockSource(inner);
                break;
            case URLPDFSourceVariant inner:
                urlpdfSource(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<Base64PDFSourceVariant, T> base64PDFSource,
        Func<PlainTextSourceVariant, T> plainTextSource,
        Func<ContentBlockSourceVariant, T> contentBlockSource,
        Func<URLPDFSourceVariant, T> urlpdfSource
    )
    {
        return this switch
        {
            Base64PDFSourceVariant inner => base64PDFSource(inner),
            PlainTextSourceVariant inner => plainTextSource(inner),
            ContentBlockSourceVariant inner => contentBlockSource(inner),
            URLPDFSourceVariant inner => urlpdfSource(inner),
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
                    var deserialized = JsonSerializer.Deserialize<Base64PDFSource>(json, options);
                    if (deserialized != null)
                    {
                        return new Base64PDFSourceVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<PlainTextSource>(json, options);
                    if (deserialized != null)
                    {
                        return new PlainTextSourceVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ContentBlockSourceVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<URLPDFSource>(json, options);
                    if (deserialized != null)
                    {
                        return new URLPDFSourceVariant(deserialized);
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
            Base64PDFSourceVariant(var base64PDFSource) => base64PDFSource,
            PlainTextSourceVariant(var plainTextSource) => plainTextSource,
            ContentBlockSourceVariant(var contentBlockSource) => contentBlockSource,
            URLPDFSourceVariant(var urlpdfSource) => urlpdfSource,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
