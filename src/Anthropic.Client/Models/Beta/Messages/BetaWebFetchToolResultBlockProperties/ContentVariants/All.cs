using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebFetchToolResultBlockProperties.ContentVariants;

public sealed record class BetaWebFetchToolResultErrorBlock(
    Messages::BetaWebFetchToolResultErrorBlock Value
) : Content, IVariant<BetaWebFetchToolResultErrorBlock, Messages::BetaWebFetchToolResultErrorBlock>
{
    public static BetaWebFetchToolResultErrorBlock From(
        Messages::BetaWebFetchToolResultErrorBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebFetchBlock(Messages::BetaWebFetchBlock Value)
    : Content,
        IVariant<BetaWebFetchBlock, Messages::BetaWebFetchBlock>
{
    public static BetaWebFetchBlock From(Messages::BetaWebFetchBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
