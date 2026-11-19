using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The request body did not finish arriving in time, so nothing was done. Send a
/// smaller body, or send it over a faster connection.
/// </summary>
public sealed class AnthropicBetaRequestBodyTimeoutException : AnthropicBadRequestException
{
    public AnthropicBetaRequestBodyTimeoutException(HttpRequestException? innerException = null)
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
    public new BetaRequestBodyTimeoutErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaRequestBodyTimeoutErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
