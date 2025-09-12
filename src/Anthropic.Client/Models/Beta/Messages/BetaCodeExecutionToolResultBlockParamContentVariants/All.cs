using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;

public sealed record class BetaCodeExecutionToolResultErrorParam(
    Messages::BetaCodeExecutionToolResultErrorParam Value
)
    : Messages::BetaCodeExecutionToolResultBlockParamContent,
        IVariant<
            BetaCodeExecutionToolResultErrorParam,
            Messages::BetaCodeExecutionToolResultErrorParam
        >
{
    public static BetaCodeExecutionToolResultErrorParam From(
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

public sealed record class BetaCodeExecutionResultBlockParam(
    Messages::BetaCodeExecutionResultBlockParam Value
)
    : Messages::BetaCodeExecutionToolResultBlockParamContent,
        IVariant<BetaCodeExecutionResultBlockParam, Messages::BetaCodeExecutionResultBlockParam>
{
    public static BetaCodeExecutionResultBlockParam From(
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
