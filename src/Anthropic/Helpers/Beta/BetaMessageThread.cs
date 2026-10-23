using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers.Threads;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

namespace Anthropic.Helpers.Beta;

/// <summary>
/// A message thread (beta) keeps the conversation on the server, so each request sends only the
/// new messages instead of the whole history. A thread runs one turn at a time, and is not
/// thread-safe.
///
/// <para>Create one with
/// <see cref="BetaMessageThreadExtensions.Thread(IMessageService, ThreadCreateParams)"/>, which
/// takes what <c>Create</c> takes and sends nothing until the first turn.
/// <see cref="ToolRunner"/> runs the tool loop over this thread. For replies parsed into a type,
/// see <see cref="BetaMessageThread{T}"/>.</para>
/// </summary>
public sealed class BetaMessageThread
{
    readonly MessageThreadState _state;

    internal BetaMessageThread(MessageThreadState state)
    {
        _state = state;
    }

    /// <summary>
    /// The whole history: every message that was sent, every reply, and the messages staged for
    /// the next turn.
    /// </summary>
    public IReadOnlyList<BetaMessageParam> Messages => _state.Messages;

    /// <summary>
    /// The ID of the reply that the next turn continues from, or <c>null</c> when the next turn
    /// starts a new thread or is sent without a thread.
    /// </summary>
    public string? PreviousMessageID => _state.PreviousMessageID;

    /// <summary>The last reply of the thread, or <c>null</c> before the first one.</summary>
    public BetaMessage? LastMessage => _state.LastReply?.Message;

    /// <summary>
    /// The parameters to create a new thread with this thread's request fields and
    /// <see cref="Messages"/>.
    /// </summary>
    public ThreadCreateParams Params =>
        ThreadCreateParams.From(_state.Params) with
        {
            UnsupportedRequestBehavior = _state.UnsupportedRequestBehavior,
        };

