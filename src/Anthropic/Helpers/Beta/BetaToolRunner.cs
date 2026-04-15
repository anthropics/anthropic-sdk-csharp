using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

namespace Anthropic.Helpers.Beta;

/// <summary>
/// Automates the multi-turn conversation loop between the model and client-side tools.
/// The runner makes API calls, detects <c>tool_use</c> content blocks, executes matching
/// tools locally, feeds results back as <c>tool_result</c> messages, and repeats until
/// the model produces a final response with no tool calls or <c>maxIterations</c> is reached.
/// </summary>
public class BetaToolRunner : IAsyncEnumerable<BetaMessage>
{
    private readonly IMessageService _service;
    private readonly Dictionary<string, IBetaRunnableTool> _toolsByName;
    private readonly IReadOnlyList<BetaToolUnion> _allToolDefinitions;
    private readonly int? _maxIterations;
    private int _consumed;

    private MessageCreateParams _currentParams;
    private bool _paramsMutated;

    internal BetaToolRunner(
        IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations
    )
    {
        _service = service;
        _maxIterations = maxIterations;

        _toolsByName = new Dictionary<string, IBetaRunnableTool>(StringComparer.Ordinal);
        var allDefs = new List<BetaToolUnion>();

        foreach (var tool in tools)
        {
            _toolsByName[tool.Name] = tool;
            allDefs.Add(tool.Definition);
        }

        // Include any plain (non-runnable) tool definitions from the original params.
        if (parameters.Tools != null)
        {
            foreach (var def in parameters.Tools)
            {
                allDefs.Add(def);
            }
        }

        _allToolDefinitions = allDefs;

        // Inject the helper header into the base params.
        _currentParams = InjectHelperHeader(parameters);
    }

    /// <summary>
    /// The current parameters that will be used for the next API call.
    /// </summary>
    public MessageCreateParams Params => _currentParams;

    /// <summary>
    /// Replaces the runner's parameters for the next API call.
    /// When called during iteration, the runner skips auto-appending the current
    /// assistant message to history for that turn.
    /// </summary>
    public void SetParams(MessageCreateParams parameters)
    {
        _currentParams = InjectHelperHeader(parameters);
        _paramsMutated = true;
    }

    /// <summary>
    /// Replaces the runner's parameters using a mutator function.
    /// When called during iteration, the runner skips auto-appending the current
    /// assistant message to history for that turn.
    /// </summary>
    public void SetParams(Func<MessageCreateParams, MessageCreateParams> mutator)
    {
        _currentParams = InjectHelperHeader(mutator(_currentParams));
        _paramsMutated = true;
    }

    /// <summary>
    /// Appends one or more messages to the conversation history without replacing all params.
    /// When called during iteration, the runner skips auto-appending the current
    /// assistant message to history for that turn.
    /// </summary>
    public void PushMessages(params BetaMessageParam[] messages)
    {
        var current = new List<BetaMessageParam>(_currentParams.Messages);
        current.AddRange(messages);
        _currentParams = _currentParams with { Messages = current };
        _paramsMutated = true;
    }

    /// <inheritdoc />
    public IAsyncEnumerator<BetaMessage> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        if (Interlocked.Exchange(ref _consumed, 1) != 0)
            throw new InvalidOperationException("Cannot iterate over a consumed tool runner.");

