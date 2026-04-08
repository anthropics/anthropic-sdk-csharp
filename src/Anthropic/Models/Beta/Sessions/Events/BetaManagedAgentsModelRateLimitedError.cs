using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The model request was rate-limited.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsModelRateLimitedError,
        BetaManagedAgentsModelRateLimitedErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsModelRateLimitedError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    /// <summary>
    /// What the client should do next in response to this error.
    /// </summary>
    public required BetaManagedAgentsModelRateLimitedErrorRetryStatus RetryStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsModelRateLimitedErrorRetryStatus>(
                "retry_status"
            );
        }
        init { this._rawData.Set("retry_status", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsModelRateLimitedErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsModelRateLimitedErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.RetryStatus.Validate();
        this.Type.Validate();
    }

    public BetaManagedAgentsModelRateLimitedError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsModelRateLimitedError(
        BetaManagedAgentsModelRateLimitedError betaManagedAgentsModelRateLimitedError
    )
        : base(betaManagedAgentsModelRateLimitedError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsModelRateLimitedError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsModelRateLimitedError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsModelRateLimitedErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsModelRateLimitedError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsModelRateLimitedErrorFromRaw
    : IFromRawJson<BetaManagedAgentsModelRateLimitedError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsModelRateLimitedError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsModelRateLimitedError.FromRawUnchecked(rawData);
}

/// <summary>
/// What the client should do next in response to this error.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsModelRateLimitedErrorRetryStatusConverter))]
public record class BetaManagedAgentsModelRateLimitedErrorRetryStatus : ModelBase
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

    public BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusRetrying value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusExhausted value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusTerminal value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsModelRateLimitedErrorRetryStatus(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsRetryStatusRetrying"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsRetryStatusRetrying(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsRetryStatusRetrying`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsRetryStatusRetrying(
        [NotNullWhen(true)] out BetaManagedAgentsRetryStatusRetrying? value
    )
    {
        value = this.Value as BetaManagedAgentsRetryStatusRetrying;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsRetryStatusExhausted"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsRetryStatusExhausted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsRetryStatusExhausted`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsRetryStatusExhausted(
        [NotNullWhen(true)] out BetaManagedAgentsRetryStatusExhausted? value
    )
    {
        value = this.Value as BetaManagedAgentsRetryStatusExhausted;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsRetryStatusTerminal"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsRetryStatusTerminal(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsRetryStatusTerminal`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsRetryStatusTerminal(
        [NotNullWhen(true)] out BetaManagedAgentsRetryStatusTerminal? value
    )
    {
        value = this.Value as BetaManagedAgentsRetryStatusTerminal;
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
    ///     (BetaManagedAgentsRetryStatusRetrying value) =&gt; {...},
    ///     (BetaManagedAgentsRetryStatusExhausted value) =&gt; {...},
    ///     (BetaManagedAgentsRetryStatusTerminal value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsRetryStatusRetrying> betaManagedAgentsRetryStatusRetrying,
        System::Action<BetaManagedAgentsRetryStatusExhausted> betaManagedAgentsRetryStatusExhausted,
        System::Action<BetaManagedAgentsRetryStatusTerminal> betaManagedAgentsRetryStatusTerminal
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsRetryStatusRetrying value:
                betaManagedAgentsRetryStatusRetrying(value);
                break;
            case BetaManagedAgentsRetryStatusExhausted value:
                betaManagedAgentsRetryStatusExhausted(value);
                break;
            case BetaManagedAgentsRetryStatusTerminal value:
                betaManagedAgentsRetryStatusTerminal(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsModelRateLimitedErrorRetryStatus"
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
    ///     (BetaManagedAgentsRetryStatusRetrying value) =&gt; {...},
    ///     (BetaManagedAgentsRetryStatusExhausted value) =&gt; {...},
    ///     (BetaManagedAgentsRetryStatusTerminal value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsRetryStatusRetrying, T> betaManagedAgentsRetryStatusRetrying,
        System::Func<
            BetaManagedAgentsRetryStatusExhausted,
            T
        > betaManagedAgentsRetryStatusExhausted,
        System::Func<BetaManagedAgentsRetryStatusTerminal, T> betaManagedAgentsRetryStatusTerminal
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsRetryStatusRetrying value => betaManagedAgentsRetryStatusRetrying(
                value
            ),
            BetaManagedAgentsRetryStatusExhausted value => betaManagedAgentsRetryStatusExhausted(
                value
            ),
            BetaManagedAgentsRetryStatusTerminal value => betaManagedAgentsRetryStatusTerminal(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsModelRateLimitedErrorRetryStatus"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusRetrying value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusExhausted value
    ) => new(value);

    public static implicit operator BetaManagedAgentsModelRateLimitedErrorRetryStatus(
        BetaManagedAgentsRetryStatusTerminal value
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
                "Data did not match any variant of BetaManagedAgentsModelRateLimitedErrorRetryStatus"
            );
        }
        this.Switch(
            (betaManagedAgentsRetryStatusRetrying) =>
                betaManagedAgentsRetryStatusRetrying.Validate(),
            (betaManagedAgentsRetryStatusExhausted) =>
                betaManagedAgentsRetryStatusExhausted.Validate(),
            (betaManagedAgentsRetryStatusTerminal) =>
                betaManagedAgentsRetryStatusTerminal.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsModelRateLimitedErrorRetryStatus? other) =>
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
            BetaManagedAgentsRetryStatusRetrying _ => 0,
            BetaManagedAgentsRetryStatusExhausted _ => 1,
            BetaManagedAgentsRetryStatusTerminal _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsModelRateLimitedErrorRetryStatusConverter
    : JsonConverter<BetaManagedAgentsModelRateLimitedErrorRetryStatus>
{
    public override BetaManagedAgentsModelRateLimitedErrorRetryStatus? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "retrying":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusRetrying>(
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
            case "exhausted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusExhausted>(
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
            case "terminal":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsRetryStatusTerminal>(
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
                return new BetaManagedAgentsModelRateLimitedErrorRetryStatus(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsModelRateLimitedErrorRetryStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsModelRateLimitedErrorTypeConverter))]
public enum BetaManagedAgentsModelRateLimitedErrorType
{
    ModelRateLimitedError,
}

sealed class BetaManagedAgentsModelRateLimitedErrorTypeConverter
    : JsonConverter<BetaManagedAgentsModelRateLimitedErrorType>
{
    public override BetaManagedAgentsModelRateLimitedErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "model_rate_limited_error" =>
                BetaManagedAgentsModelRateLimitedErrorType.ModelRateLimitedError,
            _ => (BetaManagedAgentsModelRateLimitedErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsModelRateLimitedErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsModelRateLimitedErrorType.ModelRateLimitedError =>
                    "model_rate_limited_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
