using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// How to set the `cmek` control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedCmekControlParamsConverter))]
public record class BetaGoogleManagedCmekControlParams : ModelBase
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

    public ApiEnum<string, BetaGoogleManagedCmekControlParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekDisabledParams _ =>
                    BetaGoogleManagedCmekControlParamsType.Disabled,
                BetaGoogleManagedCmekEnabledParams _ =>
                    BetaGoogleManagedCmekControlParamsType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedCmekControlParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedCmekControlParams(
        BetaGoogleManagedCmekDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekControlParams(
        BetaGoogleManagedCmekEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekControlParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out BetaGoogleManagedCmekDisabledParams? value)
    {
        value = this.Value as BetaGoogleManagedCmekDisabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaGoogleManagedCmekEnabledParams? value)
    {
        value = this.Value as BetaGoogleManagedCmekEnabledParams;
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
    ///     (BetaGoogleManagedCmekDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedCmekEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedCmekDisabledParams> disabled,
        Action<BetaGoogleManagedCmekEnabledParams> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedCmekDisabledParams value:
                disabled(value);
                break;
            case BetaGoogleManagedCmekEnabledParams value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedCmekControlParams"
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
    ///     (BetaGoogleManagedCmekDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedCmekEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedCmekDisabledParams, T> disabled,
        Func<BetaGoogleManagedCmekEnabledParams, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedCmekDisabledParams value => disabled(value),
            BetaGoogleManagedCmekEnabledParams value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedCmekControlParams"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedCmekControlParams(
        BetaGoogleManagedCmekDisabledParams value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekControlParams(
        BetaGoogleManagedCmekEnabledParams value
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
                "Data did not match any variant of BetaGoogleManagedCmekControlParams"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedCmekControlParams? other) =>
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
            BetaGoogleManagedCmekDisabledParams _ => 0,
            BetaGoogleManagedCmekEnabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedCmekControlParamsConverter
    : JsonConverter<BetaGoogleManagedCmekControlParams>
{
    public override BetaGoogleManagedCmekControlParams? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekDisabledParams>(
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
            case "enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekEnabledParams>(
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
                return new BetaGoogleManagedCmekControlParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekControlParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedCmekControlParamsTypeConverter))]
public enum BetaGoogleManagedCmekControlParamsType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedCmekControlParamsTypeConverter
    : JsonConverter<BetaGoogleManagedCmekControlParamsType>
{
    public override BetaGoogleManagedCmekControlParamsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedCmekControlParamsType.Disabled,
            "enabled" => BetaGoogleManagedCmekControlParamsType.Enabled,
            _ => (BetaGoogleManagedCmekControlParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekControlParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedCmekControlParamsType.Disabled => "disabled",
                BetaGoogleManagedCmekControlParamsType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
