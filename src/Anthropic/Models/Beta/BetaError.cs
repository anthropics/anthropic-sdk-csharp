using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaErrorVariants = Anthropic.Models.Beta.BetaErrorVariants;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(BetaErrorConverter))]
public abstract record class BetaError
{
    internal BetaError() { }

    public static implicit operator BetaError(BetaInvalidRequestError value) =>
        new BetaErrorVariants::BetaInvalidRequestError(value);

    public static implicit operator BetaError(BetaAuthenticationError value) =>
        new BetaErrorVariants::BetaAuthenticationError(value);

    public static implicit operator BetaError(BetaBillingError value) =>
        new BetaErrorVariants::BetaBillingError(value);

    public static implicit operator BetaError(BetaPermissionError value) =>
        new BetaErrorVariants::BetaPermissionError(value);

    public static implicit operator BetaError(BetaNotFoundError value) =>
        new BetaErrorVariants::BetaNotFoundError(value);

    public static implicit operator BetaError(BetaRateLimitError value) =>
        new BetaErrorVariants::BetaRateLimitError(value);

    public static implicit operator BetaError(BetaGatewayTimeoutError value) =>
        new BetaErrorVariants::BetaGatewayTimeoutError(value);

    public static implicit operator BetaError(BetaAPIError value) =>
        new BetaErrorVariants::BetaAPIError(value);

    public static implicit operator BetaError(BetaOverloadedError value) =>
        new BetaErrorVariants::BetaOverloadedError(value);

    public bool TryPickInvalidRequest([NotNullWhen(true)] out BetaInvalidRequestError? value)
    {
        value = (this as BetaErrorVariants::BetaInvalidRequestError)?.Value;
        return value != null;
    }

    public bool TryPickAuthentication([NotNullWhen(true)] out BetaAuthenticationError? value)
    {
        value = (this as BetaErrorVariants::BetaAuthenticationError)?.Value;
        return value != null;
    }

    public bool TryPickBilling([NotNullWhen(true)] out BetaBillingError? value)
    {
        value = (this as BetaErrorVariants::BetaBillingError)?.Value;
        return value != null;
    }

    public bool TryPickPermission([NotNullWhen(true)] out BetaPermissionError? value)
    {
        value = (this as BetaErrorVariants::BetaPermissionError)?.Value;
        return value != null;
    }

    public bool TryPickNotFound([NotNullWhen(true)] out BetaNotFoundError? value)
    {
        value = (this as BetaErrorVariants::BetaNotFoundError)?.Value;
        return value != null;
    }

    public bool TryPickRateLimit([NotNullWhen(true)] out BetaRateLimitError? value)
    {
        value = (this as BetaErrorVariants::BetaRateLimitError)?.Value;
        return value != null;
    }

    public bool TryPickGatewayTimeout([NotNullWhen(true)] out BetaGatewayTimeoutError? value)
    {
        value = (this as BetaErrorVariants::BetaGatewayTimeoutError)?.Value;
        return value != null;
    }

    public bool TryPickAPI([NotNullWhen(true)] out BetaAPIError? value)
    {
        value = (this as BetaErrorVariants::BetaAPIError)?.Value;
        return value != null;
    }

    public bool TryPickOverloaded([NotNullWhen(true)] out BetaOverloadedError? value)
    {
        value = (this as BetaErrorVariants::BetaOverloadedError)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaErrorVariants::BetaInvalidRequestError> invalidRequest,
        Action<BetaErrorVariants::BetaAuthenticationError> authentication,
        Action<BetaErrorVariants::BetaBillingError> billing,
        Action<BetaErrorVariants::BetaPermissionError> permission,
        Action<BetaErrorVariants::BetaNotFoundError> notFound,
        Action<BetaErrorVariants::BetaRateLimitError> rateLimit,
        Action<BetaErrorVariants::BetaGatewayTimeoutError> gatewayTimeout,
        Action<BetaErrorVariants::BetaAPIError> api,
        Action<BetaErrorVariants::BetaOverloadedError> overloaded
    )
    {
        switch (this)
        {
            case BetaErrorVariants::BetaInvalidRequestError inner:
                invalidRequest(inner);
                break;
            case BetaErrorVariants::BetaAuthenticationError inner:
                authentication(inner);
                break;
            case BetaErrorVariants::BetaBillingError inner:
                billing(inner);
                break;
            case BetaErrorVariants::BetaPermissionError inner:
                permission(inner);
                break;
            case BetaErrorVariants::BetaNotFoundError inner:
                notFound(inner);
                break;
            case BetaErrorVariants::BetaRateLimitError inner:
                rateLimit(inner);
                break;
            case BetaErrorVariants::BetaGatewayTimeoutError inner:
                gatewayTimeout(inner);
                break;
            case BetaErrorVariants::BetaAPIError inner:
                api(inner);
                break;
            case BetaErrorVariants::BetaOverloadedError inner:
                overloaded(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaErrorVariants::BetaInvalidRequestError, T> invalidRequest,
        Func<BetaErrorVariants::BetaAuthenticationError, T> authentication,
        Func<BetaErrorVariants::BetaBillingError, T> billing,
        Func<BetaErrorVariants::BetaPermissionError, T> permission,
        Func<BetaErrorVariants::BetaNotFoundError, T> notFound,
        Func<BetaErrorVariants::BetaRateLimitError, T> rateLimit,
        Func<BetaErrorVariants::BetaGatewayTimeoutError, T> gatewayTimeout,
        Func<BetaErrorVariants::BetaAPIError, T> api,
        Func<BetaErrorVariants::BetaOverloadedError, T> overloaded
    )
    {
        return this switch
        {
            BetaErrorVariants::BetaInvalidRequestError inner => invalidRequest(inner),
            BetaErrorVariants::BetaAuthenticationError inner => authentication(inner),
            BetaErrorVariants::BetaBillingError inner => billing(inner),
            BetaErrorVariants::BetaPermissionError inner => permission(inner),
            BetaErrorVariants::BetaNotFoundError inner => notFound(inner),
            BetaErrorVariants::BetaRateLimitError inner => rateLimit(inner),
            BetaErrorVariants::BetaGatewayTimeoutError inner => gatewayTimeout(inner),
            BetaErrorVariants::BetaAPIError inner => api(inner),
            BetaErrorVariants::BetaOverloadedError inner => overloaded(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaErrorConverter : JsonConverter<BetaError>
{
    public override BetaError? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "invalid_request_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInvalidRequestError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaInvalidRequestError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "authentication_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAuthenticationError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaAuthenticationError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "billing_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBillingError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaBillingError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "permission_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPermissionError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaPermissionError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "not_found_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaNotFoundError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaNotFoundError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "rate_limit_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRateLimitError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaRateLimitError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "timeout_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaGatewayTimeoutError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaGatewayTimeoutError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "api_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAPIError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaAPIError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "overloaded_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaOverloadedError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaOverloadedError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaError value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaErrorVariants::BetaInvalidRequestError(var invalidRequest) => invalidRequest,
            BetaErrorVariants::BetaAuthenticationError(var authentication) => authentication,
            BetaErrorVariants::BetaBillingError(var billing) => billing,
            BetaErrorVariants::BetaPermissionError(var permission) => permission,
            BetaErrorVariants::BetaNotFoundError(var notFound) => notFound,
            BetaErrorVariants::BetaRateLimitError(var rateLimit) => rateLimit,
            BetaErrorVariants::BetaGatewayTimeoutError(var gatewayTimeout) => gatewayTimeout,
            BetaErrorVariants::BetaAPIError(var api) => api,
            BetaErrorVariants::BetaOverloadedError(var overloaded) => overloaded,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
