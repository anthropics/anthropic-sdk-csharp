using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization;

/// <summary>
/// Anthropic has temporarily disabled billing changes for the user account the credential
/// belongs to. Contact support.
/// </summary>
public sealed class AnthropicBetaBillingFrozenException : AnthropicForbiddenException
{
    public AnthropicBetaBillingFrozenException(HttpRequestException? innerException = null)
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
    public new BetaBillingFrozenErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaBillingFrozenErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
