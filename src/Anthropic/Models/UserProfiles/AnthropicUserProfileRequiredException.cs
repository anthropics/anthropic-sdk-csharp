using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The request sets `billing_policy.bill_to` to `"user_profile"` but names no user
/// profile. Name the profile to bill in the `anthropic-user-profile-id` header.
/// </summary>
public sealed class AnthropicUserProfileRequiredException : AnthropicBadRequestException
{
    public AnthropicUserProfileRequiredException(HttpRequestException? innerException = null)
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
    public new UserProfileRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<UserProfileRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
