using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

public sealed record class BetaWebSearchToolResultErrorVariant(
    Messages::BetaWebSearchToolResultError Value
)
    : Messages::BetaWebSearchToolResultBlockContent,
        IVariant<BetaWebSearchToolResultErrorVariant, Messages::BetaWebSearchToolResultError>
{
    public static BetaWebSearchToolResultErrorVariant From(
        Messages::BetaWebSearchToolResultError value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchResultBlocks(List<Messages::BetaWebSearchResultBlock> Value)
    : Messages::BetaWebSearchToolResultBlockContent,
        IVariant<BetaWebSearchResultBlocks, List<Messages::BetaWebSearchResultBlock>>
{
    public static BetaWebSearchResultBlocks From(List<Messages::BetaWebSearchResultBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
