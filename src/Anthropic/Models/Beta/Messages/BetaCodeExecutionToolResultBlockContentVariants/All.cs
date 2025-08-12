using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

public sealed record class BetaCodeExecutionToolResultErrorVariant(
    Messages::BetaCodeExecutionToolResultError Value
)
    : Messages::BetaCodeExecutionToolResultBlockContent,
        IVariant<
            BetaCodeExecutionToolResultErrorVariant,
            Messages::BetaCodeExecutionToolResultError
        >
{
    public static BetaCodeExecutionToolResultErrorVariant From(
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

public sealed record class BetaCodeExecutionResultBlockVariant(
    Messages::BetaCodeExecutionResultBlock Value
)
    : Messages::BetaCodeExecutionToolResultBlockContent,
        IVariant<BetaCodeExecutionResultBlockVariant, Messages::BetaCodeExecutionResultBlock>
{
    public static BetaCodeExecutionResultBlockVariant From(
        Messages::BetaCodeExecutionResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
