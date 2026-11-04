using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The organization's compliance configuration does not let Claude Tag store anything new.
/// </summary>
public sealed class AnthropicBetaComplianceConfigurationRestrictedException
    : AnthropicForbiddenException
{
    public AnthropicBetaComplianceConfigurationRestrictedException(
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
    public new BetaComplianceConfigurationRestrictedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaComplianceConfigurationRestrictedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
