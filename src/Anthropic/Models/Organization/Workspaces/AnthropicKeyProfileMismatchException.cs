using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// The External Key is bound to a user profile, and the Workspace does not have that
/// user profile. A Workspace can use only a key bound to its own user profile or
/// a key that isn't bound to one.
/// </summary>
public sealed class AnthropicKeyProfileMismatchException : AnthropicBadRequestException
{
    public AnthropicKeyProfileMismatchException(HttpRequestException? innerException = null)
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
    public new KeyProfileMismatchErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<KeyProfileMismatchErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
