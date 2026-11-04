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
                this.ErrorJson,
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
                this.ErrorJson,
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
                this.ErrorDetailsJson,
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
                this.ErrorJson,
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

    private protected JsonElement ErrorJson
    {
        get
        {
            return WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                ?? default;
        }
    }

    private protected JsonElement ErrorDetailsJson
    {
        get
        {
            return WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    this.ErrorJson,
                    "details"
                ) ?? default;
        }
    }
}
