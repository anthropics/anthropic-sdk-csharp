using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag;

/// <summary>
/// The API key lacks the scope the request needs: `read:claude_tag` for a read, `write:claude_tag`
/// for a change.
/// </summary>
public sealed class AnthropicBetaApiKeyScopeMissingException : AnthropicForbiddenException
{
    public AnthropicBetaApiKeyScopeMissingException(HttpRequestException? innerException = null)
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
    public new BetaApiKeyScopeMissingErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<BetaApiKeyScopeMissingErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
