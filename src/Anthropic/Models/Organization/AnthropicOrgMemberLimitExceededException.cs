using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// The organization has reached the member limit that Anthropic set for it. Pending
/// invites count toward the limit.
/// </summary>
public sealed class AnthropicOrgMemberLimitExceededException : AnthropicBadRequestException
{
    public AnthropicOrgMemberLimitExceededException(HttpRequestException? innerException = null)
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
    public new OrgMemberLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<OrgMemberLimitExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
