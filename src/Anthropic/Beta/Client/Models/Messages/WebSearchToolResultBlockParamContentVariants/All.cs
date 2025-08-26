using System.Collections.Generic;
using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.WebSearchToolResultBlockParamContentVariants;

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
