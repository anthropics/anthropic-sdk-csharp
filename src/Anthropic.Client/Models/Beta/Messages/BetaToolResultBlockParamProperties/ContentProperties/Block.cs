using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public record class Block
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextBlockParam: (x) => x.Type,
                betaImageBlockParam: (x) => x.Type,
                betaSearchResultBlockParam: (x) => x.Type,
                betaRequestDocument: (x) => x.Type
            );
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                betaTextBlockParam: (x) => x.CacheControl,
                betaImageBlockParam: (x) => x.CacheControl,
                betaSearchResultBlockParam: (x) => x.CacheControl,
                betaRequestDocument: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                betaTextBlockParam: (_) => null,
                betaImageBlockParam: (_) => null,
                betaSearchResultBlockParam: (x) => x.Title,
                betaRequestDocument: (x) => x.Title
            );
        }
    }

    public Block(BetaTextBlockParam value)
    {
        Value = value;
    }

    public Block(BetaImageBlockParam value)
    {
        Value = value;
    }

    public Block(BetaSearchResultBlockParam value)
    {
        Value = value;
    }

    public Block(BetaRequestDocumentBlock value)
    {
        Value = value;
    }

    Block(UnknownVariant value)
    {
        Value = value;
    }

    public static Block CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    public bool TryPickBetaImageBlockParam([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = this.Value as BetaImageBlockParam;
        return value != null;
    }

    public bool TryPickBetaSearchResultBlockParam(
        [NotNullWhen(true)] out BetaSearchResultBlockParam? value
    )
    {
        value = this.Value as BetaSearchResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaRequestDocument([NotNullWhen(true)] out BetaRequestDocumentBlock? value)
    {
        value = this.Value as BetaRequestDocumentBlock;
        return value != null;
    }

    public void Switch(
        Action<BetaTextBlockParam> betaTextBlockParam,
        Action<BetaImageBlockParam> betaImageBlockParam,
        Action<BetaSearchResultBlockParam> betaSearchResultBlockParam,
        Action<BetaRequestDocumentBlock> betaRequestDocument
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                betaTextBlockParam(value);
                break;
            case BetaImageBlockParam value:
                betaImageBlockParam(value);
                break;
            case BetaSearchResultBlockParam value:
                betaSearchResultBlockParam(value);
                break;
            case BetaRequestDocumentBlock value:
                betaRequestDocument(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        Func<BetaTextBlockParam, T> betaTextBlockParam,
        Func<BetaImageBlockParam, T> betaImageBlockParam,
        Func<BetaSearchResultBlockParam, T> betaSearchResultBlockParam,
        Func<BetaRequestDocumentBlock, T> betaRequestDocument
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => betaTextBlockParam(value),
            BetaImageBlockParam value => betaImageBlockParam(value),
            BetaSearchResultBlockParam value => betaSearchResultBlockParam(value),
            BetaRequestDocumentBlock value => betaRequestDocument(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class BlockConverter : JsonConverter<Block>
{
    public override Block? Read(
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
            case "text":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaTextBlockParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaImageBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaImageBlockParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "search_result":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaSearchResultBlockParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "document":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestDocumentBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRequestDocumentBlock'",
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

    public override void Write(Utf8JsonWriter writer, Block value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
