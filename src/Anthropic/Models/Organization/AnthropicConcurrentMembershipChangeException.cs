using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

/// <summary>
/// Another change to the organization's members is in progress. Retry the request
/// once it completes.
/// </summary>
public sealed class AnthropicConcurrentMembershipChangeException : AnthropicConflictException
{
    public AnthropicConcurrentMembershipChangeException(HttpRequestException? innerException = null)
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
    public new ConcurrentMembershipChangeErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ConcurrentMembershipChangeErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
