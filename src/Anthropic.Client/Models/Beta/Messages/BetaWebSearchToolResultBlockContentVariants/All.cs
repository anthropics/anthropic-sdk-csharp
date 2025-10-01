using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

public sealed record class BetaWebSearchToolResultError(
    Messages::BetaWebSearchToolResultError Value
)
    : Messages::BetaWebSearchToolResultBlockContent,
        IVariant<BetaWebSearchToolResultError, Messages::BetaWebSearchToolResultError>
{
    public static BetaWebSearchToolResultError From(Messages::BetaWebSearchToolResultError value)
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
