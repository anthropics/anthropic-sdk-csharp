using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaCitationsDelta, BetaCitationsDeltaFromRaw>))]
public sealed record class BetaCitationsDelta : JsonModel
{
    public required Citation Citation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Citation>("citation");
        }
        init { this._rawData.Set("citation", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
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

    public BetaCitationsDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

    public BetaCitationsDelta(BetaCitationsDelta betaCitationsDelta)
        : base(betaCitationsDelta) { }

    public BetaCitationsDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"citations_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationsDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCitationsDeltaFromRaw.FromRawUnchecked"/>
    public static BetaCitationsDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCitationsDelta(Citation citation)
        : this()
    {
        this.Citation = citation;
    }
}

class BetaCitationsDeltaFromRaw : IFromRawJson<BetaCitationsDelta>
{
    /// <inheritdoc/>
    public BetaCitationsDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCitationsDelta.FromRawUnchecked(rawData);
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
                betaCitationCharLocation: (x) => x.CitedText,
                betaCitationPageLocation: (x) => x.CitedText,
                betaCitationContentBlockLocation: (x) => x.CitedText,
                betaCitationsWebSearchResultLocation: (x) => x.CitedText,
                betaCitationSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (x) => x.DocumentIndex,
                betaCitationPageLocation: (x) => x.DocumentIndex,
                betaCitationContentBlockLocation: (x) => x.DocumentIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (x) => x.DocumentTitle,
                betaCitationPageLocation: (x) => x.DocumentTitle,
                betaCitationContentBlockLocation: (x) => x.DocumentTitle,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (x) => x.FileID,
                betaCitationPageLocation: (x) => x.FileID,
                betaCitationContentBlockLocation: (x) => x.FileID,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaCitationCharLocation: (x) => x.Type,
                betaCitationPageLocation: (x) => x.Type,
                betaCitationContentBlockLocation: (x) => x.Type,
                betaCitationsWebSearchResultLocation: (x) => x.Type,
                betaCitationSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (x) => x.EndBlockIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (x) => x.StartBlockIndex,
                betaCitationsWebSearchResultLocation: (_) => null,
                betaCitationSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                betaCitationCharLocation: (_) => null,
                betaCitationPageLocation: (_) => null,
                betaCitationContentBlockLocation: (_) => null,
                betaCitationsWebSearchResultLocation: (x) => x.Title,
                betaCitationSearchResultLocation: (x) => x.Title
            );
        }
    }

    public Citation(BetaCitationCharLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(BetaCitationPageLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(BetaCitationContentBlockLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(BetaCitationsWebSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Citation(BetaCitationSearchResultLocation value, JsonElement? element = null)
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
    /// type <see cref="BetaCitationCharLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCitationCharLocation(out var value)) {
    ///     // `value` is of type `BetaCitationCharLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocation? value
    )
    {
        value = this.Value as BetaCitationCharLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationPageLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCitationPageLocation(out var value)) {
    ///     // `value` is of type `BetaCitationPageLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocation? value
    )
    {
        value = this.Value as BetaCitationPageLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationContentBlockLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCitationContentBlockLocation(out var value)) {
    ///     // `value` is of type `BetaCitationContentBlockLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocation? value
    )
    {
        value = this.Value as BetaCitationContentBlockLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationsWebSearchResultLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCitationsWebSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationsWebSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationsWebSearchResultLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationSearchResultLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaCitationSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocation;
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
    ///     (BetaCitationCharLocation value) => {...},
    ///     (BetaCitationPageLocation value) => {...},
    ///     (BetaCitationContentBlockLocation value) => {...},
    ///     (BetaCitationsWebSearchResultLocation value) => {...},
    ///     (BetaCitationSearchResultLocation value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCitationCharLocation> betaCitationCharLocation,
        System::Action<BetaCitationPageLocation> betaCitationPageLocation,
        System::Action<BetaCitationContentBlockLocation> betaCitationContentBlockLocation,
        System::Action<BetaCitationsWebSearchResultLocation> betaCitationsWebSearchResultLocation,
        System::Action<BetaCitationSearchResultLocation> betaCitationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocation value:
                betaCitationCharLocation(value);
                break;
            case BetaCitationPageLocation value:
                betaCitationPageLocation(value);
                break;
            case BetaCitationContentBlockLocation value:
                betaCitationContentBlockLocation(value);
                break;
            case BetaCitationsWebSearchResultLocation value:
                betaCitationsWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocation value:
                betaCitationSearchResultLocation(value);
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
    ///     (BetaCitationCharLocation value) => {...},
    ///     (BetaCitationPageLocation value) => {...},
    ///     (BetaCitationContentBlockLocation value) => {...},
    ///     (BetaCitationsWebSearchResultLocation value) => {...},
    ///     (BetaCitationSearchResultLocation value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCitationCharLocation, T> betaCitationCharLocation,
        System::Func<BetaCitationPageLocation, T> betaCitationPageLocation,
        System::Func<BetaCitationContentBlockLocation, T> betaCitationContentBlockLocation,
        System::Func<BetaCitationsWebSearchResultLocation, T> betaCitationsWebSearchResultLocation,
        System::Func<BetaCitationSearchResultLocation, T> betaCitationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocation value => betaCitationCharLocation(value),
            BetaCitationPageLocation value => betaCitationPageLocation(value),
            BetaCitationContentBlockLocation value => betaCitationContentBlockLocation(value),
            BetaCitationsWebSearchResultLocation value => betaCitationsWebSearchResultLocation(
                value
            ),
            BetaCitationSearchResultLocation value => betaCitationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
    }

    public static implicit operator Citation(BetaCitationCharLocation value) => new(value);

    public static implicit operator Citation(BetaCitationPageLocation value) => new(value);

    public static implicit operator Citation(BetaCitationContentBlockLocation value) => new(value);

    public static implicit operator Citation(BetaCitationsWebSearchResultLocation value) =>
        new(value);

    public static implicit operator Citation(BetaCitationSearchResultLocation value) => new(value);

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
            (betaCitationCharLocation) => betaCitationCharLocation.Validate(),
            (betaCitationPageLocation) => betaCitationPageLocation.Validate(),
            (betaCitationContentBlockLocation) => betaCitationContentBlockLocation.Validate(),
            (betaCitationsWebSearchResultLocation) =>
                betaCitationsWebSearchResultLocation.Validate(),
            (betaCitationSearchResultLocation) => betaCitationSearchResultLocation.Validate()
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationsWebSearchResultLocation>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
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
