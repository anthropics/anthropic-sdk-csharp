using System.Text.Json.Serialization;
using MessageBatchResultVariants = Anthropic.Models.Messages.Batches.MessageBatchResultVariants;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(UnionConverter<MessageBatchResult>))]
public abstract record class MessageBatchResult
{
    internal MessageBatchResult() { }

    public static implicit operator MessageBatchResult(MessageBatchSucceededResult value) =>
        new MessageBatchResultVariants::MessageBatchSucceededResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchErroredResult value) =>
        new MessageBatchResultVariants::MessageBatchErroredResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchCanceledResult value) =>
        new MessageBatchResultVariants::MessageBatchCanceledResultVariant(value);

    public static implicit operator MessageBatchResult(MessageBatchExpiredResult value) =>
        new MessageBatchResultVariants::MessageBatchExpiredResultVariant(value);

    public abstract void Validate();
}
