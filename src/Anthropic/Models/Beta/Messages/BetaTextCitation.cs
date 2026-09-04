using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationConverter))]
public record class BetaTextCitation : ModelBase
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
            return this.Value switch
            {
                BetaCitationCharLocation x => x.CitedText,
                BetaCitationPageLocation x => x.CitedText,
                BetaCitationContentBlockLocation x => x.CitedText,
                BetaCitationsWebSearchResultLocation x => x.CitedText,
                BetaCitationSearchResultLocation x => x.CitedText,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "cited_text"),
            };
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation x => x.DocumentIndex,
                BetaCitationPageLocation x => x.DocumentIndex,
                BetaCitationContentBlockLocation x => x.DocumentIndex,
                BetaCitationsWebSearchResultLocation _ => null,
                BetaCitationSearchResultLocation _ => null,
                _ => WrappedJsonSerializer.GetNullableStructProperty<long>(
                    this.Json,
                    "document_index"
                ),
            };
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation x => x.DocumentTitle,
                BetaCitationPageLocation x => x.DocumentTitle,
                BetaCitationContentBlockLocation x => x.DocumentTitle,
                BetaCitationsWebSearchResultLocation _ => null,
                BetaCitationSearchResultLocation _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "document_title"
                ),
            };
        }
    }

    public string? FileID
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation x => x.FileID,
                BetaCitationPageLocation x => x.FileID,
                BetaCitationContentBlockLocation x => x.FileID,
                BetaCitationsWebSearchResultLocation _ => null,
                BetaCitationSearchResultLocation _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "file_id"),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation x => x.Type,
                BetaCitationPageLocation x => x.Type,
                BetaCitationContentBlockLocation x => x.Type,
                BetaCitationsWebSearchResultLocation x => x.Type,
                BetaCitationSearchResultLocation x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation _ => null,
                BetaCitationPageLocation _ => null,
                BetaCitationContentBlockLocation x => x.EndBlockIndex,
                BetaCitationsWebSearchResultLocation _ => null,
                BetaCitationSearchResultLocation x => x.EndBlockIndex,
                _ => WrappedJsonSerializer.GetNullableStructProperty<long>(
                    this.Json,
                    "end_block_index"
                ),
            };
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation _ => null,
                BetaCitationPageLocation _ => null,
                BetaCitationContentBlockLocation x => x.StartBlockIndex,
                BetaCitationsWebSearchResultLocation _ => null,
                BetaCitationSearchResultLocation x => x.StartBlockIndex,
                _ => WrappedJsonSerializer.GetNullableStructProperty<long>(
                    this.Json,
                    "start_block_index"
                ),
            };
        }
    }

    public string? Title
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocation _ => null,
                BetaCitationPageLocation _ => null,
                BetaCitationContentBlockLocation _ => null,
                BetaCitationsWebSearchResultLocation x => x.Title,
                BetaCitationSearchResultLocation x => x.Title,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "title"),
            };
        }
    }

    public BetaTextCitation(BetaCitationCharLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitation(BetaCitationPageLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitation(BetaCitationContentBlockLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitation(BetaCitationsWebSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitation(BetaCitationSearchResultLocation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationCharLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationCharLocation(out var value)) {
    ///     // `value` is of type `BetaCitationCharLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationCharLocation([NotNullWhen(true)] out BetaCitationCharLocation? value)
    {
        value = this.Value as BetaCitationCharLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationPageLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationPageLocation(out var value)) {
    ///     // `value` is of type `BetaCitationPageLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationPageLocation([NotNullWhen(true)] out BetaCitationPageLocation? value)
    {
        value = this.Value as BetaCitationPageLocation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationContentBlockLocation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationContentBlockLocation(out var value)) {
    ///     // `value` is of type `BetaCitationContentBlockLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationContentBlockLocation(
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationsWebSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationsWebSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationsWebSearchResultLocation(
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
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationSearchResultLocation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocation? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocation;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BetaCitationCharLocation value) =&gt; {...},
    ///     (BetaCitationPageLocation value) =&gt; {...},
    ///     (BetaCitationContentBlockLocation value) =&gt; {...},
    ///     (BetaCitationsWebSearchResultLocation value) =&gt; {...},
    ///     (BetaCitationSearchResultLocation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCitationCharLocation> citationCharLocation,
        System::Action<BetaCitationPageLocation> citationPageLocation,
        System::Action<BetaCitationContentBlockLocation> citationContentBlockLocation,
        System::Action<BetaCitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        System::Action<BetaCitationSearchResultLocation> citationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocation value:
                citationCharLocation(value);
                break;
            case BetaCitationPageLocation value:
                citationPageLocation(value);
                break;
            case BetaCitationContentBlockLocation value:
                citationContentBlockLocation(value);
                break;
            case BetaCitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocation value:
                citationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextCitation"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BetaCitationCharLocation value) =&gt; {...},
    ///     (BetaCitationPageLocation value) =&gt; {...},
    ///     (BetaCitationContentBlockLocation value) =&gt; {...},
    ///     (BetaCitationsWebSearchResultLocation value) =&gt; {...},
    ///     (BetaCitationSearchResultLocation value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCitationCharLocation, T> citationCharLocation,
        System::Func<BetaCitationPageLocation, T> citationPageLocation,
        System::Func<BetaCitationContentBlockLocation, T> citationContentBlockLocation,
        System::Func<BetaCitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        System::Func<BetaCitationSearchResultLocation, T> citationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocation value => citationCharLocation(value),
            BetaCitationPageLocation value => citationPageLocation(value),
            BetaCitationContentBlockLocation value => citationContentBlockLocation(value),
            BetaCitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            BetaCitationSearchResultLocation value => citationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitation"
            ),
        };
    }

    public static implicit operator BetaTextCitation(BetaCitationCharLocation value) => new(value);

    public static implicit operator BetaTextCitation(BetaCitationPageLocation value) => new(value);

    public static implicit operator BetaTextCitation(BetaCitationContentBlockLocation value) =>
        new(value);

    public static implicit operator BetaTextCitation(BetaCitationsWebSearchResultLocation value) =>
        new(value);

    public static implicit operator BetaTextCitation(BetaCitationSearchResultLocation value) =>
        new(value);

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
                "Data did not match any variant of BetaTextCitation"
            );
        }
        this.Switch(
            (citationCharLocation) => citationCharLocation.Validate(),
            (citationPageLocation) => citationPageLocation.Validate(),
            (citationContentBlockLocation) => citationContentBlockLocation.Validate(),
            (citationsWebSearchResultLocation) => citationsWebSearchResultLocation.Validate(),
            (citationSearchResultLocation) => citationSearchResultLocation.Validate()
        );
    }

    public virtual bool Equals(BetaTextCitation? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaCitationCharLocation _ => 0,
            BetaCitationPageLocation _ => 1,
            BetaCitationContentBlockLocation _ => 2,
            BetaCitationsWebSearchResultLocation _ => 3,
            BetaCitationSearchResultLocation _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaTextCitationConverter : JsonConverter<BetaTextCitation>
{
    public override BetaTextCitation? Read(
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaTextCitation(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextCitation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
