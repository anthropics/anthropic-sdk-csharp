using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ErrorObjectVariants = Anthropic.Models.ErrorObjectVariants;

namespace Anthropic.Models;

[JsonConverter(typeof(ErrorObjectConverter))]
public abstract record class ErrorObject
{
    internal ErrorObject() { }

    public static implicit operator ErrorObject(InvalidRequestError value) =>
        new ErrorObjectVariants::InvalidRequestErrorVariant(value);

    public static implicit operator ErrorObject(AuthenticationError value) =>
        new ErrorObjectVariants::AuthenticationErrorVariant(value);

    public static implicit operator ErrorObject(BillingError value) =>
        new ErrorObjectVariants::BillingErrorVariant(value);

    public static implicit operator ErrorObject(PermissionError value) =>
        new ErrorObjectVariants::PermissionErrorVariant(value);

    public static implicit operator ErrorObject(NotFoundError value) =>
        new ErrorObjectVariants::NotFoundErrorVariant(value);

    public static implicit operator ErrorObject(RateLimitError value) =>
        new ErrorObjectVariants::RateLimitErrorVariant(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) =>
        new ErrorObjectVariants::GatewayTimeoutErrorVariant(value);

    public static implicit operator ErrorObject(APIErrorObject value) =>
        new ErrorObjectVariants::APIErrorObjectVariant(value);

    public static implicit operator ErrorObject(OverloadedError value) =>
        new ErrorObjectVariants::OverloadedErrorVariant(value);

    public abstract void Validate();
}

sealed class ErrorObjectConverter : JsonConverter<ErrorObject>
{
    public override ErrorObject? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<InvalidRequestError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::InvalidRequestErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AuthenticationError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::AuthenticationErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BillingError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::BillingErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PermissionError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::PermissionErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NotFoundError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::NotFoundErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<RateLimitError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::RateLimitErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<GatewayTimeoutError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::GatewayTimeoutErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<APIErrorObject>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::APIErrorObjectVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<OverloadedError>(ref reader, options);
            if (deserialized != null)
            {
                return new ErrorObjectVariants::OverloadedErrorVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorObject value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            ErrorObjectVariants::InvalidRequestErrorVariant(var invalidRequestError) =>
                invalidRequestError,
            ErrorObjectVariants::AuthenticationErrorVariant(var authenticationError) =>
                authenticationError,
            ErrorObjectVariants::BillingErrorVariant(var billingError) => billingError,
            ErrorObjectVariants::PermissionErrorVariant(var permissionError) => permissionError,
            ErrorObjectVariants::NotFoundErrorVariant(var notFoundError) => notFoundError,
            ErrorObjectVariants::RateLimitErrorVariant(var rateLimitError) => rateLimitError,
            ErrorObjectVariants::GatewayTimeoutErrorVariant(var gatewayTimeoutError) =>
                gatewayTimeoutError,
            ErrorObjectVariants::APIErrorObjectVariant(var apiErrorObject) => apiErrorObject,
            ErrorObjectVariants::OverloadedErrorVariant(var overloadedError) => overloadedError,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
