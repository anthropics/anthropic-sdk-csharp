using System.Collections.Generic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

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

public sealed record class WebSearchToolRequestErrorVariant(
    Messages::WebSearchToolRequestError Value
)
    : Messages::WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolRequestErrorVariant, Messages::WebSearchToolRequestError>
{
    public static WebSearchToolRequestErrorVariant From(Messages::WebSearchToolRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
