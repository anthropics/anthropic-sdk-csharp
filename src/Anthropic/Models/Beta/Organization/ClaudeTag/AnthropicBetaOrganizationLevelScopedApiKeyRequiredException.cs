using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The credential is not a scoped API key that is bound at the organization level.
/// </summary>
public sealed class AnthropicBetaOrganizationLevelScopedApiKeyRequiredException
    : AnthropicForbiddenException
{
    public AnthropicBetaOrganizationLevelScopedApiKeyRequiredException(
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
    public new BetaOrganizationLevelScopedApiKeyRequiredErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaOrganizationLevelScopedApiKeyRequiredErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
