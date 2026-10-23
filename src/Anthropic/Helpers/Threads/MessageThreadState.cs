using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

namespace Anthropic.Helpers.Threads;

/// <summary>How the next request names the thread.</summary>
internal abstract record ThreadAnchor
{
    ThreadAnchor() { }

    /// <summary>
    /// It starts a new thread with the whole history, which may replace a thread that the API did
    /// not find.
    /// </summary>
    internal sealed record Create(bool ReplacesThreadNotFound = false) : ThreadAnchor;

    /// <summary>
    /// It continues from a reply, on a thread created with this <c>system</c> and <c>tools</c>. It
    /// may be the first to continue a thread that replaced one the API did not find.
    /// </summary>
    internal sealed record Continue(
        string PreviousMessageID,
        JsonElement? System,
        JsonElement? Tools,
        bool ReplacesThreadNotFound
    ) : ThreadAnchor;

    /// <summary>It names none and sends the whole history, and so does every later one.</summary>
    internal sealed record Unthreaded : ThreadAnchor;
}

/// <summary>
/// A reply as the API sent it: all of it, or the part that arrived before its stream ended.
/// </summary>
internal sealed record ReceivedReply(BetaMessage Message, bool Whole);

/// <summary>One message of a thread's history, with the reply it records if the API sent it.</summary>
internal sealed class ThreadEntry(BetaMessageParam param, ReceivedReply? reply = null)
{
    internal BetaMessageParam Param { get; } = param;

    /// <summary>The message as a request carries it.</summary>
    internal JsonElement Wire { get; } =
        JsonSerializer.SerializeToElement(param, ModelBase.SerializerOptions);

    internal ReceivedReply? Reply { get; } = reply;
}

/// <summary>
/// The state of a message thread: the history, what the next turn sends, and whether it
/// continues the thread.
/// </summary>
internal sealed class MessageThreadState
{
    const string UnsupportedRequestCode = "thread_unsupported_request";
    const string NotFoundCode = "thread_not_found";

    // A `continue` rejected with one of these is sent again as a `create`.
    static readonly string[] s_replayCodes =
    [
        NotFoundCode,
        "thread_already_continued",
        "thread_continue_in_flight",
    ];

    // Where a message holds what can have a `cache_control` of its own. Any other value may be
    // free-form, with a key of that name.
    static readonly string[] s_keysThatHoldBlocks =
    [
        "content",
        "source",
        "tool",
        "definition",
        "tool_references",
    ];

    // The clients whose APIs have no message threads. They are told by name because their
    // packages have versions of their own: one released before message threads says nothing
    // about them.
    static readonly string[] s_clientsWithoutThreads =
    [
        "Anthropic.Bedrock.AnthropicBedrockClient",
        "Anthropic.Bedrock.AnthropicBedrockMantleClient",
        "Anthropic.Vertex.AnthropicVertexClient",
    ];

    // What the API holds, and what the next turn adds to it.
    readonly List<ThreadEntry> _stored = [];
    readonly List<ThreadEntry> _staged = [];

    MessageCreateParams _fields;
    ThreadAnchor _anchor = new ThreadAnchor.Create();
    Turn? _turn;

    sealed class Turn(MessageCreateParams fields, int stagedBefore)
    {
        internal MessageCreateParams Fields { get; } = fields;

        /// <summary>How many messages were staged before the turn staged those it was given.</summary>
        internal int StagedBefore { get; } = stagedBefore;

        /// <summary>What was appended since the turn started. It is staged when the turn ends.</summary>
        internal List<BetaMessageParam> Appended { get; } = [];
    }

    internal MessageThreadState(
        IMessageService service,
        MessageCreateParams parameters,
        BetaUnsupportedRequestBehavior unsupportedRequestBehavior
    )
    {
        Service = service;
        UnsupportedRequestBehavior = unsupportedRequestBehavior;
        _fields = Without(parameters, "thread");
        if (parameters.RawBodyData.ContainsKey("messages"))
        {
            Stage(parameters.Messages);
        }
    }

    internal IMessageService Service { get; }

    internal BetaUnsupportedRequestBehavior UnsupportedRequestBehavior { get; }

