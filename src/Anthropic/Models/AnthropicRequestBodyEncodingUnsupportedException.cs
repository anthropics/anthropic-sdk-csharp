using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's `Content-Encoding` is not supported.
/// </summary>
public sealed class AnthropicRequestBodyEncodingUnsupportedException : AnthropicBadRequestException
{
    public AnthropicRequestBodyEncodingUnsupportedException(
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
    public new RequestBodyEncodingUnsupportedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RequestBodyEncodingUnsupportedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
