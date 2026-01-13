using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(TextCitationConverter))]
public record class TextCitation : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string CitedText
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.CitedText,
                citationPageLocation: (x) => x.CitedText,
                citationContentBlockLocation: (x) => x.CitedText,
                citationsWebSearchResultLocation: (x) => x.CitedText,
                citationsSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (x) => x.DocumentIndex,
                citationPageLocation: (x) => x.DocumentIndex,
                citationContentBlockLocation: (x) => x.DocumentIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (x) => x.DocumentTitle,
                citationPageLocation: (x) => x.DocumentTitle,
                citationContentBlockLocation: (x) => x.DocumentTitle,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (x) => x.FileID,
                citationPageLocation: (x) => x.FileID,
                citationContentBlockLocation: (x) => x.FileID,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.Type,
                citationPageLocation: (x) => x.Type,
                citationContentBlockLocation: (x) => x.Type,
                citationsWebSearchResultLocation: (x) => x.Type,
                citationsSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.EndBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.StartBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (_) => null,
                citationsWebSearchResultLocation: (x) => x.Title,
                citationsSearchResultLocation: (x) => x.Title
            );
        }
    }

    public TextCitation(CitationCharLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextCitation(CitationPageLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextCitation(CitationContentBlockLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextCitation(CitationsWebSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextCitation(CitationsSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TextCitation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationCharLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationCharLocation(out var value)) {
    ///     // `value` is of type `CitationCharLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationCharLocation([NotNullWhen(true)] out CitationCharLocation? value)
    {
        value = this.Value as CitationCharLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationPageLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationPageLocation(out var value)) {
    ///     // `value` is of type `CitationPageLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationPageLocation([NotNullWhen(true)] out CitationPageLocation? value)
    {
        value = this.Value as CitationPageLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationContentBlockLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationContentBlockLocation(out var value)) {
    ///     // `value` is of type `CitationContentBlockLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocation? value
    )
    {
        value = this.Value as CitationContentBlockLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationsWebSearchResultLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationsWebSearchResultLocation(out var value)) {
    ///     // `value` is of type `CitationsWebSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out CitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as CitationsWebSearchResultLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CitationsSearchResultLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationsSearchResultLocation(out var value)) {
    ///     // `value` is of type `CitationsSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationsSearchResultLocation(
        [NotNullWhen(true)] out CitationsSearchResultLocation? value
    )
    {
        value = this.Value as CitationsSearchResultLocation;
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
    ///     (CitationCharLocation value) => {...},
    ///     (CitationPageLocation value) => {...},
    ///     (CitationContentBlockLocation value) => {...},
    ///     (CitationsWebSearchResultLocation value) => {...},
    ///     (CitationsSearchResultLocation value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CitationCharLocation> citationCharLocation,
        System::Action<CitationPageLocation> citationPageLocation,
        System::Action<CitationContentBlockLocation> citationContentBlockLocation,
        System::Action<CitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        System::Action<CitationsSearchResultLocation> citationsSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case CitationCharLocation value:
                citationCharLocation(value);
                break;
            case CitationPageLocation value:
                citationPageLocation(value);
                break;
            case CitationContentBlockLocation value:
                citationContentBlockLocation(value);
                break;
            case CitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case CitationsSearchResultLocation value:
                citationsSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TextCitation"
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
    ///     (CitationCharLocation value) => {...},
    ///     (CitationPageLocation value) => {...},
    ///     (CitationContentBlockLocation value) => {...},
    ///     (CitationsWebSearchResultLocation value) => {...},
    ///     (CitationsSearchResultLocation value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CitationCharLocation, T> citationCharLocation,
        System::Func<CitationPageLocation, T> citationPageLocation,
        System::Func<CitationContentBlockLocation, T> citationContentBlockLocation,
        System::Func<CitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        System::Func<CitationsSearchResultLocation, T> citationsSearchResultLocation
    )
    {
        return this.Value switch
        {
            CitationCharLocation value => citationCharLocation(value),
            CitationPageLocation value => citationPageLocation(value),
            CitationContentBlockLocation value => citationContentBlockLocation(value),
            CitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            CitationsSearchResultLocation value => citationsSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextCitation"
            ),
        };
    }

    public static implicit operator TextCitation(CitationCharLocation value) => new(value);

    public static implicit operator TextCitation(CitationPageLocation value) => new(value);

    public static implicit operator TextCitation(CitationContentBlockLocation value) => new(value);

    public static implicit operator TextCitation(CitationsWebSearchResultLocation value) =>
        new(value);

    public static implicit operator TextCitation(CitationsSearchResultLocation value) => new(value);

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
                "Data did not match any variant of TextCitation"
            );
        }
        this.Switch(
            (citationCharLocation) => citationCharLocation.Validate(),
            (citationPageLocation) => citationPageLocation.Validate(),
            (citationContentBlockLocation) => citationContentBlockLocation.Validate(),
            (citationsWebSearchResultLocation) => citationsWebSearchResultLocation.Validate(),
            (citationsSearchResultLocation) => citationsSearchResultLocation.Validate()
        );
    }

    public virtual bool Equals(TextCitation? other)
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

sealed class TextCitationConverter : JsonConverter<TextCitation>
{
    public override TextCitation? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "char_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "page_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "content_block_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "web_search_result_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "search_result_location":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsSearchResultLocation>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new TextCitation(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextCitation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
