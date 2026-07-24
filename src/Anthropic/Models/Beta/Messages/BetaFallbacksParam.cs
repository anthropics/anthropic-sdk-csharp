using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Opt-in server-side retry on one or more substitute models when the requested
/// model declines for policy reasons. Tried in order: if the first entry also declines,
/// the second is tried, and so on. The string "default" requests the requested model's
/// server-defined default fallback configuration.
/// </summary>
[JsonConverter(typeof(BetaFallbacksParamConverter))]
public record class BetaFallbacksParam : ModelBase
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

    public BetaFallbacksParam(IReadOnlyList<BetaFallbackParam> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public BetaFallbacksParam(Default value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaFallbacksParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>BetaFallbackParam</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaFallbackParams(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;BetaFallbackParam&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaFallbackParams(
        [NotNullWhen(true)] out IReadOnlyList<BetaFallbackParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaFallbackParam>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Default"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDefault(out var value)) {
    ///     // `value` is of type `Default`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDefault([NotNullWhen(true)] out Default? value)
    {
        value = this.Value as Default;
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
    ///     (IReadOnlyList&lt;BetaFallbackParam&gt; value) =&gt; {...},
    ///     (Default value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyList<BetaFallbackParam>> betaFallbackParams,
        System::Action<Default> default_
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<BetaFallbackParam> value:
                betaFallbackParams(value);
                break;
            case Default value:
                default_(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaFallbacksParam"
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
    ///     (IReadOnlyList&lt;BetaFallbackParam&gt; value) =&gt; {...},
    ///     (Default value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyList<BetaFallbackParam>, T> betaFallbackParams,
        System::Func<Default, T> default_
    )
    {
        return this.Value switch
        {
            IReadOnlyList<BetaFallbackParam> value => betaFallbackParams(value),
            Default value => default_(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaFallbacksParam"
            ),
        };
    }

    public static implicit operator BetaFallbacksParam(List<BetaFallbackParam> value) =>
        new((IReadOnlyList<BetaFallbackParam>)value);

    public static implicit operator BetaFallbacksParam(Default value) => new(value);

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
                "Data did not match any variant of BetaFallbacksParam"
            );
        }
        this.Switch(
            (betaFallbackParams) =>
            {
                foreach (var item in betaFallbackParams)
                {
                    item.Validate();
                }
            },
            (default_) => default_.Validate()
        );
    }

    public virtual bool Equals(BetaFallbacksParam? other) =>
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
            IReadOnlyList<BetaFallbackParam> _ => 0,
            Default _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaFallbacksParamConverter : JsonConverter<BetaFallbacksParam?>
{
    public override BetaFallbacksParam? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Default>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<List<BetaFallbackParam>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
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
        BetaFallbacksParam? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(DefaultConverter))]
public record class Default
{
    public JsonElement Element { get; private init; }

    public Default()
    {
        Element = JsonSerializer.SerializeToElement("default");
    }

    internal Default(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new Default())
        {
            throw new AnthropicInvalidDataException("Invalid value given for 'Default'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Default? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class DefaultConverter : JsonConverter<Default>
{
    public override Default? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Default value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}
