using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.BetaErrorVariants;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(BetaErrorConverter))]
public abstract record class BetaError
{
    internal BetaError() { }

    public static implicit operator BetaError(BetaInvalidRequestError value) =>
        new BetaInvalidRequestErrorVariant(value);

    public static implicit operator BetaError(BetaAuthenticationError value) =>
        new BetaAuthenticationErrorVariant(value);

    public static implicit operator BetaError(BetaBillingError value) =>
        new BetaBillingErrorVariant(value);

    public static implicit operator BetaError(BetaPermissionError value) =>
        new BetaPermissionErrorVariant(value);

    public static implicit operator BetaError(BetaNotFoundError value) =>
        new BetaNotFoundErrorVariant(value);

    public static implicit operator BetaError(BetaRateLimitError value) =>
        new BetaRateLimitErrorVariant(value);

    public static implicit operator BetaError(BetaGatewayTimeoutError value) =>
        new BetaGatewayTimeoutErrorVariant(value);

    public static implicit operator BetaError(BetaAPIError value) => new BetaAPIErrorVariant(value);

    public static implicit operator BetaError(BetaOverloadedError value) =>
        new BetaOverloadedErrorVariant(value);

    public bool TryPickBetaInvalidRequestErrorVariant(
        [NotNullWhen(true)] out BetaInvalidRequestError? value
    )
    {
        value = (this as BetaInvalidRequestErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaAuthenticationErrorVariant(
        [NotNullWhen(true)] out BetaAuthenticationError? value
    )
    {
        value = (this as BetaAuthenticationErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaBillingErrorVariant([NotNullWhen(true)] out BetaBillingError? value)
    {
        value = (this as BetaBillingErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaPermissionErrorVariant(
        [NotNullWhen(true)] out BetaPermissionError? value
    )
    {
        value = (this as BetaPermissionErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaNotFoundErrorVariant([NotNullWhen(true)] out BetaNotFoundError? value)
    {
        value = (this as BetaNotFoundErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaRateLimitErrorVariant([NotNullWhen(true)] out BetaRateLimitError? value)
    {
        value = (this as BetaRateLimitErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaGatewayTimeoutErrorVariant(
        [NotNullWhen(true)] out BetaGatewayTimeoutError? value
    )
    {
        value = (this as BetaGatewayTimeoutErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaAPIErrorVariant([NotNullWhen(true)] out BetaAPIError? value)
    {
        value = (this as BetaAPIErrorVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaOverloadedErrorVariant(
        [NotNullWhen(true)] out BetaOverloadedError? value
    )
    {
        value = (this as BetaOverloadedErrorVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaInvalidRequestErrorVariant> betaInvalidRequestError,
        Action<BetaAuthenticationErrorVariant> betaAuthenticationError,
        Action<BetaBillingErrorVariant> betaBillingError,
        Action<BetaPermissionErrorVariant> betaPermissionError,
        Action<BetaNotFoundErrorVariant> betaNotFoundError,
        Action<BetaRateLimitErrorVariant> betaRateLimitError,
        Action<BetaGatewayTimeoutErrorVariant> betaGatewayTimeoutError,
        Action<BetaAPIErrorVariant> betaAPIError,
        Action<BetaOverloadedErrorVariant> betaOverloadedError
    )
    {
        switch (this)
        {
            case BetaInvalidRequestErrorVariant inner:
                betaInvalidRequestError(inner);
                break;
            case BetaAuthenticationErrorVariant inner:
                betaAuthenticationError(inner);
                break;
            case BetaBillingErrorVariant inner:
                betaBillingError(inner);
                break;
            case BetaPermissionErrorVariant inner:
                betaPermissionError(inner);
                break;
            case BetaNotFoundErrorVariant inner:
                betaNotFoundError(inner);
                break;
            case BetaRateLimitErrorVariant inner:
                betaRateLimitError(inner);
                break;
            case BetaGatewayTimeoutErrorVariant inner:
                betaGatewayTimeoutError(inner);
                break;
            case BetaAPIErrorVariant inner:
                betaAPIError(inner);
                break;
            case BetaOverloadedErrorVariant inner:
                betaOverloadedError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaInvalidRequestErrorVariant, T> betaInvalidRequestError,
        Func<BetaAuthenticationErrorVariant, T> betaAuthenticationError,
        Func<BetaBillingErrorVariant, T> betaBillingError,
        Func<BetaPermissionErrorVariant, T> betaPermissionError,
        Func<BetaNotFoundErrorVariant, T> betaNotFoundError,
        Func<BetaRateLimitErrorVariant, T> betaRateLimitError,
        Func<BetaGatewayTimeoutErrorVariant, T> betaGatewayTimeoutError,
        Func<BetaAPIErrorVariant, T> betaAPIError,
        Func<BetaOverloadedErrorVariant, T> betaOverloadedError
    )
    {
        return this switch
        {
            BetaInvalidRequestErrorVariant inner => betaInvalidRequestError(inner),
            BetaAuthenticationErrorVariant inner => betaAuthenticationError(inner),
            BetaBillingErrorVariant inner => betaBillingError(inner),
            BetaPermissionErrorVariant inner => betaPermissionError(inner),
            BetaNotFoundErrorVariant inner => betaNotFoundError(inner),
            BetaRateLimitErrorVariant inner => betaRateLimitError(inner),
            BetaGatewayTimeoutErrorVariant inner => betaGatewayTimeoutError(inner),
            BetaAPIErrorVariant inner => betaAPIError(inner),
            BetaOverloadedErrorVariant inner => betaOverloadedError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaErrorConverter : JsonConverter<BetaError>
{
    public override BetaError? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaInvalidRequestError>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaInvalidRequestErrorVariant(deserialized);
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
                        return new BetaAuthenticationErrorVariant(deserialized);
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
                        return new BetaBillingErrorVariant(deserialized);
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
                        return new BetaPermissionErrorVariant(deserialized);
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
                        return new BetaNotFoundErrorVariant(deserialized);
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
                        return new BetaRateLimitErrorVariant(deserialized);
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
                        return new BetaGatewayTimeoutErrorVariant(deserialized);
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
                        return new BetaAPIErrorVariant(deserialized);
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
                        return new BetaOverloadedErrorVariant(deserialized);
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
            BetaInvalidRequestErrorVariant(var betaInvalidRequestError) => betaInvalidRequestError,
            BetaAuthenticationErrorVariant(var betaAuthenticationError) => betaAuthenticationError,
            BetaBillingErrorVariant(var betaBillingError) => betaBillingError,
            BetaPermissionErrorVariant(var betaPermissionError) => betaPermissionError,
            BetaNotFoundErrorVariant(var betaNotFoundError) => betaNotFoundError,
            BetaRateLimitErrorVariant(var betaRateLimitError) => betaRateLimitError,
            BetaGatewayTimeoutErrorVariant(var betaGatewayTimeoutError) => betaGatewayTimeoutError,
            BetaAPIErrorVariant(var betaAPIError) => betaAPIError,
            BetaOverloadedErrorVariant(var betaOverloadedError) => betaOverloadedError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
