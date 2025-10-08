using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(BlockConverter))]
public record class Block
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                textBlockParam: (x) => x.Type,
                imageBlockParam: (x) => x.Type,
                searchResultBlockParam: (x) => x.Type,
                documentBlockParam: (x) => x.Type
            );
        }
    }

    public CacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<CacheControlEphemeral?>(
                textBlockParam: (x) => x.CacheControl,
                imageBlockParam: (x) => x.CacheControl,
                searchResultBlockParam: (x) => x.CacheControl,
                documentBlockParam: (x) => x.CacheControl
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                textBlockParam: (_) => null,
                imageBlockParam: (_) => null,
                searchResultBlockParam: (x) => x.Title,
                documentBlockParam: (x) => x.Title
            );
        }
    }

    public Block(TextBlockParam value)
    {
        Value = value;
    }

    public Block(ImageBlockParam value)
    {
        Value = value;
    }

    public Block(SearchResultBlockParam value)
    {
        Value = value;
    }

    public Block(DocumentBlockParam value)
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

    public bool TryPickTextBlockParam([NotNullWhen(true)] out TextBlockParam? value)
    {
        value = this.Value as TextBlockParam;
        return value != null;
    }

    public bool TryPickImageBlockParam([NotNullWhen(true)] out ImageBlockParam? value)
    {
        value = this.Value as ImageBlockParam;
        return value != null;
    }

    public bool TryPickSearchResultBlockParam([NotNullWhen(true)] out SearchResultBlockParam? value)
    {
        value = this.Value as SearchResultBlockParam;
        return value != null;
    }

    public bool TryPickDocumentBlockParam([NotNullWhen(true)] out DocumentBlockParam? value)
    {
        value = this.Value as DocumentBlockParam;
        return value != null;
    }

    public void Switch(
        Action<TextBlockParam> textBlockParam,
        Action<ImageBlockParam> imageBlockParam,
        Action<SearchResultBlockParam> searchResultBlockParam,
        Action<DocumentBlockParam> documentBlockParam
    )
    {
        switch (this.Value)
        {
            case TextBlockParam value:
                textBlockParam(value);
                break;
            case ImageBlockParam value:
                imageBlockParam(value);
                break;
            case SearchResultBlockParam value:
                searchResultBlockParam(value);
                break;
            case DocumentBlockParam value:
                documentBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Block");
        }
    }

    public T Match<T>(
        Func<TextBlockParam, T> textBlockParam,
        Func<ImageBlockParam, T> imageBlockParam,
        Func<SearchResultBlockParam, T> searchResultBlockParam,
        Func<DocumentBlockParam, T> documentBlockParam
    )
    {
        return this.Value switch
        {
            TextBlockParam value => textBlockParam(value),
            ImageBlockParam value => imageBlockParam(value),
            SearchResultBlockParam value => searchResultBlockParam(value),
            DocumentBlockParam value => documentBlockParam(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Block"),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
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
                    var deserialized = JsonSerializer.Deserialize<TextBlockParam>(json, options);
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
                            "Data does not match union variant 'TextBlockParam'",
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
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'ImageBlockParam'",
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
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'SearchResultBlockParam'",
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
                        deserialized.Validate();
                        return new Block(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'DocumentBlockParam'",
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
