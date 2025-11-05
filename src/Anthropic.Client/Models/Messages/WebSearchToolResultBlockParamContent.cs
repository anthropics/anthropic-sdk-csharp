using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public record class WebSearchToolResultBlockParamContent
{
    public object Value { get; private init; }

    public WebSearchToolResultBlockParamContent(IReadOnlyList<WebSearchResultBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
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

    public bool TryPickItem([NotNullWhen(true)] out IReadOnlyList<WebSearchResultBlockParam>? value)
    {
        value = this.Value as IReadOnlyList<WebSearchResultBlockParam>;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out WebSearchToolRequestError? value)
    {
        value = this.Value as WebSearchToolRequestError;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<WebSearchResultBlockParam>> webSearchToolResultBlockItem,
        System::Action<WebSearchToolRequestError> requestError
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
        System::Func<IReadOnlyList<WebSearchResultBlockParam>, T> webSearchToolResultBlockItem,
        System::Func<WebSearchToolRequestError, T> requestError
    )
    {
        return this.Value switch
        {
            IReadOnlyList<WebSearchResultBlockParam> value => webSearchToolResultBlockItem(value),
            WebSearchToolRequestError value => requestError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockParamContent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockParamContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class WebSearchToolResultBlockParamContentConverter
    : JsonConverter<WebSearchToolResultBlockParamContent>
{
    public override WebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<WebSearchResultBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
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
