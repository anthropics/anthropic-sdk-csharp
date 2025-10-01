using Anthropic.Client.Core;
using Batches = Anthropic.Client.Models.Beta.Messages.Batches;

namespace Anthropic.Client.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

public sealed record class BetaMessageBatchSucceededResult(
    Batches::BetaMessageBatchSucceededResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchSucceededResult, Batches::BetaMessageBatchSucceededResult>
{
    public static BetaMessageBatchSucceededResult From(
        Batches::BetaMessageBatchSucceededResult value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMessageBatchErroredResult(
    Batches::BetaMessageBatchErroredResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchErroredResult, Batches::BetaMessageBatchErroredResult>
{
    public static BetaMessageBatchErroredResult From(Batches::BetaMessageBatchErroredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMessageBatchCanceledResult(
    Batches::BetaMessageBatchCanceledResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchCanceledResult, Batches::BetaMessageBatchCanceledResult>
{
    public static BetaMessageBatchCanceledResult From(Batches::BetaMessageBatchCanceledResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMessageBatchExpiredResult(
    Batches::BetaMessageBatchExpiredResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchExpiredResult, Batches::BetaMessageBatchExpiredResult>
{
    public static BetaMessageBatchExpiredResult From(Batches::BetaMessageBatchExpiredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
