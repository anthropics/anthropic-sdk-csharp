using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<CitationsDelta, CitationsDeltaFromRaw>))]
public sealed record class CitationsDelta : JsonModel
{
    public required Citation Citation
    {
        get { return this._rawData.GetNotNullClass<Citation>("citation"); }
        init { this._rawData.Set("citation", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Citation.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

    public CitationsDelta(CitationsDelta citationsDelta)
        : base(citationsDelta) { }

    public CitationsDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CitationsDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CitationsDeltaFromRaw.FromRawUnchecked"/>
    public static CitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}

class CitationsDeltaFromRaw : IFromRawJson<CitationsDelta>
{
    /// <inheritdoc/>
    public CitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CitationsDelta.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CitationConverter))]
public record class Citation : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string CitedText
    {
        get
        {
            return Match(
                charLocation: (x) => x.CitedText,
                pageLocation: (x) => x.CitedText,
                contentBlockLocation: (x) => x.CitedText,
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
                charLocation: (x) => x.DocumentIndex,
                pageLocation: (x) => x.DocumentIndex,
                contentBlockLocation: (x) => x.DocumentIndex,
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
                charLocation: (x) => x.DocumentTitle,
                pageLocation: (x) => x.DocumentTitle,
                contentBlockLocation: (x) => x.DocumentTitle,
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
                charLocation: (x) => x.FileID,
                pageLocation: (x) => x.FileID,
                contentBlockLocation: (x) => x.FileID,
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
                charLocation: (x) => x.Type,
                pageLocation: (x) => x.Type,
                contentBlockLocation: (x) => x.Type,
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
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.EndBlockIndex,
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
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.StartBlockIndex,
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
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (_) => null,
                citationsWebSearchResultLocation: (x) => x.Title,
                citationsSearchResultLocation: (x) => x.Title
            );
        }
    }

    public Citation(CitationCharLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(CitationPageLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(CitationContentBlockLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(CitationsWebSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(CitationsSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(JsonElement element)
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
    /// if (instance.TryPickCharLocation(out var value)) {
    ///     // `value` is of type `CitationCharLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCharLocation([NotNullWhen(true)] out CitationCharLocation? value)
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
    /// if (instance.TryPickPageLocation(out var value)) {
    ///     // `value` is of type `CitationPageLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPageLocation([NotNullWhen(true)] out CitationPageLocation? value)
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
    /// if (instance.TryPickContentBlockLocation(out var value)) {
    ///     // `value` is of type `CitationContentBlockLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContentBlockLocation(
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
        System::Action<CitationCharLocation> charLocation,
        System::Action<CitationPageLocation> pageLocation,
        System::Action<CitationContentBlockLocation> contentBlockLocation,
        System::Action<CitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        System::Action<CitationsSearchResultLocation> citationsSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case CitationCharLocation value:
                charLocation(value);
                break;
            case CitationPageLocation value:
                pageLocation(value);
                break;
            case CitationContentBlockLocation value:
                contentBlockLocation(value);
                break;
            case CitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case CitationsSearchResultLocation value:
                citationsSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Citation"
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
        System::Func<CitationCharLocation, T> charLocation,
        System::Func<CitationPageLocation, T> pageLocation,
        System::Func<CitationContentBlockLocation, T> contentBlockLocation,
        System::Func<CitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        System::Func<CitationsSearchResultLocation, T> citationsSearchResultLocation
    )
    {
        return this.Value switch
        {
            CitationCharLocation value => charLocation(value),
            CitationPageLocation value => pageLocation(value),
            CitationContentBlockLocation value => contentBlockLocation(value),
            CitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            CitationsSearchResultLocation value => citationsSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
    }

    public static implicit operator Citation(CitationCharLocation value) => new(value);

    public static implicit operator Citation(CitationPageLocation value) => new(value);

    public static implicit operator Citation(CitationContentBlockLocation value) => new(value);

    public static implicit operator Citation(CitationsWebSearchResultLocation value) => new(value);

    public static implicit operator Citation(CitationsSearchResultLocation value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Citation");
        }
        this.Switch(
            (charLocation) => charLocation.Validate(),
            (pageLocation) => pageLocation.Validate(),
            (contentBlockLocation) => contentBlockLocation.Validate(),
            (citationsWebSearchResultLocation) => citationsWebSearchResultLocation.Validate(),
            (citationsSearchResultLocation) => citationsSearchResultLocation.Validate()
        );
    }

    public virtual bool Equals(Citation? other)
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

sealed class CitationConverter : JsonConverter<Citation>
{
    public override Citation? Read(
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
                return new Citation(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
