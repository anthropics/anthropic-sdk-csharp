using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockProperties.ContentVariants;

public sealed record class BetaTextEditorCodeExecutionToolResultError(
    Messages::BetaTextEditorCodeExecutionToolResultError Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionToolResultError,
            Messages::BetaTextEditorCodeExecutionToolResultError
        >
{
    public static BetaTextEditorCodeExecutionToolResultError From(
        Messages::BetaTextEditorCodeExecutionToolResultError value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionViewResultBlock(
    Messages::BetaTextEditorCodeExecutionViewResultBlock Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionViewResultBlock,
            Messages::BetaTextEditorCodeExecutionViewResultBlock
        >
{
    public static BetaTextEditorCodeExecutionViewResultBlock From(
        Messages::BetaTextEditorCodeExecutionViewResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionCreateResultBlock(
    Messages::BetaTextEditorCodeExecutionCreateResultBlock Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionCreateResultBlock,
            Messages::BetaTextEditorCodeExecutionCreateResultBlock
        >
{
    public static BetaTextEditorCodeExecutionCreateResultBlock From(
        Messages::BetaTextEditorCodeExecutionCreateResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionStrReplaceResultBlock(
    Messages::BetaTextEditorCodeExecutionStrReplaceResultBlock Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionStrReplaceResultBlock,
            Messages::BetaTextEditorCodeExecutionStrReplaceResultBlock
        >
{
    public static BetaTextEditorCodeExecutionStrReplaceResultBlock From(
        Messages::BetaTextEditorCodeExecutionStrReplaceResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
