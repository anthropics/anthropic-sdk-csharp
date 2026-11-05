using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// On a public-sector deployment, only an API key or token that belongs to a person
/// with owner permissions can sign out a member with the `managed` role.
/// </summary>
public sealed class AnthropicBetaCannotSignOutManagedMemberException : AnthropicForbiddenException
{
    public AnthropicBetaCannotSignOutManagedMemberException(
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
    public new BetaCannotSignOutManagedMemberErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutManagedMemberErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
