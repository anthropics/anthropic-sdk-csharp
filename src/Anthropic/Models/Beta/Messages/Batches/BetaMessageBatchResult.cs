using Anthropic = Anthropic;
using BetaMessageBatchResultVariants = Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.Batches;

/// <summary>
/// Processing result for this request.
///
/// Contains a Message output if processing was successful, an error response if processing
/// failed, or the reason why processing was not attempted, such as cancellation
/// or expiration.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaMessageBatchResult>))]
public abstract record class BetaMessageBatchResult
{
    internal BetaMessageBatchResult() { }

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchSucceededResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchSucceededResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchErroredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchErroredResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchCanceledResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchCanceledResult(value);

    public static implicit operator BetaMessageBatchResult(BetaMessageBatchExpiredResult value) =>
        new BetaMessageBatchResultVariants::BetaMessageBatchExpiredResult(value);

    public abstract void Validate();
}
