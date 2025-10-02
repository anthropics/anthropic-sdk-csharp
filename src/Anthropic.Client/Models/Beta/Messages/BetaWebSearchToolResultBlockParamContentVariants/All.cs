using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

public sealed record class ResultBlock(List<BetaWebSearchResultBlockParam> Value)
    : BetaWebSearchToolResultBlockParamContent,
        IVariant<ResultBlock, List<BetaWebSearchResultBlockParam>>
{
    public static ResultBlock From(List<BetaWebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaWebSearchToolRequestError(
    Messages::BetaWebSearchToolRequestError Value
)
    : BetaWebSearchToolResultBlockParamContent,
        IVariant<BetaWebSearchToolRequestError, Messages::BetaWebSearchToolRequestError>
{
    public static BetaWebSearchToolRequestError From(Messages::BetaWebSearchToolRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
