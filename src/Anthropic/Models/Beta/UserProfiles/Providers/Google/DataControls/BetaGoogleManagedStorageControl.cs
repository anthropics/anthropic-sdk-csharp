using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// The customer-owned storage control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedStorageControlConverter))]
public record class BetaGoogleManagedStorageControl : ModelBase
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

    public IReadOnlyList<BetaGoogleManagedRetiredBucket> RetiredBuckets
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageDisabled x => x.RetiredBuckets,
                BetaGoogleManagedStorageEnabled x => x.RetiredBuckets,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    IReadOnlyList<BetaGoogleManagedRetiredBucket>
                >(this.Json, "retired_buckets"),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedStorageControlType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageDisabled _ => BetaGoogleManagedStorageControlType.Disabled,
                BetaGoogleManagedStorageEnabled _ => BetaGoogleManagedStorageControlType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedStorageControlType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedStorageControl(
        BetaGoogleManagedStorageDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageControl(
        BetaGoogleManagedStorageEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageControl(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled([NotNullWhen(true)] out BetaGoogleManagedStorageDisabled? value)
    {
        value = this.Value as BetaGoogleManagedStorageDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaGoogleManagedStorageEnabled? value)
    {
        value = this.Value as BetaGoogleManagedStorageEnabled;
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
    ///     (BetaGoogleManagedStorageDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedStorageEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedStorageDisabled> disabled,
        Action<BetaGoogleManagedStorageEnabled> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedStorageDisabled value:
                disabled(value);
                break;
            case BetaGoogleManagedStorageEnabled value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedStorageControl"
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
    ///     (BetaGoogleManagedStorageDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedStorageEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedStorageDisabled, T> disabled,
        Func<BetaGoogleManagedStorageEnabled, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedStorageDisabled value => disabled(value),
            BetaGoogleManagedStorageEnabled value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedStorageControl"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedStorageControl(
        BetaGoogleManagedStorageDisabled value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageControl(
        BetaGoogleManagedStorageEnabled value
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
                "Data did not match any variant of BetaGoogleManagedStorageControl"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedStorageControl? other) =>
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
            BetaGoogleManagedStorageDisabled _ => 0,
            BetaGoogleManagedStorageEnabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedStorageControlConverter
    : JsonConverter<BetaGoogleManagedStorageControl>
{
    public override BetaGoogleManagedStorageControl? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageDisabled>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaGoogleManagedStorageEnabled>(
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
                return new BetaGoogleManagedStorageControl(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedStorageControlTypeConverter))]
public enum BetaGoogleManagedStorageControlType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedStorageControlTypeConverter
    : JsonConverter<BetaGoogleManagedStorageControlType>
{
    public override BetaGoogleManagedStorageControlType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedStorageControlType.Disabled,
            "enabled" => BetaGoogleManagedStorageControlType.Enabled,
            _ => (BetaGoogleManagedStorageControlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageControlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedStorageControlType.Disabled => "disabled",
                BetaGoogleManagedStorageControlType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
