using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

/// <summary>
/// The organization cannot retrieve, set or delete spend limits with an Admin API credential.
/// </summary>
public sealed class AnthropicBetaSpendLimitsAdminApiWritesNotEnabledException
    : AnthropicForbiddenException
{
    public AnthropicBetaSpendLimitsAdminApiWritesNotEnabledException(
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
    public new BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaSpendLimitsAdminApiWritesNotEnabledErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
