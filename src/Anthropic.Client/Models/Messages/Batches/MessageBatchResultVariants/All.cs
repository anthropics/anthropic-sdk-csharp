using Anthropic.Client.Core;
using Batches = Anthropic.Client.Models.Messages.Batches;

namespace Anthropic.Client.Models.Messages.Batches.MessageBatchResultVariants;

public sealed record class MessageBatchSucceededResult(Batches::MessageBatchSucceededResult Value)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchSucceededResult, Batches::MessageBatchSucceededResult>
{
    public static MessageBatchSucceededResult From(Batches::MessageBatchSucceededResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchErroredResult(Batches::MessageBatchErroredResult Value)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchErroredResult, Batches::MessageBatchErroredResult>
{
    public static MessageBatchErroredResult From(Batches::MessageBatchErroredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchCanceledResult(Batches::MessageBatchCanceledResult Value)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchCanceledResult, Batches::MessageBatchCanceledResult>
{
    public static MessageBatchCanceledResult From(Batches::MessageBatchCanceledResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class MessageBatchExpiredResult(Batches::MessageBatchExpiredResult Value)
    : Batches::MessageBatchResult,
        IVariant<MessageBatchExpiredResult, Batches::MessageBatchExpiredResult>
{
    public static MessageBatchExpiredResult From(Batches::MessageBatchExpiredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
