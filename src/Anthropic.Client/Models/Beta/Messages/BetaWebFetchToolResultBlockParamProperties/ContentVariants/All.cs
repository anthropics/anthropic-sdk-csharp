using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockParamProperties.ContentVariants;

public sealed record class BetaWebFetchToolResultErrorBlockParam(
    Messages::BetaWebFetchToolResultErrorBlockParam Value
)
    : Content,
        IVariant<
            BetaWebFetchToolResultErrorBlockParam,
            Messages::BetaWebFetchToolResultErrorBlockParam
        >
{
    public static BetaWebFetchToolResultErrorBlockParam From(
        Messages::BetaWebFetchToolResultErrorBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebFetchBlockParam(Messages::BetaWebFetchBlockParam Value)
    : Content,
        IVariant<BetaWebFetchBlockParam, Messages::BetaWebFetchBlockParam>
{
    public static BetaWebFetchBlockParam From(Messages::BetaWebFetchBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
