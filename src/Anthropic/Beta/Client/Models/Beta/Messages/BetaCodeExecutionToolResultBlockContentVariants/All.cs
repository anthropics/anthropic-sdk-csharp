using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

public sealed record class BetaCodeExecutionToolResultError(
    Messages::BetaCodeExecutionToolResultError Value
)
    : Messages::BetaCodeExecutionToolResultBlockContent,
        IVariant<BetaCodeExecutionToolResultError, Messages::BetaCodeExecutionToolResultError>
{
    public static BetaCodeExecutionToolResultError From(
        Messages::BetaCodeExecutionToolResultError value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionResultBlock(
    Messages::BetaCodeExecutionResultBlock Value
)
    : Messages::BetaCodeExecutionToolResultBlockContent,
        IVariant<BetaCodeExecutionResultBlock, Messages::BetaCodeExecutionResultBlock>
{
    public static BetaCodeExecutionResultBlock From(Messages::BetaCodeExecutionResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
