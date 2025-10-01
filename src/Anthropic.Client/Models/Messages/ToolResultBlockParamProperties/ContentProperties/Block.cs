using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using BlockVariants = Anthropic.Client.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;

namespace Anthropic.Client.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(TextBlockParam value) =>
        new BlockVariants::TextBlockParam(value);

    public static implicit operator Block(ImageBlockParam value) =>
        new BlockVariants::ImageBlockParam(value);

    public static implicit operator Block(SearchResultBlockParam value) =>
        new BlockVariants::SearchResultBlockParam(value);

    public static implicit operator Block(DocumentBlockParam value) =>
        new BlockVariants::DocumentBlockParam(value);

    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = (this as BlockVariants::TextBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = (this as BlockVariants::ImageBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickSearchResultBlockParam([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = (this as BlockVariants::SearchResultBlockParam)?.Value;
        return value != null;
    }

    public bool TryPickDocumentBlockParam([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = (this as BlockVariants::DocumentBlockParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BlockVariants::TextBlockParam> textBlockParam,
        Action<BlockVariants::ImageBlockParam> imageBlockParam,
        Action<BlockVariants::SearchResultBlockParam> searchResultBlockParam,
        Action<BlockVariants::DocumentBlockParam> documentBlockParam
    )
    {
        switch (this)
        {
            case BlockVariants::TextBlockParam inner:
                textBlockParam(inner);
                break;
            case BlockVariants::ImageBlockParam inner:
                imageBlockParam(inner);
                break;
            case BlockVariants::SearchResultBlockParam inner:
                searchResultBlockParam(inner);
                break;
            case BlockVariants::DocumentBlockParam inner:
                documentBlockParam(inner);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        Func<BlockVariants::TextBlockParam, T> textBlockParam,
        Func<BlockVariants::ImageBlockParam, T> imageBlockParam,
        Func<BlockVariants::SearchResultBlockParam, T> searchResultBlockParam,
        Func<BlockVariants::DocumentBlockParam, T> documentBlockParam
    )
    {
        return this switch
        {
            BlockVariants::TextBlockParam inner => textBlockParam(inner),
            BlockVariants::ImageBlockParam inner => imageBlockParam(inner),
            BlockVariants::SearchResultBlockParam inner => searchResultBlockParam(inner),
            BlockVariants::DocumentBlockParam inner => documentBlockParam(inner),
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
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new BlockVariants::TextBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::TextBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<ImageBlockParam>(json, options);
                    if (deserialized != null)
                    {
                        return new BlockVariants::ImageBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::ImageBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<SearchResultBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BlockVariants::SearchResultBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::SearchResultBlockParam",
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
                    var deserialized = JsonSerializer.Deserialize<DocumentBlockParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BlockVariants::DocumentBlockParam(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant BlockVariants::DocumentBlockParam",
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
            BlockVariants::TextBlockParam(var textBlockParam) => textBlockParam,
            BlockVariants::ImageBlockParam(var imageBlockParam) => imageBlockParam,
            BlockVariants::SearchResultBlockParam(var searchResultBlockParam) =>
                searchResultBlockParam,
            BlockVariants::DocumentBlockParam(var documentBlockParam) => documentBlockParam,
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
