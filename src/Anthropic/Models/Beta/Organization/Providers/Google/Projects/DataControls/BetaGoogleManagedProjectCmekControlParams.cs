using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The customer-managed encryption key control. Leave it out to keep the control
/// as it is. Send `cmek`, `storage`, or both.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedProjectCmekControlParamsConverter))]
public record class BetaGoogleManagedProjectCmekControlParams : ModelBase
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

    public ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectCmekDisabledParams _ =>
                    BetaGoogleManagedProjectCmekControlParamsType.Disabled,
                BetaGoogleManagedProjectCmekEnabledParams _ =>
                    BetaGoogleManagedProjectCmekControlParamsType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectCmekControlParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedProjectCmekControlParams(
        BetaGoogleManagedProjectCmekDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekControlParams(
        BetaGoogleManagedProjectCmekEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekControlParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekDisabledParams? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekDisabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekEnabledParams? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekEnabledParams;
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
    ///     (BetaGoogleManagedProjectCmekDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectCmekDisabledParams> disabled,
        Action<BetaGoogleManagedProjectCmekEnabledParams> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectCmekDisabledParams value:
                disabled(value);
                break;
            case BetaGoogleManagedProjectCmekEnabledParams value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectCmekControlParams"
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
    ///     (BetaGoogleManagedProjectCmekDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectCmekDisabledParams, T> disabled,
        Func<BetaGoogleManagedProjectCmekEnabledParams, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectCmekDisabledParams value => disabled(value),
            BetaGoogleManagedProjectCmekEnabledParams value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectCmekControlParams"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectCmekControlParams(
        BetaGoogleManagedProjectCmekDisabledParams value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekControlParams(
        BetaGoogleManagedProjectCmekEnabledParams value
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
                "Data did not match any variant of BetaGoogleManagedProjectCmekControlParams"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedProjectCmekControlParams? other) =>
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
            BetaGoogleManagedProjectCmekDisabledParams _ => 0,
            BetaGoogleManagedProjectCmekEnabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectCmekControlParamsConverter
    : JsonConverter<BetaGoogleManagedProjectCmekControlParams>
{
    public override BetaGoogleManagedProjectCmekControlParams? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekDisabledParams>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabledParams>(
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
                return new BetaGoogleManagedProjectCmekControlParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekControlParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectCmekControlParamsTypeConverter))]
public enum BetaGoogleManagedProjectCmekControlParamsType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedProjectCmekControlParamsTypeConverter
    : JsonConverter<BetaGoogleManagedProjectCmekControlParamsType>
{
    public override BetaGoogleManagedProjectCmekControlParamsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedProjectCmekControlParamsType.Disabled,
            "enabled" => BetaGoogleManagedProjectCmekControlParamsType.Enabled,
            _ => (BetaGoogleManagedProjectCmekControlParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekControlParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectCmekControlParamsType.Disabled => "disabled",
                BetaGoogleManagedProjectCmekControlParamsType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
