using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Invites;

/// <summary>
/// The email address's domain is not one of the verified domains of the organization's
/// parent organization.
/// </summary>
public sealed class AnthropicCannotInviteEmailsWithUnverifiedDomainsException
    : AnthropicBadRequestException
{
    public AnthropicCannotInviteEmailsWithUnverifiedDomainsException(
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
    public new CannotInviteEmailsWithUnverifiedDomainsErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CannotInviteEmailsWithUnverifiedDomainsErrorDetails>(
                WrappedJsonSerializer.GetNullableStructProperty<JsonElement>(this.Body, "error")
                    ?? default,
                "details"
            );
        }
    }
}
