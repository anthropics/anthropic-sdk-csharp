using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public abstract record class WebSearchToolResultBlockParamContent
{
    internal WebSearchToolResultBlockParamContent() { }

    public static implicit operator WebSearchToolResultBlockParamContent(
        List<WebSearchResultBlockParam> value
    ) => new WebSearchToolResultBlockItem(value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new WebSearchToolRequestErrorVariant(value);

    public bool TryPickWebSearchToolResultBlockItem(
        [NotNullWhen(true)] out List<WebSearchResultBlockParam>? value
    )
    {
        value = (this as WebSearchToolResultBlockItem)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchToolRequestErrorVariant(
        [NotNullWhen(true)] out WebSearchToolRequestError? value
    )
    {
        value = (this as WebSearchToolRequestErrorVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<WebSearchToolResultBlockItem> webSearchToolResultBlockItem,
        Action<WebSearchToolRequestErrorVariant> webSearchToolRequestError
    )
    {
        switch (this)
        {
            case WebSearchToolResultBlockItem inner:
                webSearchToolResultBlockItem(inner);
                break;
            case WebSearchToolRequestErrorVariant inner:
                webSearchToolRequestError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<WebSearchToolResultBlockItem, T> webSearchToolResultBlockItem,
        Func<WebSearchToolRequestErrorVariant, T> webSearchToolRequestError
    )
    {
        return this switch
        {
            WebSearchToolResultBlockItem inner => webSearchToolResultBlockItem(inner),
            WebSearchToolRequestErrorVariant inner => webSearchToolRequestError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class WebSearchToolResultBlockParamContentConverter
    : JsonConverter<WebSearchToolResultBlockParamContent>
{
    public override WebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolRequestErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockItem(deserialized);
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
        WebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            WebSearchToolResultBlockItem(var webSearchToolResultBlockItem) =>
                webSearchToolResultBlockItem,
            WebSearchToolRequestErrorVariant(var webSearchToolRequestError) =>
                webSearchToolRequestError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
