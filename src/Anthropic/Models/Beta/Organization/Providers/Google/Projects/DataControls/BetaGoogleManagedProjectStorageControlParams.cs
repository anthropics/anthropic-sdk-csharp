using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The customer-owned storage control. Leave it out to keep the control as it is.
/// Send `cmek`, `storage`, or both.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedProjectStorageControlParamsConverter))]
public record class BetaGoogleManagedProjectStorageControlParams : ModelBase
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

    public ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageDisabledParams _ =>
                    BetaGoogleManagedProjectStorageControlParamsType.Disabled,
                BetaGoogleManagedProjectStorageEnabledParams _ =>
                    BetaGoogleManagedProjectStorageControlParamsType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectStorageControlParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedProjectStorageControlParams(
        BetaGoogleManagedProjectStorageDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageControlParams(
        BetaGoogleManagedProjectStorageEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageControlParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageDisabledParams? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageDisabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageEnabledParams? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageEnabledParams;
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
    ///     (BetaGoogleManagedProjectStorageDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectStorageDisabledParams> disabled,
        Action<BetaGoogleManagedProjectStorageEnabledParams> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectStorageDisabledParams value:
                disabled(value);
                break;
            case BetaGoogleManagedProjectStorageEnabledParams value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectStorageControlParams"
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
    ///     (BetaGoogleManagedProjectStorageDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectStorageDisabledParams, T> disabled,
        Func<BetaGoogleManagedProjectStorageEnabledParams, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectStorageDisabledParams value => disabled(value),
            BetaGoogleManagedProjectStorageEnabledParams value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectStorageControlParams"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectStorageControlParams(
        BetaGoogleManagedProjectStorageDisabledParams value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageControlParams(
        BetaGoogleManagedProjectStorageEnabledParams value
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
                "Data did not match any variant of BetaGoogleManagedProjectStorageControlParams"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedProjectStorageControlParams? other) =>
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
            BetaGoogleManagedProjectStorageDisabledParams _ => 0,
            BetaGoogleManagedProjectStorageEnabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectStorageControlParamsConverter
    : JsonConverter<BetaGoogleManagedProjectStorageControlParams>
{
    public override BetaGoogleManagedProjectStorageControlParams? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageDisabledParams>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabledParams>(
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
                return new BetaGoogleManagedProjectStorageControlParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageControlParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectStorageControlParamsTypeConverter))]
public enum BetaGoogleManagedProjectStorageControlParamsType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedProjectStorageControlParamsTypeConverter
    : JsonConverter<BetaGoogleManagedProjectStorageControlParamsType>
{
    public override BetaGoogleManagedProjectStorageControlParamsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedProjectStorageControlParamsType.Disabled,
            "enabled" => BetaGoogleManagedProjectStorageControlParamsType.Enabled,
            _ => (BetaGoogleManagedProjectStorageControlParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageControlParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectStorageControlParamsType.Disabled => "disabled",
                BetaGoogleManagedProjectStorageControlParamsType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
