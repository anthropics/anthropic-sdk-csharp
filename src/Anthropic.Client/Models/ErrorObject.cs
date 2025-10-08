using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models;

[JsonConverter(typeof(ErrorObjectConverter))]
public record class ErrorObject
{
    public object Value { get; private init; }

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

    public ErrorObject(InvalidRequestError value)
    {
        Value = value;
    }

    public ErrorObject(AuthenticationError value)
    {
        Value = value;
    }

    public ErrorObject(BillingError value)
    {
        Value = value;
    }

    public ErrorObject(PermissionError value)
    {
        Value = value;
    }

    public ErrorObject(NotFoundError value)
    {
        Value = value;
    }

    public ErrorObject(RateLimitError value)
    {
        Value = value;
    }

    public ErrorObject(GatewayTimeoutError value)
    {
        Value = value;
    }

    public ErrorObject(APIErrorObject value)
    {
        Value = value;
    }

    public ErrorObject(OverloadedError value)
    {
        Value = value;
    }

    ErrorObject(UnknownVariant value)
    {
        Value = value;
    }

    public static ErrorObject CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickInvalidRequestError([NotNullWhen(true)] out InvalidRequestError? value)
    {
        value = this.Value as InvalidRequestError;
        return value != null;
    }

    public bool TryPickAuthenticationError([NotNullWhen(true)] out AuthenticationError? value)
    {
        value = this.Value as AuthenticationError;
        return value != null;
    }

    public bool TryPickBillingError([NotNullWhen(true)] out BillingError? value)
    {
        value = this.Value as BillingError;
        return value != null;
    }

    public bool TryPickPermissionError([NotNullWhen(true)] out PermissionError? value)
    {
        value = this.Value as PermissionError;
        return value != null;
    }

    public bool TryPickNotFoundError([NotNullWhen(true)] out NotFoundError? value)
    {
        value = this.Value as NotFoundError;
        return value != null;
    }

    public bool TryPickRateLimitError([NotNullWhen(true)] out RateLimitError? value)
    {
        value = this.Value as RateLimitError;
        return value != null;
    }

    public bool TryPickGatewayTimeoutError([NotNullWhen(true)] out GatewayTimeoutError? value)
    {
        value = this.Value as GatewayTimeoutError;
        return value != null;
    }

    public bool TryPickAPI([NotNullWhen(true)] out APIErrorObject? value)
    {
        value = this.Value as APIErrorObject;
        return value != null;
    }

    public bool TryPickOverloadedError([NotNullWhen(true)] out OverloadedError? value)
    {
        value = this.Value as OverloadedError;
        return value != null;
    }

    public void Switch(
        Action<InvalidRequestError> invalidRequestError,
        Action<AuthenticationError> authenticationError,
        Action<BillingError> billingError,
        Action<PermissionError> permissionError,
        Action<NotFoundError> notFoundError,
        Action<RateLimitError> rateLimitError,
        Action<GatewayTimeoutError> gatewayTimeoutError,
        Action<APIErrorObject> api,
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
            case APIErrorObject value:
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

    public T Match<T>(
        Func<InvalidRequestError, T> invalidRequestError,
        Func<AuthenticationError, T> authenticationError,
        Func<BillingError, T> billingError,
        Func<PermissionError, T> permissionError,
        Func<NotFoundError, T> notFoundError,
        Func<RateLimitError, T> rateLimitError,
        Func<GatewayTimeoutError, T> gatewayTimeoutError,
        Func<APIErrorObject, T> api,
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
            APIErrorObject value => api(value),
            OverloadedError value => overloadedError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorObject"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ErrorObject"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'InvalidRequestError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'AuthenticationError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BillingError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'PermissionError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'NotFoundError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'RateLimitError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'GatewayTimeoutError'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'APIErrorObject'",
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
                        deserialized.Validate();
                        return new ErrorObject(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'OverloadedError'",
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
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