        return IterateAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
    }

    /// <summary>
    /// Iterates the tool-use loop, yielding each <see cref="BetaMessage"/> response.
    /// The loop terminates when the model returns no <c>tool_use</c> blocks or
    /// <c>maxIterations</c> is reached.
    /// </summary>
    private async IAsyncEnumerable<BetaMessage> IterateAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var messages = new List<BetaMessageParam>(_currentParams.Messages);
        var iterations = 0;

        while (true)
        {
            if (_maxIterations.HasValue && iterations >= _maxIterations.Value)
                yield break;

            _paramsMutated = false;

            var iterationParams = _currentParams with
            {
                Messages = messages,
                Tools = _allToolDefinitions,
            };

            var response = await _service
                .Create(iterationParams, cancellationToken)
                .ConfigureAwait(false);
            iterations++;

            yield return response;

            // Collect tool_use blocks from the response.
            var toolUseBlocks = new List<BetaToolUseBlock>();
            foreach (var block in response.Content)
            {
                if (block.TryPickToolUse(out var toolUse))
                {
                    toolUseBlocks.Add(toolUse);
                }
            }

            if (toolUseBlocks.Count == 0)
                yield break;

            // Execute tools in parallel and collect results in order.
            var toolResults = await ExecuteToolsAsync(toolUseBlocks, cancellationToken)
                .ConfigureAwait(false);

            // If params were mutated during this iteration (between yield and here),
            // skip auto-appending — the caller is managing history manually.
            if (_paramsMutated)
            {
                messages = [.. _currentParams.Messages];
                continue;
            }

            // Append assistant message to conversation history.
            // Use JSON round-trip to convert response content blocks to param format.
            var contentJson = JsonSerializer.SerializeToElement(
                response.Content.Select(b => b.Json).ToArray()
            );
            messages.Add(
                new BetaMessageParam
                {
                    Role = Role.Assistant,
                    Content = new BetaMessageParamContent(contentJson),
                }
            );

            // Append tool results as a user message.
            messages.Add(
                new BetaMessageParam
                {
                    Role = Role.User,
                    Content = new BetaMessageParamContent(toolResults),
                }
            );
        }
    }

    /// <summary>
    /// Creates a streaming tool runner that yields <see cref="BetaRawMessageStreamEvent"/>
    /// sequences per iteration instead of aggregated messages.
    /// </summary>
    public IAsyncEnumerable<IAsyncEnumerable<BetaRawMessageStreamEvent>> Streaming(
        CancellationToken cancellationToken = default
    )
    {
        if (Interlocked.Exchange(ref _consumed, 1) != 0)
            throw new InvalidOperationException("Cannot iterate over a consumed tool runner.");

        return IterateStreamingAsync(cancellationToken);
    }

    private async IAsyncEnumerable<
        IAsyncEnumerable<BetaRawMessageStreamEvent>
    > IterateStreamingAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var messages = new List<BetaMessageParam>(_currentParams.Messages);
        var iterations = 0;

        while (true)
        {
            if (_maxIterations.HasValue && iterations >= _maxIterations.Value)
                yield break;

            _paramsMutated = false;

            var iterationParams = _currentParams with
            {
                Messages = messages,
                Tools = _allToolDefinitions,
            };

            // Create an aggregator to collect the streamed message while yielding events.
            var aggregator = new BetaMessageContentAggregator();
            var rawStream = _service.CreateStreaming(iterationParams, cancellationToken);

            // Yield the stream wrapped with the aggregator so events flow through to the
            // caller while the aggregator collects them for tool dispatch.
            yield return aggregator.CollectAsync(rawStream);

            var response = aggregator.Message();
            iterations++;

            // Collect tool_use blocks from the aggregated response.
            var toolUseBlocks = new List<BetaToolUseBlock>();
            foreach (var block in response.Content)
            {
                if (block.TryPickToolUse(out var toolUse))
                {
                    toolUseBlocks.Add(toolUse);
                }
            }

            if (toolUseBlocks.Count == 0)
                yield break;

            // Execute tools in parallel and collect results in order.
            var toolResults = await ExecuteToolsAsync(toolUseBlocks, cancellationToken)
                .ConfigureAwait(false);

            if (_paramsMutated)
            {
                messages = [.. _currentParams.Messages];
                continue;
            }

            var contentJson = JsonSerializer.SerializeToElement(
                response.Content.Select(b => b.Json).ToArray()
            );
            messages.Add(
                new BetaMessageParam
                {
                    Role = Role.Assistant,
                    Content = new BetaMessageParamContent(contentJson),
                }
            );

            messages.Add(
                new BetaMessageParam
                {
                    Role = Role.User,
                    Content = new BetaMessageParamContent(toolResults),
                }
            );
        }
    }

    /// <summary>
    /// Drives the tool-use loop to completion and returns the final <see cref="BetaMessage"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the runner produces no messages (should not happen in practice).
    /// </exception>
    public async Task<BetaMessage> RunUntilDoneAsync(CancellationToken cancellationToken = default)
    {
        BetaMessage? last = null;
        await foreach (
            var message in this.WithCancellation(cancellationToken).ConfigureAwait(false)
        )
        {
            last = message;
        }

        return last
            ?? throw new InvalidOperationException(
                "Tool runner completed without producing any messages."
            );
    }

    private async Task<List<BetaContentBlockParam>> ExecuteToolsAsync(
        List<BetaToolUseBlock> toolUseBlocks,
        CancellationToken cancellationToken
    )
    {
        var tasks = new Task<BetaToolResultBlockParam>[toolUseBlocks.Count];
        for (var i = 0; i < toolUseBlocks.Count; i++)
        {
            tasks[i] = ExecuteToolAsync(toolUseBlocks[i], cancellationToken);
        }

        var results = await Task.WhenAll(tasks).ConfigureAwait(false);
        return [.. results.Select(r => (BetaContentBlockParam)r)];
    }

    private async Task<BetaToolResultBlockParam> ExecuteToolAsync(
        BetaToolUseBlock toolUse,
        CancellationToken cancellationToken
    )
    {
        if (!_toolsByName.TryGetValue(toolUse.Name, out var tool))
        {
            return new BetaToolResultBlockParam(toolUse.ID)
            {
                Content = $"Tool '{toolUse.Name}' not found",
                IsError = true,
            };
        }

        try
        {
            var content = await tool.ExecuteAsync(toolUse, cancellationToken).ConfigureAwait(false);
            return new BetaToolResultBlockParam(toolUse.ID) { Content = content };
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (BetaToolError ex)
        {
            return new BetaToolResultBlockParam(toolUse.ID)
            {
                Content = ex.Content,
                IsError = true,
            };
        }
        catch (Exception ex)
        {
            return new BetaToolResultBlockParam(toolUse.ID)
            {
                Content = ex.Message,
                IsError = true,
            };
        }
    }

    private static MessageCreateParams InjectHelperHeader(MessageCreateParams parameters)
    {
        var rawHeaderData = parameters.RawHeaderData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        rawHeaderData["x-stainless-helper"] = JsonSerializer.SerializeToElement("BetaToolRunner");
        return MessageCreateParams.FromRawUnchecked(
            rawHeaderData,
            parameters.RawQueryData,
            parameters.RawBodyData
        );
    }
}

/// <summary>
/// Extension methods for creating a <see cref="BetaToolRunner"/> from the beta messages service.
/// </summary>
public static class BetaToolRunnerExtensions
{
    /// <summary>
    /// Creates a <see cref="BetaToolRunner"/> that automates the tool-use conversation loop.
    /// </summary>
    /// <param name="service">The beta messages service.</param>
    /// <param name="parameters">
    /// The base parameters for each API call. The <c>Messages</c> field provides the initial
    /// conversation history. Any <c>Tools</c> set here are treated as plain (non-runnable)
    /// definitions and are merged with the runnable tool definitions.
    /// </param>
    /// <param name="tools">
    /// The runnable tools that the runner can execute locally. Their definitions are
    /// automatically included in API calls.
    /// </param>
    /// <param name="maxIterations">
    /// Maximum number of API calls before the loop terminates, even if the model is
    /// still requesting tools. <c>null</c> means no limit.
    /// </param>
    public static BetaToolRunner ToolRunner(
        this IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations = null
    )
    {
        return new BetaToolRunner(service, parameters, tools, maxIterations);
    }
}
