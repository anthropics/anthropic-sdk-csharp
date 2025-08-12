using System.Collections.Generic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

public sealed record class WebSearchToolResultErrorVariant(Messages::WebSearchToolResultError Value)
    : Messages::WebSearchToolResultBlockContent,
        IVariant<WebSearchToolResultErrorVariant, Messages::WebSearchToolResultError>
{
    public static WebSearchToolResultErrorVariant From(Messages::WebSearchToolResultError value)
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
