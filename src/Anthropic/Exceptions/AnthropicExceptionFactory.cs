using System;
using System.Net;
using System.Text.Json;
using Anthropic.Models;

namespace Anthropic.Exceptions;

public class AnthropicExceptionFactory
{
    public static AnthropicApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        var errorType = ExtractErrorType(responseBody);

        return (int)statusCode switch
        {
            400 => new AnthropicBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            401 => new AnthropicUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            403 => new AnthropicForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            404 => new AnthropicNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            422 => new AnthropicUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            429 => new AnthropicRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            >= 400 and <= 499 => new Anthropic4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            >= 500 and <= 599 => new Anthropic5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
            _ => new AnthropicUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                ErrorType = errorType,
            },
        };
    }

    internal static ErrorType? ExtractErrorType(string jsonBody)
    {
        try
        {
            using var doc = JsonDocument.Parse(jsonBody);
            if (
                doc.RootElement.TryGetProperty("error", out var errorElement)
                && errorElement.TryGetProperty("type", out var typeElement)
                && typeElement.ValueKind == JsonValueKind.String
            )
            {
                var result = typeElement.Deserialize<ErrorType>();
                return Enum.IsDefined(typeof(ErrorType), result) ? result : null;
            }
        }
        catch (JsonException)
        {
            // Response body isn't valid JSON — leave ErrorType as null
        }
        return null;
    }
}