    /// <summary>Stages messages for the next turn without sending them.</summary>
    /// <param name="messages">The messages to stage, in order.</param>
    public void Append(params BetaMessageParam[] messages)
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        _state.Append(messages);
    }

    /// <summary>
    /// Stages replies for the next turn without sending them, each as an <c>assistant</c> message
    /// with the content of the reply. See <see cref="Append(BetaMessageParam[])"/>.
    /// </summary>
    /// <param name="messages">The replies to stage, in order.</param>
    public void Append(params BetaMessage[] messages)
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        _state.Append(_state.ToAssistantParams(messages));
    }

    /// <summary>Sends the next turn with what is staged and returns the reply.</summary>
    /// <param name="cancellationToken">Cancels the request.</param>
    /// <exception cref="InvalidOperationException">
    /// Another turn is in progress on this thread, or the turn would continue the thread with a
    /// changed <c>System</c> or <c>Tools</c>.
    /// </exception>
    public Task<BetaMessage> Send(CancellationToken cancellationToken = default) =>
        _state.Send(null, null, cancellationToken);

    /// <summary>
    /// Sends the next turn, with what is staged followed by <paramref name="message"/>, and
    /// returns the reply.
    /// </summary>
    /// <param name="message">The message of this turn.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    public Task<BetaMessage> Send(
        BetaMessageParam message,
        CancellationToken cancellationToken = default
    )
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _state.Send([message], null, cancellationToken);
    }

    /// <summary>
    /// Sends the next turn like <see cref="Send(BetaMessageParam, CancellationToken)"/>, with a
    /// reply as the message. See <see cref="Append(BetaMessage[])"/>.
    /// </summary>
    /// <param name="message">The reply to send as the message of this turn.</param>
    /// <param name="cancellationToken">Cancels the request.</param>
    public Task<BetaMessage> Send(
        BetaMessage message,
        CancellationToken cancellationToken = default
    )
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _state.Send(_state.ToAssistantParams([message]), null, cancellationToken);
    }

    /// <summary>
    /// Sends the next turn, with what is staged followed by <paramref name="messages"/>, and
    /// returns the reply.
    /// </summary>
    /// <param name="messages">The messages of this turn, in order. They are not merged.</param>
    /// <param name="configure">
    /// Changes the request fields for this turn only. It receives the thread's fields.
    /// </param>
    /// <param name="cancellationToken">Cancels the request.</param>
    public Task<BetaMessage> Send(
        IEnumerable<BetaMessageParam> messages,
        Func<ThreadSendParams, ThreadSendParams>? configure = null,
        CancellationToken cancellationToken = default
    )
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        return _state.Send(
            messages,
            configure == null ? null : OnRequestFields(configure),
            cancellationToken
        );
    }

    /// <summary>
    /// Sends the next turn like <see cref="Send(CancellationToken)"/> and returns the events of
    /// the reply as they arrive. The turn starts when the result is first read, so read it once.
    /// It is in progress until the stream ends or the enumerator is disposed.
    /// </summary>
    /// <param name="cancellationToken">Cancels the request and the stream.</param>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        CancellationToken cancellationToken = default
    ) => _state.Stream(null, null, cancellationToken);

    /// <summary>
    /// Sends the next turn like <see cref="Send(BetaMessageParam, CancellationToken)"/> and
    /// returns the events of the reply as they arrive. See
    /// <see cref="SendStreaming(CancellationToken)"/>.
    /// </summary>
    /// <param name="message">The message of this turn.</param>
    /// <param name="cancellationToken">Cancels the request and the stream.</param>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        BetaMessageParam message,
        CancellationToken cancellationToken = default
    )
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _state.Stream([message], null, cancellationToken);
    }

    /// <summary>
    /// Sends the next turn like <see cref="Send(BetaMessage, CancellationToken)"/> and returns
    /// the events of the reply as they arrive. See
    /// <see cref="SendStreaming(CancellationToken)"/>.
    /// </summary>
    /// <param name="message">The reply to send as the message of this turn.</param>
    /// <param name="cancellationToken">Cancels the request and the stream.</param>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        BetaMessage message,
        CancellationToken cancellationToken = default
    )
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _state.Stream(_state.ToAssistantParams([message]), null, cancellationToken);
    }

    /// <summary>
    /// Sends the next turn like
    /// <see cref="Send(IEnumerable{BetaMessageParam}, Func{ThreadSendParams, ThreadSendParams}?, CancellationToken)"/>
    /// and returns the events of the reply as they arrive. See
    /// <see cref="SendStreaming(CancellationToken)"/>.
    /// </summary>
    /// <param name="messages">The messages of this turn, in order. They are not merged.</param>
    /// <param name="configure">Changes the request fields for this turn only.</param>
    /// <param name="cancellationToken">Cancels the request and the stream.</param>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        IEnumerable<BetaMessageParam> messages,
        Func<ThreadSendParams, ThreadSendParams>? configure = null,
        CancellationToken cancellationToken = default
    )
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        return _state.Stream(
            messages,
            configure == null ? null : OnRequestFields(configure),
            cancellationToken
        );
    }

    /// <summary>
    /// Changes the thread's request fields for every later turn, and sends no request.
    /// <c>System</c> and <c>Tools</c> cannot change once a turn has created the thread.
    /// </summary>
    /// <param name="configure">Returns the new fields. It receives the thread's fields.</param>
    public void Update(Func<ThreadSendParams, ThreadSendParams> configure)
    {
        if (configure == null)
        {
            throw new ArgumentNullException(nameof(configure));
        }

        _state.Update(OnRequestFields(configure));
    }

    /// <summary>
    /// Returns a new, independent thread with a copy of this thread's history and request fields.
    /// It sends no request.
    /// </summary>
    public BetaMessageThread Fork() => new(_state.Fork());

    /// <summary>
    /// Creates a tool runner whose turns are turns of this thread, and sends no request. After the
    /// run the thread holds the whole history.
    /// </summary>
    /// <param name="tools">The runnable tools that the runner can execute locally.</param>
    /// <param name="maxIterations">
    /// Maximum number of turns that the runner sends before the loop terminates. <c>null</c>
    /// means no limit.
    /// </param>
    public BetaToolRunner ToolRunner(
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations = null
    )
    {
        if (tools == null)
        {
            throw new ArgumentNullException(nameof(tools));
        }

        return new BetaToolRunner(_state, tools, maxIterations);
    }

    static Func<MessageCreateParams, MessageCreateParams> OnRequestFields(
        Func<ThreadSendParams, ThreadSendParams> configure
    ) => fields => configure(ThreadSendParams.From(fields)).ToMessageCreateParams();
}

