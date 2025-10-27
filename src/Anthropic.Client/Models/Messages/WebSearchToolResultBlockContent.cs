using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public record class WebSearchToolResultBlockContent
{
    public object Value { get; private init; }

    public WebSearchToolResultBlockContent(WebSearchToolResultError value)
    {
        Value = value;
    }

    public WebSearchToolResultBlockContent(List<WebSearchResultBlock> value)
    {
        Value = value;
    }

    WebSearchToolResultBlockContent(UnknownVariant value)
    {
        Value = value;
    }

    public static WebSearchToolResultBlockContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickError([NotNullWhen(true)] out WebSearchToolResultError? value)
    {
        value = this.Value as WebSearchToolResultError;
        return value != null;
    }

    public bool TryPickWebSearchResultBlocks(
        [NotNullWhen(true)] out List<WebSearchResultBlock>? value
    )
    {
        value = this.Value as List<WebSearchResultBlock>;
        return value != null;
    }

    public void Switch(
        Action<WebSearchToolResultError> error,
        Action<List<WebSearchResultBlock>> webSearchResultBlocks
    )
    {
        switch (this.Value)
        {
            case WebSearchToolResultError value:
                error(value);
                break;
            case List<WebSearchResultBlock> value:
                webSearchResultBlocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of WebSearchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        Func<WebSearchToolResultError, T> error,
        Func<List<WebSearchResultBlock>, T> webSearchResultBlocks
    )
    {
        return this.Value switch
        {
            WebSearchToolResultError value => error(value),
            List<WebSearchResultBlock> value => webSearchResultBlocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class WebSearchToolResultBlockContentConverter
    : JsonConverter<WebSearchToolResultBlockContent>
{
    public override WebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new WebSearchToolResultBlockContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'WebSearchToolResultError'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<WebSearchResultBlock>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
