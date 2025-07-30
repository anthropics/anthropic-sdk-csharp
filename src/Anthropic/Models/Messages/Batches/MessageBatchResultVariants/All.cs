using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.Batches.MessageBatchResultVariants;

[JsonConverter(
    typeof(VariantConverter<MessageBatchSucceededResultVariant, MessageBatchSucceededResult>)
)]
public sealed record class MessageBatchSucceededResultVariant(MessageBatchSucceededResult Value)
    : MessageBatchResult,
        IVariant<MessageBatchSucceededResultVariant, MessageBatchSucceededResult>
{
    public static MessageBatchSucceededResultVariant From(MessageBatchSucceededResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<MessageBatchErroredResultVariant, MessageBatchErroredResult>)
)]
public sealed record class MessageBatchErroredResultVariant(MessageBatchErroredResult Value)
    : MessageBatchResult,
        IVariant<MessageBatchErroredResultVariant, MessageBatchErroredResult>
{
    public static MessageBatchErroredResultVariant From(MessageBatchErroredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<MessageBatchCanceledResultVariant, MessageBatchCanceledResult>)
)]
public sealed record class MessageBatchCanceledResultVariant(MessageBatchCanceledResult Value)
    : MessageBatchResult,
        IVariant<MessageBatchCanceledResultVariant, MessageBatchCanceledResult>
{
    public static MessageBatchCanceledResultVariant From(MessageBatchCanceledResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<MessageBatchExpiredResultVariant, MessageBatchExpiredResult>)
)]
public sealed record class MessageBatchExpiredResultVariant(MessageBatchExpiredResult Value)
    : MessageBatchResult,
        IVariant<MessageBatchExpiredResultVariant, MessageBatchExpiredResult>
{
    public static MessageBatchExpiredResultVariant From(MessageBatchExpiredResult value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
