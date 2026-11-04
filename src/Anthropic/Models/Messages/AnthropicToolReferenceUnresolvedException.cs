using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A tool change or MCP tool listing references a tool or MCP server that is not
/// defined at that position in the conversation.
/// </summary>
public sealed class AnthropicToolReferenceUnresolvedException : AnthropicBadRequestException
{
    public AnthropicToolReferenceUnresolvedException(HttpRequestException? innerException = null)
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
    public new ToolReferenceUnresolvedErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ToolReferenceUnresolvedErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
