using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestDocumentBlock>))]
public sealed record class BetaRequestDocumentBlock : ModelBase, IFromRaw<BetaRequestDocumentBlock>
{
    public required Source1 Source
    {
        get
        {
            if (!this._properties.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Source1>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new System::ArgumentNullException("source")
                );
        }
        init
        {
            this._properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            if (!this._properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCitationsConfigParam?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Context
    {
        get
        {
            if (!this._properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Source.Validate();
        _ = this.Type;
        this.CacheControl?.Validate();
        this.Citations?.Validate();
        _ = this.Context;
        _ = this.Title;
    }

    public BetaRequestDocumentBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

    public BetaRequestDocumentBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestDocumentBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaRequestDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaRequestDocumentBlock(Source1 source)
        : this()
    {
        this.Source = source;
    }
}

[JsonConverter(typeof(Source1Converter))]
public record class Source1
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

    public Source1(BetaBase64PDFSource value)
    {
        Value = value;
    }

    public Source1(BetaPlainTextSource value)
    {
        Value = value;
    }

    public Source1(BetaContentBlockSource value)
    {
        Value = value;
    }

    public Source1(BetaURLPDFSource value)
    {
        Value = value;
    }

    public Source1(BetaFileDocumentSource value)
    {
        Value = value;
    }

    Source1(UnknownVariant value)
    {
        Value = value;
    }

    public static Source1 CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of Source1"
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
                "Data did not match any variant of Source1"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Source1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Source1Converter : JsonConverter<Source1>
{
    public override Source1? Read(
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
                        return new Source1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaBase64PDFSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        return new Source1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaPlainTextSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        return new Source1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaContentBlockSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        return new Source1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaURLPDFSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
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
                        return new Source1(deserialized);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaFileDocumentSource'",
                            e
                        )
                    );
                }

                throw new System::AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
