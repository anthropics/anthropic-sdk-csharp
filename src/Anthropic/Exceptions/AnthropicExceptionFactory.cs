using System;
using System.Net;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Exceptions;

public class AnthropicExceptionFactory
{
    public static AnthropicApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    ) => CreateApiException(statusCode, responseBody, null);

    internal static AnthropicApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody,
        HttpResponse? response
    )
    {
        var errorType = ExtractErrorType(responseBody);

        return (int)statusCode switch
        {
            400 => new AnthropicBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            401 => new AnthropicUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            403 => new AnthropicForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            404 => new AnthropicNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            422 => new AnthropicUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            429 => new AnthropicRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            >= 400 and <= 499 => new Anthropic4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            >= 500 and <= 599 => new Anthropic5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
                ErrorType = errorType,
            },
            _ => new AnthropicUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
                RequestID = response?.RequestID,
                WorkspaceID = response?.WorkspaceID,
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
                doc.RootElement.ValueKind == JsonValueKind.Object
                && doc.RootElement.TryGetProperty("error", out var errorElement)
                && errorElement.ValueKind == JsonValueKind.Object
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
