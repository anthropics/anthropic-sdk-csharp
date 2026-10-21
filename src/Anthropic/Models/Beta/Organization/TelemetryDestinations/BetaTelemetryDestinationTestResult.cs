using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The outcome of a test: `success`, or `failure` with the reason.
/// </summary>
[JsonConverter(typeof(BetaTelemetryDestinationTestResultConverter))]
public record class BetaTelemetryDestinationTestResult : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaTelemetryDestinationTestSuccess x => x.Type,
                BetaTelemetryDestinationTestFailure x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaTelemetryDestinationTestResult(
        BetaTelemetryDestinationTestSuccess value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationTestResult(
        BetaTelemetryDestinationTestFailure value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaTelemetryDestinationTestResult(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationTestSuccess"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSuccess(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationTestSuccess`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSuccess([NotNullWhen(true)] out BetaTelemetryDestinationTestSuccess? value)
    {
        value = this.Value as BetaTelemetryDestinationTestSuccess;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTelemetryDestinationTestFailure"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailure(out var value)) {
    ///     // `value` is of type `BetaTelemetryDestinationTestFailure`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailure([NotNullWhen(true)] out BetaTelemetryDestinationTestFailure? value)
    {
        value = this.Value as BetaTelemetryDestinationTestFailure;
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
    ///     (BetaTelemetryDestinationTestSuccess value) =&gt; {...},
    ///     (BetaTelemetryDestinationTestFailure value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaTelemetryDestinationTestSuccess> success,
        Action<BetaTelemetryDestinationTestFailure> failure
    )
    {
        switch (this.Value)
        {
            case BetaTelemetryDestinationTestSuccess value:
                success(value);
                break;
            case BetaTelemetryDestinationTestFailure value:
                failure(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTelemetryDestinationTestResult"
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
    ///     (BetaTelemetryDestinationTestSuccess value) =&gt; {...},
    ///     (BetaTelemetryDestinationTestFailure value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaTelemetryDestinationTestSuccess, T> success,
        Func<BetaTelemetryDestinationTestFailure, T> failure
    )
    {
        return this.Value switch
        {
            BetaTelemetryDestinationTestSuccess value => success(value),
            BetaTelemetryDestinationTestFailure value => failure(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTelemetryDestinationTestResult"
            ),
        };
    }

    public static implicit operator BetaTelemetryDestinationTestResult(
        BetaTelemetryDestinationTestSuccess value
    ) => new(value);

    public static implicit operator BetaTelemetryDestinationTestResult(
        BetaTelemetryDestinationTestFailure value
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
                "Data did not match any variant of BetaTelemetryDestinationTestResult"
            );
        }
        this.Switch((success) => success.Validate(), (failure) => failure.Validate());
    }

    public virtual bool Equals(BetaTelemetryDestinationTestResult? other) =>
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
            BetaTelemetryDestinationTestSuccess _ => 0,
            BetaTelemetryDestinationTestFailure _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaTelemetryDestinationTestResultConverter
    : JsonConverter<BetaTelemetryDestinationTestResult>
{
    public override BetaTelemetryDestinationTestResult? Read(
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
            case "success":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationTestSuccess>(
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
            case "failure":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTelemetryDestinationTestFailure>(
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
                return new BetaTelemetryDestinationTestResult(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTelemetryDestinationTestResult value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
