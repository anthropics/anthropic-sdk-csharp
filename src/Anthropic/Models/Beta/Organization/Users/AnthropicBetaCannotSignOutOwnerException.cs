using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is an owner or has owner permissions, and this API key or token cannot
/// sign them out. In a Claude Enterprise organization, an API key with the `write:members`
/// scope can.
/// </summary>
public sealed class AnthropicBetaCannotSignOutOwnerException : AnthropicForbiddenException
{
    public AnthropicBetaCannotSignOutOwnerException(HttpRequestException? innerException = null)
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
    public new BetaCannotSignOutOwnerErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutOwnerErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
