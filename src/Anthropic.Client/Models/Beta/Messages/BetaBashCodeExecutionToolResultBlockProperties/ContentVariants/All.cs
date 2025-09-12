using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockProperties.ContentVariants;

public sealed record class BetaBashCodeExecutionToolResultError(
    Messages::BetaBashCodeExecutionToolResultError Value
)
    : Content,
        IVariant<
            BetaBashCodeExecutionToolResultError,
            Messages::BetaBashCodeExecutionToolResultError
        >
{
    public static BetaBashCodeExecutionToolResultError From(
        Messages::BetaBashCodeExecutionToolResultError value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaBashCodeExecutionResultBlock(
    Messages::BetaBashCodeExecutionResultBlock Value
) : Content, IVariant<BetaBashCodeExecutionResultBlock, Messages::BetaBashCodeExecutionResultBlock>
{
    public static BetaBashCodeExecutionResultBlock From(
        Messages::BetaBashCodeExecutionResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
