using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The customer-managed encryption key control: the key in your Google Cloud KMS
/// that is set for each region. It covers the project's requests that name no user
/// profile, or a user profile that has no key of its own for the project.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedProjectCmekControlConverter))]
public record class BetaGoogleManagedProjectCmekControl : ModelBase
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

    public IReadOnlyList<BetaGoogleManagedProjectRetiredKey> RetiredKeys
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectCmekDisabled x => x.RetiredKeys,
                BetaGoogleManagedProjectCmekEnabled x => x.RetiredKeys,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    IReadOnlyList<BetaGoogleManagedProjectRetiredKey>
                >(this.Json, "retired_keys"),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedProjectCmekControlType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectCmekDisabled _ =>
                    BetaGoogleManagedProjectCmekControlType.Disabled,
                BetaGoogleManagedProjectCmekEnabled _ =>
                    BetaGoogleManagedProjectCmekControlType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectCmekControlType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedProjectCmekControl(
        BetaGoogleManagedProjectCmekDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekControl(
        BetaGoogleManagedProjectCmekEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekControl(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out BetaGoogleManagedProjectCmekDisabled? value)
    {
        value = this.Value as BetaGoogleManagedProjectCmekDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaGoogleManagedProjectCmekEnabled? value)
    {
        value = this.Value as BetaGoogleManagedProjectCmekEnabled;
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
    ///     (BetaGoogleManagedProjectCmekDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectCmekDisabled> disabled,
        Action<BetaGoogleManagedProjectCmekEnabled> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectCmekDisabled value:
                disabled(value);
                break;
            case BetaGoogleManagedProjectCmekEnabled value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectCmekControl"
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
    ///     (BetaGoogleManagedProjectCmekDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectCmekDisabled, T> disabled,
        Func<BetaGoogleManagedProjectCmekEnabled, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectCmekDisabled value => disabled(value),
            BetaGoogleManagedProjectCmekEnabled value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectCmekControl"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectCmekControl(
        BetaGoogleManagedProjectCmekDisabled value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekControl(
        BetaGoogleManagedProjectCmekEnabled value
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
                "Data did not match any variant of BetaGoogleManagedProjectCmekControl"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedProjectCmekControl? other) =>
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
            BetaGoogleManagedProjectCmekDisabled _ => 0,
            BetaGoogleManagedProjectCmekEnabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectCmekControlConverter
    : JsonConverter<BetaGoogleManagedProjectCmekControl>
{
    public override BetaGoogleManagedProjectCmekControl? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekDisabled>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekEnabled>(
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
                return new BetaGoogleManagedProjectCmekControl(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectCmekControlTypeConverter))]
public enum BetaGoogleManagedProjectCmekControlType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedProjectCmekControlTypeConverter
    : JsonConverter<BetaGoogleManagedProjectCmekControlType>
{
    public override BetaGoogleManagedProjectCmekControlType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedProjectCmekControlType.Disabled,
            "enabled" => BetaGoogleManagedProjectCmekControlType.Enabled,
            _ => (BetaGoogleManagedProjectCmekControlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekControlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectCmekControlType.Disabled => "disabled",
                BetaGoogleManagedProjectCmekControlType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
