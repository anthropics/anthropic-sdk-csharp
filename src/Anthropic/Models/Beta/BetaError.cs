using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(BetaErrorConverter))]
public record class BetaError : ModelBase
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
                invalidRequest: (x) => x.Message,
                authentication: (x) => x.Message,
                billing: (x) => x.Message,
                permission: (x) => x.Message,
                notFound: (x) => x.Message,
                rateLimit: (x) => x.Message,
                gatewayTimeout: (x) => x.Message,
                api: (x) => x.Message,
                overloaded: (x) => x.Message
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                invalidRequest: (x) => x.Type,
                authentication: (x) => x.Type,
                billing: (x) => x.Type,
                permission: (x) => x.Type,
                notFound: (x) => x.Type,
                rateLimit: (x) => x.Type,
                gatewayTimeout: (x) => x.Type,
                api: (x) => x.Type,
                overloaded: (x) => x.Type
            );
        }
    }

    public BetaError(BetaInvalidRequestError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaAuthenticationError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaBillingError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaPermissionError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaNotFoundError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaRateLimitError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaGatewayTimeoutError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaApiError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(BetaOverloadedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaError(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaInvalidRequestError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInvalidRequest(out var value)) {
    ///     // `value` is of type `BetaInvalidRequestError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInvalidRequest([NotNullWhen(true)] out BetaInvalidRequestError? value)
    {
        value = this.Value as BetaInvalidRequestError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAuthenticationError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuthentication(out var value)) {
    ///     // `value` is of type `BetaAuthenticationError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuthentication([NotNullWhen(true)] out BetaAuthenticationError? value)
    {
        value = this.Value as BetaAuthenticationError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBillingError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBilling(out var value)) {
    ///     // `value` is of type `BetaBillingError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBilling([NotNullWhen(true)] out BetaBillingError? value)
    {
        value = this.Value as BetaBillingError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPermissionError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPermission(out var value)) {
    ///     // `value` is of type `BetaPermissionError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPermission([NotNullWhen(true)] out BetaPermissionError? value)
    {
        value = this.Value as BetaPermissionError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaNotFoundError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotFound(out var value)) {
    ///     // `value` is of type `BetaNotFoundError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotFound([NotNullWhen(true)] out BetaNotFoundError? value)
    {
        value = this.Value as BetaNotFoundError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRateLimitError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRateLimit(out var value)) {
    ///     // `value` is of type `BetaRateLimitError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRateLimit([NotNullWhen(true)] out BetaRateLimitError? value)
    {
        value = this.Value as BetaRateLimitError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaGatewayTimeoutError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGatewayTimeout(out var value)) {
    ///     // `value` is of type `BetaGatewayTimeoutError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGatewayTimeout([NotNullWhen(true)] out BetaGatewayTimeoutError? value)
    {
        value = this.Value as BetaGatewayTimeoutError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaApiError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApi(out var value)) {
    ///     // `value` is of type `BetaApiError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApi([NotNullWhen(true)] out BetaApiError? value)
    {
        value = this.Value as BetaApiError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOverloadedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOverloaded(out var value)) {
    ///     // `value` is of type `BetaOverloadedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOverloaded([NotNullWhen(true)] out BetaOverloadedError? value)
    {
        value = this.Value as BetaOverloadedError;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (BetaInvalidRequestError value) => {...},
    ///     (BetaAuthenticationError value) => {...},
    ///     (BetaBillingError value) => {...},
    ///     (BetaPermissionError value) => {...},
    ///     (BetaNotFoundError value) => {...},
    ///     (BetaRateLimitError value) => {...},
    ///     (BetaGatewayTimeoutError value) => {...},
    ///     (BetaApiError value) => {...},
    ///     (BetaOverloadedError value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaInvalidRequestError> invalidRequest,
        Action<BetaAuthenticationError> authentication,
        Action<BetaBillingError> billing,
        Action<BetaPermissionError> permission,
        Action<BetaNotFoundError> notFound,
        Action<BetaRateLimitError> rateLimit,
        Action<BetaGatewayTimeoutError> gatewayTimeout,
        Action<BetaApiError> api,
        Action<BetaOverloadedError> overloaded
    )
    {
        switch (this.Value)
        {
            case BetaInvalidRequestError value:
                invalidRequest(value);
                break;
            case BetaAuthenticationError value:
                authentication(value);
                break;
            case BetaBillingError value:
                billing(value);
                break;
            case BetaPermissionError value:
                permission(value);
                break;
            case BetaNotFoundError value:
                notFound(value);
                break;
            case BetaRateLimitError value:
                rateLimit(value);
                break;
            case BetaGatewayTimeoutError value:
                gatewayTimeout(value);
                break;
            case BetaApiError value:
                api(value);
                break;
            case BetaOverloadedError value:
                overloaded(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaError"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (BetaInvalidRequestError value) => {...},
    ///     (BetaAuthenticationError value) => {...},
    ///     (BetaBillingError value) => {...},
    ///     (BetaPermissionError value) => {...},
    ///     (BetaNotFoundError value) => {...},
    ///     (BetaRateLimitError value) => {...},
    ///     (BetaGatewayTimeoutError value) => {...},
    ///     (BetaApiError value) => {...},
    ///     (BetaOverloadedError value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaInvalidRequestError, T> invalidRequest,
        Func<BetaAuthenticationError, T> authentication,
        Func<BetaBillingError, T> billing,
        Func<BetaPermissionError, T> permission,
        Func<BetaNotFoundError, T> notFound,
        Func<BetaRateLimitError, T> rateLimit,
        Func<BetaGatewayTimeoutError, T> gatewayTimeout,
        Func<BetaApiError, T> api,
        Func<BetaOverloadedError, T> overloaded
    )
    {
        return this.Value switch
        {
            BetaInvalidRequestError value => invalidRequest(value),
            BetaAuthenticationError value => authentication(value),
            BetaBillingError value => billing(value),
            BetaPermissionError value => permission(value),
            BetaNotFoundError value => notFound(value),
            BetaRateLimitError value => rateLimit(value),
            BetaGatewayTimeoutError value => gatewayTimeout(value),
            BetaApiError value => api(value),
            BetaOverloadedError value => overloaded(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaError"
            ),
        };
    }

    public static implicit operator BetaError(BetaInvalidRequestError value) => new(value);

    public static implicit operator BetaError(BetaAuthenticationError value) => new(value);

    public static implicit operator BetaError(BetaBillingError value) => new(value);

    public static implicit operator BetaError(BetaPermissionError value) => new(value);

    public static implicit operator BetaError(BetaNotFoundError value) => new(value);

    public static implicit operator BetaError(BetaRateLimitError value) => new(value);

    public static implicit operator BetaError(BetaGatewayTimeoutError value) => new(value);

    public static implicit operator BetaError(BetaApiError value) => new(value);

    public static implicit operator BetaError(BetaOverloadedError value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of BetaError");
        }
        this.Switch(
            (invalidRequest) => invalidRequest.Validate(),
            (authentication) => authentication.Validate(),
            (billing) => billing.Validate(),
            (permission) => permission.Validate(),
            (notFound) => notFound.Validate(),
            (rateLimit) => rateLimit.Validate(),
            (gatewayTimeout) => gatewayTimeout.Validate(),
            (api) => api.Validate(),
            (overloaded) => overloaded.Validate()
        );
    }

    public virtual bool Equals(BetaError? other) =>
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
            BetaInvalidRequestError _ => 0,
            BetaAuthenticationError _ => 1,
            BetaBillingError _ => 2,
            BetaPermissionError _ => 3,
            BetaNotFoundError _ => 4,
            BetaRateLimitError _ => 5,
            BetaGatewayTimeoutError _ => 6,
            BetaApiError _ => 7,
            BetaOverloadedError _ => 8,
            _ => -1,
        };
    }
}

sealed class BetaErrorConverter : JsonConverter<BetaError>
{
    public override BetaError? Read(
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
            case "invalid_request_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInvalidRequestError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "authentication_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAuthenticationError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "billing_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBillingError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "permission_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPermissionError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "not_found_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaNotFoundError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "rate_limit_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRateLimitError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "timeout_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaGatewayTimeoutError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "api_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaApiError>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "overloaded_error":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaOverloadedError>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaError(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaError value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
