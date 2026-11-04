using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// A pending invite already exists for the email address. The message names the invite.
/// </summary>
public sealed class AnthropicInviteAlreadyExistsException : AnthropicBadRequestException
{
    public AnthropicInviteAlreadyExistsException(HttpRequestException? innerException = null)
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
    public new InviteAlreadyExistsErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<InviteAlreadyExistsErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
