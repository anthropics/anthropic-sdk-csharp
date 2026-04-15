using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Helpers.Beta;

/// <summary>
/// A tool that can be executed locally by the <see cref="BetaToolRunner"/>.
/// When the model requests this tool, the runner invokes <see cref="ExecuteAsync"/> and
/// feeds the result back as a <c>tool_result</c> message.
/// </summary>
public interface IBetaRunnableTool
{
    /// <summary>
    /// The tool name used to match <c>tool_use</c> blocks from the model's response.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The tool definition sent to the API so the model knows the tool is available.
    /// </summary>
    BetaToolUnion Definition { get; }

    /// <summary>
    /// Executes the tool with the given input and returns the result content.
    /// </summary>
    Task<BetaToolResultBlockParamContent> ExecuteAsync(
        BetaToolUseBlock toolUseBlock,
        CancellationToken cancellationToken
    );
}

/// <summary>
/// A convenience implementation of <see cref="IBetaRunnableTool"/> that wraps a delegate.
/// </summary>
public class BetaRunnableTool : IBetaRunnableTool
{
    /// <inheritdoc />
    public required string Name { get; init; }

    /// <inheritdoc />
    public required BetaToolUnion Definition { get; init; }

    /// <summary>
    /// An async callback that receives the <see cref="BetaToolUseBlock"/> and a
    /// <see cref="CancellationToken"/>, and returns the tool result content.
    /// </summary>
    public required Func<
        BetaToolUseBlock,
        CancellationToken,
        Task<BetaToolResultBlockParamContent>
    > Run { get; init; }

    /// <inheritdoc />
    public Task<BetaToolResultBlockParamContent> ExecuteAsync(
        BetaToolUseBlock toolUseBlock,
        CancellationToken cancellationToken
    )
    {
        return Run(toolUseBlock, cancellationToken);
    }
}
