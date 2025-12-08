using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestDocumentBlock, BetaRequestDocumentBlockFromRaw>))]
public sealed record class BetaRequestDocumentBlock : ModelBase
{
    public required BetaRequestDocumentBlockSource Source
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaRequestDocumentBlockSource>(
                this.RawData,
                "source"
            );
        }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCitationsConfigParam>(this.RawData, "citations");
        }
        init { ModelBase.Set(this._rawData, "citations", value); }
    }

    public string? Context
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "context"); }
        init { ModelBase.Set(this._rawData, "context", value); }
    }

    public string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
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

    public BetaRequestDocumentBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

    public BetaRequestDocumentBlock(BetaRequestDocumentBlock betaRequestDocumentBlock)
        : base(betaRequestDocumentBlock) { }

    public BetaRequestDocumentBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestDocumentBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestDocumentBlockFromRaw.FromRawUnchecked"/>
    public static BetaRequestDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRequestDocumentBlock(BetaRequestDocumentBlockSource source)
        : this()
    {
        this.Source = source;
    }
}

class BetaRequestDocumentBlockFromRaw : IFromRaw<BetaRequestDocumentBlock>
{
    /// <inheritdoc/>
    public BetaRequestDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestDocumentBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaRequestDocumentBlockSourceConverter))]
public record class BetaRequestDocumentBlockSource
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

    public BetaRequestDocumentBlockSource(BetaBase64PDFSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRequestDocumentBlockSource(BetaPlainTextSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRequestDocumentBlockSource(BetaContentBlockSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRequestDocumentBlockSource(BetaURLPDFSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRequestDocumentBlockSource(BetaFileDocumentSource value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaRequestDocumentBlockSource(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBase64PDFSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaBase64PDF(out var value)) {
    ///     // `value` is of type `BetaBase64PDFSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaBase64PDF([NotNullWhen(true)] out BetaBase64PDFSource? value)
    {
        value = this.Value as BetaBase64PDFSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPlainTextSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPlainText(out var value)) {
    ///     // `value` is of type `BetaPlainTextSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPlainText([NotNullWhen(true)] out BetaPlainTextSource? value)
    {
        value = this.Value as BetaPlainTextSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaContentBlockSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaContentBlock(out var value)) {
    ///     // `value` is of type `BetaContentBlockSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaContentBlock([NotNullWhen(true)] out BetaContentBlockSource? value)
    {
        value = this.Value as BetaContentBlockSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaURLPDFSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaURLPDF(out var value)) {
    ///     // `value` is of type `BetaURLPDFSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaURLPDF([NotNullWhen(true)] out BetaURLPDFSource? value)
    {
        value = this.Value as BetaURLPDFSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaFileDocumentSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFileDocument(out var value)) {
    ///     // `value` is of type `BetaFileDocumentSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFileDocument([NotNullWhen(true)] out BetaFileDocumentSource? value)
    {
        value = this.Value as BetaFileDocumentSource;
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
    ///     (BetaBase64PDFSource value) => {...},
    ///     (BetaPlainTextSource value) => {...},
    ///     (BetaContentBlockSource value) => {...},
    ///     (BetaURLPDFSource value) => {...},
    ///     (BetaFileDocumentSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBase64PDFSource> betaBase64PDF,
        System::Action<BetaPlainTextSource> betaPlainText,
        System::Action<BetaContentBlockSource> betaContentBlock,
        System::Action<BetaURLPDFSource> betaURLPDF,
        System::Action<BetaFileDocumentSource> betaFileDocument
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
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRequestDocumentBlockSource"
                );
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
    ///     (BetaBase64PDFSource value) => {...},
    ///     (BetaPlainTextSource value) => {...},
    ///     (BetaContentBlockSource value) => {...},
    ///     (BetaURLPDFSource value) => {...},
    ///     (BetaFileDocumentSource value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBase64PDFSource, T> betaBase64PDF,
        System::Func<BetaPlainTextSource, T> betaPlainText,
        System::Func<BetaContentBlockSource, T> betaContentBlock,
        System::Func<BetaURLPDFSource, T> betaURLPDF,
        System::Func<BetaFileDocumentSource, T> betaFileDocument
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
                "Data did not match any variant of BetaRequestDocumentBlockSource"
            ),
        };
    }

    public static implicit operator BetaRequestDocumentBlockSource(BetaBase64PDFSource value) =>
        new(value);

    public static implicit operator BetaRequestDocumentBlockSource(BetaPlainTextSource value) =>
        new(value);

    public static implicit operator BetaRequestDocumentBlockSource(BetaContentBlockSource value) =>
        new(value);

    public static implicit operator BetaRequestDocumentBlockSource(BetaURLPDFSource value) =>
        new(value);

    public static implicit operator BetaRequestDocumentBlockSource(BetaFileDocumentSource value) =>
        new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRequestDocumentBlockSource"
            );
        }
    }

    public virtual bool Equals(BetaRequestDocumentBlockSource? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaRequestDocumentBlockSourceConverter : JsonConverter<BetaRequestDocumentBlockSource>
{
    public override BetaRequestDocumentBlockSource? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPlainTextSource>(
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
            case "content":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContentBlockSource>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaURLPDFSource>(json, options);
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
            case "file":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaFileDocumentSource>(
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
            default:
            {
                return new BetaRequestDocumentBlockSource(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRequestDocumentBlockSource value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
