using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaDocumentBlock>))]
public sealed record class BetaDocumentBlock : ModelBase, IFromRaw<BetaDocumentBlock>
{
    /// <summary>
    /// Citation configuration for the document
    /// </summary>
    public required BetaCitationConfig? Citations
    {
        get
        {
            if (!this._properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCitationConfig?>(
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

    public required Source Source
    {
        get
        {
            if (!this._properties.TryGetValue("source", out JsonElement element))
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
            this._properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The title of the document
    /// </summary>
    public required string? Title
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

    public override void Validate()
    {
        this.Citations?.Validate();
        this.Source.Validate();
        _ = this.Title;
        _ = this.Type;
    }

    public BetaDocumentBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

    public BetaDocumentBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDocumentBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaDocumentBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(SourceConverter))]
public record class Source
{
    public object Value { get; private init; }

    public string Data
    {
        get { return Match(betaBase64PDF: (x) => x.Data, betaPlainText: (x) => x.Data); }
    }

    public JsonElement MediaType
    {
        get { return Match(betaBase64PDF: (x) => x.MediaType, betaPlainText: (x) => x.MediaType); }
    }

    public JsonElement Type
    {
        get { return Match(betaBase64PDF: (x) => x.Type, betaPlainText: (x) => x.Type); }
    }

    public Source(BetaBase64PDFSource value)
    {
        Value = value;
    }

    public Source(BetaPlainTextSource value)
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

    public void Switch(
        System::Action<BetaBase64PDFSource> betaBase64PDF,
        System::Action<BetaPlainTextSource> betaPlainText
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
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        System::Func<BetaBase64PDFSource, T> betaBase64PDF,
        System::Func<BetaPlainTextSource, T> betaPlainText
    )
    {
        return this.Value switch
        {
            BetaBase64PDFSource value => betaBase64PDF(value),
            BetaPlainTextSource value => betaPlainText(value),
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
                        return new Source(deserialized);
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
                        return new Source(deserialized);
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
