using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is the organization's primary owner, whom no API key or token can
/// sign out.
/// </summary>
public sealed class AnthropicBetaCannotSignOutPrimaryOwnerException : AnthropicBadRequestException
{
    public AnthropicBetaCannotSignOutPrimaryOwnerException(
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
    public new BetaCannotSignOutPrimaryOwnerErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutPrimaryOwnerErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
