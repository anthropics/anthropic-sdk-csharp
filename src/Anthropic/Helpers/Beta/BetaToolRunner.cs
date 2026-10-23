using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Core.Telemetry;
using Anthropic.Exceptions;
using Anthropic.Helpers.Threads;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

namespace Anthropic.Helpers.Beta;

/// <summary>
/// Automates the multi-turn conversation loop between the model and client-side tools.
/// The runner makes API calls, detects <c>tool_use</c> content blocks, executes matching
/// tools locally, feeds results back as <c>tool_result</c> messages, and repeats until
/// the model produces a final response with no tool calls or <c>maxIterations</c> is reached.
///
/// <para>The runner keeps its conversation in a message thread by default, so each request sends
/// only the new messages, and <c>System</c> and <c>Tools</c> cannot change during a run. Create
/// it with <c>thread: false</c> to send the whole history with every request instead, as it
/// always does on the Bedrock and Vertex clients.</para>
/// </summary>
public class BetaToolRunner : IAsyncEnumerable<BetaMessage>
{
    private readonly IMessageService _service;
    private readonly ConcurrentDictionary<string, IBetaRunnableTool> _toolsByName;
    private readonly IReadOnlyList<BetaToolUnion> _allToolDefinitions;
    private readonly int? _maxIterations;
    private readonly MessageThreadState? _thread;

    // The options of the SDK client behind _service, which the runner's spans follow, or null
    // when the service is not the SDK's own and the runner emits none.
    private readonly ClientOptions? _clientOptions;

    // The tool runner span, while the loop runs.
    private Activity? _toolRunnerSpan;
    private int _consumed;

    private MessageCreateParams _currentParams;
    private bool _paramsMutated;

    private BetaCompactionConfig? _pendingCompaction;

    // Stays set while the consumer handles the yielded compaction response.
    private bool _compacting;

    // Tools run in parallel and may call AddTools / RemoveTools.
    private readonly ConcurrentQueue<SystemMessageContentBlock> _pendingToolChanges = new();