/// <summary>
/// A <see cref="BetaMessageThread"/> whose replies fit <typeparamref name="T"/>. <c>Send</c> and
/// <see cref="LastMessage"/> return the reply with its text parsed. Create one with
/// <see cref="BetaMessageThreadExtensions.Thread{T}"/>.
/// </summary>
/// <typeparam name="T">The type to parse the replies into.</typeparam>
public sealed class BetaMessageThread<T>
    where T : class, new()
{
    readonly BetaMessageThread _thread;

    internal BetaMessageThread(BetaMessageThread thread)
    {
        _thread = thread;
    }

    /// <inheritdoc cref="BetaMessageThread.Messages"/>
    public IReadOnlyList<BetaMessageParam> Messages => _thread.Messages;

    /// <inheritdoc cref="BetaMessageThread.PreviousMessageID"/>
    public string? PreviousMessageID => _thread.PreviousMessageID;

    /// <inheritdoc cref="BetaMessageThread.LastMessage"/>
    public BetaStructuredMessage<T>? LastMessage =>
        _thread.LastMessage is { } message ? new(message) : null;

    /// <inheritdoc cref="BetaMessageThread.Params"/>
    public ThreadCreateParams Params => _thread.Params;

    /// <inheritdoc cref="BetaMessageThread.Append(BetaMessageParam[])"/>
    public void Append(params BetaMessageParam[] messages) => _thread.Append(messages);

    /// <inheritdoc cref="BetaMessageThread.Append(BetaMessage[])"/>
    public void Append(params BetaMessage[] messages) => _thread.Append(messages);

    /// <inheritdoc cref="BetaMessageThread.Send(CancellationToken)"/>
    public async Task<BetaStructuredMessage<T>> Send(
        CancellationToken cancellationToken = default
    ) => new(await _thread.Send(cancellationToken).ConfigureAwait(false));

    /// <inheritdoc cref="BetaMessageThread.Send(BetaMessageParam, CancellationToken)"/>
    public async Task<BetaStructuredMessage<T>> Send(
        BetaMessageParam message,
        CancellationToken cancellationToken = default
    ) => new(await _thread.Send(message, cancellationToken).ConfigureAwait(false));

    /// <inheritdoc cref="BetaMessageThread.Send(BetaMessage, CancellationToken)"/>
    public async Task<BetaStructuredMessage<T>> Send(
        BetaMessage message,
        CancellationToken cancellationToken = default
    ) => new(await _thread.Send(message, cancellationToken).ConfigureAwait(false));

    /// <inheritdoc cref="BetaMessageThread.Send(IEnumerable{BetaMessageParam}, Func{ThreadSendParams, ThreadSendParams}?, CancellationToken)"/>
    public async Task<BetaStructuredMessage<T>> Send(
        IEnumerable<BetaMessageParam> messages,
        Func<ThreadSendParams, ThreadSendParams>? configure = null,
        CancellationToken cancellationToken = default
    ) => new(await _thread.Send(messages, configure, cancellationToken).ConfigureAwait(false));

    /// <inheritdoc cref="BetaMessageThread.SendStreaming(CancellationToken)"/>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        CancellationToken cancellationToken = default
    ) => _thread.SendStreaming(cancellationToken);

    /// <inheritdoc cref="BetaMessageThread.SendStreaming(BetaMessageParam, CancellationToken)"/>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        BetaMessageParam message,
        CancellationToken cancellationToken = default
    ) => _thread.SendStreaming(message, cancellationToken);

    /// <inheritdoc cref="BetaMessageThread.SendStreaming(BetaMessage, CancellationToken)"/>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        BetaMessage message,
        CancellationToken cancellationToken = default
    ) => _thread.SendStreaming(message, cancellationToken);

    /// <inheritdoc cref="BetaMessageThread.SendStreaming(IEnumerable{BetaMessageParam}, Func{ThreadSendParams, ThreadSendParams}?, CancellationToken)"/>
    public IAsyncEnumerable<BetaRawMessageStreamEvent> SendStreaming(
        IEnumerable<BetaMessageParam> messages,
        Func<ThreadSendParams, ThreadSendParams>? configure = null,
        CancellationToken cancellationToken = default
    ) => _thread.SendStreaming(messages, configure, cancellationToken);

    /// <inheritdoc cref="BetaMessageThread.Update"/>
    public void Update(Func<ThreadSendParams, ThreadSendParams> configure) =>
        _thread.Update(configure);

    /// <inheritdoc cref="BetaMessageThread.Fork"/>
    public BetaMessageThread<T> Fork() => new(_thread.Fork());

    /// <inheritdoc cref="BetaMessageThread.ToolRunner"/>
    public BetaToolRunner ToolRunner(
        IReadOnlyList<IBetaRunnableTool> tools,
        int? maxIterations = null
    ) => _thread.ToolRunner(tools, maxIterations);
}

