using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

/// <summary>
/// The customer-owned storage control: your Cloud Storage bucket that is set for
/// each region. It covers the project's requests that name no user profile, or a
/// user profile that has no bucket of its own for the project.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedProjectStorageControlConverter))]
public record class BetaGoogleManagedProjectStorageControl : ModelBase
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

    public IReadOnlyList<BetaGoogleManagedProjectRetiredBucket> RetiredBuckets
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageDisabled x => x.RetiredBuckets,
                BetaGoogleManagedProjectStorageEnabled x => x.RetiredBuckets,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    IReadOnlyList<BetaGoogleManagedProjectRetiredBucket>
                >(this.Json, "retired_buckets"),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedProjectStorageControlType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageDisabled _ =>
                    BetaGoogleManagedProjectStorageControlType.Disabled,
                BetaGoogleManagedProjectStorageEnabled _ =>
                    BetaGoogleManagedProjectStorageControlType.Enabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectStorageControlType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaGoogleManagedProjectStorageControl(
        BetaGoogleManagedProjectStorageDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageControl(
        BetaGoogleManagedProjectStorageEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageControl(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageDisabled? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageDisabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageEnabled? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageEnabled;
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
    ///     (BetaGoogleManagedProjectStorageDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectStorageDisabled> disabled,
        Action<BetaGoogleManagedProjectStorageEnabled> enabled
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectStorageDisabled value:
                disabled(value);
                break;
            case BetaGoogleManagedProjectStorageEnabled value:
                enabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectStorageControl"
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
    ///     (BetaGoogleManagedProjectStorageDisabled value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageEnabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectStorageDisabled, T> disabled,
        Func<BetaGoogleManagedProjectStorageEnabled, T> enabled
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectStorageDisabled value => disabled(value),
            BetaGoogleManagedProjectStorageEnabled value => enabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectStorageControl"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectStorageControl(
        BetaGoogleManagedProjectStorageDisabled value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageControl(
        BetaGoogleManagedProjectStorageEnabled value
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
                "Data did not match any variant of BetaGoogleManagedProjectStorageControl"
            );
        }
        this.Switch((disabled) => disabled.Validate(), (enabled) => enabled.Validate());
    }

    public virtual bool Equals(BetaGoogleManagedProjectStorageControl? other) =>
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
            BetaGoogleManagedProjectStorageDisabled _ => 0,
            BetaGoogleManagedProjectStorageEnabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectStorageControlConverter
    : JsonConverter<BetaGoogleManagedProjectStorageControl>
{
    public override BetaGoogleManagedProjectStorageControl? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageDisabled>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageEnabled>(
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
                return new BetaGoogleManagedProjectStorageControl(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageControl value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectStorageControlTypeConverter))]
public enum BetaGoogleManagedProjectStorageControlType
{
    Disabled = 2068438255,
    Enabled = 924343854,
}

sealed class BetaGoogleManagedProjectStorageControlTypeConverter
    : JsonConverter<BetaGoogleManagedProjectStorageControlType>
{
    public override BetaGoogleManagedProjectStorageControlType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled" => BetaGoogleManagedProjectStorageControlType.Disabled,
            "enabled" => BetaGoogleManagedProjectStorageControlType.Enabled,
            _ => (BetaGoogleManagedProjectStorageControlType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageControlType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectStorageControlType.Disabled => "disabled",
                BetaGoogleManagedProjectStorageControlType.Enabled => "enabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
