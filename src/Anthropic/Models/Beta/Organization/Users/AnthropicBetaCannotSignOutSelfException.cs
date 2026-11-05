using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

/// <summary>
/// The member is the user the API key or token belongs to.
/// </summary>
public sealed class AnthropicBetaCannotSignOutSelfException : AnthropicBadRequestException
{
    public AnthropicBetaCannotSignOutSelfException(HttpRequestException? innerException = null)
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
    public new BetaCannotSignOutSelfErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaCannotSignOutSelfErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
