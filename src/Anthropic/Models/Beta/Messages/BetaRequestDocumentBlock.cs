using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestDocumentBlock>))]
public sealed record class BetaRequestDocumentBlock : ModelBase, IFromRaw<BetaRequestDocumentBlock>
{
    public required BetaRequestDocumentBlockSource Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaRequestDocumentBlockSource>(
                    element,
                    ModelBase.SerializerOptions
                )
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
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
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

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            if (!this._rawData.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCitationsConfigParam?>(
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

    public BetaRequestDocumentBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRequestDocumentBlockSource"
            );
        }
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
