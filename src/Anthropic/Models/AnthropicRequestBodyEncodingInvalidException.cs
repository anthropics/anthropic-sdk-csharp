using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request body is not valid for its `Content-Encoding`.
/// </summary>
public sealed class AnthropicRequestBodyEncodingInvalidException : AnthropicBadRequestException
{
    public AnthropicRequestBodyEncodingInvalidException(HttpRequestException? innerException = null)
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
    public new RequestBodyEncodingInvalidErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<RequestBodyEncodingInvalidErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
