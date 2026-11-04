using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The key management service's network access controls blocked the request to the
/// workspace's customer-managed encryption key. The key itself may be healthy.
/// </summary>
public sealed class AnthropicCmekKeyNetworkBlockedException : AnthropicBadRequestException
{
    public AnthropicCmekKeyNetworkBlockedException(HttpRequestException? innerException = null)
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
    public new CmekKeyNetworkBlockedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CmekKeyNetworkBlockedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
