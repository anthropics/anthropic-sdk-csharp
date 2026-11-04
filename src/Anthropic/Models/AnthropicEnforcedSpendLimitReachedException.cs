using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The organization has crossed the monthly API usage threshold of its API tier.
/// </summary>
public sealed class AnthropicEnforcedSpendLimitReachedException : AnthropicRateLimitException
{
    public AnthropicEnforcedSpendLimitReachedException(HttpRequestException? innerException = null)
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
    public new EnforcedSpendLimitReachedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<EnforcedSpendLimitReachedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
