using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ErrorTypeConverter))]
public enum ErrorType
{
    InvalidRequestError,
    AuthenticationError,
    PermissionError,
    NotFoundError,
    RateLimitError,
    TimeoutError,
    OverloadedError,
    ApiError,
    BillingError,
}

sealed class ErrorTypeConverter : JsonConverter<ErrorType>
{
    public override ErrorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_request_error" => ErrorType.InvalidRequestError,
            "authentication_error" => ErrorType.AuthenticationError,
            "permission_error" => ErrorType.PermissionError,
            "not_found_error" => ErrorType.NotFoundError,
            "rate_limit_error" => ErrorType.RateLimitError,
            "timeout_error" => ErrorType.TimeoutError,
            "overloaded_error" => ErrorType.OverloadedError,
            "api_error" => ErrorType.ApiError,
            "billing_error" => ErrorType.BillingError,
            _ => (ErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorType.InvalidRequestError => "invalid_request_error",
                ErrorType.AuthenticationError => "authentication_error",
                ErrorType.PermissionError => "permission_error",
                ErrorType.NotFoundError => "not_found_error",
                ErrorType.RateLimitError => "rate_limit_error",
                ErrorType.TimeoutError => "timeout_error",
                ErrorType.OverloadedError => "overloaded_error",
                ErrorType.ApiError => "api_error",
                ErrorType.BillingError => "billing_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
