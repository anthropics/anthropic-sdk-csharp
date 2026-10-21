using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Whether a telemetry destination receives deliveries.
///
/// <para>A caller can set either state. The API also disables an enabled destination
/// on its own in some cases. The `reason` of the disabled state says whether a caller
/// or the API disabled the destination and, when the API did, why.</para>
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
/// to learn when the API disables a destination.</para>
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationStateConverter))]
public record class BetaTelemetryDestinationState : ModelBase
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

    public ApiEnum<string, BetaTelemetryDestinationStateType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaTelemetryDestinationStateEnabled _ => BetaTelemetryDestinationStateType.Enabled,
                BetaTelemetryDestinationStateDisabled _ =>
                    BetaTelemetryDestinationStateType.Disabled,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaTelemetryDestinationStateType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaTelemetryDestinationState(
        BetaTelemetryDestinationStateEnabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationState(
        BetaTelemetryDestinationStateDisabled value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationState(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationStateEnabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEnabled(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationStateEnabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEnabled([NotNullWhen(true)] out BetaTelemetryDestinationStateEnabled? value)
    {
        value = this.Value as BetaTelemetryDestinationStateEnabled;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationStateDisabled"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDisabled(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationStateDisabled`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDisabled(
        [NotNullWhen(true)] out BetaTelemetryDestinationStateDisabled? value
    )
    {
        value = this.Value as BetaTelemetryDestinationStateDisabled;
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
    ///     (BetaTelemetryDestinationStateEnabled value) =&gt; {...},
    ///     (BetaTelemetryDestinationStateDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaTelemetryDestinationStateEnabled> enabled,
        Action<BetaTelemetryDestinationStateDisabled> disabled
    )
    {
        switch (this.Value)
        {
            case BetaTelemetryDestinationStateEnabled value:
                enabled(value);
                break;
            case BetaTelemetryDestinationStateDisabled value:
                disabled(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTelemetryDestinationState"
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
    ///     (BetaTelemetryDestinationStateEnabled value) =&gt; {...},
    ///     (BetaTelemetryDestinationStateDisabled value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaTelemetryDestinationStateEnabled, T> enabled,
        Func<BetaTelemetryDestinationStateDisabled, T> disabled
    )
    {
        return this.Value switch
        {
            BetaTelemetryDestinationStateEnabled value => enabled(value),
            BetaTelemetryDestinationStateDisabled value => disabled(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTelemetryDestinationState"
            ),
        };
    }

    public static implicit operator BetaTelemetryDestinationState(
        BetaTelemetryDestinationStateEnabled value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationState(
        BetaTelemetryDestinationStateDisabled value
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
                "Data did not match any variant of BetaTelemetryDestinationState"
            );
        }
        this.Switch((enabled) => enabled.Validate(), (disabled) => disabled.Validate());
    }

    public virtual bool Equals(BetaTelemetryDestinationState? other) =>
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
            BetaTelemetryDestinationStateEnabled _ => 0,
            BetaTelemetryDestinationStateDisabled _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaTelemetryDestinationStateConverter : JsonConverter<BetaTelemetryDestinationState>
{
    public override BetaTelemetryDestinationState? Read(
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
            case "enabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationStateEnabled>(
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
            case "disabled":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationStateDisabled>(
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
                return new BetaTelemetryDestinationState(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaTelemetryDestinationStateTypeConverter))]
public enum BetaTelemetryDestinationStateType
{
    Enabled,
    Disabled,
}

sealed class BetaTelemetryDestinationStateTypeConverter
    : JsonConverter<BetaTelemetryDestinationStateType>
{
    public override BetaTelemetryDestinationStateType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled" => BetaTelemetryDestinationStateType.Enabled,
            "disabled" => BetaTelemetryDestinationStateType.Disabled,
            _ => (BetaTelemetryDestinationStateType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationStateType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaTelemetryDestinationStateType.Enabled => "enabled",
                BetaTelemetryDestinationStateType.Disabled => "disabled",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
