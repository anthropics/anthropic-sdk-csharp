using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<DocumentBlockParam, DocumentBlockParamFromRaw>))]
public sealed record class DocumentBlockParam : ModelBase
{
    public required Source Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentNullException("source")
                );
        }
        init
        {
            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            if (!this._rawData.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CitationsConfigParam?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Context
    {
        get
        {
            if (!this._rawData.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._rawData.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Source.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"document\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Citations?.Validate();
        _ = this.Context;
        _ = this.Title;
    }

    public DocumentBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

    public DocumentBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static DocumentBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DocumentBlockParam(Source source)
        : this()
    {
        this.Source = source;
    }
}

class DocumentBlockParamFromRaw : IFromRaw<DocumentBlockParam>
{
    public DocumentBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

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

    public Source(Base64PDFSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Source(PlainTextSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Source(ContentBlockSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Source(URLPDFSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Source(JsonElement json)
    {
        this._json = json;
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
        System::Action<Base64PDFSource> base64PDF,
        System::Action<PlainTextSource> plainText,
        System::Action<ContentBlockSource> contentBlock,
        System::Action<URLPDFSource> urlPDF
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
        System::Func<Base64PDFSource, T> base64PDF,
        System::Func<PlainTextSource, T> plainText,
        System::Func<ContentBlockSource, T> contentBlock,
        System::Func<URLPDFSource, T> urlPDF
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

    public static implicit operator Source(Base64PDFSource value) => new(value);

    public static implicit operator Source(PlainTextSource value) => new(value);

    public static implicit operator Source(ContentBlockSource value) => new(value);

    public static implicit operator Source(URLPDFSource value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public virtual bool Equals(Source? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Base64PDFSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlainTextSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "content":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<URLPDFSource>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new Source(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
