using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.WebSearchToolResultBlockParamContentVariants;

public sealed record class WebSearchToolResultBlockItem(List<WebSearchResultBlockParam> Value)
    : WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolResultBlockItem, List<WebSearchResultBlockParam>>
{
    public static WebSearchToolResultBlockItem From(List<WebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class WebSearchToolRequestError(Messages::WebSearchToolRequestError Value)
    : WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolRequestError, Messages::WebSearchToolRequestError>
{
    public static WebSearchToolRequestError From(Messages::WebSearchToolRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
