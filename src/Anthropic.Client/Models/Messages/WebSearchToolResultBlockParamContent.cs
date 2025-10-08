using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public record class WebSearchToolResultBlockParamContent
{
    public object Value { get; private init; }

    public WebSearchToolResultBlockParamContent(List<WebSearchResultBlockParam> value)
    {
        Value = value;
    }

    public WebSearchToolResultBlockParamContent(WebSearchToolRequestError value)
    {
        Value = value;
    }

    WebSearchToolResultBlockParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static WebSearchToolResultBlockParamContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickItem([NotNullWhen(true)] out List<WebSearchResultBlockParam>? value)
    {
        value = this.Value as List<WebSearchResultBlockParam>;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out WebSearchToolRequestError? value)
    {
        value = this.Value as WebSearchToolRequestError;
        return value != null;
    }

    public void Switch(
        Action<List<WebSearchResultBlockParam>> webSearchToolResultBlockItem,
        Action<WebSearchToolRequestError> requestError
    )
    {
        switch (this.Value)
        {
            case List<WebSearchResultBlockParam> value:
                webSearchToolResultBlockItem(value);
                break;
            case WebSearchToolRequestError value:
                requestError(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of WebSearchToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        Func<List<WebSearchResultBlockParam>, T> webSearchToolResultBlockItem,
        Func<WebSearchToolRequestError, T> requestError
    )
    {
        return this.Value switch
        {
            List<WebSearchResultBlockParam> value => webSearchToolResultBlockItem(value),
            WebSearchToolRequestError value => requestError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockParamContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockParamContent"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new WebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'WebSearchToolRequestError'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new WebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<WebSearchResultBlockParam>'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
