using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using SourceVariants = Anthropic.Client.Models.Beta.Messages.BetaDocumentBlockProperties.SourceVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaDocumentBlockProperties;

[JsonConverter(typeof(SourceConverter))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64PDFSource value) =>
        new SourceVariants::BetaBase64PDFSource(value);

    public static implicit operator Source(BetaPlainTextSource value) =>
        new SourceVariants::BetaPlainTextSource(value);

    public bool TryPickBetaBase64PDF([NotNullWhen(true)] out BetaBase64PDFSource? value)
    {
        value = (this as SourceVariants::BetaBase64PDFSource)?.Value;
        return value != null;
    }

    public bool TryPickBetaPlainText([NotNullWhen(true)] out BetaPlainTextSource? value)
    {
        value = (this as SourceVariants::BetaPlainTextSource)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SourceVariants::BetaBase64PDFSource> betaBase64PDF,
        Action<SourceVariants::BetaPlainTextSource> betaPlainText
    )
    {
        switch (this)
        {
            case SourceVariants::BetaBase64PDFSource inner:
                betaBase64PDF(inner);
                break;
            case SourceVariants::BetaPlainTextSource inner:
                betaPlainText(inner);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
    }

    public T Match<T>(
        Func<SourceVariants::BetaBase64PDFSource, T> betaBase64PDF,
        Func<SourceVariants::BetaPlainTextSource, T> betaPlainText
    )
    {
        return this switch
        {
            SourceVariants::BetaBase64PDFSource inner => betaBase64PDF(inner),
            SourceVariants::BetaPlainTextSource inner => betaPlainText(inner),
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
                    var deserialized = JsonSerializer.Deserialize<BetaBase64PDFSource>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new SourceVariants::BetaBase64PDFSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::BetaBase64PDFSource",
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
                        return new SourceVariants::BetaPlainTextSource(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant SourceVariants::BetaPlainTextSource",
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
            SourceVariants::BetaBase64PDFSource(var betaBase64PDF) => betaBase64PDF,
            SourceVariants::BetaPlainTextSource(var betaPlainText) => betaPlainText,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
