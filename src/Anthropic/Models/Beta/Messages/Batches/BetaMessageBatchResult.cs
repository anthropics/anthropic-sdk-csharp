using System.Text.Json.Serialization;
using BetaMessageBatchResultVariants = Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[JsonConverter(typeof(UnionConverter<BetaMessageBatchResult>))]
public abstract record class BetaMessageBatchResult
{
    internal BetaMessageBatchResult() { }

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchSucceededResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchErroredResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResultVariant(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResultVariant(value);

    public abstract void Validate();
}