    /// <summary>
    /// Whether <paramref name="service"/> may take a thread: any service but that of a client
    /// whose API has no message threads, or of a class derived from such a client.
    /// </summary>
    internal static bool SupportsThreads(IMessageService service)
    {
        var client = (service as MessageService)?._client.GetType();
        for (; client != null; client = client.BaseType)
        {
            if (s_clientsWithoutThreads.Contains(client.FullName))
            {
                return false;
            }
        }

        return true;
    }

    internal IReadOnlyList<BetaMessageParam> Messages =>
        [.. _stored.Concat(_staged).Select(entry => entry.Param), .. _turn?.Appended ?? []];

    internal string? PreviousMessageID => (_anchor as ThreadAnchor.Continue)?.PreviousMessageID;

    internal ReceivedReply? LastReply => _stored.LastOrDefault(entry => entry.Reply != null)?.Reply;

    internal MessageCreateParams Params => _fields with { Messages = Messages };

    /// <summary>
    /// What was appended since the history held <paramref name="count"/> messages: the messages
    /// after them, but for the last reply and any copy of it.
    /// </summary>
    internal IReadOnlyList<BetaMessageParam> AppendedSince(int count)
    {
        var reply = _stored.LastOrDefault(entry => entry.Reply != null);
        return
        [
            .. _stored
                .Concat(_staged)
                .Skip(count)
                .Where(entry => reply == null || !SameMessage(entry, reply))
                .Select(entry => entry.Param),
        ];
    }

    /// <summary>A reply as a request carries it, with its blocks as the API sent them.</summary>
    internal static BetaMessageParam ToAssistantParam(BetaMessage reply) =>
        new BetaAssistantMessageParam
        {
            Content = new BetaMessageContentParam(
                JsonSerializer.SerializeToElement(
                    reply.Content.Select(block => block.Json).ToArray()
                )
            ),
        };

    /// <summary>
    /// Replies as the messages to stage for them: none for the last reply, which the history
    /// already holds.
    /// </summary>
    internal IEnumerable<BetaMessageParam> ToAssistantParams(IEnumerable<BetaMessage> replies) =>
        replies.Where(reply => reply.ID != LastReply?.Message.ID).Select(ToAssistantParam);

    internal void Append(IEnumerable<BetaMessageParam> messages)
    {
        if (_turn == null)
        {
            Stage(messages);
        }
        else
        {
            _turn.Appended.AddRange(messages);
        }
    }

    internal void Update(Func<MessageCreateParams, MessageCreateParams> configure) =>
        _fields = Without(configure(Params), "thread");

    /// <summary>A thread with a copy of this one's history, whose first turn sends all of it.</summary>
    internal MessageThreadState Fork()
    {
        var fork = new MessageThreadState(
            Service,
            _fields with
            {
                Messages = [],
            },
            UnsupportedRequestBehavior
        )
        {
            _anchor = _anchor,
        };
        fork._stored.AddRange(_stored);
        fork._staged.AddRange(_staged);
        fork._staged.AddRange((_turn?.Appended ?? []).Select(message => new ThreadEntry(message)));
        fork.StartNewThread();
        return fork;
    }

    /// <summary>
    /// Makes the next turn start a new thread with the whole history, unless the thread no longer
    /// uses one.
    /// </summary>
    internal void StartNewThread()
    {
        if (_anchor is not ThreadAnchor.Unthreaded)
        {
            _anchor = new ThreadAnchor.Create();
        }
    }

    /// <summary>
    /// Takes the history from <paramref name="messages"/>. A list that begins with what the API
    /// holds keeps the thread and stages the rest. Any other list replaces the history, and the
    /// next turn starts a new thread with it.
    /// </summary>
    internal void ReplaceMessages(IReadOnlyList<BetaMessageParam> messages)
    {
        ThrowIfTurnInProgress();

        var given = messages.Select(message => new ThreadEntry(message)).ToList();
        if (given.Count < _stored.Count || !_stored.Zip(given, SameMessage).All(same => same))
        {
            _stored.Clear();
            StartNewThread();
        }

        _staged.Clear();
        _staged.AddRange(given.Skip(_stored.Count));
    }

