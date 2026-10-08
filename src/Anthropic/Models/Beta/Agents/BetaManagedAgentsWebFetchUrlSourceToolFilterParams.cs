using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Which tools' results contribute URLs that may be fetched. Accepts the string
/// "all" or "none", or an object whose type is "all", "none", "only" or "except".
/// Responses use the object form.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsWebFetchUrlSourceToolFilterParamsConverter))]
public record class BetaManagedAgentsWebFetchUrlSourceToolFilterParams : ModelBase
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

    public BetaManagedAgentsWebFetchUrlSourceToolFilterParams(
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilterParams(
        BetaManagedAgentsWebFetchUrlSourceToolFilter value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsWebFetchUrlSourceToolFilterParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of BetaManagedAgentsWebFetchUrlSourceShorthand.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickShorthand(out var value)) {
    ///     // `value` is of type `ApiEnum&lt;string, BetaManagedAgentsWebFetchUrlSourceShorthand&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickShorthand(
        [NotNullWhen(true)] out ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>? value
    )
    {
        value = this.Value as ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsWebFetchUrlSourceToolFilter"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsWebFetchUrlSourceToolFilter(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsWebFetchUrlSourceToolFilter`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsWebFetchUrlSourceToolFilter(
        [NotNullWhen(true)] out BetaManagedAgentsWebFetchUrlSourceToolFilter? value
    )
    {
        value = this.Value as BetaManagedAgentsWebFetchUrlSourceToolFilter;
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsWebFetchUrlSourceShorthand&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceToolFilter value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>> shorthand,
        System::Action<BetaManagedAgentsWebFetchUrlSourceToolFilter> betaManagedAgentsWebFetchUrlSourceToolFilter
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value:
                shorthand(value);
                break;
            case BetaManagedAgentsWebFetchUrlSourceToolFilter value:
                betaManagedAgentsWebFetchUrlSourceToolFilter(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilterParams"
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
    ///     (ApiEnum&lt;string, BetaManagedAgentsWebFetchUrlSourceShorthand&gt; value) =&gt; {...},
    ///     (BetaManagedAgentsWebFetchUrlSourceToolFilter value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>, T> shorthand,
        System::Func<
            BetaManagedAgentsWebFetchUrlSourceToolFilter,
            T
        > betaManagedAgentsWebFetchUrlSourceToolFilter
    )
    {
        return this.Value switch
        {
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value => shorthand(value),
            BetaManagedAgentsWebFetchUrlSourceToolFilter value =>
                betaManagedAgentsWebFetchUrlSourceToolFilter(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilterParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilterParams(
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilterParams(
        BetaManagedAgentsWebFetchUrlSourceShorthand value
    ) => new(value);

    public static implicit operator BetaManagedAgentsWebFetchUrlSourceToolFilterParams(
        BetaManagedAgentsWebFetchUrlSourceToolFilter value
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
                "Data did not match any variant of BetaManagedAgentsWebFetchUrlSourceToolFilterParams"
            );
        }
        this.Switch(
            (shorthand) => shorthand.Validate(),
            (betaManagedAgentsWebFetchUrlSourceToolFilter) =>
                betaManagedAgentsWebFetchUrlSourceToolFilter.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsWebFetchUrlSourceToolFilterParams? other) =>
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
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand> _ => 0,
            BetaManagedAgentsWebFetchUrlSourceToolFilter _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsWebFetchUrlSourceToolFilterParamsConverter
    : JsonConverter<BetaManagedAgentsWebFetchUrlSourceToolFilterParams>
{
    public override BetaManagedAgentsWebFetchUrlSourceToolFilterParams? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<
                ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceShorthand>
            >(element, options);
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
            var deserialized =
                JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceToolFilter>(
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWebFetchUrlSourceToolFilterParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
