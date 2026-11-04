using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The request comes from a Claude Code version older than the minimum that the
/// requested model or the organization requires. Update Claude Code, then retry.
/// </summary>
public sealed class AnthropicClaudeCodeVersionTooOldException : AnthropicBadRequestException
{
    public AnthropicClaudeCodeVersionTooOldException(HttpRequestException? innerException = null)
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
    public new ClaudeCodeVersionTooOldErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ClaudeCodeVersionTooOldErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
