using System.Collections.Generic;
using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.WebSearchToolResultBlockParamContentVariants;

public sealed record class WebSearchToolResultBlockItem(
    List<Messages::WebSearchResultBlockParam> Value
)
    : Messages::WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolResultBlockItem, List<Messages::WebSearchResultBlockParam>>
{
    public static WebSearchToolResultBlockItem From(List<Messages::WebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class WebSearchToolRequestError(Messages::WebSearchToolRequestError Value)
    : Messages::WebSearchToolResultBlockParamContent,
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
