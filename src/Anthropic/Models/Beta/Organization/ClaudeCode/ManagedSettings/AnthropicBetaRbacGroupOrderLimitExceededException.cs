using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

/// <summary>
/// The RBAC Group order already has the most groups allowed. Delete another group's
/// settings first.
/// </summary>
public sealed class AnthropicBetaRbacGroupOrderLimitExceededException : AnthropicBadRequestException
{
    public AnthropicBetaRbacGroupOrderLimitExceededException(
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
    public new BetaRbacGroupOrderLimitExceededErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaRbacGroupOrderLimitExceededErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
