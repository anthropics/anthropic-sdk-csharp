using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Why the destination is disabled: `caller` when a caller disabled it, or the reason
/// the API disabled it automatically (`sustained_failure`, `invalid_address`, or
/// `redirect`). Every automatic disable is reversible with an update that sets `state`
/// to `enabled`. An update that sets `disabled` on a destination that is already
/// disabled keeps its reason.
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationDisabledReasonConverter))]
public record class BetaTelemetryDestinationDisabledReason : ModelBase
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

    public ApiEnum<string, BetaTelemetryDestinationDisabledReasonType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaTelemetryDestinationDisabledReasonCaller _ =>
                    BetaTelemetryDestinationDisabledReasonType.Caller,
                BetaTelemetryDestinationDisabledReasonSustainedFailure _ =>
                    BetaTelemetryDestinationDisabledReasonType.SustainedFailure,
                BetaTelemetryDestinationDisabledReasonInvalidAddress _ =>
                    BetaTelemetryDestinationDisabledReasonType.InvalidAddress,
                BetaTelemetryDestinationDisabledReasonRedirect _ =>
                    BetaTelemetryDestinationDisabledReasonType.Redirect,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaTelemetryDestinationDisabledReasonType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonCaller value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonSustainedFailure value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonInvalidAddress value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonRedirect value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationDisabledReason(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationDisabledReasonCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCaller(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationDisabledReasonCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCaller(
        [NotNullWhen(true)] out BetaTelemetryDestinationDisabledReasonCaller? value
    )
    {
        value = this.Value as BetaTelemetryDestinationDisabledReasonCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationDisabledReasonSustainedFailure"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSustainedFailure(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationDisabledReasonSustainedFailure`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSustainedFailure(
        [NotNullWhen(true)] out BetaTelemetryDestinationDisabledReasonSustainedFailure? value
    )
    {
        value = this.Value as BetaTelemetryDestinationDisabledReasonSustainedFailure;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationDisabledReasonInvalidAddress"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInvalidAddress(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationDisabledReasonInvalidAddress`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInvalidAddress(
        [NotNullWhen(true)] out BetaTelemetryDestinationDisabledReasonInvalidAddress? value
    )
    {
        value = this.Value as BetaTelemetryDestinationDisabledReasonInvalidAddress;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationDisabledReasonRedirect"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRedirect(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationDisabledReasonRedirect`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRedirect(
        [NotNullWhen(true)] out BetaTelemetryDestinationDisabledReasonRedirect? value
    )
    {
        value = this.Value as BetaTelemetryDestinationDisabledReasonRedirect;
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
    ///     (BetaTelemetryDestinationDisabledReasonCaller value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonSustainedFailure value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonInvalidAddress value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonRedirect value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaTelemetryDestinationDisabledReasonCaller> caller,
        Action<BetaTelemetryDestinationDisabledReasonSustainedFailure> sustainedFailure,
        Action<BetaTelemetryDestinationDisabledReasonInvalidAddress> invalidAddress,
        Action<BetaTelemetryDestinationDisabledReasonRedirect> redirect
    )
    {
        switch (this.Value)
        {
            case BetaTelemetryDestinationDisabledReasonCaller value:
                caller(value);
                break;
            case BetaTelemetryDestinationDisabledReasonSustainedFailure value:
                sustainedFailure(value);
                break;
            case BetaTelemetryDestinationDisabledReasonInvalidAddress value:
                invalidAddress(value);
                break;
            case BetaTelemetryDestinationDisabledReasonRedirect value:
                redirect(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTelemetryDestinationDisabledReason"
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
    ///     (BetaTelemetryDestinationDisabledReasonCaller value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonSustainedFailure value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonInvalidAddress value) =&gt; {...},
    ///     (BetaTelemetryDestinationDisabledReasonRedirect value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaTelemetryDestinationDisabledReasonCaller, T> caller,
        Func<BetaTelemetryDestinationDisabledReasonSustainedFailure, T> sustainedFailure,
        Func<BetaTelemetryDestinationDisabledReasonInvalidAddress, T> invalidAddress,
        Func<BetaTelemetryDestinationDisabledReasonRedirect, T> redirect
    )
    {
        return this.Value switch
        {
            BetaTelemetryDestinationDisabledReasonCaller value => caller(value),
            BetaTelemetryDestinationDisabledReasonSustainedFailure value => sustainedFailure(value),
            BetaTelemetryDestinationDisabledReasonInvalidAddress value => invalidAddress(value),
            BetaTelemetryDestinationDisabledReasonRedirect value => redirect(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTelemetryDestinationDisabledReason"
            ),
        };
    }

    public static implicit operator BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonCaller value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonSustainedFailure value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonInvalidAddress value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationDisabledReason(
        BetaTelemetryDestinationDisabledReasonRedirect value
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
                "Data did not match any variant of BetaTelemetryDestinationDisabledReason"
            );
        }
        this.Switch(
            (caller) => caller.Validate(),
            (sustainedFailure) => sustainedFailure.Validate(),
            (invalidAddress) => invalidAddress.Validate(),
            (redirect) => redirect.Validate()
        );
    }

    public virtual bool Equals(BetaTelemetryDestinationDisabledReason? other) =>
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
            BetaTelemetryDestinationDisabledReasonCaller _ => 0,
            BetaTelemetryDestinationDisabledReasonSustainedFailure _ => 1,
            BetaTelemetryDestinationDisabledReasonInvalidAddress _ => 2,
            BetaTelemetryDestinationDisabledReasonRedirect _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaTelemetryDestinationDisabledReasonConverter
    : JsonConverter<BetaTelemetryDestinationDisabledReason>
{
    public override BetaTelemetryDestinationDisabledReason? Read(
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
            case "caller":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReasonCaller>(
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
            case "sustained_failure":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReasonSustainedFailure>(
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
            case "invalid_address":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReasonInvalidAddress>(
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
            case "redirect":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationDisabledReasonRedirect>(
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
                return new BetaTelemetryDestinationDisabledReason(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationDisabledReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaTelemetryDestinationDisabledReasonTypeConverter))]
public enum BetaTelemetryDestinationDisabledReasonType
{
    Caller,
    SustainedFailure,
    InvalidAddress,
    Redirect,
}

sealed class BetaTelemetryDestinationDisabledReasonTypeConverter
    : JsonConverter<BetaTelemetryDestinationDisabledReasonType>
{
    public override BetaTelemetryDestinationDisabledReasonType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "caller" => BetaTelemetryDestinationDisabledReasonType.Caller,
            "sustained_failure" => BetaTelemetryDestinationDisabledReasonType.SustainedFailure,
            "invalid_address" => BetaTelemetryDestinationDisabledReasonType.InvalidAddress,
            "redirect" => BetaTelemetryDestinationDisabledReasonType.Redirect,
            _ => (BetaTelemetryDestinationDisabledReasonType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationDisabledReasonType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTelemetryDestinationDisabledReasonType.Caller => "caller",
                BetaTelemetryDestinationDisabledReasonType.SustainedFailure => "sustained_failure",
                BetaTelemetryDestinationDisabledReasonType.InvalidAddress => "invalid_address",
                BetaTelemetryDestinationDisabledReasonType.Redirect => "redirect",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
