using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

public sealed record class ResultBlock(List<Messages::BetaWebSearchResultBlockParam> Value)
    : Messages::BetaWebSearchToolResultBlockParamContent,
        IVariant<ResultBlock, List<Messages::BetaWebSearchResultBlockParam>>
{
    public static ResultBlock From(List<Messages::BetaWebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaWebSearchToolRequestError(
    Messages::BetaWebSearchToolRequestError Value
)
    : Messages::BetaWebSearchToolResultBlockParamContent,
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
