using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public record class BetaTextCitationParam : ModelBase
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
                BetaCitationCharLocationParam x => x.CitedText,
                BetaCitationPageLocationParam x => x.CitedText,
                BetaCitationContentBlockLocationParam x => x.CitedText,
                BetaCitationWebSearchResultLocationParam x => x.CitedText,
                BetaCitationSearchResultLocationParam x => x.CitedText,
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
                BetaCitationCharLocationParam x => x.DocumentIndex,
                BetaCitationPageLocationParam x => x.DocumentIndex,
                BetaCitationContentBlockLocationParam x => x.DocumentIndex,
                BetaCitationWebSearchResultLocationParam _ => null,
                BetaCitationSearchResultLocationParam _ => null,
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
                BetaCitationCharLocationParam x => x.DocumentTitle,
                BetaCitationPageLocationParam x => x.DocumentTitle,
                BetaCitationContentBlockLocationParam x => x.DocumentTitle,
                BetaCitationWebSearchResultLocationParam _ => null,
                BetaCitationSearchResultLocationParam _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "document_title"
                ),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaCitationCharLocationParam x => x.Type,
                BetaCitationPageLocationParam x => x.Type,
                BetaCitationContentBlockLocationParam x => x.Type,
                BetaCitationWebSearchResultLocationParam x => x.Type,
                BetaCitationSearchResultLocationParam x => x.Type,
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
                BetaCitationCharLocationParam _ => null,
                BetaCitationPageLocationParam _ => null,
                BetaCitationContentBlockLocationParam x => x.EndBlockIndex,
                BetaCitationWebSearchResultLocationParam _ => null,
                BetaCitationSearchResultLocationParam x => x.EndBlockIndex,
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
                BetaCitationCharLocationParam _ => null,
                BetaCitationPageLocationParam _ => null,
                BetaCitationContentBlockLocationParam x => x.StartBlockIndex,
                BetaCitationWebSearchResultLocationParam _ => null,
                BetaCitationSearchResultLocationParam x => x.StartBlockIndex,
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
                BetaCitationCharLocationParam _ => null,
                BetaCitationPageLocationParam _ => null,
                BetaCitationContentBlockLocationParam _ => null,
                BetaCitationWebSearchResultLocationParam x => x.Title,
                BetaCitationSearchResultLocationParam x => x.Title,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "title"),
            };
        }
    }

    public BetaTextCitationParam(BetaCitationCharLocationParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitationParam(BetaCitationPageLocationParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTextCitationParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationCharLocationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationCharLocation(out var value)) {
    ///     // `value` is of type `BetaCitationCharLocationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocationParam? value
    )
    {
        value = this.Value as BetaCitationCharLocationParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationPageLocationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationPageLocation(out var value)) {
    ///     // `value` is of type `BetaCitationPageLocationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocationParam? value
    )
    {
        value = this.Value as BetaCitationPageLocationParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationContentBlockLocationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationContentBlockLocation(out var value)) {
    ///     // `value` is of type `BetaCitationContentBlockLocationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocationParam? value
    )
    {
        value = this.Value as BetaCitationContentBlockLocationParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationWebSearchResultLocationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationWebSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationWebSearchResultLocationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationWebSearchResultLocationParam? value
    )
    {
        value = this.Value as BetaCitationWebSearchResultLocationParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCitationSearchResultLocationParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCitationSearchResultLocation(out var value)) {
    ///     // `value` is of type `BetaCitationSearchResultLocationParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocationParam? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocationParam;
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
    ///     (BetaCitationCharLocationParam value) =&gt; {...},
    ///     (BetaCitationPageLocationParam value) =&gt; {...},
    ///     (BetaCitationContentBlockLocationParam value) =&gt; {...},
    ///     (BetaCitationWebSearchResultLocationParam value) =&gt; {...},
    ///     (BetaCitationSearchResultLocationParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaCitationCharLocationParam> citationCharLocation,
        System::Action<BetaCitationPageLocationParam> citationPageLocation,
        System::Action<BetaCitationContentBlockLocationParam> citationContentBlockLocation,
        System::Action<BetaCitationWebSearchResultLocationParam> citationWebSearchResultLocation,
        System::Action<BetaCitationSearchResultLocationParam> citationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocationParam value:
                citationCharLocation(value);
                break;
            case BetaCitationPageLocationParam value:
                citationPageLocation(value);
                break;
            case BetaCitationContentBlockLocationParam value:
                citationContentBlockLocation(value);
                break;
            case BetaCitationWebSearchResultLocationParam value:
                citationWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocationParam value:
                citationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextCitationParam"
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
    ///     (BetaCitationCharLocationParam value) =&gt; {...},
    ///     (BetaCitationPageLocationParam value) =&gt; {...},
    ///     (BetaCitationContentBlockLocationParam value) =&gt; {...},
    ///     (BetaCitationWebSearchResultLocationParam value) =&gt; {...},
    ///     (BetaCitationSearchResultLocationParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaCitationCharLocationParam, T> citationCharLocation,
        System::Func<BetaCitationPageLocationParam, T> citationPageLocation,
        System::Func<BetaCitationContentBlockLocationParam, T> citationContentBlockLocation,
        System::Func<BetaCitationWebSearchResultLocationParam, T> citationWebSearchResultLocation,
        System::Func<BetaCitationSearchResultLocationParam, T> citationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocationParam value => citationCharLocation(value),
            BetaCitationPageLocationParam value => citationPageLocation(value),
            BetaCitationContentBlockLocationParam value => citationContentBlockLocation(value),
            BetaCitationWebSearchResultLocationParam value => citationWebSearchResultLocation(
                value
            ),
            BetaCitationSearchResultLocationParam value => citationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitationParam"
            ),
        };
    }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new(value);

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
                "Data did not match any variant of BetaTextCitationParam"
            );
        }
        this.Switch(
            (citationCharLocation) => citationCharLocation.Validate(),
            (citationPageLocation) => citationPageLocation.Validate(),
            (citationContentBlockLocation) => citationContentBlockLocation.Validate(),
            (citationWebSearchResultLocation) => citationWebSearchResultLocation.Validate(),
            (citationSearchResultLocation) => citationSearchResultLocation.Validate()
        );
    }

    public virtual bool Equals(BetaTextCitationParam? other) =>
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
            BetaCitationCharLocationParam _ => 0,
            BetaCitationPageLocationParam _ => 1,
            BetaCitationContentBlockLocationParam _ => 2,
            BetaCitationWebSearchResultLocationParam _ => 3,
            BetaCitationSearchResultLocationParam _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocationParam>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationContentBlockLocationParam>(
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
                        JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationSearchResultLocationParam>(
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
                return new BetaTextCitationParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextCitationParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
