using System.Collections.Generic;
using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.WebSearchToolResultBlockContentVariants;

public sealed record class WebSearchToolResultError(Messages::WebSearchToolResultError Value)
    : Messages::WebSearchToolResultBlockContent,
        IVariant<WebSearchToolResultError, Messages::WebSearchToolResultError>
{
    public static WebSearchToolResultError From(Messages::WebSearchToolResultError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class WebSearchResultBlocks(List<Messages::WebSearchResultBlock> Value)
    : Messages::WebSearchToolResultBlockContent,
        IVariant<WebSearchResultBlocks, List<Messages::WebSearchResultBlock>>
{
    public static WebSearchResultBlocks From(List<Messages::WebSearchResultBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
