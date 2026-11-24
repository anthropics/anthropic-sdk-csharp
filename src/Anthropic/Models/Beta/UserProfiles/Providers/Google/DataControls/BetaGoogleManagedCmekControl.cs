using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The customer-managed encryption key control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedCmekControlConverter))]
public record class BetaGoogleManagedCmekControl : ModelBase
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

    public IReadOnlyList<BetaGoogleManagedRetiredKey> RetiredKeys
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekDisabled x => x.RetiredKeys,
                BetaGoogleManagedCmekEnabled x => x.RetiredKeys,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    IReadOnlyList<BetaGoogleManagedRetiredKey>
                >(this.Json, "retired_keys"),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedCmekControlType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekDisabled _ => BetaGoogleManagedCmekControlType.Disabled,
                BetaGoogleManagedCmekEnabled _ => BetaGoogleManagedCmekControlType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedCmekControlType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedCmekControl(
        BetaGoogleManagedCmekDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekControl(
        BetaGoogleManagedCmekEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekControl(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out BetaGoogleManagedCmekDisabled? value)
    {
        value = this.Value as BetaGoogleManagedCmekDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaGoogleManagedCmekEnabled? value)
    {
        value = this.Value as BetaGoogleManagedCmekEnabled;
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
    ///     (BetaGoogleManagedCmekDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedCmekEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedCmekDisabled> disabled,
        Action<BetaGoogleManagedCmekEnabled> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedCmekDisabled value:
                disabled(value);
                break;
            case BetaGoogleManagedCmekEnabled value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedCmekControl"
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
    ///     (BetaGoogleManagedCmekDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedCmekEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedCmekDisabled, T> disabled,
        Func<BetaGoogleManagedCmekEnabled, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedCmekDisabled value => disabled(value),
            BetaGoogleManagedCmekEnabled value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedCmekControl"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedCmekControl(
        BetaGoogleManagedCmekDisabled value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekControl(
        BetaGoogleManagedCmekEnabled value
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
                "Data did not match any variant of BetaGoogleManagedCmekControl"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedCmekControl? other) =>
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
            BetaGoogleManagedCmekDisabled _ => 0,
            BetaGoogleManagedCmekEnabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedCmekControlConverter : JsonConverter<BetaGoogleManagedCmekControl>
{
    public override BetaGoogleManagedCmekControl? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekDisabled>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedCmekEnabled>(
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
                return new BetaGoogleManagedCmekControl(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedCmekControlTypeConverter))]
public enum BetaGoogleManagedCmekControlType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedCmekControlTypeConverter
    : JsonConverter<BetaGoogleManagedCmekControlType>
{
    public override BetaGoogleManagedCmekControlType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedCmekControlType.Disabled,
            "enabled" => BetaGoogleManagedCmekControlType.Enabled,
            _ => (BetaGoogleManagedCmekControlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekControlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedCmekControlType.Disabled => "disabled",
                BetaGoogleManagedCmekControlType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
