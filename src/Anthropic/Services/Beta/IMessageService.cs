using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta.Messages;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMessageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    global::Anthropic.Services.Beta.IMessageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Anthropic.Services.Beta.IMessageService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IBatchService Batches { get; }

    /// <summary>
    /// Send a structured list of input messages with text and/or image content,
    /// and the model will generate the next message in the conversation.
    ///
    /// <para>The Messages API can be used for either single queries or stateless
    /// multi-turn conversations.</para>
    ///
    /// <para>Learn more about the Messages API in our [user guide](https://docs.claude.com/en/docs/initial-setup)</para>
    /// </summary>
    Task<BetaMessage> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Send a structured list of input messages with text and/or image content,
    /// and the model will generate the next message in the conversation.
    ///
    /// <para>The Messages API can be used for either single queries or stateless
    /// multi-turn conversations.</para>
    ///
    /// <para>Learn more about the Messages API in our [user guide](https://docs.claude.com/en/docs/initial-setup)</para>
    /// </summary>
    IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Count the number of tokens in a Message.
    ///
    /// <para>The Token Count API can be used to count the number of tokens in a Message,
    /// including tools, images, and documents, without creating it.</para>
    ///
    /// <para>Learn more about token counting in our [user guide](https://docs.claude.com/en/docs/build-with-claude/token-counting)</para>
    /// </summary>
    Task<BetaMessageTokensCount> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="global::Anthropic.Services.Beta.IMessageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMessageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Anthropic.Services.Beta.IMessageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    IBatchServiceWithRawResponse Batches { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/messages?beta=true`, but is otherwise the
    /// same as <see cref="global::Anthropic.Services.Beta.IMessageService.Create(MessageCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaMessage>> Create(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/messages?beta=true`, but is otherwise the
    /// same as <see cref="global::Anthropic.Services.Beta.IMessageService.CreateStreaming(MessageCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<StreamingHttpResponse<BetaRawMessageStreamEvent>> CreateStreaming(
        MessageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/messages/count_tokens?beta=true`, but is otherwise the
    /// same as <see cref="global::Anthropic.Services.Beta.IMessageService.CountTokens(MessageCountTokensParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaMessageTokensCount>> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}
