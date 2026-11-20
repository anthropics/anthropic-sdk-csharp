using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Turning human review off needs Anthropic's approval for the organization, and
/// the organization doesn't have it. Contact Anthropic support to request approval.
/// </summary>
public sealed class AnthropicBetaApprovalRequiredException : AnthropicBadRequestException
{
    public AnthropicBetaApprovalRequiredException(HttpRequestException? innerException = null)
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
    public new BetaApprovalRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaApprovalRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
