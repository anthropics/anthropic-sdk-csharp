using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anthropic.Client.Core;
using Anthropic.Client.Models.Beta.Messages;
using Anthropic.Client.Services.Beta.Messages.Batches;

namespace Anthropic.Client.Services.Beta.Messages;

public interface IMessageService
{
    IMessageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBatchService Batches { get; }

    /// <summary>
    /// Send a structured list of input messages with text and/or image content, and
    /// the model will generate the next message in the conversation.
    ///
    /// The Messages API can be used for either single queries or stateless multi-turn conversations.
    ///
    /// Learn more about the Messages API in our [user guide](/en/docs/initial-setup)
    /// </summary>
    Task<BetaMessage> Create(MessageCreateParams parameters);

    /// <summary>
    /// Send a structured list of input messages with text and/or image content, and
    /// the model will generate the next message in the conversation.
    ///
    /// The Messages API can be used for either single queries or stateless multi-turn conversations.
    ///
    /// Learn more about the Messages API in our [user guide](/en/docs/initial-setup)
    /// </summary>
    IAsyncEnumerable<BetaRawMessageStreamEvent> CreateStreaming(MessageCreateParams parameters);

    /// <summary>
    /// Count the number of tokens in a Message.
    ///
    /// The Token Count API can be used to count the number of tokens in a Message,
    /// including tools, images, and documents, without creating it.
    ///
    /// Learn more about token counting in our [user guide](/en/docs/build-with-claude/token-counting)
    /// </summary>
    Task<BetaMessageTokensCount> CountTokens(MessageCountTokensParams parameters);
}
