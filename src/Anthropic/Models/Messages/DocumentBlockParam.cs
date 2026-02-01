using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<DocumentBlockParam, DocumentBlockParamFromRaw>))]
public sealed record class DocumentBlockParam : JsonModel
{
    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    public CitationsConfigParam? Citations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CitationsConfigParam>("citations");
        }
        init { this._rawData.Set("citations", value); }
    }

    public string? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Source.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("document")))
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
        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DocumentBlockParam(DocumentBlockParam documentBlockParam)
        : base(documentBlockParam) { }
#pragma warning restore CS8618

    public DocumentBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("document");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DocumentBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DocumentBlockParamFromRaw.FromRawUnchecked"/>
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

class DocumentBlockParamFromRaw : IFromRawJson<DocumentBlockParam>
{
    /// <inheritdoc/>
    public DocumentBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DocumentBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SourceConverter))]
public record class Source : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Data
    {
        get
        {
            return Match<string?>(
                base64Pdf: (x) => x.Data,
                plainText: (x) => x.Data,
                contentBlock: (_) => null,
                urlPdf: (_) => null
            );
        }
    }

    public JsonElement? MediaType
    {
        get
        {
            return Match<JsonElement?>(
                base64Pdf: (x) => x.MediaType,
                plainText: (x) => x.MediaType,
                contentBlock: (_) => null,
                urlPdf: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                base64Pdf: (x) => x.Type,
                plainText: (x) => x.Type,
                contentBlock: (x) => x.Type,
                urlPdf: (x) => x.Type
            );
        }
    }

    public Source(Base64PdfSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(PlainTextSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(ContentBlockSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(UrlPdfSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Base64PdfSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBase64Pdf(out var value)) {
    ///     // `value` is of type `Base64PdfSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBase64Pdf([NotNullWhen(true)] out Base64PdfSource? value)
    {
        value = this.Value as Base64PdfSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PlainTextSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPlainText(out var value)) {
    ///     // `value` is of type `PlainTextSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPlainText([NotNullWhen(true)] out PlainTextSource? value)
    {
        value = this.Value as PlainTextSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContentBlockSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContentBlock(out var value)) {
    ///     // `value` is of type `ContentBlockSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlock([NotNullWhen(true)] out ContentBlockSource? value)
    {
        value = this.Value as ContentBlockSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlPdfSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUrlPdf(out var value)) {
    ///     // `value` is of type `UrlPdfSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUrlPdf([NotNullWhen(true)] out UrlPdfSource? value)
    {
        value = this.Value as UrlPdfSource;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Base64PdfSource value) => {...},
    ///     (PlainTextSource value) => {...},
    ///     (ContentBlockSource value) => {...},
    ///     (UrlPdfSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Base64PdfSource> base64Pdf,
        System::Action<PlainTextSource> plainText,
        System::Action<ContentBlockSource> contentBlock,
        System::Action<UrlPdfSource> urlPdf
    )
    {
        switch (this.Value)
        {
            case Base64PdfSource value:
                base64Pdf(value);
                break;
            case PlainTextSource value:
                plainText(value);
                break;
            case ContentBlockSource value:
                contentBlock(value);
                break;
            case UrlPdfSource value:
                urlPdf(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Base64PdfSource value) => {...},
    ///     (PlainTextSource value) => {...},
    ///     (ContentBlockSource value) => {...},
    ///     (UrlPdfSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Base64PdfSource, T> base64Pdf,
        System::Func<PlainTextSource, T> plainText,
        System::Func<ContentBlockSource, T> contentBlock,
        System::Func<UrlPdfSource, T> urlPdf
    )
    {
        return this.Value switch
        {
            Base64PdfSource value => base64Pdf(value),
            PlainTextSource value => plainText(value),
            ContentBlockSource value => contentBlock(value),
            UrlPdfSource value => urlPdf(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(Base64PdfSource value) => new(value);

    public static implicit operator Source(PlainTextSource value) => new(value);

    public static implicit operator Source(ContentBlockSource value) => new(value);

    public static implicit operator Source(UrlPdfSource value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
        this.Switch(
            (base64Pdf) => base64Pdf.Validate(),
            (plainText) => plainText.Validate(),
            (contentBlock) => contentBlock.Validate(),
            (urlPdf) => urlPdf.Validate()
        );
    }

    public virtual bool Equals(Source? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            Base64PdfSource _ => 0,
            PlainTextSource _ => 1,
            ContentBlockSource _ => 2,
            UrlPdfSource _ => 3,
            _ => -1,
        };
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<Base64PdfSource>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<PlainTextSource>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "content":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContentBlockSource>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "url":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UrlPdfSource>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Source(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
