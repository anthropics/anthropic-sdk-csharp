using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ErrorObjectConverter))]
public record class ErrorObject : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string Message
    {
        get
        {
            return Match(
                invalidRequestError: (x) => x.Message,
                authenticationError: (x) => x.Message,
                billingError: (x) => x.Message,
                permissionError: (x) => x.Message,
                notFoundError: (x) => x.Message,
                rateLimitError: (x) => x.Message,
                gatewayTimeoutError: (x) => x.Message,
                api: (x) => x.Message,
                overloadedError: (x) => x.Message
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                invalidRequestError: (x) => x.Type,
                authenticationError: (x) => x.Type,
                billingError: (x) => x.Type,
                permissionError: (x) => x.Type,
                notFoundError: (x) => x.Type,
                rateLimitError: (x) => x.Type,
                gatewayTimeoutError: (x) => x.Type,
                api: (x) => x.Type,
                overloadedError: (x) => x.Type
            );
        }
    }

    public ErrorObject(InvalidRequestError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(AuthenticationError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(BillingError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(PermissionError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(NotFoundError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(RateLimitError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(GatewayTimeoutError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(ApiErrorObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(OverloadedError value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ErrorObject(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InvalidRequestError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickInvalidRequestError(out var value)) {
    ///     // `value` is of type `InvalidRequestError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickInvalidRequestError([NotNullWhen(true)] out InvalidRequestError? value)
    {
        value = this.Value as InvalidRequestError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AuthenticationError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAuthenticationError(out var value)) {
    ///     // `value` is of type `AuthenticationError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAuthenticationError([NotNullWhen(true)] out AuthenticationError? value)
    {
        value = this.Value as AuthenticationError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BillingError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBillingError(out var value)) {
    ///     // `value` is of type `BillingError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBillingError([NotNullWhen(true)] out BillingError? value)
    {
        value = this.Value as BillingError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PermissionError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPermissionError(out var value)) {
    ///     // `value` is of type `PermissionError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPermissionError([NotNullWhen(true)] out PermissionError? value)
    {
        value = this.Value as PermissionError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NotFoundError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotFoundError(out var value)) {
    ///     // `value` is of type `NotFoundError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotFoundError([NotNullWhen(true)] out NotFoundError? value)
    {
        value = this.Value as NotFoundError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimitError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRateLimitError(out var value)) {
    ///     // `value` is of type `RateLimitError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRateLimitError([NotNullWhen(true)] out RateLimitError? value)
    {
        value = this.Value as RateLimitError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GatewayTimeoutError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGatewayTimeoutError(out var value)) {
    ///     // `value` is of type `GatewayTimeoutError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGatewayTimeoutError([NotNullWhen(true)] out GatewayTimeoutError? value)
    {
        value = this.Value as GatewayTimeoutError;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiErrorObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApi(out var value)) {
    ///     // `value` is of type `ApiErrorObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApi([NotNullWhen(true)] out ApiErrorObject? value)
    {
        value = this.Value as ApiErrorObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OverloadedError"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOverloadedError(out var value)) {
    ///     // `value` is of type `OverloadedError`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOverloadedError([NotNullWhen(true)] out OverloadedError? value)
    {
        value = this.Value as OverloadedError;
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
    ///     (InvalidRequestError value) => {...},
    ///     (AuthenticationError value) => {...},
    ///     (BillingError value) => {...},
    ///     (PermissionError value) => {...},
    ///     (NotFoundError value) => {...},
    ///     (RateLimitError value) => {...},
    ///     (GatewayTimeoutError value) => {...},
    ///     (ApiErrorObject value) => {...},
    ///     (OverloadedError value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<InvalidRequestError> invalidRequestError,
        Action<AuthenticationError> authenticationError,
        Action<BillingError> billingError,
        Action<PermissionError> permissionError,
        Action<NotFoundError> notFoundError,
        Action<RateLimitError> rateLimitError,
        Action<GatewayTimeoutError> gatewayTimeoutError,
        Action<ApiErrorObject> api,
        Action<OverloadedError> overloadedError
    )
    {
        switch (this.Value)
        {
            case InvalidRequestError value:
                invalidRequestError(value);
                break;
            case AuthenticationError value:
                authenticationError(value);
                break;
            case BillingError value:
                billingError(value);
                break;
            case PermissionError value:
                permissionError(value);
                break;
            case NotFoundError value:
                notFoundError(value);
                break;
            case RateLimitError value:
                rateLimitError(value);
                break;
            case GatewayTimeoutError value:
                gatewayTimeoutError(value);
                break;
            case ApiErrorObject value:
                api(value);
                break;
            case OverloadedError value:
                overloadedError(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ErrorObject"
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
    ///     (InvalidRequestError value) => {...},
    ///     (AuthenticationError value) => {...},
    ///     (BillingError value) => {...},
    ///     (PermissionError value) => {...},
    ///     (NotFoundError value) => {...},
    ///     (RateLimitError value) => {...},
    ///     (GatewayTimeoutError value) => {...},
    ///     (ApiErrorObject value) => {...},
    ///     (OverloadedError value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<InvalidRequestError, T> invalidRequestError,
        Func<AuthenticationError, T> authenticationError,
        Func<BillingError, T> billingError,
        Func<PermissionError, T> permissionError,
        Func<NotFoundError, T> notFoundError,
        Func<RateLimitError, T> rateLimitError,
        Func<GatewayTimeoutError, T> gatewayTimeoutError,
        Func<ApiErrorObject, T> api,
        Func<OverloadedError, T> overloadedError
    )
    {
        return this.Value switch
        {
            InvalidRequestError value => invalidRequestError(value),
            AuthenticationError value => authenticationError(value),
            BillingError value => billingError(value),
            PermissionError value => permissionError(value),
            NotFoundError value => notFoundError(value),
            RateLimitError value => rateLimitError(value),
            GatewayTimeoutError value => gatewayTimeoutError(value),
            ApiErrorObject value => api(value),
            OverloadedError value => overloadedError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorObject"
            ),
        };
    }

    public static implicit operator ErrorObject(InvalidRequestError value) => new(value);

    public static implicit operator ErrorObject(AuthenticationError value) => new(value);

    public static implicit operator ErrorObject(BillingError value) => new(value);

    public static implicit operator ErrorObject(PermissionError value) => new(value);

    public static implicit operator ErrorObject(NotFoundError value) => new(value);

    public static implicit operator ErrorObject(RateLimitError value) => new(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) => new(value);

    public static implicit operator ErrorObject(ApiErrorObject value) => new(value);

    public static implicit operator ErrorObject(OverloadedError value) => new(value);

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
                "Data did not match any variant of ErrorObject"
            );
        }
        this.Switch(
            (invalidRequestError) => invalidRequestError.Validate(),
            (authenticationError) => authenticationError.Validate(),
            (billingError) => billingError.Validate(),
            (permissionError) => permissionError.Validate(),
            (notFoundError) => notFoundError.Validate(),
            (rateLimitError) => rateLimitError.Validate(),
            (gatewayTimeoutError) => gatewayTimeoutError.Validate(),
            (api) => api.Validate(),
            (overloadedError) => overloadedError.Validate()
        );
    }

    public virtual bool Equals(ErrorObject? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ErrorObjectConverter : JsonConverter<ErrorObject>
{
    public override ErrorObject? Read(
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
                    var deserialized = JsonSerializer.Deserialize<InvalidRequestError>(
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
                    var deserialized = JsonSerializer.Deserialize<AuthenticationError>(
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
                    var deserialized = JsonSerializer.Deserialize<BillingError>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<PermissionError>(
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
                    var deserialized = JsonSerializer.Deserialize<NotFoundError>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<RateLimitError>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<GatewayTimeoutError>(
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
                    var deserialized = JsonSerializer.Deserialize<ApiErrorObject>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<OverloadedError>(
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
                return new ErrorObject(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorObject value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
