using Anthropic = Anthropic;
using MessageBatchResultVariants = Anthropic.Models.Messages.Batches.MessageBatchResultVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<MessageBatchResult>))]
public abstract record class MessageBatchResult
{
    internal MessageBatchResult() { }

    public static implicit operator MessageBatchResult(MessageBatchSucceededResult value) =>
        new MessageBatchResultVariants::MessageBatchSucceededResult(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new MessageBatchResultVariants::MessageBatchErroredResult(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new MessageBatchResultVariants::MessageBatchCanceledResult(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new MessageBatchResultVariants::MessageBatchExpiredResult(value);

    public abstract void Validate();
}
