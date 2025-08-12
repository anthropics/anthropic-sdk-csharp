using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;

public sealed record class BetaCodeExecutionToolResultErrorParamVariant(
    Messages::BetaCodeExecutionToolResultErrorParam Value
)
    : Messages::BetaCodeExecutionToolResultBlockParamContent,
        IVariant<
            BetaCodeExecutionToolResultErrorParamVariant,
            Messages::BetaCodeExecutionToolResultErrorParam
        >
{
    public static BetaCodeExecutionToolResultErrorParamVariant From(
        Messages::BetaCodeExecutionToolResultErrorParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionResultBlockParamVariant(
    Messages::BetaCodeExecutionResultBlockParam Value
)
    : Messages::BetaCodeExecutionToolResultBlockParamContent,
        IVariant<
            BetaCodeExecutionResultBlockParamVariant,
            Messages::BetaCodeExecutionResultBlockParam
        >
{
    public static BetaCodeExecutionResultBlockParamVariant From(
        Messages::BetaCodeExecutionResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
