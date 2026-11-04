using System;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Exceptions;

public class AnthropicServiceException : AnthropicException
{
    public AnthropicServiceException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected AnthropicServiceException(HttpRequestException? innerException)
        : base(innerException) { }

    /// <summary>
    /// The JSON the service described the error with, or <c>default</c> if it sent none.
    /// </summary>
    public JsonElement Body { get; init; }

    /// <summary>
    /// <c>error.message</c> of <see cref="AnthropicServiceException.Body"/>, or null if it can't be read as this type.
    /// </summary>
    public string? ApiMessage
    {
        get
        {
            return WrappedJsonSerializer.GetNullableClassProperty<string>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "message"
            );
        }
    }

    /// <summary>
    /// <c>error.type</c> of <see cref="AnthropicServiceException.Body"/>, or null if it can't be read as this type.
    /// </summary>
    public ApiEnum<string, ErrorType>? Type
    {
        get
        {
            return WrappedJsonSerializer.GetNullableClassProperty<ApiEnum<string, ErrorType>>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "type"
            );
        }
    }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>, or null if it can't be read as this type.
    /// </summary>
    public string? ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNullableClassProperty<string>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                        ?? default,
                    "details"
                ) ?? default,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>, or null if it can't be read as this type.
    /// </summary>
    public ErrorDetails? Details
    {
        get
        {
            return WrappedJsonSerializer.GetNullableClassProperty<ErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }

    [Obsolete("Use Type instead.")]
    public ErrorType? ErrorType
    {
        get
        {
            var type =
                _errorType
                ?? (
                    this.Type is { Json.ValueKind: JsonValueKind.String } sent
                        ? sent.Value()
                        : (ErrorType?)null
                );
            return type is { } value && Enum.IsDefined(typeof(ErrorType), value) ? value : null;
        }
        init { _errorType = value; }
    }

    readonly ErrorType? _errorType;

    internal static JsonElement ParseBody(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<JsonElement>(json);
        }
        catch (JsonException)
        {
            return default;
        }
    }
}