    internal BetaToolRunner(
        IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations,
        bool thread = true
    )
    {
        ThrowIfCompactionParam(parameters);
        ThrowIfThreadParam(parameters);
        _service = service;
        _maxIterations = maxIterations;
        _clientOptions = (service as MessageService)?.ClientOptions;

        _toolsByName = new ConcurrentDictionary<string, IBetaRunnableTool>(StringComparer.Ordinal);
        var allDefs = new List<BetaToolUnion>();

        // The params of a thread or of another runner already hold definitions of its tools.
        var named = (parameters.Tools ?? []).Select(DefinitionName).ToList();
        foreach (var tool in tools)
        {
            _toolsByName[tool.Name] = tool;
            if (!named.Contains(tool.Name))
            {
                allDefs.Add(tool.Definition);
            }
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

        if (thread && MessageThreadState.SupportsThreads(service))
        {
            _thread = new MessageThreadState(
                service,
                _currentParams,
                BetaUnsupportedRequestBehavior.ContinueUnthreaded
            );
        }
    }

    internal BetaToolRunner(
        MessageThreadState thread,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations
    )
        : this(thread.Service, thread.Params, tools, maxIterations, thread: false)
    {
        _thread = thread;
    }

    /// <summary>
    /// The current parameters that will be used for the next API call.
    /// </summary>
    public MessageCreateParams Params => _currentParams;

    /// <summary>
    /// Replaces the runner's parameters for the next API call.
    /// When called during iteration, the runner skips auto-appending the current
    /// assistant message to history for that turn.
    ///
    /// <para>On a message thread, <c>System</c> cannot change. To change it during a run, create
    /// the runner with <c>thread: false</c>.</para>
    /// </summary>
    /// <exception cref="ArgumentException">
    /// <paramref name="parameters"/> sets <c>Thread</c>, which the runner sets for each request
    /// itself.
    /// </exception>
    public void SetParams(MessageCreateParams parameters)
    {
        ThrowIfCompactionParam(parameters);
        ThrowIfThreadParam(parameters);
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

    private static SystemMessageContentBlock ToolAddition(BetaToolUnion definition) =>
        new BetaRequestToolAdditionBlock(new BetaToolChangeToolDefinitionParam(definition));

    private static string? DefinitionName(BetaToolUnion definition) =>
        definition.Json.TryGetProperty("name", out var name) ? name.GetString() : null;

    private void SendPendingToolChanges(List<BetaMessageParam> messages, bool resumingPausedTurn)
    {
        // A paused turn goes back as the last message, so changes wait until it has finished. A
        // compaction is resumed the same way but can be followed by them.
        if (resumingPausedTurn)
            return;

        var blocks = new List<SystemMessageContentBlock>();
        while (_pendingToolChanges.TryDequeue(out var block))
        {
            blocks.Add(block);
        }

        if (blocks.Count > 0)
        {
            messages.Add(new BetaSystemMessageParam { Content = blocks });
        }
    }

    /// <summary>
    /// Schedules a compaction of the conversation before the model's next turn. Once the
    /// current turn has finished, including any tool calls, the runner requests a summary,
    /// replaces its message history with the compaction response and yields that response like
    /// any other message, without counting it towards <c>maxIterations</c>. Calling this again
    /// first replaces the pending compaction; one still pending when <c>maxIterations</c> is
    /// reached is dropped. Requires the <c>compact-2026-09-04</c> beta. On a message thread the
    /// compaction request starts a new thread.
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

    private static void ThrowIfThreadParam(MessageCreateParams parameters)
    {
        if (parameters.Thread != null)
        {
            throw new ArgumentException(
                "`Thread` cannot be set on a tool runner. The runner sets it for each request "
                    + "itself. To run without a message thread, pass `thread: false`.",
                nameof(parameters)
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
                edit.Type.Json.ValueKind == JsonValueKind.String
                && edit.Type.Json.GetString()!.StartsWith("compact_", StringComparison.Ordinal)
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

        return RunLoopInToolRunnerSpan(
                RunLoopAsync<BetaMessage>(
                    async (parameters, ct) =>
                    {
                        _thread?.ReplaceMessages(parameters.Messages);
                        var message = await (
                            _thread?.Send(null, _ => parameters, ct)
                            ?? _service.Create(parameters, ct)
                        ).ConfigureAwait(false);
                        return (message, () => message);
                    },
                    cancellationToken
                ),
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

        return RunLoopInToolRunnerSpan(
            RunLoopAsync(
                (parameters, ct) =>
                {
                    _thread?.ReplaceMessages(parameters.Messages);

                    // Yield the stream wrapped with the aggregator so events flow through to the
                    // caller while the aggregator collects them for tool dispatch.
                    var aggregator = new BetaMessageContentAggregator();
                    var stream = InToolRunnerSpan(
                        aggregator.CollectAsync(
                            _thread?.Stream(null, _ => parameters, ct)
                                ?? _service.CreateStreaming(parameters, ct)
                        ),
                        ct
                    );
                    return Task.FromResult((stream, (Func<BetaMessage>)aggregator.Message));
                },
                cancellationToken
            ),
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
        var messages = new List<BetaMessageParam>(History);
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
            _currentParams = MessageThreadState.WithContainerOf(_currentParams, response);

            var nextStep = DetermineNextStepFromStopReason(response);
            turnPaused = nextStep == NextStep.Resume;
            resumingPausedTurn = response.StopReason?.Value() == BetaStopReason.PauseTurn;
            if (turnPaused)
            {
                _thread?.ThrowIfCreateOnlyChanged(BuildRequestParams(messages));
                messages = HistoryAfter(response, messages);
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

            if (_thread != null)
            {
                // No tool runs for a turn that the thread would refuse. It is asked first, because
                // messages that start a new thread would take the change with them.
                _thread.ThrowIfCreateOnlyChanged(BuildRequestParams(messages));
                if (_paramsMutated)
                    _thread.ReplaceMessages(_currentParams.Messages);
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

            messages = HistoryAfter(response, messages);

            // If params were mutated during this iteration (between yield and here),
            // skip auto-appending — the caller is managing history manually.
            if (_paramsMutated)
                continue;

            // Add tool results as a user message, directly after the calls they answer.
            var calls = messages.FindLastIndex(message => message.Role.Raw() == "assistant");
            messages.Insert(calls + 1, new BetaUserMessageParam { Content = toolResults });

            // The run can end here, and the thread goes on from the results.
            _thread?.ReplaceMessages(messages);
        }
    }

    /// <summary>
    /// The history after <paramref name="response"/>. It is not appended to params that were set
    /// during the iteration, whose caller manages the history, nor on a thread, which holds it.
    /// </summary>
    private List<BetaMessageParam> HistoryAfter(
        BetaMessage response,
        List<BetaMessageParam> messages
    ) =>
        _paramsMutated || _thread != null
            ? [.. History]
            : [.. messages, MessageThreadState.ToAssistantParam(response)];

    private IReadOnlyList<BetaMessageParam> History =>
        _paramsMutated || _thread == null ? _currentParams.Messages : _thread.Messages;

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

            // The request carries the whole history, so it starts a new thread.
            _thread?.StartNewThread();
            var (item, message) = await send(parameters, cancellationToken).ConfigureAwait(false);

            yield return item;

            var appended = _thread?.AppendedSince(messages.Count) ?? [];
            AdoptCompactionResponse(message(), messages);
            messages.AddRange(appended);
            _thread?.ReplaceMessages(messages);
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
        var compacted = MessageThreadState.ToAssistantParam(response);
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
        else if (_thread != null)
        {
            messages.Clear();
            messages.AddRange(_thread.Messages);
        }
        else
        {
            messages.Add(MessageThreadState.ToAssistantParam(response));
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

    /// <summary>
    /// Runs <paramref name="turns"/>, the turns of the loop, inside the tool runner span, which
    /// starts with the first turn when the client emits spans. The span ends with the loop:
    /// <c>Ok</c> when the turns run out, <c>Error</c> when one throws, and no status when the
    /// application stops early, cancels, or disposes of the enumerator.
    /// </summary>
    private async IAsyncEnumerable<T> RunLoopInToolRunnerSpan<T>(
        IAsyncEnumerable<T> turns,
        CancellationToken cancellationToken,
        [EnumeratorCancellation] CancellationToken enumeratorToken = default
    )
    {
        var toolRunnerSpan = _clientOptions is { } options
            ? ToolSpans.StartToolRunnerSpan(options, _currentParams)
            : null;
        _toolRunnerSpan = toolRunnerSpan;
        var complete = false;
        try
        {
            await foreach (
                var turn in InToolRunnerSpan(turns, cancellationToken)
                    .WithCancellation(enumeratorToken)
                    .ConfigureAwait(false)
            )
            {
                yield return turn;
            }
            complete = true;
        }
        finally
        {
            _toolRunnerSpan = null;
            if (toolRunnerSpan != null)
            {
                if (complete)
                {
                    toolRunnerSpan.SetStatus(ActivityStatusCode.Ok);
                }
                Tracing.End(toolRunnerSpan);
            }
        }
    }

    /// <summary>
    /// Reads <paramref name="items"/>, the loop's turns or the events of one streamed turn, with
    /// the tool runner span current in every step, and none of the application's code under it.
    /// A step that fails, other than by the application's cancellation through
    /// <paramref name="cancellationToken"/>, fails the span: a streamed turn throws to the
    /// application without passing through the loop.
    /// </summary>
    private async IAsyncEnumerable<T> InToolRunnerSpan<T>(
        IAsyncEnumerable<T> items,
        CancellationToken cancellationToken,
        [EnumeratorCancellation] CancellationToken enumeratorToken = default
    )
    {
        var enumerator = items.GetAsyncEnumerator(enumeratorToken);
        try
        {
            while (true)
            {
                // A step resumes in the context of whoever asks for the next item, which can be
                // another trace each time. Returning from the step puts that context back.
                if (_toolRunnerSpan is { } toolRunnerSpan)
                {
                    Activity.Current = toolRunnerSpan;
                }
                bool moved;
                try
                {
                    moved = await enumerator.MoveNextAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    if (_toolRunnerSpan is { } failedToolRunnerSpan)
                    {
                        // The application cancels through either token: the runner's, or the
                        // enumerator's.
                        Tracing.SetErrorStatus(
                            failedToolRunnerSpan,
                            e,
                            enumeratorToken.IsCancellationRequested
                                ? enumeratorToken
                                : cancellationToken
                        );
                    }
                    throw;
                }
                if (!moved)
                {
                    yield break;
                }
                yield return enumerator.Current;
            }
        }
        finally
        {
            await enumerator.DisposeAsync().ConfigureAwait(false);
        }
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

            // Block by block: one this SDK can't model must not hide a removal beside it.
            var blocks = WrappedJsonSerializer.GetNullableClassProperty<BetaContentBlockParam?[]>(
                message.Json,
                "content"
            );
            foreach (var block in blocks ?? [])
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

    private static void ApplyToolChange(BetaContentBlockParam? block, HashSet<string> available)
    {
        switch (block?.Value)
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

        var spanName = tool is BetaRunnableTool { IsMcpTool: true }
            ? "anthropic.mcp_tool_use"
            : "anthropic.custom_tool_use";
        if (
            _clientOptions is not { } options
            || !Tracing.IsEnabled(options)
            || ToolSpans.StartToolUseSpan(options, spanName, toolUse, DefinitionForSpan(tool))
                is not { } toolUseSpan
        )
        {
            return await RunToolAsync(tool, toolUse, cancellationToken).ConfigureAwait(false);
        }
        BetaToolResultBlockParam result;
        try
        {
            result = await RunToolAsync(tool, toolUse, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            ToolSpans.EndToolUseSpan(toolUseSpan, e, cancellationToken);
            throw;
        }
        ToolSpans.EndToolUseSpan(options, toolUseSpan, result);
        return result;
    }

    /// <summary>
    /// The definition of <paramref name="tool"/>, for its span to take the description from. The
    /// tool computes it, so it is read only when there is a span to start, and a tool that throws
    /// here still runs: its span has no description.
    /// </summary>
    private static BetaToolUnion? DefinitionForSpan(IBetaRunnableTool tool)
    {
        try
        {
            return tool.Definition;
        }
        catch (Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// Executes <paramref name="tool"/> for <paramref name="toolUse"/> and makes the result to
    /// send back. An error the tool throws becomes an error result.
    /// </summary>
    private static async Task<BetaToolResultBlockParam> RunToolAsync(
        IBetaRunnableTool tool,
        BetaToolUseBlock toolUse,
        CancellationToken cancellationToken
    )
    {
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

    private static MessageCreateParams InjectHelperHeader(MessageCreateParams parameters) =>
        MessageCreateParams.FromRawUnchecked(
            StainlessHelperHeader.Tagged(
                parameters.RawHeaderData,
                StainlessHelperHeader.BetaToolRunner
            ),
            parameters.RawQueryData,
            parameters.RawBodyData
        );
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
    /// definitions and are merged with the runnable tool definitions. A runnable tool whose name
    /// they already hold adds no second definition.
    /// </param>
    /// <param name="tools">
    /// The runnable tools that the runner can execute locally. Their definitions are
    /// automatically included in API calls.
    /// </param>
    /// <param name="maxIterations">
    /// Maximum number of API calls before the loop terminates, even if the model is
    /// still requesting tools. <c>null</c> means no limit. Compaction requests sent for
    /// <see cref="BetaToolRunner.CompactBeforeNextTurn"/> are not counted, nor is a request that
    /// is sent again because the API rejected its message thread.
    /// </param>
    /// <exception cref="ArgumentException">
    /// <paramref name="parameters"/> sets <c>Thread</c>, which the runner sets for each request
    /// itself.
    /// </exception>
    public static BetaToolRunner ToolRunner(
        this IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations = null
    )
    {
        return new BetaToolRunner(service, parameters, tools, maxIterations);
    }

    /// <summary>
    /// Creates a <see cref="BetaToolRunner"/> like
    /// <see cref="ToolRunner(IMessageService, MessageCreateParams, IReadOnlyList{IBetaRunnableTool}, int?)"/>,
    /// and says whether it keeps the conversation on a message thread.
    /// </summary>
    /// <param name="service">The beta messages service.</param>
    /// <param name="parameters">The base parameters for each API call.</param>
    /// <param name="tools">The runnable tools that the runner can execute locally.</param>
    /// <param name="thread">
    /// <c>false</c> sends the whole history with every request, without a message thread and
    /// without its beta. <c>true</c> is the default of the other overload.
    /// </param>
    /// <param name="maxIterations">Maximum number of API calls, as in the other overload.</param>
    public static BetaToolRunner ToolRunner(
        this IMessageService service,
        MessageCreateParams parameters,
        IReadOnlyList<IBetaRunnableTool> tools,
        bool thread,
        int? maxIterations = null
    )
    {
        return new BetaToolRunner(service, parameters, tools, maxIterations, thread);
    }
}
