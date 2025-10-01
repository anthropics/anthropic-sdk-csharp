using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using ErrorObjectVariants = Anthropic.Client.Models.ErrorObjectVariants;

namespace Anthropic.Client.Models;

[JsonConverter(typeof(ErrorObjectConverter))]
public abstract record class ErrorObject
{
    internal ErrorObject() { }

    public static implicit operator ErrorObject(InvalidRequestError value) =>
        new ErrorObjectVariants::InvalidRequestError(value);

    public static implicit operator ErrorObject(AuthenticationError value) =>
        new ErrorObjectVariants::AuthenticationError(value);

    public static implicit operator ErrorObject(BillingError value) =>
        new ErrorObjectVariants::BillingError(value);

    public static implicit operator ErrorObject(PermissionError value) =>
        new ErrorObjectVariants::PermissionError(value);

    public static implicit operator ErrorObject(NotFoundError value) =>
        new ErrorObjectVariants::NotFoundError(value);

    public static implicit operator ErrorObject(RateLimitError value) =>
        new ErrorObjectVariants::RateLimitError(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) =>
        new ErrorObjectVariants::GatewayTimeoutError(value);

    public static implicit operator ErrorObject(APIErrorObject value) =>
        new ErrorObjectVariants::APIErrorObject(value);

    public static implicit operator ErrorObject(OverloadedError value) =>
        new ErrorObjectVariants::OverloadedError(value);

    public bool TryPickInvalidRequestError([NotNullWhen(true)] out InvalidRequestError? value)
    {
        value = (this as ErrorObjectVariants::InvalidRequestError)?.Value;
        return value != null;
    }

    public bool TryPickAuthenticationError([NotNullWhen(true)] out AuthenticationError? value)
    {
        value = (this as ErrorObjectVariants::AuthenticationError)?.Value;
        return value != null;
    }

    public bool TryPickBillingError([NotNullWhen(true)] out BillingError? value)
    {
        value = (this as ErrorObjectVariants::BillingError)?.Value;
        return value != null;
    }

    public bool TryPickPermissionError([NotNullWhen(true)] out PermissionError? value)
    {
        value = (this as ErrorObjectVariants::PermissionError)?.Value;
        return value != null;
    }

    public bool TryPickNotFoundError([NotNullWhen(true)] out NotFoundError? value)
    {
        value = (this as ErrorObjectVariants::NotFoundError)?.Value;
        return value != null;
    }

    public bool TryPickRateLimitError([NotNullWhen(true)] out RateLimitError? value)
    {
        value = (this as ErrorObjectVariants::RateLimitError)?.Value;
        return value != null;
    }

    public bool TryPickGatewayTimeoutError([NotNullWhen(true)] out GatewayTimeoutError? value)
    {
        value = (this as ErrorObjectVariants::GatewayTimeoutError)?.Value;
        return value != null;
    }

    public bool TryPickAPI([NotNullWhen(true)] out APIErrorObject? value)
    {
        value = (this as ErrorObjectVariants::APIErrorObject)?.Value;
        return value != null;
    }

    public bool TryPickOverloadedError([NotNullWhen(true)] out OverloadedError? value)
    {
        value = (this as ErrorObjectVariants::OverloadedError)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ErrorObjectVariants::InvalidRequestError> invalidRequestError,
        Action<ErrorObjectVariants::AuthenticationError> authenticationError,
        Action<ErrorObjectVariants::BillingError> billingError,
        Action<ErrorObjectVariants::PermissionError> permissionError,
        Action<ErrorObjectVariants::NotFoundError> notFoundError,
        Action<ErrorObjectVariants::RateLimitError> rateLimitError,
        Action<ErrorObjectVariants::GatewayTimeoutError> gatewayTimeoutError,
        Action<ErrorObjectVariants::APIErrorObject> api,
        Action<ErrorObjectVariants::OverloadedError> overloadedError
    )
    {
        switch (this)
        {
            case ErrorObjectVariants::InvalidRequestError inner:
                invalidRequestError(inner);
                break;
            case ErrorObjectVariants::AuthenticationError inner:
                authenticationError(inner);
                break;
            case ErrorObjectVariants::BillingError inner:
                billingError(inner);
                break;
            case ErrorObjectVariants::PermissionError inner:
                permissionError(inner);
                break;
            case ErrorObjectVariants::NotFoundError inner:
                notFoundError(inner);
                break;
            case ErrorObjectVariants::RateLimitError inner:
                rateLimitError(inner);
                break;
            case ErrorObjectVariants::GatewayTimeoutError inner:
                gatewayTimeoutError(inner);
                break;
            case ErrorObjectVariants::APIErrorObject inner:
                api(inner);
                break;
            case ErrorObjectVariants::OverloadedError inner:
                overloadedError(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ErrorObject"
                );
        }
    }

