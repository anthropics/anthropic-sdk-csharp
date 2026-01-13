using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(WebSearchToolResultBlockContentConverter))]
public record class WebSearchToolResultBlockContent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public WebSearchToolResultBlockContent(
        WebSearchToolResultError value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public WebSearchToolResultBlockContent(
        IReadOnlyList<WebSearchResultBlock> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public WebSearchToolResultBlockContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebSearchToolResultError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickError(out var value)) {
    ///     // `value` is of type `WebSearchToolResultError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickError([NotNullWhen(true)] out WebSearchToolResultError? value)
    {
        value = this.Value as WebSearchToolResultError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<WebSearchResultBlock>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchResultBlocks(out var value)) {
    ///     // `value` is of type `IReadOnlyList<WebSearchResultBlock>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchResultBlocks(
        [NotNullWhen(true)] out IReadOnlyList<WebSearchResultBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<WebSearchResultBlock>;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (WebSearchToolResultError value) => {...},
    ///     (IReadOnlyList<WebSearchResultBlock> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
            case IReadOnlyList<WebSearchResultBlock> value:
                webSearchResultBlocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of WebSearchToolResultBlockContent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (WebSearchToolResultError value) => {...},
    ///     (IReadOnlyList<WebSearchResultBlock> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of WebSearchToolResultBlockContent"
            );
        }
        this.Switch((error) => error.Validate(), (_) => { });
    }

    public virtual bool Equals(WebSearchToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
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
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<WebSearchToolResultError>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<WebSearchResultBlock>>(
                element,
                options
            );
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
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
