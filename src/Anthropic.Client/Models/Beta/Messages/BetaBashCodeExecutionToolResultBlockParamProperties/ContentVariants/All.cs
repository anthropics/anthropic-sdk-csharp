using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaBashCodeExecutionToolResultBlockParamProperties.ContentVariants;

public sealed record class BetaBashCodeExecutionToolResultErrorParam(
    Messages::BetaBashCodeExecutionToolResultErrorParam Value
)
    : Content,
        IVariant<
            BetaBashCodeExecutionToolResultErrorParam,
            Messages::BetaBashCodeExecutionToolResultErrorParam
        >
{
    public static BetaBashCodeExecutionToolResultErrorParam From(
        Messages::BetaBashCodeExecutionToolResultErrorParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaBashCodeExecutionResultBlockParam(
    Messages::BetaBashCodeExecutionResultBlockParam Value
)
    : Content,
        IVariant<
            BetaBashCodeExecutionResultBlockParam,
            Messages::BetaBashCodeExecutionResultBlockParam
        >
{
    public static BetaBashCodeExecutionResultBlockParam From(
        Messages::BetaBashCodeExecutionResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
