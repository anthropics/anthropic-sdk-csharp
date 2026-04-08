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
/// An error event indicating a problem occurred during session execution.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionErrorEvent,
        BetaManagedAgentsSessionErrorEventFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionErrorEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for this event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// An unknown or unexpected error occurred during session execution. A fallback
    /// variant; clients that don't recognize a new error code can match on `retry_status`
    /// and `message` alone.
    /// </summary>
    public required Error Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Error>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset ProcessedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("processed_at");
        }
        init { this._rawData.Set("processed_at", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsSessionErrorEventType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsSessionErrorEventType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Error.Validate();
        _ = this.ProcessedAt;
        this.Type.Validate();
    }

    public BetaManagedAgentsSessionErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionErrorEvent(
        BetaManagedAgentsSessionErrorEvent betaManagedAgentsSessionErrorEvent
    )
        : base(betaManagedAgentsSessionErrorEvent) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionErrorEventFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionErrorEventFromRaw : IFromRawJson<BetaManagedAgentsSessionErrorEvent>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionErrorEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// An unknown or unexpected error occurred during session execution. A fallback variant;
/// clients that don't recognize a new error code can match on `retry_status` and
/// `message` alone.
/// </summary>
[JsonConverter(typeof(ErrorConverter))]
public record class Error : ModelBase
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

    public string Message
    {
        get
        {
            return Match(
                betaManagedAgentsUnknown: (x) => x.Message,
                betaManagedAgentsModelOverloaded: (x) => x.Message,
                betaManagedAgentsModelRateLimited: (x) => x.Message,
                betaManagedAgentsModelRequestFailed: (x) => x.Message,
                betaManagedAgentsMcpConnectionFailed: (x) => x.Message,
                betaManagedAgentsMcpAuthenticationFailed: (x) => x.Message,
                betaManagedAgentsBilling: (x) => x.Message
            );
        }
    }

    public string? McpServerName
    {
        get
        {
            return Match<string?>(
                betaManagedAgentsUnknown: (_) => null,
                betaManagedAgentsModelOverloaded: (_) => null,
                betaManagedAgentsModelRateLimited: (_) => null,
                betaManagedAgentsModelRequestFailed: (_) => null,
                betaManagedAgentsMcpConnectionFailed: (x) => x.McpServerName,
                betaManagedAgentsMcpAuthenticationFailed: (x) => x.McpServerName,
                betaManagedAgentsBilling: (_) => null
            );
        }
    }

    public Error(BetaManagedAgentsUnknownError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsModelOverloadedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsModelRateLimitedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsModelRequestFailedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsMcpConnectionFailedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsMcpAuthenticationFailedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(BetaManagedAgentsBillingError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Error(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnknownError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUnknown(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnknownError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUnknown(
        [NotNullWhen(true)] out BetaManagedAgentsUnknownError? value
    )
    {
        value = this.Value as BetaManagedAgentsUnknownError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsModelOverloadedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsModelOverloaded(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsModelOverloadedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsModelOverloaded(
        [NotNullWhen(true)] out BetaManagedAgentsModelOverloadedError? value
    )
    {
        value = this.Value as BetaManagedAgentsModelOverloadedError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsModelRateLimitedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsModelRateLimited(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsModelRateLimitedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsModelRateLimited(
        [NotNullWhen(true)] out BetaManagedAgentsModelRateLimitedError? value
    )
    {
        value = this.Value as BetaManagedAgentsModelRateLimitedError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsModelRequestFailedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsModelRequestFailed(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsModelRequestFailedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsModelRequestFailed(
        [NotNullWhen(true)] out BetaManagedAgentsModelRequestFailedError? value
    )
    {
        value = this.Value as BetaManagedAgentsModelRequestFailedError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpConnectionFailedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpConnectionFailed(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpConnectionFailedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpConnectionFailed(
        [NotNullWhen(true)] out BetaManagedAgentsMcpConnectionFailedError? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpConnectionFailedError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpAuthenticationFailedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpAuthenticationFailed(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpAuthenticationFailedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpAuthenticationFailed(
        [NotNullWhen(true)] out BetaManagedAgentsMcpAuthenticationFailedError? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpAuthenticationFailedError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsBillingError"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsBilling(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsBillingError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsBilling(
        [NotNullWhen(true)] out BetaManagedAgentsBillingError? value
    )
    {
        value = this.Value as BetaManagedAgentsBillingError;
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
    ///     (BetaManagedAgentsUnknownError value) =&gt; {...},
    ///     (BetaManagedAgentsModelOverloadedError value) =&gt; {...},
    ///     (BetaManagedAgentsModelRateLimitedError value) =&gt; {...},
    ///     (BetaManagedAgentsModelRequestFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpConnectionFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpAuthenticationFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsBillingError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUnknownError> betaManagedAgentsUnknown,
        System::Action<BetaManagedAgentsModelOverloadedError> betaManagedAgentsModelOverloaded,
        System::Action<BetaManagedAgentsModelRateLimitedError> betaManagedAgentsModelRateLimited,
        System::Action<BetaManagedAgentsModelRequestFailedError> betaManagedAgentsModelRequestFailed,
        System::Action<BetaManagedAgentsMcpConnectionFailedError> betaManagedAgentsMcpConnectionFailed,
        System::Action<BetaManagedAgentsMcpAuthenticationFailedError> betaManagedAgentsMcpAuthenticationFailed,
        System::Action<BetaManagedAgentsBillingError> betaManagedAgentsBilling
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUnknownError value:
                betaManagedAgentsUnknown(value);
                break;
            case BetaManagedAgentsModelOverloadedError value:
                betaManagedAgentsModelOverloaded(value);
                break;
            case BetaManagedAgentsModelRateLimitedError value:
                betaManagedAgentsModelRateLimited(value);
                break;
            case BetaManagedAgentsModelRequestFailedError value:
                betaManagedAgentsModelRequestFailed(value);
                break;
            case BetaManagedAgentsMcpConnectionFailedError value:
                betaManagedAgentsMcpConnectionFailed(value);
                break;
            case BetaManagedAgentsMcpAuthenticationFailedError value:
                betaManagedAgentsMcpAuthenticationFailed(value);
                break;
            case BetaManagedAgentsBillingError value:
                betaManagedAgentsBilling(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Error");
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
    ///     (BetaManagedAgentsUnknownError value) =&gt; {...},
    ///     (BetaManagedAgentsModelOverloadedError value) =&gt; {...},
    ///     (BetaManagedAgentsModelRateLimitedError value) =&gt; {...},
    ///     (BetaManagedAgentsModelRequestFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpConnectionFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsMcpAuthenticationFailedError value) =&gt; {...},
    ///     (BetaManagedAgentsBillingError value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUnknownError, T> betaManagedAgentsUnknown,
        System::Func<BetaManagedAgentsModelOverloadedError, T> betaManagedAgentsModelOverloaded,
        System::Func<BetaManagedAgentsModelRateLimitedError, T> betaManagedAgentsModelRateLimited,
        System::Func<
            BetaManagedAgentsModelRequestFailedError,
            T
        > betaManagedAgentsModelRequestFailed,
        System::Func<
            BetaManagedAgentsMcpConnectionFailedError,
            T
        > betaManagedAgentsMcpConnectionFailed,
        System::Func<
            BetaManagedAgentsMcpAuthenticationFailedError,
            T
        > betaManagedAgentsMcpAuthenticationFailed,
        System::Func<BetaManagedAgentsBillingError, T> betaManagedAgentsBilling
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUnknownError value => betaManagedAgentsUnknown(value),
            BetaManagedAgentsModelOverloadedError value => betaManagedAgentsModelOverloaded(value),
            BetaManagedAgentsModelRateLimitedError value => betaManagedAgentsModelRateLimited(
                value
            ),
            BetaManagedAgentsModelRequestFailedError value => betaManagedAgentsModelRequestFailed(
                value
            ),
            BetaManagedAgentsMcpConnectionFailedError value => betaManagedAgentsMcpConnectionFailed(
                value
            ),
            BetaManagedAgentsMcpAuthenticationFailedError value =>
                betaManagedAgentsMcpAuthenticationFailed(value),
            BetaManagedAgentsBillingError value => betaManagedAgentsBilling(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Error"),
        };
    }

    public static implicit operator Error(BetaManagedAgentsUnknownError value) => new(value);

    public static implicit operator Error(BetaManagedAgentsModelOverloadedError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsModelRateLimitedError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsModelRequestFailedError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsMcpConnectionFailedError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsMcpAuthenticationFailedError value) =>
        new(value);

    public static implicit operator Error(BetaManagedAgentsBillingError value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Error");
        }
        this.Switch(
            (betaManagedAgentsUnknown) => betaManagedAgentsUnknown.Validate(),
            (betaManagedAgentsModelOverloaded) => betaManagedAgentsModelOverloaded.Validate(),
            (betaManagedAgentsModelRateLimited) => betaManagedAgentsModelRateLimited.Validate(),
            (betaManagedAgentsModelRequestFailed) => betaManagedAgentsModelRequestFailed.Validate(),
            (betaManagedAgentsMcpConnectionFailed) =>
                betaManagedAgentsMcpConnectionFailed.Validate(),
            (betaManagedAgentsMcpAuthenticationFailed) =>
                betaManagedAgentsMcpAuthenticationFailed.Validate(),
            (betaManagedAgentsBilling) => betaManagedAgentsBilling.Validate()
        );
    }

    public virtual bool Equals(Error? other) =>
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
            BetaManagedAgentsUnknownError _ => 0,
            BetaManagedAgentsModelOverloadedError _ => 1,
            BetaManagedAgentsModelRateLimitedError _ => 2,
            BetaManagedAgentsModelRequestFailedError _ => 3,
            BetaManagedAgentsMcpConnectionFailedError _ => 4,
            BetaManagedAgentsMcpAuthenticationFailedError _ => 5,
            BetaManagedAgentsBillingError _ => 6,
            _ => -1,
        };
    }
}

sealed class ErrorConverter : JsonConverter<Error>
{
    public override Error? Read(
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
            case "unknown_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUnknownError>(
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
            case "model_overloaded_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsModelOverloadedError>(
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
            case "model_rate_limited_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsModelRateLimitedError>(
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
            case "model_request_failed_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsModelRequestFailedError>(
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
            case "mcp_connection_failed_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedError>(
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
            case "mcp_authentication_failed_error":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedError>(
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
            case "billing_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBillingError>(
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
                return new Error(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Error value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionErrorEventTypeConverter))]
public enum BetaManagedAgentsSessionErrorEventType
{
    SessionError,
}

sealed class BetaManagedAgentsSessionErrorEventTypeConverter
    : JsonConverter<BetaManagedAgentsSessionErrorEventType>
{
    public override BetaManagedAgentsSessionErrorEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "session.error" => BetaManagedAgentsSessionErrorEventType.SessionError,
            _ => (BetaManagedAgentsSessionErrorEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionErrorEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionErrorEventType.SessionError => "session.error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
