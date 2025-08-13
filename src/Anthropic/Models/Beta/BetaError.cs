using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaErrorVariants = Anthropic.Models.Beta.BetaErrorVariants;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(BetaErrorConverter))]
public abstract record class BetaError
{
    internal BetaError() { }

    public static implicit operator BetaError(BetaInvalidRequestError value) =>
        new BetaErrorVariants::BetaInvalidRequestErrorVariant(value);

    public static implicit operator BetaError(BetaAuthenticationError value) =>
        new BetaErrorVariants::BetaAuthenticationErrorVariant(value);

    public static implicit operator BetaError(BetaBillingError value) =>
        new BetaErrorVariants::BetaBillingErrorVariant(value);

    public static implicit operator BetaError(BetaPermissionError value) =>
        new BetaErrorVariants::BetaPermissionErrorVariant(value);

    public static implicit operator BetaError(BetaNotFoundError value) =>
        new BetaErrorVariants::BetaNotFoundErrorVariant(value);

    public static implicit operator BetaError(BetaRateLimitError value) =>
        new BetaErrorVariants::BetaRateLimitErrorVariant(value);

    public static implicit operator BetaError(BetaGatewayTimeoutError value) =>
        new BetaErrorVariants::BetaGatewayTimeoutErrorVariant(value);

    public static implicit operator BetaError(BetaAPIError value) =>
        new BetaErrorVariants::BetaAPIErrorVariant(value);

    public static implicit operator BetaError(BetaOverloadedError value) =>
        new BetaErrorVariants::BetaOverloadedErrorVariant(value);

    public abstract void Validate();
}

sealed class BetaErrorConverter : JsonConverter<BetaError>
{
    public override BetaError? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new BetaErrorVariants::BetaInvalidRequestErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaErrorVariants::BetaAuthenticationErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "billing_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBillingError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaBillingErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaErrorVariants::BetaPermissionErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "not_found_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaNotFoundError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaNotFoundErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaErrorVariants::BetaRateLimitErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaErrorVariants::BetaGatewayTimeoutErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "api_error":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAPIError>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaErrorVariants::BetaAPIErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new BetaErrorVariants::BetaOverloadedErrorVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            BetaErrorVariants::BetaInvalidRequestErrorVariant(var betaInvalidRequestError) =>
                betaInvalidRequestError,
            BetaErrorVariants::BetaAuthenticationErrorVariant(var betaAuthenticationError) =>
                betaAuthenticationError,
            BetaErrorVariants::BetaBillingErrorVariant(var betaBillingError) => betaBillingError,
            BetaErrorVariants::BetaPermissionErrorVariant(var betaPermissionError) =>
                betaPermissionError,
            BetaErrorVariants::BetaNotFoundErrorVariant(var betaNotFoundError) => betaNotFoundError,
            BetaErrorVariants::BetaRateLimitErrorVariant(var betaRateLimitError) =>
                betaRateLimitError,
            BetaErrorVariants::BetaGatewayTimeoutErrorVariant(var betaGatewayTimeoutError) =>
                betaGatewayTimeoutError,
            BetaErrorVariants::BetaAPIErrorVariant(var betaAPIError) => betaAPIError,
            BetaErrorVariants::BetaOverloadedErrorVariant(var betaOverloadedError) =>
                betaOverloadedError,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
