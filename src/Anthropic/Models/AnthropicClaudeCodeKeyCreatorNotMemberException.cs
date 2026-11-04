using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The API key belongs to the Claude Code workspace, and the user who created it
/// is no longer a member of the organization or of that workspace.
/// </summary>
public sealed class AnthropicClaudeCodeKeyCreatorNotMemberException : AnthropicBadRequestException
{
    public AnthropicClaudeCodeKeyCreatorNotMemberException(
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
    public new ClaudeCodeKeyCreatorNotMemberErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ClaudeCodeKeyCreatorNotMemberErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
