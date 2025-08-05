using System.Threading.Tasks;
using Anthropic.Models.Messages;
using Batches = Anthropic.Services.Messages.Batches;

namespace Anthropic.Services.Messages;

public interface IMessageService
{
    Batches::IBatchService Batches { get; }

    /// <summary>
    /// Send a structured list of input messages with text and/or image content, and
    /// the model will generate the next message in the conversation.
    ///
    /// The Messages API can be used for either single queries or stateless multi-turn conversations.
    ///
    /// Learn more about the Messages API in our [user guide](/en/docs/initial-setup)
    /// </summary>
    Task<Message> Create(MessageCreateParams parameters);

    /// <summary>
    /// Count the number of tokens in a Message.
    ///
    /// The Token Count API can be used to count the number of tokens in a Message,
    /// including tools, images, and documents, without creating it.
    ///
    /// Learn more about token counting in our [user guide](/en/docs/build-with-claude/token-counting)
    /// </summary>
    Task<MessageTokensCount> CountTokens(MessageCountTokensParams parameters);
}
