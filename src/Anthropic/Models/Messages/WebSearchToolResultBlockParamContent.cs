using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockParamContentConverter))]
public record class WebSearchToolResultBlockParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public WebSearchToolResultBlockParamContent(
        IReadOnlyList<WebSearchResultBlockParam> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public WebSearchToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
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

    public static implicit operator WebSearchToolResultBlockParamContent(
        List<WebSearchResultBlockParam> value
    ) => new((IReadOnlyList<WebSearchResultBlockParam>)value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockParamContent"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolRequestError>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlockParam>>(
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
        WebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
