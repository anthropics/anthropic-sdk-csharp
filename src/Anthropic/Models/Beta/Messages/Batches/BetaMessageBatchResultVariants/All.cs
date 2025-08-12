using Batches = Anthropic.Models.Beta.Messages.Batches;

namespace Anthropic.Models.Beta.Messages.Batches.BetaMessageBatchResultVariants;

public sealed record class BetaMessageBatchSucceededResultVariant(
    Batches::BetaMessageBatchSucceededResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchSucceededResultVariant, Batches::BetaMessageBatchSucceededResult>
{
    public static BetaMessageBatchSucceededResultVariant From(
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

public sealed record class BetaMessageBatchErroredResultVariant(
    Batches::BetaMessageBatchErroredResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchErroredResultVariant, Batches::BetaMessageBatchErroredResult>
{
    public static BetaMessageBatchErroredResultVariant From(
        Batches::BetaMessageBatchErroredResult value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMessageBatchCanceledResultVariant(
    Batches::BetaMessageBatchCanceledResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchCanceledResultVariant, Batches::BetaMessageBatchCanceledResult>
{
    public static BetaMessageBatchCanceledResultVariant From(
        Batches::BetaMessageBatchCanceledResult value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMessageBatchExpiredResultVariant(
    Batches::BetaMessageBatchExpiredResult Value
)
    : Batches::BetaMessageBatchResult,
        IVariant<BetaMessageBatchExpiredResultVariant, Batches::BetaMessageBatchExpiredResult>
{
    public static BetaMessageBatchExpiredResultVariant From(
        Batches::BetaMessageBatchExpiredResult value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
