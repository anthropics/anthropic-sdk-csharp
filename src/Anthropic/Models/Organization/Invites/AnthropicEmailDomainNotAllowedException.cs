using System.Net.Http;
using System.Text.Json;
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
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(
                    WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                        ?? default,
                    "details"
                ) ?? default,
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
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
