using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// The feature isn't offered to this organization. The error's `message` names the
/// kind of organization or, when it names none, says to contact your Anthropic account team.
/// </summary>
public sealed class AnthropicBetaOrganizationNotEligibleException : AnthropicBadRequestException
{
    public AnthropicBetaOrganizationNotEligibleException(
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
    public new BetaOrganizationNotEligibleErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaOrganizationNotEligibleErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
