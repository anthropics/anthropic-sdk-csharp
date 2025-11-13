using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public record class WebSearchToolResultBlockContent
{
    public object Value { get; private init; }

    public WebSearchToolResultBlockContent(WebSearchToolResultError value)
    {
        Value = value;
    }

    public WebSearchToolResultBlockContent(IReadOnlyList<WebSearchResultBlock> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
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
        [NotNullWhen(true)] out IReadOnlyList<WebSearchResultBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<WebSearchResultBlock>;
        return value != null;
    }

    public void Switch(
        System::Action<WebSearchToolResultError> error,
        System::Action<IReadOnlyList<WebSearchResultBlock>> webSearchResultBlocks
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
        System::Func<WebSearchToolResultError, T> error,
        System::Func<IReadOnlyList<WebSearchResultBlock>, T> webSearchResultBlocks
    )
    {
        return this.Value switch
        {
            WebSearchToolResultError value => error(value),
            IReadOnlyList<WebSearchResultBlock> value => webSearchResultBlocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new(value);

    public static implicit operator WebSearchToolResultBlockContent(
        List<WebSearchResultBlock> value
    ) => new((IReadOnlyList<WebSearchResultBlock>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class WebSearchToolResultBlockContentConverter
    : JsonConverter<WebSearchToolResultBlockContent>
{
    public override WebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
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
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<WebSearchResultBlock>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
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
