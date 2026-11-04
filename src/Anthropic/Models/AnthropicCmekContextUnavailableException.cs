using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request's workspace encryption context could not be resolved, so the request
/// was refused. Retry in a few minutes.
/// </summary>
public sealed class AnthropicCmekContextUnavailableException : AnthropicServiceUnavailableException
{
    public AnthropicCmekContextUnavailableException(HttpRequestException? innerException = null)
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
    public new CmekContextUnavailableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CmekContextUnavailableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
