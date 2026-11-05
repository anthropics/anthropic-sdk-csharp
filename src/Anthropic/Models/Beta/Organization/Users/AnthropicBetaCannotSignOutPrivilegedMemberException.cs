using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// This OAuth token cannot sign out a membership admin or a member whose roles grant
/// owner, user management, or identity and access management.
/// </summary>
public sealed class AnthropicBetaCannotSignOutPrivilegedMemberException
    : AnthropicForbiddenException
{
    public AnthropicBetaCannotSignOutPrivilegedMemberException(
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
    public new BetaCannotSignOutPrivilegedMemberErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutPrivilegedMemberErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
