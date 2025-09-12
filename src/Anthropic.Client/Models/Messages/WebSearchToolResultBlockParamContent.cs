using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockParamContentVariants = Anthropic.Client.Models.Messages.WebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public abstract record class WebSearchToolResultBlockParamContent
{
    internal WebSearchToolResultBlockParamContent() { }

    public static implicit operator WebSearchToolResultBlockParamContent(
        List<WebSearchResultBlockParam> value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError(value);

    public bool TryPickItem([NotNullWhen(true)] out List<WebSearchResultBlockParam>? value)
    {
        value = (
            this as WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem
        )?.Value;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out WebSearchToolRequestError? value)
    {
        value = (
            this as WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError
        )?.Value;
        return value != null;
    }

    public void Switch(
        Action<WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem> webSearchToolResultBlockItem,
        Action<WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError> requestError
    )
    {
        switch (this)
        {
            case WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem inner:
                webSearchToolResultBlockItem(inner);
                break;
            case WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError inner:
                requestError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem,
            T
        > webSearchToolResultBlockItem,
        Func<
            WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError,
            T
        > requestError
    )
    {
        return this switch
        {
            WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem inner =>
                webSearchToolResultBlockItem(inner),
            WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError inner =>
                requestError(inner),
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
        Type typeToConvert,
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
                return new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError(
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
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(
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
        WebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(
                var webSearchToolResultBlockItem
            ) => webSearchToolResultBlockItem,
            WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError(
                var requestError
            ) => requestError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
