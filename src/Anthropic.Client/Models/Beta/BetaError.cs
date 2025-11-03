using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta;

[JsonConverter(typeof(BetaErrorConverter))]
public record class BetaError
{
    public object Value { get; private init; }

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

    public BetaError(BetaInvalidRequestError value)
    {
        Value = value;
    }

    public BetaError(BetaAuthenticationError value)
    {
        Value = value;
    }

    public BetaError(BetaBillingError value)
    {
        Value = value;
    }

    public BetaError(BetaPermissionError value)
    {
        Value = value;
    }

    public BetaError(BetaNotFoundError value)
    {
        Value = value;
    }

    public BetaError(BetaRateLimitError value)
    {
        Value = value;
    }

    public BetaError(BetaGatewayTimeoutError value)
    {
        Value = value;
    }

    public BetaError(BetaAPIError value)
    {
        Value = value;
    }

    public BetaError(BetaOverloadedError value)
    {
        Value = value;
    }

    BetaError(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaError CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickInvalidRequest([NotNullWhen(true)] out BetaInvalidRequestError? value)
    {
        value = this.Value as BetaInvalidRequestError;
        return value != null;
    }

    public bool TryPickAuthentication([NotNullWhen(true)] out BetaAuthenticationError? value)
    {
        value = this.Value as BetaAuthenticationError;
        return value != null;
    }

    public bool TryPickBilling([NotNullWhen(true)] out BetaBillingError? value)
    {
        value = this.Value as BetaBillingError;
        return value != null;
    }

    public bool TryPickPermission([NotNullWhen(true)] out BetaPermissionError? value)
    {
        value = this.Value as BetaPermissionError;
        return value != null;
    }

    public bool TryPickNotFound([NotNullWhen(true)] out BetaNotFoundError? value)
    {
        value = this.Value as BetaNotFoundError;
        return value != null;
    }

    public bool TryPickRateLimit([NotNullWhen(true)] out BetaRateLimitError? value)
    {
        value = this.Value as BetaRateLimitError;
        return value != null;
    }

    public bool TryPickGatewayTimeout([NotNullWhen(true)] out BetaGatewayTimeoutError? value)
    {
        value = this.Value as BetaGatewayTimeoutError;
        return value != null;
    }

    public bool TryPickAPI([NotNullWhen(true)] out BetaAPIError? value)
    {
        value = this.Value as BetaAPIError;
        return value != null;
    }

    public bool TryPickOverloaded([NotNullWhen(true)] out BetaOverloadedError? value)
    {
        value = this.Value as BetaOverloadedError;
        return value != null;
    }

    public void Switch(
        Action<BetaInvalidRequestError> invalidRequest,
        Action<BetaAuthenticationError> authentication,
        Action<BetaBillingError> billing,
        Action<BetaPermissionError> permission,
        Action<BetaNotFoundError> notFound,
        Action<BetaRateLimitError> rateLimit,
        Action<BetaGatewayTimeoutError> gatewayTimeout,
        Action<BetaAPIError> api,
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
            case BetaAPIError value:
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

    public T Match<T>(
        Func<BetaInvalidRequestError, T> invalidRequest,
        Func<BetaAuthenticationError, T> authentication,
        Func<BetaBillingError, T> billing,
        Func<BetaPermissionError, T> permission,
        Func<BetaNotFoundError, T> notFound,
        Func<BetaRateLimitError, T> rateLimit,
        Func<BetaGatewayTimeoutError, T> gatewayTimeout,
        Func<BetaAPIError, T> api,
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
            BetaAPIError value => api(value),
            BetaOverloadedError value => overloaded(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaError"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of BetaError");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaInvalidRequestError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaInvalidRequestError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaAuthenticationError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaAuthenticationError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaBillingError>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaBillingError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaPermissionError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaPermissionError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaNotFoundError>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaNotFoundError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaRateLimitError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaRateLimitError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaGatewayTimeoutError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaGatewayTimeoutError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaAPIError>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaAPIError'",
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
                    var deserialized = JsonSerializer.Deserialize<BetaOverloadedError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaError(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaOverloadedError'",
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
        BetaError value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
