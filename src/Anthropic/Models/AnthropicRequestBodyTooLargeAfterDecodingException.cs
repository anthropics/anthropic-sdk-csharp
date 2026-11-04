using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The compressed request body exceeds the request size limit once decoded.
/// </summary>
public sealed class AnthropicRequestBodyTooLargeAfterDecodingException
    : AnthropicContentTooLargeException
{
    public AnthropicRequestBodyTooLargeAfterDecodingException(
        HttpRequestException? innerException = null
    )
        : base(innerException) { }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new string ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<string>(
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
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new RequestBodyTooLargeAfterDecodingErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RequestBodyTooLargeAfterDecodingErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
