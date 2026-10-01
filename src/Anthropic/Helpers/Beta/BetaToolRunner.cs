using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
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
    private readonly ConcurrentDictionary<string, IBetaRunnableTool> _toolsByName;
    private readonly IReadOnlyList<BetaToolUnion> _allToolDefinitions;
    private readonly int? _maxIterations;
    private int _consumed;

    private MessageCreateParams _currentParams;
    private bool _paramsMutated;

    private BetaCompactionConfig? _pendingCompaction;

    // Stays set while the consumer handles the yielded compaction response.
    private bool _compacting;

    // Tools run in parallel and may call AddTools / RemoveTools.
    private readonly ConcurrentQueue<BetaContentBlockParam> _pendingToolChanges = new();

    internal BetaToolRunner(
        IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations
    )
    {
        ThrowIfCompactionParam(parameters);
        _service = service;
        _maxIterations = maxIterations;

        _toolsByName = new ConcurrentDictionary<string, IBetaRunnableTool>(StringComparer.Ordinal);
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
        ThrowIfCompactionParam(parameters);
        if (_compacting && !HasSameMessages(parameters, _currentParams))
        {
            throw new AnthropicException(
                "Message params can't be changed while the conversation is being compacted, "
                    + "because the compaction response replaces them. Make the change on the "
                    + "next iteration."
            );
        }
        if (_compacting || _pendingCompaction != null)
        {
            ThrowIfCompactionEdit(parameters);
        }

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
        SetParams(mutator(_currentParams));
    }

    /// <summary>
    /// Appends one or more messages to the conversation history without replacing all params.
    /// When called during iteration, the runner skips auto-appending the current
    /// assistant message to history for that turn.
    /// </summary>
    public void PushMessages(params BetaMessageParam[] messages)
    {
        SetParams(p => p with { Messages = [.. p.Messages, .. messages] });
    }

    /// <summary>
    /// Sends each tool's definition in a <c>tool_addition</c> block with the next request, without
    /// changing <c>Tools</c> (which would miss the prompt cache). The runner runs the tool at once,
    /// in place of any tool of the same name, even for calls in the message it last returned.
    /// Requires the <c>inline-tools-2026-09-15</c> beta, which the runner does not add.
    /// </summary>
    public void AddTools(params IBetaRunnableTool[] tools)
    {
        foreach (var tool in tools)
        {
            _toolsByName[tool.Name] = tool;
            _pendingToolChanges.Enqueue(ToolAddition(tool.Definition));
        }
    }

    /// <summary>
    /// Like <see cref="AddTools(IBetaRunnableTool[])"/> for definitions the runner has nothing to
    /// execute, such as a server tool. Each is sent as given. A client tool added this way is never
    /// run, and replaces any runnable tool of the same name.
    /// </summary>
    public void AddTools(params BetaToolUnion[] definitions)
    {
        foreach (var definition in definitions)
        {
            if (DefinitionName(definition) is { } name)
                _toolsByName.TryRemove(name, out _);
            _pendingToolChanges.Enqueue(ToolAddition(definition));
        }
    }

    /// <summary>
    /// Sends a <c>tool_removal</c> block with the next request, without changing <c>Tools</c>. The
    /// runner stops starting the tools at once, even for calls in the message it last returned
    /// (calls already running are not interrupted), until <c>AddTools</c> adds them again.
    /// </summary>
    /// <remarks>
    /// A conversation that starts from a compaction block made elsewhere, whose
    /// <c>tool_changes</c> removes a tool that is also passed to the runner, is not refused
    /// locally (the API applies the removal for the model): call this for that tool.
    /// </remarks>
    public void RemoveTools(params string[] names)
    {
        foreach (var name in names)
        {
            _toolsByName.TryRemove(name, out _);
            _pendingToolChanges.Enqueue(
                new BetaRequestToolRemovalBlock(new BetaToolChangeToolReference(name))
            );
        }
    }

    /// <summary>Removes each tool by its <see cref="IBetaRunnableTool.Name"/>.</summary>
    public void RemoveTools(params IBetaRunnableTool[] tools)
    {
        RemoveTools([.. tools.Select(tool => tool.Name)]);
    }

    private static BetaContentBlockParam ToolAddition(BetaToolUnion definition) =>
        new BetaRequestToolAdditionBlock(new BetaToolChangeToolDefinitionParam(definition));

    private static string? DefinitionName(BetaToolUnion definition) =>
        definition.Json.TryGetProperty("name", out var name) ? name.GetString() : null;

    private void SendPendingToolChanges(List<BetaMessageParam> messages, bool resumingPausedTurn)
    {
        // A paused turn goes back as the last message, so changes wait until it has finished. A
        // compaction is resumed the same way but can be followed by them.
        if (resumingPausedTurn)
            return;

        var blocks = new List<BetaContentBlockParam>();
        while (_pendingToolChanges.TryDequeue(out var block))
        {
            blocks.Add(block);
        }

        if (blocks.Count > 0)
        {
            messages.Add(
                new BetaMessageParam
                {
                    Role = Role.System,
                    Content = new BetaMessageParamContent(blocks),
                }
            );
        }
    }

    /// <summary>
    /// Schedules a compaction of the conversation before the model's next turn. Once the
    /// current turn has finished, including any tool calls, the runner requests a summary,
    /// replaces its message history with the compaction response and yields that response like
    /// any other message, without counting it towards <c>maxIterations</c>. Calling this again
    /// first replaces the pending compaction; one still pending when <c>maxIterations</c> is
    /// reached is dropped. Requires the <c>compact-2026-09-04</c> beta.
    /// </summary>
    /// <param name="compaction">
    /// The same config <c>Create</c> takes. <c>null</c> means <c>{"type": "summarize"}</c>.
    /// </param>
    /// <exception cref="AnthropicException">
    /// The runner's <c>context_management</c> has a compaction edit.
    /// </exception>
    public void CompactBeforeNextTurn(BetaCompactionConfig? compaction = null)
    {
        if (_compacting)
        {
            return;
        }

        ThrowIfCompactionEdit(_currentParams);
        _pendingCompaction = compaction ?? new BetaCompactionConfig();
    }

    private static void ThrowIfCompactionParam(MessageCreateParams parameters)
    {
        if (parameters.Compaction != null)
        {
            throw new AnthropicException(
                "The `compaction` param cannot be set on a tool runner: every request in the "
                    + "loop would compact again. Call `CompactBeforeNextTurn()` on the runner "
                    + "when the conversation should be compacted instead."
            );
        }
    }

    private static void ThrowIfCompactionEdit(MessageCreateParams parameters)
    {
        // The compaction request is sent without `context_management`, so the API can't reject
        // this combination there: it would run and bill the compaction, then reject the next
        // request, where the compaction response and the compaction edit meet.
        var edits = parameters.ContextManagement?.Edits ?? [];
        if (
            edits.Any(edit =>
                edit.Type.ValueKind == JsonValueKind.String
                && edit.Type.GetString()!.StartsWith("compact_", StringComparison.Ordinal)
            )
        )
        {
            throw new AnthropicException(
                "`CompactBeforeNextTurn()` can't be combined with a compaction edit in "
                    + "`context_management`, because the API doesn't accept a compaction block "
                    + "together with one. Remove the edit first."
            );
        }
    }

    private static bool HasSameMessages(MessageCreateParams a, MessageCreateParams b) =>
        a.RawBodyData.TryGetValue("messages", out var aMessages)
        && b.RawBodyData.TryGetValue("messages", out var bMessages)
        && JsonElement.DeepEquals(aMessages, bMessages);

    /// <inheritdoc />
    public IAsyncEnumerator<BetaMessage> GetAsyncEnumerator(
        CancellationToken cancellationToken = default
    )
    {
        if (Interlocked.Exchange(ref _consumed, 1) != 0)
            throw new InvalidOperationException("Cannot iterate over a consumed tool runner.");

        return RunLoopAsync<BetaMessage>(
                async (parameters, ct) =>
                {
                    var message = await _service.Create(parameters, ct).ConfigureAwait(false);
                    return (message, () => message);
                },
                cancellationToken
            )
            .GetAsyncEnumerator(cancellationToken);
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

        return RunLoopAsync(
            (parameters, ct) =>
            {
                // Yield the stream wrapped with the aggregator so events flow through to the
                // caller while the aggregator collects them for tool dispatch.
                var aggregator = new BetaMessageContentAggregator();
                var stream = aggregator.CollectAsync(_service.CreateStreaming(parameters, ct));
                return Task.FromResult((stream, (Func<BetaMessage>)aggregator.Message));
            },
            cancellationToken
        );
    }

    /// <summary>
    /// Makes one API call. Returns the item the loop yields for it, plus how to read the
    /// completed <see cref="BetaMessage"/> once the caller has consumed that item.
    /// </summary>
    private delegate Task<(T Item, Func<BetaMessage> Message)> Send<T>(
        MessageCreateParams parameters,
        CancellationToken cancellationToken
    );

    /// <summary>
    /// Iterates the tool-use loop, yielding one item per API call. The loop terminates when
    /// the model returns no <c>tool_use</c> blocks or <c>maxIterations</c> is reached.
    /// </summary>
    private async IAsyncEnumerable<T> RunLoopAsync<T>(
        Send<T> send,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var messages = new List<BetaMessageParam>(_currentParams.Messages);
        var iterations = 0;
        var turnPaused = false;
        var resumingPausedTurn = false;

        while (true)
        {
            if (_maxIterations.HasValue && iterations >= _maxIterations.Value)
                yield break;

            _paramsMutated = false;

            SendPendingToolChanges(messages, resumingPausedTurn);

            // The API can't compact a conversation that ends mid-turn, so a paused turn is
            // resumed first.
            if (!turnPaused && _pendingCompaction is { } pending)
            {
                await foreach (
                    var compacted in CompactAsync(send, pending, messages, cancellationToken)
                        .ConfigureAwait(false)
                )
                {
                    yield return compacted;
                }
                continue;
            }

            var (item, message) = await send(BuildRequestParams(messages), cancellationToken)
                .ConfigureAwait(false);
            iterations++;

            yield return item;

            var response = message();
            AdoptContainer(response);

            var nextStep = DetermineNextStepFromStopReason(response);
            turnPaused = nextStep == NextStep.Resume;
            resumingPausedTurn = response.StopReason?.Value() == BetaStopReason.PauseTurn;
            if (turnPaused)
            {
                if (_paramsMutated)
                {
                    messages = [.. _currentParams.Messages];
                }
                else
                {
                    messages.Add(ToAssistantParam(response));
                }
                continue;
            }

            var toolUseBlocks = nextStep == NextStep.RunTools ? CollectToolUses(response) : [];
            if (toolUseBlocks.Count == 0)
            {
                if (PrepareFinalCompaction(response, messages) is { } last)
                {
                    await foreach (
                        var compacted in CompactAsync(send, last, messages, cancellationToken)
                            .ConfigureAwait(false)
                    )
                    {
                        yield return compacted;
                    }
                }
                yield break;
            }

            // Execute tools in parallel and collect results in order. Availability is
            // folded from the live params — not the loop-local snapshot — so a tool_removal
            // pushed while yielding this turn is honored before dispatch.
            var toolResults = await ExecuteToolsAsync(
                    toolUseBlocks,
                    AvailableToolNames(_currentParams.Messages),
                    cancellationToken
                )
                .ConfigureAwait(false);

            // If params were mutated during this iteration (between yield and here),
            // skip auto-appending — the caller is managing history manually.
            if (_paramsMutated)
            {
                messages = [.. _currentParams.Messages];
                continue;
            }

            messages.Add(ToAssistantParam(response));

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

    private MessageCreateParams BuildRequestParams(IReadOnlyList<BetaMessageParam> messages) =>
        _currentParams with
        {
            Messages = messages,
            Tools = _allToolDefinitions,
        };

    /// <summary>
    /// Sends one compaction request, yields its item and then makes the response the history.
    /// </summary>
    private async IAsyncEnumerable<T> CompactAsync<T>(
        Send<T> send,
        BetaCompactionConfig compaction,
        List<BetaMessageParam> messages,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        _pendingCompaction = null;
        _compacting = true;
        try
        {
            var parameters = WithoutCompactionIncompatibleParams(BuildRequestParams(messages)) with
            {
                Compaction = compaction,
            };

            var (item, message) = await send(parameters, cancellationToken).ConfigureAwait(false);

            yield return item;

            AdoptCompactionResponse(message(), messages);
        }
        finally
        {
            _compacting = false;
        }
    }

    /// <summary>
    /// A compaction request returns only the compaction block, never a reply, so the API rejects
    /// the params that only shape a reply. The runner's later requests keep them.
    /// </summary>
    private static MessageCreateParams WithoutCompactionIncompatibleParams(
        MessageCreateParams parameters
    )
    {
        // The keys are removed because setting a param to null would send a null.
        var rawBodyData = parameters.RawBodyData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        rawBodyData.Remove("context_management");
        rawBodyData.Remove("stop_sequences");
        rawBodyData.Remove("output_format");
        if (
            parameters.ToolChoice is { } toolChoice
            && (toolChoice.TryPickAny(out _) || toolChoice.TryPickTool(out _))
        )
        {
            rawBodyData.Remove("tool_choice");
        }
        RemoveOutputFormat(rawBodyData);
        if (
            rawBodyData.TryGetValue("fallbacks", out var fallbacks)
            && fallbacks.ValueKind == JsonValueKind.Array
        )
        {
            rawBodyData["fallbacks"] = JsonSerializer.SerializeToElement(
                fallbacks.EnumerateArray().Select(WithoutOutputFormat).ToList()
            );
        }
        return MessageCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            rawBodyData
        );
    }

    /// <summary>
    /// Removes <c>output_config.format</c>, and <c>output_config</c> itself when it held nothing
    /// else.
    /// </summary>
    private static void RemoveOutputFormat(Dictionary<string, JsonElement> fields)
    {
        if (
            !fields.TryGetValue("output_config", out var outputConfig)
            || outputConfig.ValueKind != JsonValueKind.Object
            || !outputConfig.TryGetProperty("format", out _)
        )
        {
            return;
        }

        var rest = outputConfig
            .EnumerateObject()
            .Where(field => field.Name != "format")
            .ToDictionary(field => field.Name, field => field.Value);
        if (rest.Count == 0)
        {
            fields.Remove("output_config");
        }
        else
        {
            fields["output_config"] = JsonSerializer.SerializeToElement(rest);
        }
    }

    private static JsonElement WithoutOutputFormat(JsonElement fallback)
    {
        if (fallback.ValueKind != JsonValueKind.Object)
        {
            return fallback;
        }

        var fields = fallback
            .EnumerateObject()
            .ToDictionary(field => field.Name, field => field.Value);
        RemoveOutputFormat(fields);
        return JsonSerializer.SerializeToElement(fields);
    }

    private static bool HasCompactionSummary(BetaMessage response) =>
        response.Content.Any(block =>
            block.TryPickCompaction(out var compaction) && !string.IsNullOrEmpty(compaction.Content)
        );

    private void AdoptCompactionResponse(BetaMessage response, List<BetaMessageParam> messages)
    {
        if (!HasCompactionSummary(response))
        {
            Warn("compaction produced no summary; keeping the conversation as it is.");
            return;
        }

        // The response has to be sent back as it came, first, replacing the messages it
        // summarizes.
        var compacted = ToAssistantParam(response);
        DropUnavailableTools();
        messages.Clear();
        messages.Add(compacted);
        _currentParams = _currentParams with { Messages = [compacted] };
    }

    /// <summary>
    /// Called when the run is ending. Returns the pending compaction if it should still be
    /// sent, after adding the final turn to <paramref name="messages"/>.
    /// </summary>
    private BetaCompactionConfig? PrepareFinalCompaction(
        BetaMessage response,
        List<BetaMessageParam> messages
    )
    {
        if (_pendingCompaction == null)
        {
            return null;
        }

        if (_paramsMutated)
        {
            messages.Clear();
            messages.AddRange(_currentParams.Messages);
        }
        else if (response.Content.Any(block => block.TryPickToolUse(out _)))
        {
            // A turn that was cut short can end with tool calls that are never run, and the API
            // can't compact a conversation whose last turn has an unanswered tool call.
            Warn(
                "the pending compaction was skipped because the last turn ended with tool calls "
                    + $"that were not run (stop_reason: {response.StopReason?.Raw()}). Call "
                    + "`CompactBeforeNextTurn()` again if you continue the conversation."
            );
            _pendingCompaction = null;
        }
        else
        {
            messages.Add(ToAssistantParam(response));
        }

        return _pendingCompaction;
    }

    private static void Warn(string message) =>
        Console.Error.WriteLine($"WARNING: `BetaToolRunner`: {message}");

    /// <summary>
    /// Drives the tool-use loop to completion and returns the final <see cref="BetaMessage"/>,
    /// or the compaction response when <see cref="CompactBeforeNextTurn"/> compacted the
    /// conversation after it.
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
            // A compaction response without a summary is not an answer: keep the turn before it.
            if (!_compacting || HasCompactionSummary(message))
            {
                last = message;
            }
        }

        return last
            ?? throw new InvalidOperationException(
                "Tool runner completed without producing any messages."
            );
    }

    private enum NextStep
    {
        /// <summary>Run the turn's client tool calls, answer them, and continue.</summary>
        RunTools,

        /// <summary>The turn is not finished: send it back unchanged to continue it.</summary>
        Resume,

        /// <summary>The turn is final; its tool calls, if any, must not be executed.</summary>
        Stop,
    }

    /// <summary>
    /// Maps every stop reason to what the loop does next. Each member is listed explicitly
    /// so a newly generated one shows up as an unclassified case; values this SDK version
    /// does not know about fall through to <see cref="NextStep.Stop"/> and end the loop.
    /// </summary>
    private static NextStep DetermineNextStepFromStopReason(BetaMessage response) =>
        response.StopReason?.Value() switch
        {
            BetaStopReason.ToolUse => NextStep.RunTools,
            // pause_after_compaction hands the turn back before the model answers; sending
            // it back unchanged continues it, the same as a paused turn.
            BetaStopReason.PauseTurn or BetaStopReason.Compaction => NextStep.Resume,
            BetaStopReason.EndTurn
            or BetaStopReason.StopSequence
            or BetaStopReason.MaxTokens
            or BetaStopReason.ModelContextWindowExceeded
            or BetaStopReason.Refusal => NextStep.Stop,
            _ => NextStep.Stop,
        };

    private static BetaMessageParam ToAssistantParam(BetaMessage response)
    {
        // JSON round-trip converts response content blocks to their param form.
        var contentJson = JsonSerializer.SerializeToElement(
            response.Content.Select(b => b.Json).ToArray()
        );
        return new BetaMessageParam
        {
            Role = Role.Assistant,
            Content = new BetaMessageParamContent(contentJson),
        };
    }

    /// <summary>
    /// Collects the <c>tool_use</c> blocks the runner should execute from a response.
    /// Tool calls before the last <c>fallback</c> block belong to the attempt that refused;
    /// the fallback handler trims them from replayed history, so answering them would
    /// orphan their <c>tool_results</c>.
    /// </summary>
    private static List<BetaToolUseBlock> CollectToolUses(BetaMessage response)
    {
        var seam = -1;
        var index = 0;
        foreach (var block in response.Content)
        {
            if (block.TryPickFallback(out _))
            {
                seam = index;
            }
            index++;
        }

        var toolUseBlocks = new List<BetaToolUseBlock>();
        index = 0;
        foreach (var block in response.Content)
        {
            if (index > seam && block.TryPickToolUse(out var toolUse))
            {
                toolUseBlocks.Add(toolUse);
            }
            index++;
        }
        return toolUseBlocks;
    }

    /// <summary>
    /// Folds mid-conversation <c>tool_removal</c> / <c>tool_addition</c> blocks in
    /// preceding <c>system</c> messages into the set of runnable tool names currently
    /// available. Callers pass the live params so a change pushed during the current
    /// turn is honored at dispatch. MCP references are ignored: those tools execute
    /// server-side.
    /// </summary>
    private HashSet<string> AvailableToolNames(IReadOnlyList<BetaMessageParam> messages)
    {
        var available = new HashSet<string>(_toolsByName.Keys, StringComparer.Ordinal);
        foreach (var message in messages)
        {
            if (message.Role.Raw() != "system")
                continue;
            if (!message.Content.TryPickBetaContentBlockParams(out var blocks))
                continue;

            foreach (var block in blocks)
            {
                ApplyToolChange(block, available);
            }
        }

        // A tool added since is already registered, and its block will follow that history.
        foreach (var block in _pendingToolChanges)
        {
            if (
                block.Value is BetaRequestToolAdditionBlock addition
                && addition.Tool.Value is BetaToolChangeToolDefinitionParam added
                && DefinitionName(added.Definition) is { } addedName
            )
            {
                available.Add(addedName);
            }
        }

        return available;
    }

    /// <summary>
    /// Forgets the callables the history made unavailable: a compaction replaces that history,
    /// which would bring them back.
    /// </summary>
    private void DropUnavailableTools()
    {
        var available = AvailableToolNames(_currentParams.Messages);
        foreach (var name in _toolsByName.Keys.Where(name => !available.Contains(name)).ToList())
        {
            _toolsByName.TryRemove(name, out _);
        }
    }

    private static void ApplyToolChange(BetaContentBlockParam block, HashSet<string> available)
    {
        switch (block.Value)
        {
            case BetaRequestToolRemovalBlock removal:
                if (ReferencedToolName(removal.Tool.Value) is { } removedName)
                    available.Remove(removedName);
                break;
            case BetaRequestToolAdditionBlock addition:
                if (ReferencedToolName(addition.Tool.Value) is { } addedName)
                    available.Add(addedName);
                break;
        }
    }

    private static string? ReferencedToolName(object? refValue) =>
        refValue is BetaToolChangeToolReference r ? r.Name : null;

    private async Task<List<BetaContentBlockParam>> ExecuteToolsAsync(
        List<BetaToolUseBlock> toolUseBlocks,
        HashSet<string> availableToolNames,
        CancellationToken cancellationToken
    )
    {
        var tasks = new Task<BetaToolResultBlockParam>[toolUseBlocks.Count];
        for (var i = 0; i < toolUseBlocks.Count; i++)
        {
            tasks[i] = ExecuteToolAsync(toolUseBlocks[i], availableToolNames, cancellationToken);
        }

        var results = await Task.WhenAll(tasks).ConfigureAwait(false);
        return [.. results.Select(r => (BetaContentBlockParam)r)];
    }

    private static BetaToolResultBlockParam ToolNotFoundResult(BetaToolUseBlock toolUse) =>
        new(toolUse.ID) { Content = $"Tool '{toolUse.Name}' not found", IsError = true };

    private async Task<BetaToolResultBlockParam> ExecuteToolAsync(
        BetaToolUseBlock toolUse,
        HashSet<string> availableToolNames,
        CancellationToken cancellationToken
    )
    {
        // A tool_removal'ed tool is indistinguishable from one never declared: the
        // removal is only a hint to the model, which may still emit the call.
        if (
            !availableToolNames.Contains(toolUse.Name)
            || !_toolsByName.TryGetValue(toolUse.Name, out var tool)
        )
        {
            return ToolNotFoundResult(toolUse);
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

    /// <summary>
    /// Reuses the container the previous turn ran in on the next request, so server-side
    /// state survives across iterations. A container the caller pinned is left alone,
    /// except that a pinned <see cref="BetaContainerParams"/> without an id gets the id filled in.
    /// </summary>
    private void AdoptContainer(BetaMessage response)
    {
        if (response.Container is not { } container)
            return;

        switch (_currentParams.Container)
        {
            case null:
                _currentParams = _currentParams with { Container = container.ID };
                break;
            case { Value: BetaContainerParams { ID: null } pinned }:
                _currentParams = _currentParams with
                {
                    Container = pinned with { ID = container.ID },
                };
                break;
        }
    }

    private static MessageCreateParams InjectHelperHeader(MessageCreateParams parameters)
    {
        var rawHeaderData = parameters.RawHeaderData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        rawHeaderData[StainlessHelperHeader.Name] = JsonSerializer.SerializeToElement(
            StainlessHelperHeader.BetaToolRunner
        );
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
    /// still requesting tools. <c>null</c> means no limit. Compaction requests sent for
    /// <see cref="BetaToolRunner.CompactBeforeNextTurn"/> are not counted.
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