/// <summary>
/// Extension methods for creating a <see cref="BetaMessageThread"/> or a
/// <see cref="BetaMessageThread{T}"/> from the beta messages service.
/// </summary>
public static class BetaMessageThreadExtensions
{
    /// <summary>
    /// Creates a message thread and sends no request. <paramref name="parameters"/> holds what
    /// <c>Create</c> takes, except <c>Thread</c>.
    /// </summary>
    /// <param name="service">The beta messages service.</param>
    /// <param name="parameters">
    /// The request fields of every turn. <c>Messages</c> are the messages the thread starts
    /// with.
    /// </param>
    /// <exception cref="NotSupportedException">
    /// <paramref name="service"/> is the service of an <c>AnthropicBedrockClient</c>,
    /// <c>AnthropicBedrockMantleClient</c> or <c>AnthropicVertexClient</c>, whose APIs have no
    /// message threads.
    /// </exception>
    public static BetaMessageThread Thread(
        this IMessageService service,
        ThreadCreateParams parameters
    )
    {
        if (service == null)
        {
            throw new ArgumentNullException(nameof(service));
        }
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }
        if (!MessageThreadState.SupportsThreads(service))
        {
            throw new NotSupportedException(
                "Message threads are not available on the Bedrock and Vertex clients. Send the "
                    + "whole history with `Create` instead."
            );
        }

        return new BetaMessageThread(
            new MessageThreadState(
                service,
                parameters.ToMessageCreateParams(),
                parameters.UnsupportedRequestBehavior
            )
        );
    }

    /// <summary>
    /// Creates a message thread like
    /// <see cref="Thread(IMessageService, ThreadCreateParams)"/>, whose every turn asks for
    /// output that fits <typeparamref name="T"/> and returns the reply with its text parsed.
    /// </summary>
    /// <typeparam name="T">
    /// The type to parse the replies into. It is settled when the thread is created.
    /// </typeparam>
    /// <param name="service">The beta messages service.</param>
    /// <param name="parameters">
    /// The request fields of every turn, as in the other overload. The <c>Format</c> of
    /// <c>OutputConfig</c> is set to the format for <typeparamref name="T"/>, and the other
    /// options of <c>OutputConfig</c> are kept.
    /// </param>
    /// <inheritdoc cref="Thread(IMessageService, ThreadCreateParams)" path="/exception"/>
    public static BetaMessageThread<T> Thread<T>(
        this IMessageService service,
        ThreadCreateParams parameters
    )
        where T : class, new()
    {
        if (parameters == null)
        {
            throw new ArgumentNullException(nameof(parameters));
        }

        return new BetaMessageThread<T>(
            service.Thread(
                parameters with
                {
                    OutputConfig = (parameters.OutputConfig ?? new()) with
                    {
                        Format = StructuredOutput.CreateBetaJsonFormat<T>(),
                    },
                }
            )
        );
    }
}
