using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.ErrorObjectVariants;

namespace Anthropic.Models;

[JsonConverter(typeof(ErrorObjectConverter))]
public abstract record class ErrorObject
{
    internal ErrorObject() { }

    public static implicit operator ErrorObject(InvalidRequestError value) =>
        new InvalidRequestErrorVariant(value);

    public static implicit operator ErrorObject(AuthenticationError value) =>
        new AuthenticationErrorVariant(value);

    public static implicit operator ErrorObject(BillingError value) =>
        new BillingErrorVariant(value);

    public static implicit operator ErrorObject(PermissionError value) =>
        new PermissionErrorVariant(value);

    public static implicit operator ErrorObject(NotFoundError value) =>
        new NotFoundErrorVariant(value);

    public static implicit operator ErrorObject(RateLimitError value) =>
        new RateLimitErrorVariant(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) =>
        new GatewayTimeoutErrorVariant(value);

    public static implicit operator ErrorObject(APIErrorObject value) =>
        new APIErrorObjectVariant(value);

    public static implicit operator ErrorObject(OverloadedError value) =>
        new OverloadedErrorVariant(value);

    public bool TryPickInvalidRequestErrorVariant(
        [NotNullWhen(true)] out InvalidRequestError? value
    )
    {
        value = (this as InvalidRequestErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickAuthenticationErrorVariant(
        [NotNullWhen(true)] out AuthenticationError? value
    )
    {
        value = (this as AuthenticationErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBillingErrorVariant([NotNullWhen(true)] out BillingError? value)
    {
        value = (this as BillingErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickPermissionErrorVariant([NotNullWhen(true)] out PermissionError? value)
    {
        value = (this as PermissionErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickNotFoundErrorVariant([NotNullWhen(true)] out NotFoundError? value)
    {
        value = (this as NotFoundErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickRateLimitErrorVariant([NotNullWhen(true)] out RateLimitError? value)
    {
        value = (this as RateLimitErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickGatewayTimeoutErrorVariant(
        [NotNullWhen(true)] out GatewayTimeoutError? value
    )
    {
        value = (this as GatewayTimeoutErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickAPIErrorObjectVariant([NotNullWhen(true)] out APIErrorObject? value)
    {
        value = (this as APIErrorObjectVariant)?.Value;
        return value != null;
    }

    public bool TryPickOverloadedErrorVariant([NotNullWhen(true)] out OverloadedError? value)
    {
        value = (this as OverloadedErrorVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<InvalidRequestErrorVariant> invalidRequestError,
        Action<AuthenticationErrorVariant> authenticationError,
        Action<BillingErrorVariant> billingError,
        Action<PermissionErrorVariant> permissionError,
        Action<NotFoundErrorVariant> notFoundError,
        Action<RateLimitErrorVariant> rateLimitError,
        Action<GatewayTimeoutErrorVariant> gatewayTimeoutError,
        Action<APIErrorObjectVariant> apiErrorObject,
        Action<OverloadedErrorVariant> overloadedError
    )
    {
        switch (this)
        {
            case InvalidRequestErrorVariant inner:
                invalidRequestError(inner);
                break;
            case AuthenticationErrorVariant inner:
                authenticationError(inner);
                break;
            case BillingErrorVariant inner:
                billingError(inner);
                break;
            case PermissionErrorVariant inner:
                permissionError(inner);
                break;
            case NotFoundErrorVariant inner:
                notFoundError(inner);
                break;
            case RateLimitErrorVariant inner:
                rateLimitError(inner);
                break;
            case GatewayTimeoutErrorVariant inner:
                gatewayTimeoutError(inner);
                break;
            case APIErrorObjectVariant inner:
                apiErrorObject(inner);
                break;
            case OverloadedErrorVariant inner:
                overloadedError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<InvalidRequestErrorVariant, T> invalidRequestError,
        Func<AuthenticationErrorVariant, T> authenticationError,
        Func<BillingErrorVariant, T> billingError,
        Func<PermissionErrorVariant, T> permissionError,
        Func<NotFoundErrorVariant, T> notFoundError,
        Func<RateLimitErrorVariant, T> rateLimitError,
        Func<GatewayTimeoutErrorVariant, T> gatewayTimeoutError,
        Func<APIErrorObjectVariant, T> apiErrorObject,
        Func<OverloadedErrorVariant, T> overloadedError
    )
    {
        return this switch
        {
            InvalidRequestErrorVariant inner => invalidRequestError(inner),
            AuthenticationErrorVariant inner => authenticationError(inner),
            BillingErrorVariant inner => billingError(inner),
            PermissionErrorVariant inner => permissionError(inner),
            NotFoundErrorVariant inner => notFoundError(inner),
            RateLimitErrorVariant inner => rateLimitError(inner),
            GatewayTimeoutErrorVariant inner => gatewayTimeoutError(inner),
            APIErrorObjectVariant inner => apiErrorObject(inner),
            OverloadedErrorVariant inner => overloadedError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ErrorObjectConverter : JsonConverter<ErrorObject>
{
    public override ErrorObject? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                    var deserialized = JsonSerializer.Deserialize<InvalidRequestError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new InvalidRequestErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<AuthenticationError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new AuthenticationErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<BillingError>(json, options);
                    if (deserialized != null)
                    {
                        return new BillingErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<PermissionError>(json, options);
                    if (deserialized != null)
                    {
                        return new PermissionErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<NotFoundError>(json, options);
                    if (deserialized != null)
                    {
                        return new NotFoundErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<RateLimitError>(json, options);
                    if (deserialized != null)
                    {
                        return new RateLimitErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<GatewayTimeoutError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new GatewayTimeoutErrorVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<APIErrorObject>(json, options);
                    if (deserialized != null)
                    {
                        return new APIErrorObjectVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<OverloadedError>(json, options);
                    if (deserialized != null)
                    {
                        return new OverloadedErrorVariant(deserialized);
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
        ErrorObject value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            InvalidRequestErrorVariant(var invalidRequestError) => invalidRequestError,
            AuthenticationErrorVariant(var authenticationError) => authenticationError,
            BillingErrorVariant(var billingError) => billingError,
            PermissionErrorVariant(var permissionError) => permissionError,
            NotFoundErrorVariant(var notFoundError) => notFoundError,
            RateLimitErrorVariant(var rateLimitError) => rateLimitError,
            GatewayTimeoutErrorVariant(var gatewayTimeoutError) => gatewayTimeoutError,
            APIErrorObjectVariant(var apiErrorObject) => apiErrorObject,
            OverloadedErrorVariant(var overloadedError) => overloadedError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
