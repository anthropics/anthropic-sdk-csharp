using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The request's `Content-Type` header names a charset other than UTF-8, ISO-8859-1
/// or US-ASCII. Send the request with no charset, or with one of these.
/// </summary>
public sealed class AnthropicBetaUnsupportedCharsetException : AnthropicBadRequestException
{
    public AnthropicBetaUnsupportedCharsetException(HttpRequestException? innerException = null)
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
    public new BetaUnsupportedCharsetErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaUnsupportedCharsetErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