    public T Match<T>(
        Func<ErrorObjectVariants::InvalidRequestError, T> invalidRequestError,
        Func<ErrorObjectVariants::AuthenticationError, T> authenticationError,
        Func<ErrorObjectVariants::BillingError, T> billingError,
        Func<ErrorObjectVariants::PermissionError, T> permissionError,
        Func<ErrorObjectVariants::NotFoundError, T> notFoundError,
        Func<ErrorObjectVariants::RateLimitError, T> rateLimitError,
        Func<ErrorObjectVariants::GatewayTimeoutError, T> gatewayTimeoutError,
        Func<ErrorObjectVariants::APIErrorObject, T> api,
        Func<ErrorObjectVariants::OverloadedError, T> overloadedError
    )
    {
        return this switch
        {
            ErrorObjectVariants::InvalidRequestError inner => invalidRequestError(inner),
            ErrorObjectVariants::AuthenticationError inner => authenticationError(inner),
            ErrorObjectVariants::BillingError inner => billingError(inner),
            ErrorObjectVariants::PermissionError inner => permissionError(inner),
            ErrorObjectVariants::NotFoundError inner => notFoundError(inner),
            ErrorObjectVariants::RateLimitError inner => rateLimitError(inner),
            ErrorObjectVariants::GatewayTimeoutError inner => gatewayTimeoutError(inner),
            ErrorObjectVariants::APIErrorObject inner => api(inner),
            ErrorObjectVariants::OverloadedError inner => overloadedError(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorObject"
            ),
        };
    }

    public abstract void Validate();
}

sealed class ErrorObjectConverter : JsonConverter<ErrorObject>
{
    public override ErrorObject? Read(
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<InvalidRequestError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::InvalidRequestError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::InvalidRequestError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "authentication_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AuthenticationError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::AuthenticationError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::AuthenticationError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "billing_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BillingError>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::BillingError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::BillingError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "permission_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PermissionError>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::PermissionError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::PermissionError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "not_found_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<NotFoundError>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::NotFoundError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::NotFoundError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "rate_limit_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<RateLimitError>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::RateLimitError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::RateLimitError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "timeout_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<GatewayTimeoutError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::GatewayTimeoutError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::GatewayTimeoutError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "api_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<APIErrorObject>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::APIErrorObject(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::APIErrorObject",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "overloaded_error":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<OverloadedError>(json, options);
                    if (deserialized != null)
                    {
                        return new ErrorObjectVariants::OverloadedError(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant ErrorObjectVariants::OverloadedError",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
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
            ErrorObjectVariants::InvalidRequestError(var invalidRequestError) =>
                invalidRequestError,
            ErrorObjectVariants::AuthenticationError(var authenticationError) =>
                authenticationError,
            ErrorObjectVariants::BillingError(var billingError) => billingError,
            ErrorObjectVariants::PermissionError(var permissionError) => permissionError,
            ErrorObjectVariants::NotFoundError(var notFoundError) => notFoundError,
            ErrorObjectVariants::RateLimitError(var rateLimitError) => rateLimitError,
            ErrorObjectVariants::GatewayTimeoutError(var gatewayTimeoutError) =>
                gatewayTimeoutError,
            ErrorObjectVariants::APIErrorObject(var api) => api,
            ErrorObjectVariants::OverloadedError(var overloadedError) => overloadedError,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorObject"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
