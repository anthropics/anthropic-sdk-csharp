using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The workspace's customer-managed encryption key could not be reached. Retry the
/// request; if this continues, check that the key is available in your key management
/// service, or contact Anthropic support.
/// </summary>
public sealed class AnthropicCmekKeyUnreachableException : AnthropicServiceUnavailableException
{
    public AnthropicCmekKeyUnreachableException(HttpRequestException? innerException = null)
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
    public new CmekKeyUnreachableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CmekKeyUnreachableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
