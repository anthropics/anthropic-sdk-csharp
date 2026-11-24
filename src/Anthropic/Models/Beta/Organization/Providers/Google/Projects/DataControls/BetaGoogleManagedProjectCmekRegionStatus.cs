using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;

[JsonConverter(typeof(BetaGoogleManagedProjectCmekRegionStatusConverter))]
public record class BetaGoogleManagedProjectCmekRegionStatus : ModelBase
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
                BetaGoogleManagedProjectCmekRegionNotConfigured x => x.EffectiveExternalKeyID,
                BetaGoogleManagedProjectCmekRegionPending x => x.EffectiveExternalKeyID,
                BetaGoogleManagedProjectCmekRegionActive x => x.EffectiveExternalKeyID,
                BetaGoogleManagedProjectCmekRegionFailed x => x.EffectiveExternalKeyID,
                BetaGoogleManagedProjectCmekRegionSuspended x => x.EffectiveExternalKeyID,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "effective_external_key_id"
                ),
            };
        }
    }

    public ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaGoogleManagedProjectCmekRegionNotConfigured _ =>
                    BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured,
                BetaGoogleManagedProjectCmekRegionPending _ =>
                    BetaGoogleManagedProjectCmekRegionStatusType.Pending,
                BetaGoogleManagedProjectCmekRegionActive _ =>
                    BetaGoogleManagedProjectCmekRegionStatusType.Active,
                BetaGoogleManagedProjectCmekRegionFailed _ =>
                    BetaGoogleManagedProjectCmekRegionStatusType.Failed,
                BetaGoogleManagedProjectCmekRegionSuspended _ =>
                    BetaGoogleManagedProjectCmekRegionStatusType.Suspended,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaGoogleManagedProjectCmekRegionStatusType>
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
                BetaGoogleManagedProjectCmekRegionNotConfigured _ => null,
                BetaGoogleManagedProjectCmekRegionPending x => x.Error,
                BetaGoogleManagedProjectCmekRegionActive x => x.Error,
                BetaGoogleManagedProjectCmekRegionFailed x => x.Error,
                BetaGoogleManagedProjectCmekRegionSuspended _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "error"),
            };
        }
    }

    public BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionNotConfigured value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionPending value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionActive value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionFailed value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionSuspended value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaGoogleManagedProjectCmekRegionStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekRegionNotConfigured"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotConfigured(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekRegionNotConfigured`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotConfigured(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekRegionNotConfigured? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekRegionNotConfigured;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekRegionPending"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPending(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekRegionPending`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPending(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekRegionPending? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekRegionPending;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekRegionActive"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickActive(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekRegionActive`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickActive(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekRegionActive? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekRegionActive;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekRegionFailed"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailed(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekRegionFailed`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailed(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekRegionFailed? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekRegionFailed;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGoogleManagedProjectCmekRegionSuspended"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuspended(out var value)) {
    ///     // `value` is of type `BetaGoogleManagedProjectCmekRegionSuspended`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuspended(
        [NotNullWhen(true)] out BetaGoogleManagedProjectCmekRegionSuspended? value
    )
    {
        value = this.Value as BetaGoogleManagedProjectCmekRegionSuspended;
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
    ///     (BetaGoogleManagedProjectCmekRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaGoogleManagedProjectCmekRegionNotConfigured> notConfigured,
        Action<BetaGoogleManagedProjectCmekRegionPending> pending,
        Action<BetaGoogleManagedProjectCmekRegionActive> active,
        Action<BetaGoogleManagedProjectCmekRegionFailed> failed,
        Action<BetaGoogleManagedProjectCmekRegionSuspended> suspended
    )
    {
        switch (this.Value)
        {
            case BetaGoogleManagedProjectCmekRegionNotConfigured value:
                notConfigured(value);
                break;
            case BetaGoogleManagedProjectCmekRegionPending value:
                pending(value);
                break;
            case BetaGoogleManagedProjectCmekRegionActive value:
                active(value);
                break;
            case BetaGoogleManagedProjectCmekRegionFailed value:
                failed(value);
                break;
            case BetaGoogleManagedProjectCmekRegionSuspended value:
                suspended(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaGoogleManagedProjectCmekRegionStatus"
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
    ///     (BetaGoogleManagedProjectCmekRegionNotConfigured value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionPending value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionActive value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionFailed value) =&gt; {...},
    ///     (BetaGoogleManagedProjectCmekRegionSuspended value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaGoogleManagedProjectCmekRegionNotConfigured, T> notConfigured,
        Func<BetaGoogleManagedProjectCmekRegionPending, T> pending,
        Func<BetaGoogleManagedProjectCmekRegionActive, T> active,
        Func<BetaGoogleManagedProjectCmekRegionFailed, T> failed,
        Func<BetaGoogleManagedProjectCmekRegionSuspended, T> suspended
    )
    {
        return this.Value switch
        {
            BetaGoogleManagedProjectCmekRegionNotConfigured value => notConfigured(value),
            BetaGoogleManagedProjectCmekRegionPending value => pending(value),
            BetaGoogleManagedProjectCmekRegionActive value => active(value),
            BetaGoogleManagedProjectCmekRegionFailed value => failed(value),
            BetaGoogleManagedProjectCmekRegionSuspended value => suspended(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaGoogleManagedProjectCmekRegionStatus"
            ),
        };
    }

    public static implicit operator BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionNotConfigured value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionPending value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionActive value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionFailed value
    ) => new(value);

    public static implicit operator BetaGoogleManagedProjectCmekRegionStatus(
        BetaGoogleManagedProjectCmekRegionSuspended value
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
                "Data did not match any variant of BetaGoogleManagedProjectCmekRegionStatus"
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

    public virtual bool Equals(BetaGoogleManagedProjectCmekRegionStatus? other) =>
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
            BetaGoogleManagedProjectCmekRegionNotConfigured _ => 0,
            BetaGoogleManagedProjectCmekRegionPending _ => 1,
            BetaGoogleManagedProjectCmekRegionActive _ => 2,
            BetaGoogleManagedProjectCmekRegionFailed _ => 3,
            BetaGoogleManagedProjectCmekRegionSuspended _ => 4,
            _ => -1,
        };
    }
}

