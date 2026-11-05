using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is a membership admin, and the person the API key or token belongs
/// to is not allowed to sign out membership admins.
/// </summary>
public sealed class AnthropicBetaCannotSignOutMembershipAdminException : AnthropicForbiddenException
{
    public AnthropicBetaCannotSignOutMembershipAdminException(
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
    public new BetaCannotSignOutMembershipAdminErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutMembershipAdminErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
