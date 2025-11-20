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
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public WebSearchToolResultBlockContent(WebSearchToolResultError value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public WebSearchToolResultBlockContent(
        IReadOnlyList<WebSearchResultBlock> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public WebSearchToolResultBlockContent(JsonElement json)
    {
        this._json = json;
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
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlock>>(
                json,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
