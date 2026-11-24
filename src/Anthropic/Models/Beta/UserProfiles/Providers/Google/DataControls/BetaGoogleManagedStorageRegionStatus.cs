using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// One region's status for the `storage` control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedStorageRegionStatusConverter))]
public record class BetaGoogleManagedStorageRegionStatus : ModelBase
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

    public BetaGoogleManagedBucketReference? EffectiveBucket
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageRegionNotConfigured x => x.EffectiveBucket,
                BetaGoogleManagedStorageRegionPending x => x.EffectiveBucket,
                BetaGoogleManagedStorageRegionActive x => x.EffectiveBucket,
                BetaGoogleManagedStorageRegionFailed x => x.EffectiveBucket,
                BetaGoogleManagedStorageRegionSuspended x => x.EffectiveBucket,
                _ =>
                    WrappedJsonSerializer.GetNullableClassProperty<BetaGoogleManagedBucketReference>(
                        this.Json,
                        "effective_bucket"
                    ),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedStorageRegionStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageRegionNotConfigured _ =>
                    BetaGoogleManagedStorageRegionStatusType.NotConfigured,
                BetaGoogleManagedStorageRegionPending _ =>
                    BetaGoogleManagedStorageRegionStatusType.Pending,
                BetaGoogleManagedStorageRegionActive _ =>
                    BetaGoogleManagedStorageRegionStatusType.Active,
                BetaGoogleManagedStorageRegionFailed _ =>
                    BetaGoogleManagedStorageRegionStatusType.Failed,
                BetaGoogleManagedStorageRegionSuspended _ =>
                    BetaGoogleManagedStorageRegionStatusType.Suspended,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedStorageRegionStatusType>
                >(this.Json, "type"),
            };
        }
    }

    public IReadOnlyList<BetaGoogleManagedStorageFailedCheck>? FailedChecks
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedStorageRegionNotConfigured _ => null,
                BetaGoogleManagedStorageRegionPending x => x.FailedChecks,
                BetaGoogleManagedStorageRegionActive x => x.FailedChecks,
                BetaGoogleManagedStorageRegionFailed x => x.FailedChecks,
                BetaGoogleManagedStorageRegionSuspended _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<
                    IReadOnlyList<BetaGoogleManagedStorageFailedCheck>
                >(this.Json, "failed_checks"),
            };
        }
    }

    public BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionNotConfigured value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionActive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionSuspended value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedStorageRegionStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageRegionNotConfigured"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotConfigured(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageRegionNotConfigured`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotConfigured(
        [NotNullWhen(true)] out BetaGoogleManagedStorageRegionNotConfigured? value
    )
    {
        value = this.Value as BetaGoogleManagedStorageRegionNotConfigured;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageRegionPending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPending(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageRegionPending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPending([NotNullWhen(true)] out BetaGoogleManagedStorageRegionPending? value)
    {
        value = this.Value as BetaGoogleManagedStorageRegionPending;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageRegionActive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActive(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageRegionActive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActive([NotNullWhen(true)] out BetaGoogleManagedStorageRegionActive? value)
    {
        value = this.Value as BetaGoogleManagedStorageRegionActive;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageRegionFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailed(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageRegionFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailed([NotNullWhen(true)] out BetaGoogleManagedStorageRegionFailed? value)
    {
        value = this.Value as BetaGoogleManagedStorageRegionFailed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedStorageRegionSuspended"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuspended(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedStorageRegionSuspended`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuspended(
        [NotNullWhen(true)] out BetaGoogleManagedStorageRegionSuspended? value
    )
    {
        value = this.Value as BetaGoogleManagedStorageRegionSuspended;
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
    ///     (BetaGoogleManagedStorageRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedStorageRegionNotConfigured> notConfigured,
        Action<BetaGoogleManagedStorageRegionPending> pending,
        Action<BetaGoogleManagedStorageRegionActive> active,
        Action<BetaGoogleManagedStorageRegionFailed> failed,
        Action<BetaGoogleManagedStorageRegionSuspended> suspended
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedStorageRegionNotConfigured value:
                notConfigured(value);
                break;
            case BetaGoogleManagedStorageRegionPending value:
                pending(value);
                break;
            case BetaGoogleManagedStorageRegionActive value:
                active(value);
                break;
            case BetaGoogleManagedStorageRegionFailed value:
                failed(value);
                break;
            case BetaGoogleManagedStorageRegionSuspended value:
                suspended(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedStorageRegionStatus"
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
    ///     (BetaGoogleManagedStorageRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedStorageRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedStorageRegionNotConfigured, T> notConfigured,
        Func<BetaGoogleManagedStorageRegionPending, T> pending,
        Func<BetaGoogleManagedStorageRegionActive, T> active,
        Func<BetaGoogleManagedStorageRegionFailed, T> failed,
        Func<BetaGoogleManagedStorageRegionSuspended, T> suspended
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedStorageRegionNotConfigured value => notConfigured(value),
            BetaGoogleManagedStorageRegionPending value => pending(value),
            BetaGoogleManagedStorageRegionActive value => active(value),
            BetaGoogleManagedStorageRegionFailed value => failed(value),
            BetaGoogleManagedStorageRegionSuspended value => suspended(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedStorageRegionStatus"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionNotConfigured value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionPending value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionActive value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionFailed value
    ) => new(value);

    public static implicit operator BetaGoogleManagedStorageRegionStatus(
        BetaGoogleManagedStorageRegionSuspended value
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
                "Data did not match any variant of BetaGoogleManagedStorageRegionStatus"
            );
        }
        this.Switch(
            (notConfigured) => notConfigured.Validate(),
            (pending) => pending.Validate(),
            (active) => active.Validate(),
            (failed) => failed.Validate(),
            (suspended) => suspended.Validate()
        );
    }

    public virtual bool Equals(BetaGoogleManagedStorageRegionStatus? other) =>
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
            BetaGoogleManagedStorageRegionNotConfigured _ => 0,
            BetaGoogleManagedStorageRegionPending _ => 1,
            BetaGoogleManagedStorageRegionActive _ => 2,
            BetaGoogleManagedStorageRegionFailed _ => 3,
            BetaGoogleManagedStorageRegionSuspended _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedStorageRegionStatusConverter
    : JsonConverter<BetaGoogleManagedStorageRegionStatus>
{
    public override BetaGoogleManagedStorageRegionStatus? Read(
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
            case "not_configured":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionNotConfigured>(
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
            case "pending":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionPending>(
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
            case "active":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionActive>(
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
            case "failed":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionFailed>(
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
            case "suspended":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaGoogleManagedStorageRegionSuspended>(
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
                return new BetaGoogleManagedStorageRegionStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageRegionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedStorageRegionStatusTypeConverter))]
public enum BetaGoogleManagedStorageRegionStatusType
{
    NotConfigured = 1232640842,
    Pending = 156685866,
    Active = 1837619551,
    Failed = 434644459,
    Suspended = 598628903,
}

sealed class BetaGoogleManagedStorageRegionStatusTypeConverter
    : JsonConverter<BetaGoogleManagedStorageRegionStatusType>
{
    public override BetaGoogleManagedStorageRegionStatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_configured" => BetaGoogleManagedStorageRegionStatusType.NotConfigured,
            "pending" => BetaGoogleManagedStorageRegionStatusType.Pending,
            "active" => BetaGoogleManagedStorageRegionStatusType.Active,
            "failed" => BetaGoogleManagedStorageRegionStatusType.Failed,
            "suspended" => BetaGoogleManagedStorageRegionStatusType.Suspended,
            _ => (BetaGoogleManagedStorageRegionStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedStorageRegionStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedStorageRegionStatusType.NotConfigured => "not_configured",
                BetaGoogleManagedStorageRegionStatusType.Pending => "pending",
                BetaGoogleManagedStorageRegionStatusType.Active => "active",
                BetaGoogleManagedStorageRegionStatusType.Failed => "failed",
                BetaGoogleManagedStorageRegionStatusType.Suspended => "suspended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
