using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Users;

/// <summary>
/// The user is the organization's only member. Add another member before removing
/// this one.
/// </summary>
public sealed class AnthropicCannotRemoveLastMemberException : AnthropicBadRequestException
{
    public AnthropicCannotRemoveLastMemberException(HttpRequestException? innerException = null)
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
    public new CannotRemoveLastMemberErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<CannotRemoveLastMemberErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
