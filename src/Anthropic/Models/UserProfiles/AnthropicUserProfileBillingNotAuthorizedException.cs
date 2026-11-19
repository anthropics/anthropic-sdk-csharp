using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The customer that the request's user profile represents has not authorized the
/// caller to bill them, or the authorization that the request's credential uses
/// has ended. The response does not say which applies.
/// </summary>
public sealed class AnthropicUserProfileBillingNotAuthorizedException : AnthropicForbiddenException
{
    public AnthropicUserProfileBillingNotAuthorizedException(
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
    public new UserProfileBillingNotAuthorizedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<UserProfileBillingNotAuthorizedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
