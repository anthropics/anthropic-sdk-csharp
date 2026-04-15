using System;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Beta;

/// <summary>
/// An exception that carries structured content to be returned to the model as an
/// error tool result. Throw this from <see cref="IBetaRunnableTool.ExecuteAsync"/> to
/// provide richer error feedback than a plain exception message.
/// </summary>
public class BetaToolError : Exception
{
    /// <summary>
    /// The content to return to the model as the tool result with <c>is_error: true</c>.
    /// </summary>
    public BetaToolResultBlockParamContent Content { get; }

    /// <summary>
    /// Creates a tool error with a string message as the error content.
    /// </summary>
    public BetaToolError(string content)
        : base(content)
    {
        Content = content;
    }

    /// <summary>
    /// Creates a tool error with structured content blocks as the error content.
    /// </summary>
    public BetaToolError(BetaToolResultBlockParamContent content)
        : base("Tool execution error")
    {
        Content = content;
    }

    /// <summary>
    /// Creates a tool error with a string message and an inner exception.
    /// </summary>
    public BetaToolError(string content, Exception innerException)
        : base(content, innerException)
    {
        Content = content;
    }
}
