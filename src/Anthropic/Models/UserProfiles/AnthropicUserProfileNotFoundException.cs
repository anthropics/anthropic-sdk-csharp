using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// The request depends on a user profile that does not exist in the organization
/// or is no longer active. The request either names this user profile by ID, or names
/// a resource, such as an External Key, that is bound to it.
/// </summary>
public sealed class AnthropicUserProfileNotFoundException : AnthropicBadRequestException
{
    public AnthropicUserProfileNotFoundException(HttpRequestException? innerException = null)
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
    public new UserProfileNotFoundErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<UserProfileNotFoundErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
