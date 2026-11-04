using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A tool made available in `messages` takes a name that an available tool of another
/// kind, or of another MCP server, already holds.
/// </summary>
public sealed class AnthropicToolNameConflictException : AnthropicBadRequestException
{
    public AnthropicToolNameConflictException(HttpRequestException? innerException = null)
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
    public new ToolNameConflictErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ToolNameConflictErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