    internal async Task<BetaMessage> Send(
        IEnumerable<BetaMessageParam>? messages,
        Func<MessageCreateParams, MessageCreateParams>? configure,
        CancellationToken cancellationToken
    )
    {
        var turn = StartTurn(messages, configure);
        try
        {
            while (true)
            {
                try
                {
                    var reply = await Service
                        .Create(Request(turn), cancellationToken)
                        .ConfigureAwait(false);
                    RecordReply(turn, reply);
                    return reply;
                }
                catch (AnthropicApiException e) when (RecoversFrom(e)) { }
            }
        }
        finally
        {
            EndTurn(turn);
        }
    }

    /// <summary>One streamed turn, which starts when the result is first read.</summary>
    internal async IAsyncEnumerable<BetaRawMessageStreamEvent> Stream(
        IEnumerable<BetaMessageParam>? messages,
        Func<MessageCreateParams, MessageCreateParams>? configure,
        [EnumeratorCancellation] CancellationToken cancellationToken
    )
    {
        // Null once the turn has ended.
        Turn? turn = StartTurn(messages, configure);
        StreamedReply? reply = null;
        IAsyncEnumerator<BetaRawMessageStreamEvent>? events = null;
        try
        {
            bool more;
            while (true)
            {
                events = Service
                    .CreateStreaming(Request(turn), cancellationToken)
                    .GetAsyncEnumerator(cancellationToken);
                try
                {
                    more = await events.MoveNextAsync().ConfigureAwait(false);
                    break;
                }
                catch (AnthropicApiException e) when (RecoversFrom(e))
                {
                    await events.DisposeAsync().ConfigureAwait(false);
                    events = null;
                }
            }

            while (more)
            {
                var streamEvent = events.Current;
                if (streamEvent.Value is BetaRawMessageStartEvent start)
                {
                    reply ??= new StreamedReply(start);
                }
                else if (turn != null && reply?.Add(streamEvent) is { } whole)
                {
                    RecordReply(turn, whole);
                    EndTurn(turn);
                    turn = null;
                }

                yield return streamEvent;

                more = await events.MoveNextAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            if (turn != null)
            {
                if (reply != null)
                {
                    // The API holds either the whole reply or none of it. A refused turn is not
                    // recorded, whether or not all of its stream was read.
                    if (!reply.IsRefusal)
                    {
                        Store(
                            reply.Partial() is { } part
                                ? new ReceivedReply(part, Whole: false)
                                : null
                        );
                    }
                    StartNewThread();
                }
                EndTurn(turn);
            }
            if (events != null)
            {
                await events.DisposeAsync().ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Refuses <paramref name="fields"/> as the fields of the next turn when that turn continues
    /// the thread with another <c>system</c> or <c>tools</c> than the thread was created with. A
    /// continue leaves both out, so the API could not reject the change itself.
    /// </summary>
    internal void ThrowIfCreateOnlyChanged(MessageCreateParams fields)
    {
        if (_anchor is not ThreadAnchor.Continue created)
        {
            return;
        }

        var changed = new List<string>();
        if (!SameValue(Field(fields, "system"), created.System))
        {
            changed.Add("`System`");
        }
        var toolsChanged = !SameValue(Field(fields, "tools"), created.Tools);
        if (toolsChanged)
        {
            changed.Add("`Tools`");
        }
        if (changed.Count > 0)
        {
            throw new InvalidOperationException(
                $"Cannot change {string.Join(" and ", changed)} on a thread: the server keeps "
                    + "the `System` and `Tools` the thread was created with. To change them, "
                    + "start a new thread from `thread.Params`."
                    + (
                        toolsChanged
                            ? " To add or remove tools on this thread, send `tool_addition` or "
                                + "`tool_removal` blocks in a `system` message."
                            : ""
                    )
            );
        }
    }

    void ThrowIfTurnInProgress()
    {
        if (_turn != null)
        {
            throw new InvalidOperationException(
                "Another turn is in progress on this message thread. Wait for it to end, or "
                    + "dispose its stream."
            );
        }
    }

    void Stage(IEnumerable<BetaMessageParam> messages)
    {
        foreach (var entry in messages.Select(message => new ThreadEntry(message)))
        {
            // The history already holds the last reply, so a copy directly after it adds nothing.
            if (
                _staged.Count > 0
                || _stored.LastOrDefault() is not { Reply: not null } last
                || !SameMessage(last, entry)
            )
            {
                _staged.Add(entry);
            }
        }
    }

    Turn StartTurn(
        IEnumerable<BetaMessageParam>? messages,
        Func<MessageCreateParams, MessageCreateParams>? configure
    )
    {
        ThrowIfTurnInProgress();

        var fields = configure?.Invoke(Params) ?? _fields;
        ThrowIfCreateOnlyChanged(fields);

        var stagedBefore = _staged.Count;
        Stage(messages ?? []);

        // With nothing new to send, a turn whose stream ended early is sent again, in place of the
        // part of its reply that arrived.
        if (_staged.Count == 0 && _stored.LastOrDefault() is { Reply.Whole: false })
        {
            _stored.RemoveAt(_stored.Count - 1);
        }

        return _turn = new Turn(fields, stagedBefore);
    }

    void EndTurn(Turn turn)
    {
        _turn = null;

        // What the turn was given is still staged only when the turn was not recorded. It is taken
        // back, so that making the same call again sends it once.
        if (_staged.Count > turn.StagedBefore)
        {
            _staged.RemoveRange(turn.StagedBefore, _staged.Count - turn.StagedBefore);
        }

        Stage(turn.Appended);
    }

    MessageCreateParams Request(Turn turn)
    {
        var request = MessageCreateParams.FromRawUnchecked(
            StainlessHelperHeader.Tagged(
                turn.Fields.RawHeaderData,
                StainlessHelperHeader.MessageThread
            ),
            turn.Fields.RawQueryData,
            turn.Fields.RawBodyData
        ) with
        {
            Messages =
            [
                .. _anchor is ThreadAnchor.Continue ? [] : StoredToSendAgain(),
                .. _staged.Select(entry => entry.Param),
            ],
        };
        if (_anchor is ThreadAnchor.Unthreaded)
        {
            return Without(request, "thread");
        }

        ApiEnum<string, AnthropicBeta> threads = AnthropicBeta.MessageThreads2026_08_12;
        var betas = request.Betas ?? [];
        request = request with { Betas = betas.Contains(threads) ? betas : [.. betas, threads] };
        return _anchor is ThreadAnchor.Continue { PreviousMessageID: var previousMessageID }
            ? Without(
                request with
                {
                    Thread = new BetaThreadContinueParams { PreviousMessageID = previousMessageID },
                },
                "system",
                "tools"
            )
            : request with
            {
                Thread = new BetaThreadCreateParams(),
            };
    }

    /// <summary>
    /// What the API held, as a request that sends it again carries it. The messages up to the last
    /// reply go without the <c>cache_control</c> of their content blocks, each of which was set
    /// for the request that first sent it. The messages after it were never answered.
    /// </summary>
    IEnumerable<BetaMessageParam> StoredToSendAgain()
    {
        var answered = _stored.FindLastIndex(entry => entry.Reply != null) + 1;
        return _stored.Select(
            (entry, index) => index < answered ? WithoutCacheControl(entry) : entry.Param
        );
    }

    static BetaMessageParam WithoutCacheControl(ThreadEntry entry)
    {
        var message = JsonSerializer.SerializeToNode(entry.Wire);
        RemoveCacheControl(message);
        return new BetaMessageParam(JsonSerializer.SerializeToElement(message));
    }

    static void RemoveCacheControl(JsonNode? node)
    {
        switch (node)
        {
            case JsonArray items:
                foreach (var item in items.OfType<JsonObject>())
                {
                    RemoveCacheControl(item);
                }
                break;
            case JsonObject fields:
                fields.Remove("cache_control");
                foreach (var key in s_keysThatHoldBlocks)
                {
                    RemoveCacheControl(fields[key]);
                }
                break;
        }
    }

    void RecordReply(Turn turn, BetaMessage reply)
    {
        if (IsRefusal(reply))
        {
            // The API may hold the refused turn, and a continue cannot leave it out.
            StartNewThread();
            return;
        }

        Store(new ReceivedReply(reply, Whole: true));
        if (_anchor is ThreadAnchor.Create)
        {
            // What creates the thread is the thread's from then on, also when it was given for
            // that turn only.
            _fields = Without(_fields, "system", "tools") with
            {
                System = turn.Fields.System,
                Tools = turn.Fields.Tools,
            };
        }
        _anchor = _anchor switch
        {
            ThreadAnchor.Create create => new ThreadAnchor.Continue(
                reply.ID,
                Field(turn.Fields, "system"),
                Field(turn.Fields, "tools"),
                create.ReplacesThreadNotFound
            ),
            ThreadAnchor.Continue created => created with
            {
                PreviousMessageID = reply.ID,
                ReplacesThreadNotFound = false,
            },
            _ => _anchor,
        };
        _fields = WithContainerOf(_fields, reply);

        // A thread keeps one model, so the API does not hold a turn that a fallback model wrote.
        var iterations = reply.Usage.Iterations ?? [];
        if (iterations.Any(iteration => iteration.Value is BetaFallbackMessageIterationUsage))
        {
            StartNewThread();
        }
    }

    /// <summary>
    /// Container-bound server tools reject a request that leaves out the container the turn before
    /// it ran in, so its id is sent on later requests unless the caller named one.
    /// </summary>
    internal static MessageCreateParams WithContainerOf(
        MessageCreateParams fields,
        BetaMessage reply
    ) =>
        (reply.Container, fields.Container) switch
        {
            ({ } container, null) => fields with { Container = container.ID },
            ({ } container, { Value: BetaContainerParams { ID: null } named }) => fields with
            {
                Container = named with { ID = container.ID },
            },
            _ => fields,
        };

    /// <summary>Moves what was staged to what the API holds, followed by the reply to it.</summary>
    void Store(ReceivedReply? reply)
    {
        _stored.AddRange(_staged);
        _staged.Clear();
        if (reply != null)
        {
            _stored.Add(new ThreadEntry(ToAssistantParam(reply.Message), reply));
        }
    }

    /// <summary>
    /// Whether the turn should be sent again because the API rejected its thread in a way the
    /// thread has now adjusted for. The error code decides, never the message. The anchor only
    /// moves from continue to create to unthreaded, so a turn sends at most three requests.
    /// </summary>
    bool RecoversFrom(AnthropicApiException error)
    {
        var code = ErrorCode(error.ResponseBody);
        if (_anchor is ThreadAnchor.Continue continued && s_replayCodes.Contains(code))
        {
            // An API that finds neither a thread nor the one that replaced it may be unable to
            // store the conversation.
            var notFound = code == NotFoundCode;
            _anchor =
                notFound
                && continued.ReplacesThreadNotFound
                && UnsupportedRequestBehavior == BetaUnsupportedRequestBehavior.ContinueUnthreaded
                    ? new ThreadAnchor.Unthreaded()
                    : new ThreadAnchor.Create(ReplacesThreadNotFound: notFound);
            return true;
        }

        if (
            _anchor is not ThreadAnchor.Unthreaded
            && code == UnsupportedRequestCode
            && UnsupportedRequestBehavior == BetaUnsupportedRequestBehavior.ContinueUnthreaded
        )
        {
            _anchor = new ThreadAnchor.Unthreaded();
            return true;
        }

        return false;
    }

    static bool IsRefusal(BetaMessage reply) => reply.StopReason?.Value() == BetaStopReason.Refusal;

    static string? ErrorCode(string responseBody)
    {
        try
        {
            return JsonNode
                .Parse(responseBody)
                ?["error"]?["details"]?["error_code"]?.GetValue<string>();
        }
        catch (Exception e) when (e is JsonException or InvalidOperationException)
        {
            return null;
        }
    }

    static bool SameMessage(ThreadEntry a, ThreadEntry b) => JsonElement.DeepEquals(a.Wire, b.Wire);

    static bool SameValue(JsonElement? a, JsonElement? b) =>
        a is { } left ? b is { } right && JsonElement.DeepEquals(left, right) : b == null;

    /// <summary>A body field, or <c>null</c> when it says nothing: unset, null or an empty list.</summary>
    static JsonElement? Field(MessageCreateParams fields, string name) =>
        fields.RawBodyData.TryGetValue(name, out var value)
        && value.ValueKind != JsonValueKind.Null
        && !(value.ValueKind == JsonValueKind.Array && value.GetArrayLength() == 0)
            ? value
            : null;

    // The keys are removed because setting a param to null would send a null.
    static MessageCreateParams Without(MessageCreateParams parameters, params string[] names) =>
        MessageCreateParams.FromRawUnchecked(
            parameters.RawHeaderData,
            parameters.RawQueryData,
            parameters
                .RawBodyData.Where(field => !names.Contains(field.Key))
                .ToDictionary(field => field.Key, field => field.Value)
        );
}
