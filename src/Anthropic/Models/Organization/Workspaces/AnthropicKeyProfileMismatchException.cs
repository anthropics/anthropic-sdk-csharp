using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Workspaces;

/// <summary>
/// After this request, the External Key and the Workspace would not have the same
/// user profile. A key and its Workspace must have the same user profile, or both
/// have none.
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
