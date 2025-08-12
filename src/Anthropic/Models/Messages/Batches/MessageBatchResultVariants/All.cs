using Batches = Anthropic.Models.Messages.Batches;

namespace Anthropic.Models.Messages.Batches.MessageBatchResultVariants;

public sealed record class MessageBatchSucceededResultVariant(
    Batches::MessageBatchSucceededResult Value
)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchSucceededResultVariant, Batches::MessageBatchSucceededResult>
{
    public static MessageBatchSucceededResultVariant From(
        Batches::MessageBatchSucceededResult value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchErroredResultVariant(
    Batches::MessageBatchErroredResult Value
)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchErroredResultVariant, Batches::MessageBatchErroredResult>
{
    public static MessageBatchErroredResultVariant From(Batches::MessageBatchErroredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchCanceledResultVariant(
    Batches::MessageBatchCanceledResult Value
)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchCanceledResultVariant, Batches::MessageBatchCanceledResult>
{
    public static MessageBatchCanceledResultVariant From(Batches::MessageBatchCanceledResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchExpiredResultVariant(
    Batches::MessageBatchExpiredResult Value
)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchExpiredResultVariant, Batches::MessageBatchExpiredResult>
{
    public static MessageBatchExpiredResultVariant From(Batches::MessageBatchExpiredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
