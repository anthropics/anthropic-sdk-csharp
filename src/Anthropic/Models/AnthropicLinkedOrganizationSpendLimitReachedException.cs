using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The organization linked to the request's user profile has reached a spend limit
/// that it set, or lacks credit for the request. The response does not say which applies.
/// </summary>
public sealed class AnthropicLinkedOrganizationSpendLimitReachedException
    : AnthropicPaymentRequiredException
{
    public AnthropicLinkedOrganizationSpendLimitReachedException(
        HttpRequestException? innerException = null
    )
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
    public new LinkedOrganizationSpendLimitReachedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<LinkedOrganizationSpendLimitReachedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
