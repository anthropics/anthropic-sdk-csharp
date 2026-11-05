using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

/// <summary>
/// The beta that the endpoint requires is not enabled for the organization. The message
/// names the beta value.
/// </summary>
public sealed class AnthropicBetaOrganizationNotEnrolledInBetaException
    : AnthropicBadRequestException
{
    public AnthropicBetaOrganizationNotEnrolledInBetaException(
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
    public new BetaOrganizationNotEnrolledInBetaErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaOrganizationNotEnrolledInBetaErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
