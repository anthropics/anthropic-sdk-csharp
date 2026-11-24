using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// How to set the `storage` control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedStorageControlParamsConverter))]
public record class BetaGoogleManagedStorageControlParams : ModelBase
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

    public ApiEnum<string, BetaGoogleManagedStorageControlParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageDisabledParams _ =>
                    BetaGoogleManagedStorageControlParamsType.Disabled,
                BetaGoogleManagedStorageEnabledParams _ =>
                    BetaGoogleManagedStorageControlParamsType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedStorageControlParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedStorageControlParams(
        BetaGoogleManagedStorageDisabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageControlParams(
        BetaGoogleManagedStorageEnabledParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageControlParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageDisabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageDisabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaGoogleManagedStorageDisabledParams? value
    )
    {
        value = this.Value as BetaGoogleManagedStorageDisabledParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageEnabledParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageEnabledParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaGoogleManagedStorageEnabledParams? value)
    {
        value = this.Value as BetaGoogleManagedStorageEnabledParams;
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
    ///     (BetaGoogleManagedStorageDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedStorageEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedStorageDisabledParams> disabled,
        Action<BetaGoogleManagedStorageEnabledParams> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedStorageDisabledParams value:
                disabled(value);
                break;
            case BetaGoogleManagedStorageEnabledParams value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedStorageControlParams"
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
    ///     (BetaGoogleManagedStorageDisabledParams value) =&gt; {...},
    ///     (BetaGoogleManagedStorageEnabledParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedStorageDisabledParams, T> disabled,
        Func<BetaGoogleManagedStorageEnabledParams, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedStorageDisabledParams value => disabled(value),
            BetaGoogleManagedStorageEnabledParams value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedStorageControlParams"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedStorageControlParams(
        BetaGoogleManagedStorageDisabledParams value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageControlParams(
        BetaGoogleManagedStorageEnabledParams value
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
                "Data did not match any variant of BetaGoogleManagedStorageControlParams"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedStorageControlParams? other) =>
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
            BetaGoogleManagedStorageDisabledParams _ => 0,
            BetaGoogleManagedStorageEnabledParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedStorageControlParamsConverter
    : JsonConverter<BetaGoogleManagedStorageControlParams>
{
    public override BetaGoogleManagedStorageControlParams? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageDisabledParams>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageEnabledParams>(
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
                return new BetaGoogleManagedStorageControlParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageControlParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedStorageControlParamsTypeConverter))]
public enum BetaGoogleManagedStorageControlParamsType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedStorageControlParamsTypeConverter
    : JsonConverter<BetaGoogleManagedStorageControlParamsType>
{
    public override BetaGoogleManagedStorageControlParamsType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedStorageControlParamsType.Disabled,
            "enabled" => BetaGoogleManagedStorageControlParamsType.Enabled,
            _ => (BetaGoogleManagedStorageControlParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageControlParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedStorageControlParamsType.Disabled => "disabled",
                BetaGoogleManagedStorageControlParamsType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
