using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// The organization restricts invites to an allowed list of email domains, and the
/// list is empty or does not include the email address's domain.
/// </summary>
public sealed class AnthropicEmailDomainNotAllowedException : AnthropicBadRequestException
{
    public AnthropicEmailDomainNotAllowedException(HttpRequestException? innerException = null)
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
    public new EmailDomainNotAllowedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<EmailDomainNotAllowedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
