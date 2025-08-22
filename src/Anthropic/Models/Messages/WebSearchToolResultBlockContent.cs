using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public abstract record class WebSearchToolResultBlockContent
{
    internal WebSearchToolResultBlockContent() { }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchToolResultError(value);

    public static implicit operator WebSearchToolResultBlockContent(
        List<WebSearchResultBlock> value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(value);

    public bool TryPickError([NotNullWhen(true)] out WebSearchToolResultError? value)
    {
        value = (this as WebSearchToolResultBlockContentVariants::WebSearchToolResultError)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchResultBlocks(
        [NotNullWhen(true)] out List<WebSearchResultBlock>? value
    )
    {
        value = (this as WebSearchToolResultBlockContentVariants::WebSearchResultBlocks)?.Value;
        return value != null;
    }

    public void Switch(
        Action<WebSearchToolResultBlockContentVariants::WebSearchToolResultError> error,
        Action<WebSearchToolResultBlockContentVariants::WebSearchResultBlocks> webSearchResultBlocks
    )
    {
        switch (this)
        {
            case WebSearchToolResultBlockContentVariants::WebSearchToolResultError inner:
                error(inner);
                break;
            case WebSearchToolResultBlockContentVariants::WebSearchResultBlocks inner:
                webSearchResultBlocks(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<WebSearchToolResultBlockContentVariants::WebSearchToolResultError, T> error,
        Func<
            WebSearchToolResultBlockContentVariants::WebSearchResultBlocks,
            T
        > webSearchResultBlocks
    )
    {
        return this switch
        {
            WebSearchToolResultBlockContentVariants::WebSearchToolResultError inner => error(inner),
            WebSearchToolResultBlockContentVariants::WebSearchResultBlocks inner =>
                webSearchResultBlocks(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockContentVariants::WebSearchToolResultError(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlock>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            WebSearchToolResultBlockContentVariants::WebSearchToolResultError(var error) => error,
            WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(
                var webSearchResultBlocks
            ) => webSearchResultBlocks,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