sealed class BetaGoogleManagedProjectCmekRegionStatusConverter
    : JsonConverter<BetaGoogleManagedProjectCmekRegionStatus>
{
    public override BetaGoogleManagedProjectCmekRegionStatus? Read(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionNotConfigured>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionPending>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionActive>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionFailed>(
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
                        JsonSerializer.Deserialize<BetaGoogleManagedProjectCmekRegionSuspended>(
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
                return new BetaGoogleManagedProjectCmekRegionStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekRegionStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaGoogleManagedProjectCmekRegionStatusTypeConverter))]
public enum BetaGoogleManagedProjectCmekRegionStatusType
{
    NotConfigured = 1232640842,
    Pending = 156685866,
    Active = 1837619551,
    Failed = 434644459,
    Suspended = 598628903,
}

sealed class BetaGoogleManagedProjectCmekRegionStatusTypeConverter
    : JsonConverter<BetaGoogleManagedProjectCmekRegionStatusType>
{
    public override BetaGoogleManagedProjectCmekRegionStatusType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "not_configured" => BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured,
            "pending" => BetaGoogleManagedProjectCmekRegionStatusType.Pending,
            "active" => BetaGoogleManagedProjectCmekRegionStatusType.Active,
            "failed" => BetaGoogleManagedProjectCmekRegionStatusType.Failed,
            "suspended" => BetaGoogleManagedProjectCmekRegionStatusType.Suspended,
            _ => (BetaGoogleManagedProjectCmekRegionStatusType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaGoogleManagedProjectCmekRegionStatusType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaGoogleManagedProjectCmekRegionStatusType.NotConfigured => "not_configured",
                BetaGoogleManagedProjectCmekRegionStatusType.Pending => "pending",
                BetaGoogleManagedProjectCmekRegionStatusType.Active => "active",
                BetaGoogleManagedProjectCmekRegionStatusType.Failed => "failed",
                BetaGoogleManagedProjectCmekRegionStatusType.Suspended => "suspended",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
