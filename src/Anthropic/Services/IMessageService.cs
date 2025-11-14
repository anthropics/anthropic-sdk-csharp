using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Messages;
using Anthropic.Services.Messages;

namespace Anthropic.Services;

public interface IMessageService
{
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

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
    Task<Message> Create(
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
    IAsyncEnumerable<RawMessageStreamEvent> CreateStreaming(
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
    Task<MessageTokensCount> CountTokens(
        MessageCountTokensParams parameters,
        CancellationToken cancellationToken = default
    );
}
