using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

[JsonConverter(typeof(BetaGoogleManagedProjectStorageRegionStatusConverter))]
public record class BetaGoogleManagedProjectStorageRegionStatus : ModelBase
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

    public BetaGoogleManagedProjectEffectiveBucket? EffectiveBucket
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageRegionNotConfigured x => x.EffectiveBucket,
                BetaGoogleManagedProjectStorageRegionPending x => x.EffectiveBucket,
                BetaGoogleManagedProjectStorageRegionActive x => x.EffectiveBucket,
                BetaGoogleManagedProjectStorageRegionFailed x => x.EffectiveBucket,
                BetaGoogleManagedProjectStorageRegionSuspended x => x.EffectiveBucket,
                _ =>
                    WrappedJsonSerializer.GetNullableClassProperty<BetaGoogleManagedProjectEffectiveBucket>(
                        this.Json,
                        "effective_bucket"
                    ),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageRegionNotConfigured _ =>
                    BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured,
                BetaGoogleManagedProjectStorageRegionPending _ =>
                    BetaGoogleManagedProjectStorageRegionStatusType.Pending,
                BetaGoogleManagedProjectStorageRegionActive _ =>
                    BetaGoogleManagedProjectStorageRegionStatusType.Active,
                BetaGoogleManagedProjectStorageRegionFailed _ =>
                    BetaGoogleManagedProjectStorageRegionStatusType.Failed,
                BetaGoogleManagedProjectStorageRegionSuspended _ =>
                    BetaGoogleManagedProjectStorageRegionStatusType.Suspended,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectStorageRegionStatusType>
                >(this.Json, "type"),
            };
        }
    }

    public IReadOnlyList<BetaGoogleManagedProjectStorageFailedCheck>? FailedChecks
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectStorageRegionNotConfigured _ => null,
                BetaGoogleManagedProjectStorageRegionPending x => x.FailedChecks,
                BetaGoogleManagedProjectStorageRegionActive x => x.FailedChecks,
                BetaGoogleManagedProjectStorageRegionFailed x => x.FailedChecks,
                BetaGoogleManagedProjectStorageRegionSuspended _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<
                    IReadOnlyList<BetaGoogleManagedProjectStorageFailedCheck>
                >(this.Json, "failed_checks"),
            };
        }
    }

    public BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionNotConfigured value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionActive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionSuspended value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectStorageRegionStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageRegionNotConfigured"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotConfigured(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageRegionNotConfigured`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotConfigured(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageRegionNotConfigured? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageRegionNotConfigured;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageRegionPending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPending(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageRegionPending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPending(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageRegionPending? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageRegionPending;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageRegionActive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActive(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageRegionActive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActive(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageRegionActive? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageRegionActive;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageRegionFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailed(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageRegionFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailed(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageRegionFailed? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageRegionFailed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectStorageRegionSuspended"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuspended(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectStorageRegionSuspended`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuspended(
        [NotNullWhen(true)] out BetaGoogleManagedProjectStorageRegionSuspended? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectStorageRegionSuspended;
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
    ///     (BetaGoogleManagedProjectStorageRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectStorageRegionNotConfigured> notConfigured,
        Action<BetaGoogleManagedProjectStorageRegionPending> pending,
        Action<BetaGoogleManagedProjectStorageRegionActive> active,
        Action<BetaGoogleManagedProjectStorageRegionFailed> failed,
        Action<BetaGoogleManagedProjectStorageRegionSuspended> suspended
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectStorageRegionNotConfigured value:
                notConfigured(value);
                break;
            case BetaGoogleManagedProjectStorageRegionPending value:
                pending(value);
                break;
            case BetaGoogleManagedProjectStorageRegionActive value:
                active(value);
                break;
            case BetaGoogleManagedProjectStorageRegionFailed value:
                failed(value);
                break;
            case BetaGoogleManagedProjectStorageRegionSuspended value:
                suspended(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectStorageRegionStatus"
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
    ///     (BetaGoogleManagedProjectStorageRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedProjectStorageRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectStorageRegionNotConfigured, T> notConfigured,
        Func<BetaGoogleManagedProjectStorageRegionPending, T> pending,
        Func<BetaGoogleManagedProjectStorageRegionActive, T> active,
        Func<BetaGoogleManagedProjectStorageRegionFailed, T> failed,
        Func<BetaGoogleManagedProjectStorageRegionSuspended, T> suspended
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectStorageRegionNotConfigured value => notConfigured(value),
            BetaGoogleManagedProjectStorageRegionPending value => pending(value),
            BetaGoogleManagedProjectStorageRegionActive value => active(value),
            BetaGoogleManagedProjectStorageRegionFailed value => failed(value),
            BetaGoogleManagedProjectStorageRegionSuspended value => suspended(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectStorageRegionStatus"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionNotConfigured value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionPending value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionActive value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionFailed value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectStorageRegionStatus(
        BetaGoogleManagedProjectStorageRegionSuspended value
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
                "Data did not match any variant of BetaGoogleManagedProjectStorageRegionStatus"
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

    public virtual bool Equals(BetaGoogleManagedProjectStorageRegionStatus? other) =>
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
            BetaGoogleManagedProjectStorageRegionNotConfigured _ => 0,
            BetaGoogleManagedProjectStorageRegionPending _ => 1,
            BetaGoogleManagedProjectStorageRegionActive _ => 2,
            BetaGoogleManagedProjectStorageRegionFailed _ => 3,
            BetaGoogleManagedProjectStorageRegionSuspended _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectStorageRegionStatusConverter
    : JsonConverter<BetaGoogleManagedProjectStorageRegionStatus>
{
    public override BetaGoogleManagedProjectStorageRegionStatus? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionNotConfigured>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionPending>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionActive>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionFailed>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectStorageRegionSuspended>(
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
                return new BetaGoogleManagedProjectStorageRegionStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageRegionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectStorageRegionStatusTypeConverter))]
public enum BetaGoogleManagedProjectStorageRegionStatusType
{
    NotConfigured = 1232640842,
    Pending = 156685866,
    Active = 1837619551,
    Failed = 434644459,
    Suspended = 598628903,
}

sealed class BetaGoogleManagedProjectStorageRegionStatusTypeConverter
    : JsonConverter<BetaGoogleManagedProjectStorageRegionStatusType>
{
    public override BetaGoogleManagedProjectStorageRegionStatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_configured" => BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured,
            "pending" => BetaGoogleManagedProjectStorageRegionStatusType.Pending,
            "active" => BetaGoogleManagedProjectStorageRegionStatusType.Active,
            "failed" => BetaGoogleManagedProjectStorageRegionStatusType.Failed,
            "suspended" => BetaGoogleManagedProjectStorageRegionStatusType.Suspended,
            _ => (BetaGoogleManagedProjectStorageRegionStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectStorageRegionStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectStorageRegionStatusType.NotConfigured => "not_configured",
                BetaGoogleManagedProjectStorageRegionStatusType.Pending => "pending",
                BetaGoogleManagedProjectStorageRegionStatusType.Active => "active",
                BetaGoogleManagedProjectStorageRegionStatusType.Failed => "failed",
                BetaGoogleManagedProjectStorageRegionStatusType.Suspended => "suspended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
