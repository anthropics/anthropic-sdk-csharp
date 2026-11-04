using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// Changes through the Claude Tag API are not enabled for the organization.
/// </summary>
public sealed class AnthropicBetaClaudeTagWritesNotEnabledException : AnthropicForbiddenException
{
    public AnthropicBetaClaudeTagWritesNotEnabledException(
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
    public new BetaClaudeTagWritesNotEnabledErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaClaudeTagWritesNotEnabledErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
