using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

/// <summary>
/// One region's status for the `cmek` control, discriminated by `type`.
/// </summary>
[JsonConverter(typeof(BetaGoogleManagedCmekRegionStatusConverter))]
public record class BetaGoogleManagedCmekRegionStatus : ModelBase
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

    public string? EffectiveExternalKeyID
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekRegionNotConfigured x => x.EffectiveExternalKeyID,
                BetaGoogleManagedCmekRegionPending x => x.EffectiveExternalKeyID,
                BetaGoogleManagedCmekRegionActive x => x.EffectiveExternalKeyID,
                BetaGoogleManagedCmekRegionFailed x => x.EffectiveExternalKeyID,
                BetaGoogleManagedCmekRegionSuspended x => x.EffectiveExternalKeyID,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "effective_external_key_id"
                ),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedCmekRegionStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekRegionNotConfigured _ =>
                    BetaGoogleManagedCmekRegionStatusType.NotConfigured,
                BetaGoogleManagedCmekRegionPending _ =>
                    BetaGoogleManagedCmekRegionStatusType.Pending,
                BetaGoogleManagedCmekRegionActive _ => BetaGoogleManagedCmekRegionStatusType.Active,
                BetaGoogleManagedCmekRegionFailed _ => BetaGoogleManagedCmekRegionStatusType.Failed,
                BetaGoogleManagedCmekRegionSuspended _ =>
                    BetaGoogleManagedCmekRegionStatusType.Suspended,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedCmekRegionStatusType>
                >(this.Json, "type"),
            };
        }
    }

    public string? Error
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedCmekRegionNotConfigured _ => null,
                BetaGoogleManagedCmekRegionPending x => x.Error,
                BetaGoogleManagedCmekRegionActive x => x.Error,
                BetaGoogleManagedCmekRegionFailed x => x.Error,
                BetaGoogleManagedCmekRegionSuspended _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "error"),
            };
        }
    }

    public BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionNotConfigured value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionActive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionSuspended value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedCmekRegionStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekRegionNotConfigured"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotConfigured(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekRegionNotConfigured`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotConfigured(
        [NotNullWhen(true)] out BetaGoogleManagedCmekRegionNotConfigured? value
    )
    {
        value = this.Value as BetaGoogleManagedCmekRegionNotConfigured;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekRegionPending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPending(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekRegionPending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPending([NotNullWhen(true)] out BetaGoogleManagedCmekRegionPending? value)
    {
        value = this.Value as BetaGoogleManagedCmekRegionPending;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekRegionActive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActive(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekRegionActive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActive([NotNullWhen(true)] out BetaGoogleManagedCmekRegionActive? value)
    {
        value = this.Value as BetaGoogleManagedCmekRegionActive;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekRegionFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailed(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekRegionFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailed([NotNullWhen(true)] out BetaGoogleManagedCmekRegionFailed? value)
    {
        value = this.Value as BetaGoogleManagedCmekRegionFailed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedCmekRegionSuspended"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuspended(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedCmekRegionSuspended`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuspended(
        [NotNullWhen(true)] out BetaGoogleManagedCmekRegionSuspended? value
    )
    {
        value = this.Value as BetaGoogleManagedCmekRegionSuspended;
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
    ///     (BetaGoogleManagedCmekRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedCmekRegionNotConfigured> notConfigured,
        Action<BetaGoogleManagedCmekRegionPending> pending,
        Action<BetaGoogleManagedCmekRegionActive> active,
        Action<BetaGoogleManagedCmekRegionFailed> failed,
        Action<BetaGoogleManagedCmekRegionSuspended> suspended
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedCmekRegionNotConfigured value:
                notConfigured(value);
                break;
            case BetaGoogleManagedCmekRegionPending value:
                pending(value);
                break;
            case BetaGoogleManagedCmekRegionActive value:
                active(value);
                break;
            case BetaGoogleManagedCmekRegionFailed value:
                failed(value);
                break;
            case BetaGoogleManagedCmekRegionSuspended value:
                suspended(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedCmekRegionStatus"
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
    ///     (BetaGoogleManagedCmekRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedCmekRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedCmekRegionNotConfigured, T> notConfigured,
        Func<BetaGoogleManagedCmekRegionPending, T> pending,
        Func<BetaGoogleManagedCmekRegionActive, T> active,
        Func<BetaGoogleManagedCmekRegionFailed, T> failed,
        Func<BetaGoogleManagedCmekRegionSuspended, T> suspended
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedCmekRegionNotConfigured value => notConfigured(value),
            BetaGoogleManagedCmekRegionPending value => pending(value),
            BetaGoogleManagedCmekRegionActive value => active(value),
            BetaGoogleManagedCmekRegionFailed value => failed(value),
            BetaGoogleManagedCmekRegionSuspended value => suspended(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedCmekRegionStatus"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionNotConfigured value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionPending value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionActive value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionFailed value
    ) => new(value);

    public static implicit operator BetaGoogleManagedCmekRegionStatus(
        BetaGoogleManagedCmekRegionSuspended value
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
                "Data did not match any variant of BetaGoogleManagedCmekRegionStatus"
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

    public virtual bool Equals(BetaGoogleManagedCmekRegionStatus? other) =>
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
            BetaGoogleManagedCmekRegionNotConfigured _ => 0,
            BetaGoogleManagedCmekRegionPending _ => 1,
            BetaGoogleManagedCmekRegionActive _ => 2,
            BetaGoogleManagedCmekRegionFailed _ => 3,
            BetaGoogleManagedCmekRegionSuspended _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedCmekRegionStatusConverter
    : JsonConverter<BetaGoogleManagedCmekRegionStatus>
{
    public override BetaGoogleManagedCmekRegionStatus? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionNotConfigured>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionPending>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionActive>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionFailed>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedCmekRegionSuspended>(
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
                return new BetaGoogleManagedCmekRegionStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekRegionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedCmekRegionStatusTypeConverter))]
public enum BetaGoogleManagedCmekRegionStatusType
{
    NotConfigured = 1232640842,
    Pending = 156685866,
    Active = 1837619551,
    Failed = 434644459,
    Suspended = 598628903,
}

sealed class BetaGoogleManagedCmekRegionStatusTypeConverter
    : JsonConverter<BetaGoogleManagedCmekRegionStatusType>
{
    public override BetaGoogleManagedCmekRegionStatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_configured" => BetaGoogleManagedCmekRegionStatusType.NotConfigured,
            "pending" => BetaGoogleManagedCmekRegionStatusType.Pending,
            "active" => BetaGoogleManagedCmekRegionStatusType.Active,
            "failed" => BetaGoogleManagedCmekRegionStatusType.Failed,
            "suspended" => BetaGoogleManagedCmekRegionStatusType.Suspended,
            _ => (BetaGoogleManagedCmekRegionStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedCmekRegionStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedCmekRegionStatusType.NotConfigured => "not_configured",
                BetaGoogleManagedCmekRegionStatusType.Pending => "pending",
                BetaGoogleManagedCmekRegionStatusType.Active => "active",
                BetaGoogleManagedCmekRegionStatusType.Failed => "failed",
                BetaGoogleManagedCmekRegionStatusType.Suspended => "suspended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
