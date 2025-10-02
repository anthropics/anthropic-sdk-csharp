using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.WebSearchToolResultBlockContentVariants;

public sealed record class WebSearchToolResultError(Messages::WebSearchToolResultError Value)
    : WebSearchToolResultBlockContent,
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

public sealed record class WebSearchResultBlocks(List<WebSearchResultBlock> Value)
    : WebSearchToolResultBlockContent,
        IVariant<WebSearchResultBlocks, List<WebSearchResultBlock>>
{
    public static WebSearchResultBlocks From(List<WebSearchResultBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
