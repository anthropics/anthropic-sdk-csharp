using System.Net.Http;
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
                this.ErrorDetailsJson,
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
                this.ErrorJson,
                "details"
            );
        }
    }
}
