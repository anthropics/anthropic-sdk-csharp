using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// One of the organization's approvals from Anthropic could not be read right now,
/// so nothing was done. Retry after the `Retry-After` delay.
/// </summary>
public sealed class AnthropicBetaAuthorizationCheckUnavailableException
    : AnthropicServiceUnavailableException
{
    public AnthropicBetaAuthorizationCheckUnavailableException(
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
    public new BetaAuthorizationCheckUnavailableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaAuthorizationCheckUnavailableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
