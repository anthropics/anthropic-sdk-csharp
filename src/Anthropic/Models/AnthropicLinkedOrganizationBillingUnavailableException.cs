using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// Anthropic cannot currently bill the organization linked to the request's user
/// profile, for a reason that lies with that organization's own account. The response
/// does not say what the reason is.
/// </summary>
public sealed class AnthropicLinkedOrganizationBillingUnavailableException
    : AnthropicPaymentRequiredException
{
    public AnthropicLinkedOrganizationBillingUnavailableException(
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
    public new LinkedOrganizationBillingUnavailableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<LinkedOrganizationBillingUnavailableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
