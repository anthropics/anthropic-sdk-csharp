using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BlockVariants = Anthropic.Client.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

namespace Anthropic.Client.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(BetaTextBlockParam value) =>
        new BlockVariants::BetaTextBlockParam(value);

    public static implicit operator Block(BetaImageBlockParam value) =>
        new BlockVariants::BetaImageBlockParam(value);

    public static implicit operator Block(BetaSearchResultBlockParam value) =>
        new BlockVariants::BetaSearchResultBlockParam(value);

    public static implicit operator Block(BetaRequestDocumentBlock value) =>
        new BlockVariants::BetaRequestDocumentBlock(value);

    public bool TryPickBetaTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = (this as BlockVariants::BetaTextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaImageBlockParam([NotNullWhen(true)] out BetaImageBlockParam? value)
    {
        value = (this as BlockVariants::BetaImageBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaSearchResultBlockParam(
        [NotNullWhen(true)] out BetaSearchResultBlockParam? value
    )
    {
        value = (this as BlockVariants::BetaSearchResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickBetaRequestDocument([NotNullWhen(true)] out BetaRequestDocumentBlock? value)
    {
        value = (this as BlockVariants::BetaRequestDocumentBlock)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BlockVariants::BetaTextBlockParam> betaTextBlockParam,
        Action<BlockVariants::BetaImageBlockParam> betaImageBlockParam,
        Action<BlockVariants::BetaSearchResultBlockParam> betaSearchResultBlockParam,
        Action<BlockVariants::BetaRequestDocumentBlock> betaRequestDocument
    )
    {
        switch (this)
        {
            case BlockVariants::BetaTextBlockParam inner:
                betaTextBlockParam(inner);
                break;
            case BlockVariants::BetaImageBlockParam inner:
                betaImageBlockParam(inner);
                break;
            case BlockVariants::BetaSearchResultBlockParam inner:
                betaSearchResultBlockParam(inner);
                break;
            case BlockVariants::BetaRequestDocumentBlock inner:
                betaRequestDocument(inner);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        Func<BlockVariants::BetaTextBlockParam, T> betaTextBlockParam,
        Func<BlockVariants::BetaImageBlockParam, T> betaImageBlockParam,
        Func<BlockVariants::BetaSearchResultBlockParam, T> betaSearchResultBlockParam,
        Func<BlockVariants::BetaRequestDocumentBlock, T> betaRequestDocument
    )
    {
        return this switch
        {
            BlockVariants::BetaTextBlockParam inner => betaTextBlockParam(inner),
            BlockVariants::BetaImageBlockParam inner => betaImageBlockParam(inner),
            BlockVariants::BetaSearchResultBlockParam inner => betaSearchResultBlockParam(inner),
            BlockVariants::BetaRequestDocumentBlock inner => betaRequestDocument(inner),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public abstract void Validate();
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
                        return new BlockVariants::BetaTextBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::BetaTextBlockParam",
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
                        return new BlockVariants::BetaImageBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::BetaImageBlockParam",
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
                        return new BlockVariants::BetaSearchResultBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::BetaSearchResultBlockParam",
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
                        return new BlockVariants::BetaRequestDocumentBlock(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::BetaRequestDocumentBlock",
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
        object variant = value switch
        {
            BlockVariants::BetaTextBlockParam(var betaTextBlockParam) => betaTextBlockParam,
            BlockVariants::BetaImageBlockParam(var betaImageBlockParam) => betaImageBlockParam,
            BlockVariants::BetaSearchResultBlockParam(var betaSearchResultBlockParam) =>
                betaSearchResultBlockParam,
            BlockVariants::BetaRequestDocumentBlock(var betaRequestDocument) => betaRequestDocument,
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
