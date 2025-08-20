using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public abstract record class WebSearchToolResultBlockContent
{
    internal WebSearchToolResultBlockContent() { }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new WebSearchToolResultErrorVariant(value);

    public static implicit operator WebSearchToolResultBlockContent(
        List<WebSearchResultBlock> value
    ) => new WebSearchResultBlocks(value);

    public bool TryPickWebSearchToolResultErrorVariant(
        [NotNullWhen(true)] out WebSearchToolResultError? value
    )
    {
        value = (this as WebSearchToolResultErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchResultBlocks(
        [NotNullWhen(true)] out List<WebSearchResultBlock>? value
    )
    {
        value = (this as WebSearchResultBlocks)?.Value;
        return value != null;
    }

    public void Switch(
        Action<WebSearchToolResultErrorVariant> webSearchToolResultError,
        Action<WebSearchResultBlocks> webSearchResultBlocks
    )
    {
        switch (this)
        {
            case WebSearchToolResultErrorVariant inner:
                webSearchToolResultError(inner);
                break;
            case WebSearchResultBlocks inner:
                webSearchResultBlocks(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<WebSearchToolResultErrorVariant, T> webSearchToolResultError,
        Func<WebSearchResultBlocks, T> webSearchResultBlocks
    )
    {
        return this switch
        {
            WebSearchToolResultErrorVariant inner => webSearchToolResultError(inner),
            WebSearchResultBlocks inner => webSearchResultBlocks(inner),
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
        Type _typeToConvert,
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
                return new WebSearchToolResultErrorVariant(deserialized);
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
                return new WebSearchResultBlocks(deserialized);
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
            WebSearchToolResultErrorVariant(var webSearchToolResultError) =>
                webSearchToolResultError,
            WebSearchResultBlocks(var webSearchResultBlocks) => webSearchResultBlocks,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
