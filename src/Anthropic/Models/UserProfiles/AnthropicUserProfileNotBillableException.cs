using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The request's user profile cannot be billed. The response gives no more specific
/// error code and does not say what the reason is.
/// </summary>
public sealed class AnthropicUserProfileNotBillableException : AnthropicForbiddenException
{
    public AnthropicUserProfileNotBillableException(HttpRequestException? innerException = null)
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
    public new UserProfileNotBillableErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<UserProfileNotBillableErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
